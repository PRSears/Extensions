using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace Extender.IO
{
    /// <summary>
    /// Abstract class for creating and managing an array from a stored, serialized XML file.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public abstract class SerializedArray<T> : INotifyPropertyChanged
    {
        public T[] SourceList
        {
            get
            {
                return _SourceList;
            }
            set
            {
                _SourceList = value;
                OnPropertyChanged("SourceList");
            }
        }
        private T[] _SourceList;
        protected string FilePath;

        /// <summary>
        /// Expands the SourceList and adds 'item' to the last index.
        /// Saves changes to the XML file.
        /// </summary>
        /// <param name="item">new item to add to the SourceList.</param>
        public virtual void Add(T item)
        {
            Reload();

            T[] appendedList = new T[SourceList.Length + 1];

            Array.Copy(SourceList, appendedList, SourceList.Length);
            appendedList[SourceList.Length] = item;

            SourceList = appendedList;
            Save();
        }

        /// <summary>
        /// Searches SourceList for element matching 'item', removes it from the array if found.
        /// The size of the array is automatically adjusted if necessary.
        /// </summary>
        /// <param name="item">item to be removed from the SourceList.</param>
        /// <returns>True if there was a matching item in SourceList.</returns>
        public virtual bool Remove(T item)
        {
            T[] ammendedList = new T[SourceList.Length - 1];

            try
            {
                int p = 0;
                for(int i = 0; i < SourceList.Length; i++)
                {
                    if (!SourceList[i].Equals(item))
                    {
                        ammendedList[p] = SourceList[i];
                        p++;
                    }
                }

                SourceList = ammendedList;
                Save();

                return true;
            }
            catch(IndexOutOfRangeException)
            {
                Extender.Debugging.Debug.WriteMessage
                (
                    string.Format("item ({0}) could not be removed from SourceList because it did not exist.", item.ToString()),
                    "warn"
                );
                return false; // 'item' was never found
            }
        }

        /// <summary>
        /// Replaces (overwrites) this class' public members with current values taken from the XML file.
        /// </summary>
        public virtual void Reload()
        {
            if (!File.Exists(FilePath))
                return;

            using(FileStream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xml = new XmlSerializer(this.GetType());

                this.UpdateFrom<SerializedArray<T>>
                (
                    (SerializedArray<T>)xml.Deserialize(stream)
                );
            }

            // TODO Test if OnPropertyChanged gets triggered by the UpdateFrom's copies
            //OnPropertyChanged("SourceList"); -- I suspect it does
        }

        /// <summary>
        /// Serializes this object and saves (overwrites) to the XML file.
        /// </summary>
        public virtual void Save()
        {
            using(FileStream stream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer xml = new XmlSerializer(this.GetType());

                xml.Serialize(stream, this);
            }
        }

        /// <summary>
        /// Calls Array.Sort on the Source List.
        /// </summary>
        public virtual void Sort()
        {
            Array.Sort(SourceList);
            OnPropertyChanged("SourceList");
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }

    public enum SerializeOperations { Save, Load }

    public class SerializeTask<T>
    {
        protected SerializeOperations Operation;
        protected SerializedArray<T> Obj;
        protected FileInfo File;

        public SerializeTask(FileInfo file, SerializedArray<T> obj, SerializeOperations operation)
        {
            this.Operation  = operation;
            this.File       = file;
            this.Obj        = obj;
        }

        public void Execute()
        {
            if (this.Operation == SerializeOperations.Save)
                Save();
            else if (this.Operation == SerializeOperations.Load)
                Load();
        }

        protected void Save()
        {
            using(FileStream stream = new FileStream(this.File.FullName, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer xml = new XmlSerializer(this.Obj.GetType());
                xml.Serialize(stream, this.Obj);
            }
        }

        protected void Load()
        {
            if (!this.File.Exists)
                return;

            using(FileStream stream = new FileStream(this.File.FullName, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xml = new XmlSerializer(this.Obj.GetType());

                this.Obj.UpdateFrom<SerializedArray<T>>
                (
                    (SerializedArray<T>)xml.Deserialize(stream)
                );
            }
        }
    }
}
