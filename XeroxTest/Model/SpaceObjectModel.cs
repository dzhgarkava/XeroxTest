using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XeroxTest.Model
{
    class SpaceObjectModel
    {
        #region Fields

        private int _objectId;
        private int _parentId;
        private string _name;
        private string _wikiPage;
        private byte[] _imageData;
        private string _imageHint;
        private int _meanRadiusInKm;
        private double _meanRadiusByEarth;
        private int _volume10Pow9Km3;
        private int _volumeByEarth;
        private int _mass10Pow21Kg;
        private int _massByEarth;
        private double _destinygByCm3;
        private int _surfaceGravitymByS2;
        private int _surfaceGravityByEarth;
        private string _typeOfObject;

        #endregion


        #region Constructor

        public SpaceObjectModel()
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

        public byte[] ImageData
        {
            get { return _imageData; }
            set { _imageData = value; }
        }

        public string ImageHint
        {
            get { return _imageHint; }
            set { _imageHint = value; }
        }

        public int MeanRadiusInKm
        {
            get { return _meanRadiusInKm; }
            set { _meanRadiusInKm = value; }
        }

        public double MeanRadiusByEarth
        {
            get { return _meanRadiusByEarth; }
            set { _meanRadiusByEarth = value; }
        }

        public int Volume10Pow9Km3
        {
            get { return _volume10Pow9Km3; }
            set { _volume10Pow9Km3 = value; }
        }

        public int VolumeByEarth
        {
            get { return _volumeByEarth; }
            set { _volumeByEarth = value; }
        }

        public int Mass10Pow21Kg
        {
            get { return _mass10Pow21Kg; }
            set { _mass10Pow21Kg = value; }
        }

        public int MassByEarth
        {
            get { return _massByEarth; }
            set { _massByEarth = value; }
        }

        public double DestinygByCm3
        {
            get { return _destinygByCm3; }
            set { _destinygByCm3 = value; }
        }

        public int SurfaceGravitymByS2
        {
            get { return _surfaceGravitymByS2; }
            set { _surfaceGravitymByS2 = value; }
        }

        public int SurfaceGravityByEarth
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
        public static ObservableCollection<SpaceObjectModel> GetSpaceObjectsCollectionByParentId(int parentId)
        {
            var spaceObjectsList = new ObservableCollection<SpaceObjectModel>();

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
                    SpaceObjectModel spaceObject = new SpaceObjectModel();
                    var xElement = xSpaceObject.Element("Name");
                    if (xElement != null) spaceObject.Name = xElement.Value;

                    spaceObjectsList.Add(spaceObject);
                }
            }

            return spaceObjectsList;
        }

        #endregion


    }
}
