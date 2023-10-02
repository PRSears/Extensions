using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Extender.Debugging;

namespace Extender.IO;

/// <summary>
/// Abstract class for creating and managing an array from a stored, serialized XML file.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public abstract class SerializedArray<T> : INotifyPropertyChanged
{
    public T[] SourceList
    {
        get => _SourceList;
        set
        {
            _SourceList = value;
            OnPropertyChanged("SourceList");
        }
    }

    private T[] _SourceList;

    public abstract string FilePath { get; }

    public SerializedArray() { Directory.CreateDirectory(Directory.GetParent(FilePath).FullName); }

    /// <summary>
    /// Expands the SourceList and adds 'item' to the last index.
    /// Saves changes to the XML file.
    /// </summary>
    /// <param name="item">new item to add to the SourceList.</param>
    public virtual void Add(T item)
    {
        BlockingReload();

        if (SourceList == null || SourceList.Length < 1)
        {
            SourceList = new T[] { item };
        }
        else
        {
            T[] appendedList = new T[SourceList.Length + 1];

            Array.Copy(SourceList, appendedList, SourceList.Length);
            appendedList[SourceList.Length] = item;

            SourceList = appendedList;
        }

        BlockingSave();
    }

    /// <summary>
    /// Expands the SourceList and adds 'items' at the end.
    /// Saves changes to the XML file.
    /// </summary>
    /// <param name="items">Array of items to append to SourceList.</param>
    public virtual void Add(T[] items)
    {
        BlockingReload();

        if (SourceList == null || SourceList.Length < 1)
        {
            SourceList = items;
        }
        else
        {
            T[] appendedList = new T[SourceList.Length + items.Length];

            Array.Copy(SourceList, appendedList, SourceList.Length);
            Array.Copy
            (
                items,
                0,
                appendedList,
                SourceList.Length,
                items.Length
            );

            SourceList = appendedList;
        }

        BlockingSave();
    }

    /// <summary>
    /// Searches SourceList for element matching 'item', removes it from the array if found.
    /// The size of the array is automatically adjusted if necessary.
    /// </summary>
    /// <param name="item">item to be removed from the SourceList.</param>
    /// <returns>True if there was a matching item in SourceList.</returns>
    public virtual bool Remove(T item)
    {
        if (SourceList == null || SourceList.Length < 1)
        {
            Debug.WriteMessage("SourceList has not been initialized.", WarnLevel.Warn);
            return false;
        }

        T[] ammendedList = new T[SourceList.Length - 1];

        try
        {
            int p = 0;
            foreach (T t in SourceList.Where(t => !t.Equals(item)))
            {
                ammendedList[p] = t;
                p++;
            }

            SourceList = ammendedList;
            BlockingSave();

            return true;
        }
        catch (IndexOutOfRangeException)
        {
            Debug.WriteMessage
            (
                $"item ({item.ToString()}) could not be removed from SourceList because it did not exist.",
                WarnLevel.Warn
            );
            return false; // 'item' was never found
        }
    }

    private void BlockingReload()
    {
        if (!File.Exists(FilePath))
            return;

        using (var stream = new FileStream
                   (FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            var xml = new XmlSerializer(GetType());

            this.UpdateFrom<SerializedArray<T>>((SerializedArray<T>) xml.Deserialize(stream));
        }

        // TODO Test if OnPropertyChanged gets triggered by the UpdateFrom's copies
        //OnPropertyChanged("SourceList"); -- I suspect it does
    }

    private void BlockingSave()
    {
        using (var stream = new FileStream
                   (FilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
        {
            var xml = new XmlSerializer(GetType());

            xml.Serialize(stream, this);
        }
    }

    /// <summary>
    /// When overridden in a derived class, queues a SerializeTask to reload the SourceList. Should be non-blocking.
    /// </summary>
    public abstract void QueueReload();

    /// <summary>
    /// When overridden in a derived class, queues a SerializeTask to save the SourceList. Should be non-blocking.
    /// </summary>
    public abstract void QueueSave();

    /// <summary>
    /// Replaces (overwrites) this class' public members with current values taken from the XML file.
    /// This method is blocking and doesn't account for simultaneous reads and writes. 
    /// </summary>
    public virtual void Reload() { BlockingReload(); }

    /// <summary>
    /// Serializes this object and saves (overwrites) to the XML file.
    /// This method is blocking and doesn't account for simultaneous reads and writes.  
    /// </summary>
    public virtual void Save() { BlockingSave(); }

    /// <summary>
    /// Calls Array.Sort on the Source List.
    /// </summary>
    public virtual void Sort()
    {
        Array.Sort(SourceList);
        OnPropertyChanged("SourceList");
    }

    /// <summary>
    /// Asynchronously reloads the source list. 
    /// </summary>
    /// <remarks>
    /// A BlockingCollection of SerializeTasks in a static class with a static constructor is recommended 
    /// to reduce IOExceptions from concurrent reads/writes.
    /// </remarks>
    public abstract Task ReloadAsync();

    /// <summary>
    /// Asynchronously saves the source list.
    /// </summary>
    /// <remarks> 
    /// A BlockingCollection of SerializeTasks in a static class with a static constructor is recommended 
    /// to reduce IOExceptions from concurrent reads/writes.
    /// </remarks>
    public abstract Task SaveAsync();


    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;

        handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}

/// <summary>
/// 
/// </summary>
public enum SerializeOperations { Save, Load }

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class SerializeTask<T>
{
    private readonly SerializeOperations _Operation;
    private readonly SerializedArray<T>  _Obj;
    private readonly FileInfo            _File;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="file"></param>
    /// <param name="obj"></param>
    /// <param name="operation"></param>
    public SerializeTask(FileInfo file, SerializedArray<T> obj, SerializeOperations operation)
    {
        _Operation = operation;
        _File      = file;
        _Obj       = obj;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Execute()
    {
        switch (_Operation)
        {
            case SerializeOperations.Save:
                Save();
                break;
            case SerializeOperations.Load:
                Load();
                break;
        }
    }

    private void Save()
    {
        using (var stream = new FileStream
                   (_File.FullName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
        {
            var xml = new XmlSerializer(_Obj.GetType());
            xml.Serialize(stream, _Obj);
        }
    }

    private void Load()
    {
        if (!_File.Exists)
            return;

        using (var stream = new FileStream
                   (_File.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            var xml = new XmlSerializer(_Obj.GetType());

            _Obj.UpdateFrom<SerializedArray<T>>((SerializedArray<T>) xml.Deserialize(stream));
        }
    }
}