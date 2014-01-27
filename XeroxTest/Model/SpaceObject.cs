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
    class SpaceObject
    {
        #region Fields

        private int _objectId;
        private int _parentId;
        private string _name;
        private string _wikiPage;
        private byte[] _imageData;
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
                    SpaceObject spaceObject = new SpaceObject();

                    spaceObject.ObjectId = Convert.ToInt32(GetXElement(xSpaceObject, "ObjectId"));
                    spaceObject.ParentId = Convert.ToInt32(GetXElement(xSpaceObject, "ParentId"));
                    spaceObject.Name = GetXElement(xSpaceObject, "Name");
                    spaceObject.WikiPage = GetXElement(xSpaceObject, "WikiPage");
                    spaceObject.ImageData = Encoding.UTF8.GetBytes(GetXElement(xSpaceObject, "ImageData"));
                    spaceObject.ImageHint = GetXElement(xSpaceObject, "ImageHint");
                    spaceObject.MeanRadiusInKm = GetXElement(xSpaceObject, "MeanRadiusInKM");
                    spaceObject.MeanRadiusByEarth = GetXElement(xSpaceObject, "MeanRadiusByEarth");
                    spaceObject.Volume10Pow9Km3 = GetXElement(xSpaceObject, "Volume10pow9KM3");
                    spaceObject.VolumeByEarth = GetXElement(xSpaceObject, "VolumeRByEarth");
                    spaceObject.Mass10Pow21Kg = GetXElement(xSpaceObject, "Mass10pow21kg");
                    spaceObject.MassByEarth = GetXElement(xSpaceObject, "MassByEarth");
                    spaceObject.DestinygByCm3 = GetXElement(xSpaceObject, "DensitygBycm3");
                    spaceObject.SurfaceGravitymByS2 = GetXElement(xSpaceObject, "SurfaceGravitymBys2");
                    spaceObject.SurfaceGravityByEarth = GetXElement(xSpaceObject, "SurfaceGravityByEarth");
                    spaceObject.TypeOfObject = GetXElement(xSpaceObject, "TypeOfObject");

                    //<ObjectId>1</ObjectId>
                    //<ParentId>-1</ParentId>
                    //<Name>Sun</Name>
                    //<WikiPage>http://en.wikipedia.org/wiki/Sun</WikiPage>
                    //<ImageData>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</ImageData>
                    //<ImageHint>The Sun by the Atmospheric Imaging Assembly of NASA's Solar Dynamics Observatory - 20100801.jpg</ImageHint>
                    //<MeanRadiusInKM>696000</MeanRadiusInKM>
                    //<MeanRadiusByEarth>109.25</MeanRadiusByEarth>
                    //<Volume10pow9KM3>1412000000</Volume10pow9KM3>
                    //<VolumeRByEarth>1303781</VolumeRByEarth>
                    //<Mass10pow21kg>1989100000</Mass10pow21kg>
                    //<MassByEarth>332837</MassByEarth>
                    //<DensitygBycm3>1.409</DensitygBycm3>
                    //<SurfaceGravitymBys2>274.0</SurfaceGravitymBys2>
                    //<SurfaceGravityByEarth>28.02</SurfaceGravityByEarth>
                    //<TypeOfObject>Star</TypeOfObject>

                    spaceObjectsList.Add(spaceObject);
                }
            }

            return spaceObjectsList;
        }

        private static string GetXElement(XElement xElement, string name)
        {
            string elementName = "";

            var element = xElement.Element(name);
            if (element != null) elementName = element.Value;

            return elementName;
        }

        #endregion


    }
}
