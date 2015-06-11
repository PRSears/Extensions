using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;


namespace Extender.IO
{
    /// <summary>
    /// Contains methods for serializing and deserializing object to a comma separated value (CSV) file.
    /// </summary>
    /// <remarks>
    /// Note: CsvSerializer can only deserialize primitives and strings.
    /// Note: Object being serialized / deserialized must have a parameterless constructor.
    /// </remarks>
    /// <typeparam name="T">Type of object this CsvSerializer can work with.</typeparam>
    public class CsvSerializer<T>
    {
        protected Type SerializeType;
        protected const int InitArraySize = 2500;
        
        protected PropertyInfo[] PublicProperties
        {
            get
            {
                if (_PublicProperties == null || _PublicProperties.Length == 0)
                    _PublicProperties = GetPublicProperties();
                return _PublicProperties;
            }
        }

        protected string[] PublicPropertyNames
        {
            get
            {
                if (_PublicPropertyNames == null || _PublicPropertyNames.Length == 0)
                    _PublicPropertyNames = GetPublicPropertyNames();
                return _PublicPropertyNames;
            }
        }

        private PropertyInfo[]  _PublicProperties;
        private string[]        _PublicPropertyNames;

        /// <summary>
        /// Initializes a new instance of the CsvSerializer that can serialize and deserialize objects 
        /// to a CSV file.
        /// </summary>
        public CsvSerializer()
        {
            SerializeType = typeof(T);

            _PublicProperties       = GetPublicProperties();
            _PublicPropertyNames    = GetPublicPropertyNames();
        }

        protected static BindingFlags _BindingFlags = BindingFlags.Public |
                                                      BindingFlags.Instance |
                                                      BindingFlags.GetProperty;

        protected PropertyInfo[] GetPublicProperties()
        {
            PropertyInfo[] properties = SerializeType.GetProperties(_BindingFlags);

            return properties.Where
                              (
                                p => p.GetCustomAttributes(false)
                                      .Count(a => a is System.Xml.Serialization.XmlIgnoreAttribute) < 1
                              )
                             .ToArray();
        }
        
        protected string[] GetPublicPropertyNames()
        {
            return GetPublicProperties().Select(p => p.Name)
                                        .ToArray();
        }

        /// <summary>
        /// Searches the list of public, non-ignored properties contained in this CsvSerializer's type.
        /// </summary>
        /// <param name="propertyName">The case-sensitive name of the parameter to search for.</param>
        /// <returns>The zero-based index of the matched property in the array of properties.
        /// Returns -1 if there's no match.
        /// </returns>
        public int GetIndexOfProperty(string propertyName)
        {
            for (int i = 0; i < PublicPropertyNames.Length; i++)
            {
                if (PublicPropertyNames[i].Equals(propertyName))
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Serializes the specified objects and writes the comma separated value string to a file using
        /// specified FileStream.
        /// </summary>
        /// <param name="stream">The stream used to write the CSV file.</param>
        /// <param name="o">Object to serialize to the csv file.</param>
        public void Serialize(FileStream stream, T o)
        {
            StreamWriter writer = new StreamWriter(stream);

            if(stream.Length == 0)
            {
                // Write the header (property names) if the file is empty
                writer.WriteLine(string.Join(",", this.PublicPropertyNames)); 
            }
            else
            {
                // If the file doesn't end with a new line, add one
                stream.Seek(-1, SeekOrigin.End);
                StreamReader reader = new StreamReader(stream);
                string lastChar = reader.ReadToEnd();

                if (!(lastChar.Equals("\n") || lastChar.Equals("\r") || lastChar.Equals("\r\n")))
                    writer.WriteLine();
            }

            // Write new entry 
            for(int i = 0; i < PublicProperties.Length; i++)
            {
                var propertyValue = PublicProperties[i].GetValue(o);

                if (propertyValue != null)
                    writer.Write(propertyValue.ToString());

                if (i != (PublicProperties.Length - 1))
                    writer.Write(",");
            }

            if (PublicProperties.Length > 0)
            {
                writer.WriteLine();
                writer.Flush();
            }
        }

        /// <summary>
        /// Serializes the specified objects and writes the comma separated value string to a file using
        /// specified FileStream.
        /// </summary>
        /// <param name="stream">The stream used to write the CSV file.</param>
        /// <param name="objects">Array of objects to serialize and add to the csv file.</param>
        public void Serialize(FileStream stream, T[] objects)
        {
            StreamWriter writer = new StreamWriter(stream);

            if (stream.Length == 0)
            {
                // Write the header (property names) if the file is empty
                writer.WriteLine(string.Join(",", this.PublicPropertyNames));
            }
            else
            {
                // If the file doesn't end with a new line, add one
                stream.Seek(-1, SeekOrigin.End);
                StreamReader reader = new StreamReader(stream);
                string lastChar = reader.ReadToEnd();

                if (!(lastChar.Equals("\n") || lastChar.Equals("\r") || lastChar.Equals("\r\n")))
                    writer.WriteLine();
            }

            // Write new entries
            foreach (var o in objects)
            {
                for (int i = 0; i < PublicProperties.Length; i++)
                {
                    var propertyValue = PublicProperties[i].GetValue(o);

                    if (propertyValue != null)
                        writer.Write(propertyValue.ToString());

                    if (i != (PublicProperties.Length - 1))
                        writer.Write(",");
                }

                if (PublicProperties.Length > 0)
                    writer.WriteLine();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes the entire CSV file using the data contained by the specified FileStream.
        /// </summary>
        /// <param name="stream">The stream that contains the CSV file to deserialize.</param>
        /// <returns>An array of all objects deserialized from the specified CSV file.</returns>
        public T[] Deserialize(FileStream stream)
        {
            if (stream.Length == 0) return null;

            stream.Seek(0, SeekOrigin.Begin);
            StreamReader reader = new StreamReader(stream);

            reader.ReadLine(); // skip the first line (where the header should be)

            List<T> data = new List<T>();
            while(reader.Peek() > -1)
            {
                data.Add(Deserialize(reader.ReadLine()));
            }

            return data.ToArray();
        }

        //
        // THOUGHT After doing some tests, I found there was very little (~15%)
        //         performance benefit to the array only method. I'm sure
        //         further optimization is possible, but I don't see what you 
        //         could do that could do any better than maybe 50%. It's expected
        //         that the returned array won't have any empty cells.
        //
        //         Besides, even an 18k line file only takes ~200ms on a crappy
        //         dual core Macbook from 2009. 

        private T[] Deserialize_NoLists(FileStream stream)
        {
            if (stream.Length == 0) return null;

            stream.Seek(0, SeekOrigin.Begin);
            StreamReader reader = new StreamReader(stream);
            reader.ReadLine(); // skip the line where the header should be

            T[] data = new T[InitArraySize];
            int i = 0;

            while(reader.Peek() > -1)
            {
                data[i] = Deserialize(reader.ReadLine());

                if(++i >= data.Length) // expand
                {
                    T[] expanded = new T[data.Length * 2];
                    Array.Copy(data, expanded, i - 1);
                    data = expanded;
                }
            }

            if (data.Length != (i - 1)) // resize
            {
                T[] trimmed = new T[i];
                Array.Copy(data, trimmed, i);

                return trimmed;
            }
            else
                return data;
        }

        /// <summary>
        /// Deserializes specific lines of the CSV file based on a predicate.
        /// </summary>
        /// <param name="stream">The stream that contains the CSV file to deserialize.</param>
        /// <param name="predicate">The function to test each line for a condition.</param>
        /// <returns>An IEnumerable of the deserialized T objects.</returns>
        public IEnumerable<T> Deserialize(FileStream stream, Func<string, bool> predicate)
        {
            string file = stream.Name;
            string tmp = @"~tmp.csv";

            if (File.Exists(tmp))
                File.Delete(tmp);

            File.Copy(file, tmp);

            return File.ReadLines(tmp).Where(predicate)
                                      .Select(s => Deserialize(s));
        }

        public IEnumerable<T> DeserializeSplitWhere(FileStream stream, Func<string[], bool> predicate)
        {
            string file = stream.Name;
            string tmp = @"~tmp.csv";

            if (File.Exists(tmp))
                File.Delete(tmp);

            File.Copy(file, tmp);

            return File.ReadLines(tmp)
                       .Select(l => l.Split(','))
                       .Where(predicate)
                       .Select(s => Deserialize(s));
        }

        /// <summary>
        /// Deserializes from a single string (one object).
        /// </summary>
        /// <param name="item">String representation (comma separated values) of single T object being deserialized.</param>
        /// <returns>T object deserialized from the provided string.</returns>
        protected T Deserialize(string item)
        {
            if (string.IsNullOrWhiteSpace(item))
                return (T)Activator.CreateInstance(typeof(T));

            return Deserialize(item.Split(','));
        }

        protected T Deserialize(string[] item)
        {
            T deserialized = (T)Activator.CreateInstance(typeof(T));

            if (item == null || item.Count() < 1)
                return deserialized;

            string[] head = PublicPropertyNames;

            #region warning
            if (item.Length != head.Length)
            {
                Debugging.Debug.WriteMessage
                (
                    string.Format
                    (
                        "[{0}] Number of properties in header ({1}) does not match number of properties being deserialized ({2}).",
                        this.GetType().Name,
                        head.Length.ToString(),
                        item.Length.ToString()
                    ),
                    "warn"
                );
            }
            #endregion

            for (int i = 0; i < item.Length; i++)
            {
                PropertyInfo cur = PublicProperties.First(p => p.Name.Equals(head[i]));

                if (cur != null && cur.CanWrite)
                {
                    if (cur.PropertyType.IsNumber())
                    {
                        cur.SetValue
                        (
                            deserialized,
                            TypeDescriptor.GetConverter(cur.PropertyType)
                                          .ConvertFromInvariantString(item[i])
                        );
                    }
                    else if (cur.PropertyType.Equals(typeof(string)))
                        cur.SetValue(deserialized, item[i]);
                    else if (cur.PropertyType.Equals(typeof(char)))
                        cur.SetValue(deserialized, item[i].ToCharArray()[0]);
                    else
                        throw new ArgumentException
                        (
                            "Not all types being deserialized are primitives or string.\n" +
                            "Use the [System.Xml.Serialization.XmlIgnore] attribute on any other properties so they aren't serialized.",
                            "item"
                        );
                }
            }

            return deserialized;
        }
    }
}
