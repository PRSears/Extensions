using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Extender.WPF
{
    /// <remarks>
    /// A simple window manager to handle proper opening and closing 
    /// of child Windows.
    /// </remarks>
    public class WindowManager
    {
        /// <summary>
        /// Occurs when a new Window is opened by this WindowManager.
        /// </summary>
        public event WindowOpenedEventHandler WindowOpened;
        /// <summary>
        /// Occurs when a child window managed by this WindowManager is closed.
        /// </summary>
        public event WindowClosedEventHandler WindowClosed;

        /// <summary>
        /// List of all child Window objects managed by this WindowManager.
        /// </summary>
        public List<Window> Children
        {
            get;
            protected set;
        }

        /// <summary>
        /// Initializes a new WindowManager.
        /// </summary>
        public WindowManager()
        {
            this.Children = new List<Window>();
        }

        /// <summary>
        /// Handler for when a new child window is opened.
        /// </summary>
        /// <param name="window">The Window object being opened.</param>
        private void OnWindowOpened(Window window)
        {
            WindowOpenedEventHandler handler = WindowOpened;
            if (handler != null)
                handler(this, window);
        }

        /// <summary>
        /// Handler for when a child window is closed.
        /// </summary>
        /// <param name="windowType">The type of the window being closed.</param>
        private void OnWindowClosed(Type windowType)
        {
            WindowClosedEventHandler handler = WindowClosed;
            if (handler != null)
                handler(this, windowType);
        }

        /// <summary>
        /// Handles the opening of the given window.
        /// </summary>
        /// <param name="view">Window to open.</param>
        /// <param name="allowMultiples">Determines whether duplicates of the same Window Type are allowed.</param>
        public void OpenWindow(Window view, bool allowMultiples = false)
        {
            if (Children == null) Children = new List<Window>();

            Type viewType = view.GetType();

            if(WindowIsOpen(viewType) && !allowMultiples)
            {
                var existing = Children.FirstOrDefault
                (
                    w => w.GetType().Equals(viewType)
                );

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

        /// <summary>
        /// Searches the list of Children Windows to check if a Window of a given 
        /// type is being managed.
        /// </summary>
        /// <param name="typeOfWindow">Type of the Window to search for.</param>
        /// <returns>
        /// True when a child window of matching type is being managed by this WindowManager.
        /// </returns>
        public bool WindowIsOpen(Type typeOfWindow)
        {
            return (Children.Where(w => w.GetType().Equals(typeOfWindow)).Count() > 0);
        }

        /// <summary>
        /// Checks if there are *any* Children Windows currently being managed by 
        /// this WindowManager.
        /// </summary>
        public bool ChildOpen()
        {
            return (Children.Count > 0);
        }

        /// <summary>
        /// Closes a matching child Window.
        /// </summary>
        /// <param name="childWindow">
        /// The child window to search for and close.
        /// Only an exact match (using .Equals() to compare) will result in a 
        /// Window being closed.
        /// </param>
        /// <returns>
        /// True if childWindow is found in the Children list and was successfully removed.
        /// </returns>
        public bool CloseChild(Window childWindow)
        {
            try
            {
                Children.First(w => w.Equals(childWindow)).Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Closes the child window at the specified index in the Children list.
        /// </summary>
        /// <param name="index">0-based index of the child window to close in the Children list.</param>
        /// <returns>True if an element was successfully removed from the provided index.</returns>
        public bool CloseChildAtIndex(int index)
        {
            if (this.Children.Count < index) return false;

            return CloseChild(this.Children[index]);
        }

        /// <summary>
        /// Closes managed child Windows based on a predicate.
        /// </summary>
        /// <returns>The number of child Windows successfully closed</returns>
        public int CloseChildren(Func<Window, bool> predicate)
        {
            var matches = Children.Where(predicate).ToArray();

            int closed = 0;
            foreach(var match in matches)
            {
                if (CloseChild(match))
                    closed++;
            }

            return closed; // number of children closed
        }

        /// <summary>
        /// Attempts to close all child Windows being managed by this WindowManager.
        /// Sets this.Children list to null when complete.
        /// </summary>
        public void CloseAll()
        {
            int attempts = 0;
            while (Children.Count > 0 && attempts < 1000)
            {
                if (Children[0] != null)
                    Children[0].Close();
                attempts++;
            }

            this.Children = null;
        }

        private void Child_Closed(object sender, EventArgs e)
        {
            if (!(sender is Window))
                return;

            Type windowType = sender.GetType();

            int childIndex = Children.IndexOf((sender as Window));

            // Properly dispose of the closed window and remove it 
            // from the list of Children being managed.
            Children[childIndex] = null; 
            Children.RemoveAt(childIndex);

            OnWindowClosed(windowType);
        }
    }
    
    public delegate void WindowOpenedEventHandler(object sender, Window window);
    public delegate void WindowClosedEventHandler(object sender, Type windowType);
}