using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XeroxTest.Model;

namespace XeroxTest.ViewModel
{
    class SpaceObjectViewModel
    {
        public SpaceObjectViewModel()
        {
            ListBoxItemClickCommand = new Command(arg => ListBoxItemClickMethod());
            LinkCommand = new Command(arg => LinkMethod());
             
            _spaceObjects = SpaceObject.GetSpaceObjectsCollectionByParentId(-1);
            //_spaceObjects[0].ChildrensCollection = SpaceObject.GetSpaceObjectsCollectionByParentId(1);
            _spaceObjects[0].ChildrensCollection.Add(new SpaceObject { Name = "123" });
            _spaceObjects[0].ChildrensCollection.Add(new SpaceObject { Name = "456" });
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
            set
            {
                _selectedSpaceObject = value;
            }
        }

        public ICommand ListBoxItemClickCommand { get; set; }
        public ICommand LinkCommand { get; set; }

        private void ListBoxItemClickMethod()
        {
            MessageBox.Show("Clicked");
        }

        private void LinkMethod()
        {
            MessageBox.Show("Clicked");
        }
    }
}
