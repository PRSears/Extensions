using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Extender.WPF
{
    public class WindowManager
    {
        public event WindowOpenedEventHandler WindowOpened;
        public event WindowClosedEventHandler WindowClosed;

        public List<Window> Children
        {
            get;
            protected set;
        }

        public WindowManager()
        {
            this.Children = new List<Window>();
        }

        protected void OnWindowOpened(Window window)
        {
            WindowOpenedEventHandler handler = WindowOpened;
            if (handler != null)
                handler(this, window);
        }

        protected void OnWindowClosed(Type windowType)
        {
            WindowClosedEventHandler handler = WindowClosed;
            if (handler != null)
                handler(this, windowType);
        }

        public void OpenWindow(Window view)
        {
            if (Children == null) Children = new List<Window>();

            Type viewType = view.GetType();

            if(WindowIsOpen(viewType))
            {
                var existing = Children.FirstOrDefault(
                                        w => w.GetType().Equals(viewType));

                if (existing != null)
                {
                    existing.Focus();
                    return;
                }
            }

            Children.Add(view);
            view.Closed += Child_Closed;

            view.Show();

            OnWindowOpened(view);
        }

        public bool WindowIsOpen(Type typeOfWindow)
        {
            return (Children.Where(w => w.GetType().Equals(typeOfWindow)).Count() > 0);
        }

        public bool ChildOpen()
        {
            return (Children.Count > 0);
        }

        public void CloseAll()
        {
            while (Children.Count > 0)
            {
                if (Children[0] != null)
                    Children[0].Close();
            }

            this.Children = null;
        }

        protected void Child_Closed(object sender, EventArgs e)
        {
            if (!(sender is Window))
                return;

            Type windowType = sender.GetType();

            int childIndex = Children.IndexOf((sender as Window));

            Children[childIndex] = null;
            Children.RemoveAt(childIndex);

            OnWindowClosed(windowType);
        }
    }

    public delegate void WindowOpenedEventHandler(object sender, Window window);
    public delegate void WindowClosedEventHandler(object sender, Type windowType);
}