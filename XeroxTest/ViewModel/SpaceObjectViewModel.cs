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
             _spaceObjects = SpaceObjectModel.GetSpaceObjectsCollectionByParentId(-1);
        }

        private ObservableCollection<SpaceObjectModel> _spaceObjects;

        public ObservableCollection<SpaceObjectModel> SpaceObjects
        {
            get { return _spaceObjects; }
            set { _spaceObjects = value; }
        }
    }
}
