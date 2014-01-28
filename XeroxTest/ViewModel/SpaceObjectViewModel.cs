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

        public ICommand ListBoxItemClickCommand { get; set; }

        private void ListBoxItemClickMethod()
        {
            MessageBox.Show("Clicked");
        }
    }
}
