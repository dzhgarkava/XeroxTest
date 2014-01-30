using System.Collections.ObjectModel;
using XeroxTest.Model;

namespace XeroxTest.ViewModel
{
    class SpaceObjectViewModel
    {
        public SpaceObjectViewModel()
        {
            SpaceObjects = SpaceObject.GetSpaceObjectsCollectionByParentId(-1);
        }

        public ObservableCollection<SpaceObject> SpaceObjects { get; set; }
    }
}
