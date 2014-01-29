using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XeroxTest.Annotations;
using XeroxTest.Model;

namespace XeroxTest.ViewModel
{
    class SpaceObjectViewModel:INotifyPropertyChanged
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

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
