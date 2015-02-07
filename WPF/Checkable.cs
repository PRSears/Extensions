using System.ComponentModel;

namespace Extender.WPF
{
    /// <summary>
    /// A wrapper object to store checked status with an object for display in 
    /// an observable collection.
    /// </summary>
    public class Checkable<T> : INotifyPropertyChanged
    {
        private T     _Resource;
        private bool  _IsChecked;

        /// <summary>
        /// Gets or sets the resource contained by this Checkable object.
        /// </summary>
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

        /// <summary>
        /// Gets or sets whether this object is checked.
        /// </summary>
        public bool IsChecked 
        {
            get
            {
                return _IsChecked;
            }
            set
            {
                _IsChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        /// <summary>
        /// Contructs a new Checkable object, defaulting to unchecked.
        /// </summary>
        public Checkable(T resource)
        {
            Resource    = resource;
            IsChecked   = false;
        }

        /// <summary>
        /// Contructs a new Checkable object with specified properties.
        /// </summary>
        public Checkable(T resource, bool isChecked)
        {
            Resource    = resource;
            IsChecked   = isChecked;
        }

        /// <returns>Returns the contained resource as a stirng.</returns>
        public override string ToString()
        {
            return _Resource.ToString();
        }

        /// <summary>
        /// Compares IsChecked states and calls Resource.Equals
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(this.GetType()))
            {
                var b = (Checkable<T>)obj;
                return (this.IsChecked == b.IsChecked) && (this.Resource.Equals(b.Resource));
            }
            else return false;
        }

        /// <summary>
        /// Occurs when one of Checkable's properties has been changed.
        /// </summary>
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
