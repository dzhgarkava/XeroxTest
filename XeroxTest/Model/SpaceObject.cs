﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using XeroxTest.Annotations;


namespace XeroxTest.Model
{
    class SpaceObject :INotifyPropertyChanged
    {
        #region Constructor

        public SpaceObject()
        {
            _childrenCollection = new ObservableCollection<SpaceObject>();
            PropertyChanged += OnPropertyChanged;
        }

        #endregion

        #region Fields

        private int _objectId;
        private int _parentId;
        private string _name;
        private string _wikiPage;
        private BitmapSource _imageData;
        private string _imageHint;
        private string _meanRadiusInKm;
        private string _meanRadiusByEarth;
        private string _volume10Pow9Km3;
        private string _volumeByEarth;
        private string _mass10Pow21Kg;
        private string _massByEarth;
        private string _destinygByCm3;
        private string _surfaceGravitymByS2;
        private string _surfaceGravityByEarth;
        private string _typeOfObject;
        private ObservableCollection<SpaceObject> _childrenCollection;
        private bool _isExpanded;
        private bool _isHasChild;

        #endregion

        #region Properties

        public int ObjectId
        {
            get { return _objectId; }
            set
            {
                if (value == _objectId) return;
                _objectId = value; 
                OnPropertyChanged();
            }
        }

        public int ParentId
        {
            get { return _parentId; }
            set
            {
                if (value == _parentId) return;
                _parentId = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public string WikiPage
        {
            get { return _wikiPage; }
            set
            {
                if (value == _wikiPage) return;
                _wikiPage = value;
                OnPropertyChanged();
            }
        }

        public BitmapSource ImageData
        {
            get { return _imageData; }
            set
            {
                if (value.Equals(_imageData)) return;
                _imageData = value;
                OnPropertyChanged();
            }
        }

        public string ImageHint
        {
            get { return _imageHint; }
            set
            {
                if (value == _imageHint) return;
                _imageHint = value;
                OnPropertyChanged();
            }
        }

        public string MeanRadiusInKm
        {
            get { return _meanRadiusInKm; }
            set
            {
                if (value == _meanRadiusInKm) return;
                _meanRadiusInKm = value;
                OnPropertyChanged();
            }
        }

        public string MeanRadiusByEarth
        {
            get { return _meanRadiusByEarth; }
            set
            {
                if (value == _meanRadiusByEarth) return;
                _meanRadiusByEarth = value;
                OnPropertyChanged();
            }
        }

        public string Volume10Pow9Km3
        {
            get { return _volume10Pow9Km3; }
            set
            {
                if (value == _volume10Pow9Km3) return;
                _volume10Pow9Km3 = value;
                OnPropertyChanged();
            }
        }

        public string VolumeByEarth
        {
            get { return _volumeByEarth; }
            set
            {
                if (value == _volumeByEarth) return;
                _volumeByEarth = value;
                OnPropertyChanged();
            }
        }

        public string Mass10Pow21Kg
        {
            get { return _mass10Pow21Kg; }
            set
            {
                if (value == _mass10Pow21Kg) return;
                _mass10Pow21Kg = value;
                OnPropertyChanged();
            }
        }

        public string MassByEarth
        {
            get { return _massByEarth; }
            set
            {
                if (value == _massByEarth) return;
                _massByEarth = value;
                OnPropertyChanged();
            }
        }

        public string DestinygByCm3
        {
            get { return _destinygByCm3; }
            set
            {
                if (value == _destinygByCm3) return;
                _destinygByCm3 = value;
                OnPropertyChanged();
            }
        }

        public string SurfaceGravitymByS2
        {
            get { return _surfaceGravitymByS2; }
            set
            {
                if (value == _surfaceGravitymByS2) return;
                _surfaceGravitymByS2 = value;
                OnPropertyChanged();
            }
        }

        public string SurfaceGravityByEarth
        {
            get { return _surfaceGravityByEarth; }
            set
            {
                if (value == _surfaceGravityByEarth) return;
                _surfaceGravityByEarth = value;
                OnPropertyChanged();
            }
        }

        public string TypeOfObject
        {
            get { return _typeOfObject; }
            set
            {
                if (value == _typeOfObject) return;
                _typeOfObject = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<SpaceObject> ChildrensCollection
        {
            get { return _childrenCollection; }
            set
            {
                if (value.Equals(_childrenCollection)) return;
                _childrenCollection = value; 
                OnPropertyChanged();
            }
        }

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsHasChild
        {
            get { return _isHasChild; }
            set
            {
                if (value != _isHasChild)
                {
                    _isHasChild = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method creates Collection of SpaceObjects 
        /// </summary>
        /// <param name="parentId">The one-based index. For root element use -1</param>
        /// <returns>ObservableCollection of SpaceObjects </returns>
        public static ObservableCollection<SpaceObject> GetSpaceObjectsCollectionByParentId(int parentId)
        {
            var spaceObjectsList = new ObservableCollection<SpaceObject>();

            XDocument xDocument = XDocument.Load("../../SpaceObjects.xml");
            if (xDocument.Root != null)
            {
                List<XElement> xSpaceObjects = xDocument.Root.Elements("SpaceObjects").Where(x =>
                {
                    var xElement = x.Element("ParentId");
                    return xElement != null && xElement.Value == parentId.ToString(CultureInfo.InvariantCulture);
                }).ToList();

                foreach (var xSpaceObject in xSpaceObjects)
                {
                    int obi = Convert.ToInt32(GetXElement(xSpaceObject, "ObjectId"));
                    var spaceObject = new SpaceObject
                    {
                        ObjectId = obi,
                        ParentId = Convert.ToInt32(GetXElement(xSpaceObject, "ParentId")),
                        Name = GetXElement(xSpaceObject, "Name"),
                        WikiPage = GetXElement(xSpaceObject, "WikiPage"),
                        ImageData = GetImageFromBytes(Convert.FromBase64String(GetXElement(xSpaceObject, "ImageData"))),
                        ImageHint = GetXElement(xSpaceObject, "ImageHint"),
                        MeanRadiusInKm = GetXElement(xSpaceObject, "MeanRadiusInKM"),
                        MeanRadiusByEarth = GetXElement(xSpaceObject, "MeanRadiusByEarth"),
                        Volume10Pow9Km3 = GetXElement(xSpaceObject, "Volume10pow9KM3"),
                        VolumeByEarth = GetXElement(xSpaceObject, "VolumeRByEarth"),
                        Mass10Pow21Kg = GetXElement(xSpaceObject, "Mass10pow21kg"),
                        MassByEarth = GetXElement(xSpaceObject, "MassByEarth"),
                        DestinygByCm3 = GetXElement(xSpaceObject, "DensitygBycm3"),
                        SurfaceGravitymByS2 = GetXElement(xSpaceObject, "SurfaceGravitymBys2"),
                        SurfaceGravityByEarth = GetXElement(xSpaceObject, "SurfaceGravityByEarth"),
                        TypeOfObject = GetXElement(xSpaceObject, "TypeOfObject"),
                        IsHasChild = IsSpaceObjectHasChild(obi)
                    };
                    
                    if (spaceObject.IsHasChild) spaceObject.ChildrensCollection.Add(new SpaceObject { Name = "Loading..." });

                    spaceObjectsList.Add(spaceObject);
                }
            }

            return spaceObjectsList;
        }

        /// <summary>
        /// Method returns True if SpaceObject has childs and Fals id doesn't
        /// </summary>
        /// <param name="objectId">The one-based index of current SpaceObject.</param>
        public static bool IsSpaceObjectHasChild(int objectId)
        {
            bool retIsHasChild = false;

            XDocument xDocument = XDocument.Load("../../SpaceObjects.xml");
            if (xDocument.Root != null)
            {
                List<XElement> xSpaceObjects = xDocument.Root.Elements("SpaceObjects").Where(x =>
                {
                    var xElement = x.Element("ParentId");
                    return xElement != null && xElement.Value == objectId.ToString(CultureInfo.InvariantCulture);
                }).ToList();

                if (xSpaceObjects.Count > 0) retIsHasChild = true;
            }

            return retIsHasChild;
        }

        /// <summary>
        /// Method returns BitmapImage from bytes array
        /// </summary>
        /// <param name="bytes">Array of bytes.</param>
        private static BitmapImage GetImageFromBytes(byte[] bytes)
        {
            var source = new BitmapImage();
            source.BeginInit();
            source.StreamSource = new MemoryStream(bytes);
            source.EndInit();

            return source;
        }

        /// <summary>
        /// Method returns value of XElement's child if applicable
        /// </summary>
        /// <param name="xElement">Parent XElement</param>
        /// <param name="name">Name of child</param>
        private static string GetXElement(XElement xElement, string name)
        {
            string elementValue = "";

            var element = xElement.Element(name);
            if (element != null) elementValue = element.Value;

            return elementValue;
        }

        /// <summary>
        /// Method handles changing of properties
        /// </summary>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "IsExpanded")
            {
                var spaceObject = (SpaceObject)sender;
                if (spaceObject.IsExpanded)
                {
                    var backgroundWorker = new BackgroundWorker();

                    backgroundWorker.DoWork += delegate
                    {
                        Thread.Sleep(2000); // Якобы длительный процесс, который загружает данные
                        Application.Current.Dispatcher.Invoke(delegate
                        {
                            spaceObject.ChildrensCollection = GetSpaceObjectsCollectionByParentId(spaceObject.ObjectId);
                        });
                    };

                    backgroundWorker.RunWorkerAsync();
                }
                else
                {
                    spaceObject.ChildrensCollection.Clear();
                    spaceObject.ChildrensCollection.Add(new SpaceObject { Name = "Loading..." });
                }
            }
        }

        #endregion

        #region Implementation INotifyProoertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
