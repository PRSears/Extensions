using System.ComponentModel;

namespace Extender.WPF
{
    public class Checkable<T> : INotifyPropertyChanged
    {
        protected T     _Resource;
        protected bool  _IsChecked;

        public T Resource 
        {
            get
            {
                return _Resource;
            }
            set
            {
                _Resource = value;
                OnPropertyChanged("Resource");
            }
        }

        public bool IsChecked 
        {
            get
            {
                return _IsChecked;
            }
            set
            {
                _IsChecked = value;
                OnPropertyChanged("Resource");
            }
        }

        public Checkable(T resource)
        {
            Resource    = resource;
            IsChecked   = false;
        }

        public Checkable(T resource, bool isChecked)
        {
            Resource    = resource;
            IsChecked   = isChecked;
        }

        public override string ToString()
        {
            return _Resource.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(this.GetType()))
            {
                var b = (Checkable<T>)obj;
                return (this.IsChecked == b.IsChecked) && (this.Resource.Equals(b.Resource));
            }
            else return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
