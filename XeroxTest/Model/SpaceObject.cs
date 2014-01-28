﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using XeroxTest.Annotations;


namespace XeroxTest.Model
{
    class SpaceObject :INotifyPropertyChanged
    {
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

        #endregion


        #region Constructor

        public SpaceObject()
        {
            
        }

        #endregion


        #region Properties

        public int ObjectId
        {
            get { return _objectId; }
            set { _objectId = value; }
        }

        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string WikiPage
        {
            get { return _wikiPage; }
            set { _wikiPage = value; }
        }

        public Image Img { get; set; }

        public BitmapSource ImageData
        {
            get { return _imageData; }
            set { _imageData = value; }
        }

        public string ImageHint
        {
            get { return _imageHint; }
            set { _imageHint = value; }
        }

        public string MeanRadiusInKm
        {
            get { return _meanRadiusInKm; }
            set { _meanRadiusInKm = value; }
        }

        public string MeanRadiusByEarth
        {
            get { return _meanRadiusByEarth; }
            set { _meanRadiusByEarth = value; }
        }

        public string Volume10Pow9Km3
        {
            get { return _volume10Pow9Km3; }
            set { _volume10Pow9Km3 = value; }
        }

        public string VolumeByEarth
        {
            get { return _volumeByEarth; }
            set { _volumeByEarth = value; }
        }

        public string Mass10Pow21Kg
        {
            get { return _mass10Pow21Kg; }
            set { _mass10Pow21Kg = value; }
        }

        public string MassByEarth
        {
            get { return _massByEarth; }
            set { _massByEarth = value; }
        }

        public string DestinygByCm3
        {
            get { return _destinygByCm3; }
            set { _destinygByCm3 = value; }
        }

        public string SurfaceGravitymByS2
        {
            get { return _surfaceGravitymByS2; }
            set { _surfaceGravitymByS2 = value; }
        }

        public string SurfaceGravityByEarth
        {
            get { return _surfaceGravityByEarth; }
            set { _surfaceGravityByEarth = value; }
        }

        public string TypeOfObject
        {
            get { return _typeOfObject; }
            set { _typeOfObject = value; }
        }

        #endregion


        #region Methods

        /// <summary>
        /// Method creates Collection of SpaceObjects 
        /// </summary>
        /// <param name="parentId">The one-based index. For root element use -1</param>
        /// <returns></returns>
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
                    var spaceObject = new SpaceObject
                    {
                        ObjectId = Convert.ToInt32(GetXElement(xSpaceObject, "ObjectId")),
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
                        TypeOfObject = GetXElement(xSpaceObject, "TypeOfObject")
                    };

                    spaceObjectsList.Add(spaceObject);
                }
            }

            return spaceObjectsList;
        }


        private static BitmapImage GetImageFromBytes(byte[] bytes)
        {
            var source = new BitmapImage();
            source.BeginInit();
            source.StreamSource = new MemoryStream(bytes);
            source.EndInit();

            return source;
        }

        private static string GetXElement(XElement xElement, string name)
        {
            string elementName = "";

            var element = xElement.Element(name);
            if (element != null) elementName = element.Value;

            return elementName;
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
