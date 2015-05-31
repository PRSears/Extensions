using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Extender.WPF
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public ICommand CloseCommand    { get; set; }
        public bool ConfirmClose        { get; set; }

        public virtual void Initialize()
        {
            ConfirmClose = false;
        }

        public void RegisterCloseAction(Action close)
        {
            this.CloseCommand = new Extender.WPF.RelayCommand(close);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
