using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeroxTest.Model;

namespace XeroxTest.ViewModel
{
    class SpaceObjectViewModel
    {
        public SpaceObjectViewModel()
        {
             _spaceObjects = SpaceObject.GetSpaceObjectsCollectionByParentId(1);
        }

        private ObservableCollection<SpaceObject> _spaceObjects;
        private SpaceObject _selectedSpaceObject;

        public ObservableCollection<SpaceObject> SpaceObjects
        {
            get { return _spaceObjects; }
            set { _spaceObjects = value; }
        }

        public SpaceObject SelectedSpaceObject 
        {
            get { return _selectedSpaceObject; }
            set { _selectedSpaceObject = value; }
        }
    }
}
