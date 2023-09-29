using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Extender
{
    public static class Strings
    {
        public static string ToPropercase(this string text)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentException("text cannot be null or empty.");

            return text.First().ToString().ToUpper() + String.Join("", text.Skip(1));
        }

        public static string InsertBeforeExtension(this string path, string insertionString)
        {
            return string.Format
            (
                "{0}{1}{2}",
                Path.GetFileNameWithoutExtension(path),
                insertionString,
                Path.GetExtension(path)
            );
        }

        public static string EscapeForHTML(this string text)
        {
            return text.Replace(@"&", @"&amp;")
                       .Replace(@"""", @"&#34;")
                       .Replace(@"<", @"&lt;")
                       .Replace(@">", @"&gt;")
                       .Replace(@"!", @"&#33;")
                       .Replace(@"©", @"&#169;");
        }

        /// <summary>
        /// Returns a modified string with the specified 'inner' HTML tag removed where it is nested in the 'outer' tag.
        /// </summary>
        /// <param name="outerTagStart"></param>
        /// <param name="outerTagEnd"></param>
        /// <param name="innerTagStart"></param>
        /// <param name="innerTagEnd"></param>
        /// <returns></returns>
        public static string RemoveNestedHTMLTag(this string html, string outerTagStart, string outerTagEnd, string innerTagStart, string innerTagEnd)
        {
            System.Text.StringBuilder buffer = new System.Text.StringBuilder();

            int pos = 0;

            int i = html.IndexOf(outerTagStart);
            int j = html.IndexOf(outerTagEnd);
            while (i >= 0 && i > pos)
            {
                buffer.Append(html.Substring(pos, i - pos)); // add everything up to the <outer> tag

                int m = html.IndexOf(innerTagStart, i, j - i);
                int n;
                if (m >= 0)
                {
                    n = html.IndexOf(innerTagEnd, m, j - i);

                    buffer.Append(html.Substring(i, m - i)); // add everything between the <outer> and the <inner> tags
                    pos = n + 1; // move to the character after the end of the tag

                    buffer.Append(html.Substring(pos, (j + 4) - pos));
                    pos = j + 4;
                }
                else
                {
                    buffer.Append(html.Substring(i, (j + 4) - i)); // add everything up to the end of the </outer> tag
                    pos = j + 4; // move to the character after the end of the </outer> tag
                }

                i = pos + html.Substring(pos).IndexOf(outerTagStart); // keep walking
                j = pos + html.Substring(pos).IndexOf(outerTagEnd);
            }

            buffer.Append(html.Substring(pos, html.Length - pos)); // add any leftovers

            return buffer.ToString();
        }
    }

    public static class DateTimes
    {
        public static bool InRange(this DateTime date, DateTime rangeStart, DateTime rangeEnd)
        {
            return InRange(date, new Extender.Date.DateRange(rangeStart, rangeEnd));
        }

        public static bool InRange(this DateTime date, Extender.Date.DateRange range)
        {
            return range.Overlaps(date);
        }

        public static bool Elapsed(this TimeSpan span, DateTime startTime)
        {
            return (DateTime.Now - startTime) >= span;
        }
    }

    public static class Sizes
    {
        public static bool WidthIsLongEdge(this System.Drawing.Size size)
        {
            return (size.Width > size.Height) ? true : false;
        }

        public static double AspectRatio(this System.Drawing.Size size)
        {
            return ((double)size.Width / (double)size.Height);
        }

        /// <returns>
        /// Returns the length of the longest edge of this size.
        /// </returns>
        public static int LongEdge(this System.Drawing.Size size)
        {
            return (size.WidthIsLongEdge()) ? size.Width : size.Height;
        }

        public static int CompareAreaTo(this System.Drawing.Size a, System.Drawing.Size b)
        {
            int aArea = a.Width * a.Height;
            int bArea = b.Width * b.Height;

            if (aArea > bArea)
                return 1;
            else if (aArea == bArea)
                return 0;
            else
                return -1;
        }
    }

    public static class Rectangles
    {
        /// <returns>Returns true if the Width of this Rectangle is greater than its height.</returns>
        public static bool IsHorizontal(this Rectangle rect)
        {
            if (rect.Width > rect.Height)   return true;
            else                            return false;
        }


        /// <returns>Returns true if the Height of this Rectangle is greater than its width.</returns>
        public static bool IsVertical(this System.Drawing.Rectangle rect)
        {
            return !IsHorizontal(rect);
        }

        /// <returns>Returns a point representing the center of this Rectangle.</returns>
        public static Point GetCenter(this Rectangle rect)
        {
            return new Point
            (
                (int)Math.Round(rect.Width / 2d),
                (int)Math.Round(rect.Height / 2d)
            );
        }
        
        /// <summary>
        /// Compares the area of this rectangle to another. 
        /// </summary>
        public static int CompareAreaTo(this Rectangle a, Rectangle b)
        {
            return a.Size.CompareAreaTo(b.Size);
        }
    }

    public static class Points
    {
        public static Extender.Drawing.Offset GetOffset(this Point a, Point b)
        {
            return new Extender.Drawing.Offset
            (
                a.X - b.X,
                a.Y - b.Y
            );
        }
    }

    public static class Actions
    {
        public static void NullSafeInvoke(this Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        public static void ForEach<T>(this IEnumerable<T> enumerator, Action<T> action)
        {
            foreach(var item in enumerator)
            {
                action(item);
            }
        }
    }

    public static class ObservableCollections
    {
        /// <summary>
        /// Removes items in a collection based on a predicate.
        /// </summary>
        /// <returns>Number of removed items.</returns>
        public static int RemoveAll<T>(this System.Collections.ObjectModel.ObservableCollection<T> collection,
                                       Func<T, bool> predicate)
        {
            var removals = collection.Where(predicate).ToArray();

            foreach(var item in removals)
                collection.Remove(item);

            return removals.Length;
        }

        /// <summary>
        /// Removes the first matching item in a collection based on a predicate.
        /// </summary>
        /// <returns>True if an item was found and removed.</returns>
        public static bool RemoveFirst<T>(this System.Collections.ObjectModel.ObservableCollection<T> collection,
                                          Func<T, bool> predicate)
        {
            var match = collection.FirstOrDefault(predicate);
            if (match != null)
                return collection.Remove(match);
            else
                return false;
        }
    }

    // Methods to do with deep copies in Objects, Arrays, and ArrayTraverse are
    // courtesy of Alexey Burtsev from StackOverflow:
    // https://raw.githubusercontent.com/Burtsev-Alexey/net-object-deep-copy/master/ObjectExtensions.cs

    public static class Objects
    {
        private static readonly MethodInfo CloneMethod = typeof(Object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);

        public static bool IsPrimitive(this Type type)
        {
            if (type == typeof(String)) return true;
            return (type.IsValueType & type.IsPrimitive);
        }

        public static Object Copy(this Object originalObject)
        {
            return InternalCopy(originalObject, new Dictionary<Object, Object>(new Extender.ObjectUtils.ReferenceEqualityComparer()));
        }

        private static Object InternalCopy(Object originalObject, IDictionary<Object, Object> visited)
        {
            if (originalObject == null) return null;
            var typeToReflect = originalObject.GetType();
            if (IsPrimitive(typeToReflect)) return originalObject;
            if (visited.ContainsKey(originalObject)) return visited[originalObject];
            if (typeof(Delegate).IsAssignableFrom(typeToReflect)) return null;
            var cloneObject = CloneMethod.Invoke(originalObject, null);
            if (typeToReflect.IsArray)
            {
                var arrayType = typeToReflect.GetElementType();
                if (IsPrimitive(arrayType) == false)
                {
                    Array clonedArray = (Array)cloneObject;
                    clonedArray.ForEach((array, indices) => array.SetValue(InternalCopy(clonedArray.GetValue(indices), visited), indices));
                }

            }
            visited.Add(originalObject, cloneObject);
            CopyFields(originalObject, visited, cloneObject, typeToReflect);
            RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect);
            return cloneObject;
        }

        private static void RecursiveCopyBaseTypePrivateFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect)
        {
            if (typeToReflect.BaseType != null)
            {
                RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect.BaseType);
                CopyFields(originalObject, visited, cloneObject, typeToReflect.BaseType, BindingFlags.Instance | BindingFlags.NonPublic, info => info.IsPrivate);
            }
        }

        private static void CopyFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy, Func<FieldInfo, bool> filter = null)
        {
            foreach (FieldInfo fieldInfo in typeToReflect.GetFields(bindingFlags))
            {
                if (filter != null && filter(fieldInfo) == false) continue;
                if (IsPrimitive(fieldInfo.FieldType)) continue;
                var originalFieldValue = fieldInfo.GetValue(originalObject);
                var clonedFieldValue = InternalCopy(originalFieldValue, visited);
                fieldInfo.SetValue(cloneObject, clonedFieldValue);
            }
        }
        public static T Copy<T>(this T original)
        {
            return (T)Copy((Object)original);
        }

        /// <summary>
        /// Performs type comparison to check if this object is a type of number.
        /// </summary>
        /// <param name="value">Object being checked.</param>
        /// <returns>True if this object is a type of number.</returns>
        public static bool IsNumber(this object value)
        {
            return  value is int    ||
                    value is double ||
                    value is float  ||
                    value is sbyte  ||
                    value is byte   ||
                    value is short  ||
                    value is ushort ||
                    value is uint   ||
                    value is long   ||
                    value is ulong  ||
                    value is decimal;
        }

        /// <summary>
        /// Performs type comparison to check if this Type is a type of number.
        /// </summary>
        /// <param name="value">Type being checked.</param>
        /// <returns>True if this Type is a type of number.</returns>
        public static bool IsNumber(this Type value)
        {
            return  value.Equals(typeof(int))       ||
                    value.Equals(typeof(double))    ||
                    value.Equals(typeof(float))     ||
                    value.Equals(typeof(sbyte))     ||
                    value.Equals(typeof(byte))      ||
                    value.Equals(typeof(short))     ||
                    value.Equals(typeof(ushort))    ||
                    value.Equals(typeof(uint))      ||
                    value.Equals(typeof(long))      ||
                    value.Equals(typeof(ulong))     ||
                    value.Equals(typeof(decimal));
        }

        /// <summary>
        /// Updates the values of all public properties of this object with the corresponding properties' values 
        /// from sourceObj. 
        /// </summary>
        /// <typeparam name="T">Class type of the source and destination object.</typeparam>
        /// <param name="destObj">Object whose properies are to be updated.</param>
        /// <param name="sourceObj">Object to take properties' values from.</param>
        public static void UpdateFrom<T>(this T destObj, T sourceObj)
            where T : class
        {
            UpdateFrom<T>
            (
                destObj, 
                sourceObj,
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty
            );
        }

        /// <summary>
        /// Updates the values of all matched properties of this object with the corresponding properties' values
        /// from sourceObj.
        /// </summary>
        /// <typeparam name="T">Class type of the source and destination object.</typeparam>
        /// <param name="destObj">Object whose properies are to be updated.</param>
        /// <param name="sourceObj">Object to take properties' values from.</param>
        /// <param name="bindingAttr">A bitmask comprising of one of more BindingFlags that 
        /// specify how the search is to be conducted.</param>
        public static void UpdateFrom<T>(this T destObj, T sourceObj, BindingFlags bindingAttr)
            where T : class
        {
            PropertyInfo[] srcFields = sourceObj.GetType()
                                                .GetProperties(bindingAttr);

            PropertyInfo[] dstFields = destObj.GetType()
                                              .GetProperties(bindingAttr);

            foreach (var srcProperty in srcFields)
            {
                var dstProperty = dstFields.FirstOrDefault(p => p.Name == srcProperty.Name);
                if (dstProperty != null && dstProperty.CanWrite)
                {
                    dstProperty.SetValue
                    (
                        destObj,
                        srcProperty.GetValue(sourceObj, null),
                        null
                    );
                }
            }

        }

        /// <summary>
        /// Checks to see if this object is not in the inheritance tree of type param T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNotA<T>(this object obj)
        {
            return !(obj is T);
        }
    }

    public static class Maths
    {
        public static bool RoughEquals(this double a, double b, double s = 1e-6)
        {
            return Math.Abs(a - b) < s;
        }

        public static bool RoughEquals(this int a, double b, double s = 1e-6)
        {
            return Math.Abs(a - b) < s;
        }

        public static bool RoughEquals(this double a, int b, double s = 1e-6)
        {
            return Maths.RoughEquals(b, a, s);
        }

        public static bool RoughEquals(this long a, double b, double s = 1e-6)
        {
            return Math.Abs(a - b) < s;
        }

        public static bool RoughEquals(this double a, long b, double s = 1e-6)
        {
            return Maths.RoughEquals(b, a, s);
        }

        public static bool RoughEquals(this float a, double b, double s = 1e-6)
        {
            return Math.Abs(a - b) < s;
        }

        public static bool RoughEquals(this double a, float b, double s = 1e-6)
        {
            return Maths.RoughEquals(b, a, s);
        }
        
        public static bool RoughEquals(this float a, float b, double s = 1e-6)
        {
            return Math.Abs(a - b) < s;
        }

        public static bool RoughEquals(this float? a, float? b, double s = 1e-6)
        {
            if (a == null || b == null) return a == null && b == null;

            return RoughEquals((float) a, (float) b, s);
        }

        public static bool RoughEquals(this float? a, double? b, double s = 1e-6)
        {
            if (a == null || b == null) return a == null && b == null;
            
            return RoughEquals((float) a, (double) b, s);
        }

        public static bool RoughEquals(this double? a, float? b, double s = 1e-6)
        {
            if (a == null || b == null) return a == null && b == null;
            
            return RoughEquals((double) a, (float) b, s);
        }

        // Courtesy of Kay Zed from StackOverflow: http://stackoverflow.com/a/32903747/344541
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="marginOfError"></param>
        /// <returns></returns>
        public static Fraction RealToFraction(double value, double marginOfError)
        {
            if (marginOfError <= 0.0 || marginOfError >= 1.0)
            {
                throw new ArgumentOutOfRangeException(nameof(marginOfError), "Must be between 0 and 1 (exclusive).");
            }

            int sign = Math.Sign(value);

            if (sign == -1)
            {
                value = Math.Abs(value);
            }

            if (sign != 0)
            {
                // marginOfError is the maximum relative marginOfError; convert to absolute
                marginOfError *= value;
            }

            int n = (int) Math.Floor(value);
            value -= n;

            if (value < marginOfError)
            {
                return new Fraction(sign * n, 1);
            }

            if (1 - marginOfError < value)
            {
                return new Fraction(sign * (n + 1), 1);
            }

            // The lower fraction is 0/1
            int lowerN = 0;
            int lowerD = 1;

            // The upper fraction is 1/1
            int upperN = 1;
            int upperD = 1;

            while (true)
            {
                // The middle fraction is (lower_n + upper_n) / (lower_d + upper_d)
                int middleN = lowerN + upperN;
                int middleD = lowerD + upperD;

                if (middleD * (value + marginOfError) < middleN)
                {
                    // real + marginOfError < middle : middle is our new upper
                    upperN = middleN;
                    upperD = middleD;
                }
                else if (middleN < (value - marginOfError) * middleD)
                {
                    // middle < real - marginOfError : middle is our new lower
                    lowerN = middleN;
                    lowerD = middleD;
                }
                else
                {
                    // Middle is our best fraction
                    return new Fraction((n * middleD + middleN) * sign, middleD);
                }
            }
        }
    }

    /// <summary>
    /// Simple struct for storing a fractional representation of a number.
    /// </summary>
    public struct Fraction
    {
        /// <summary>
        /// 
        /// </summary>
        public int Numerator   { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public int Denominator { get; private set; }
        /// <summary>
        /// The Whole (integer) part of a mixed fraction.
        /// </summary>
        public int WholePart   { get; private set; }

        /// <summary>
        /// Constructs a new fraction struct from an integer numerator and denominator.
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        public Fraction(int numerator, int denominator)
        {
            if (numerator > denominator)
            {
                WholePart   = (int)Math.Floor((double)numerator / denominator);
                Numerator   = numerator - (denominator * WholePart);
                Denominator = denominator;
            }
            else
            {
                WholePart   = 0;
                Numerator   = numerator;
                Denominator = denominator;
            }
        }

        /// <summary>
        /// Converts to a human-readable string.
        /// </summary>
        /// <returns>A string of the form 'Numerator/Denominator'.</returns>
        public override string ToString()
        {
            if (WholePart == 0)
                return $"{Numerator}/{Denominator}";
            else
                return $"{WholePart} {Numerator}/{Denominator}";
        }
    }

    public static class BitConverterEx
    {
        /// <summary>
        /// Converts a decimal value to an array of bytes.
        /// </summary>
        public static byte[] GetBytes(decimal value)
        {
            int[] bits = decimal.GetBits(value);

            List<byte> bytes = new List<byte>();

            foreach(int i in bits)
            {
                bytes.AddRange(BitConverter.GetBytes(i));
            }

            return bytes.ToArray();
        }

        public static decimal ToDecimal(byte[] bytes)
        {
            if (bytes.Count() != 16)
                throw new Exception("A decimal must be created from exactly 16 bytes");

            int[] bits = new Int32[4];
            for (int i = 0; i <= 15; i += 4)
            {
                bits[i / 4] = BitConverter.ToInt32(bytes, i);
            }

            return new decimal(bits);
        }
    }

    public static class Arrays
    {
        public static void ForEach(this Array array, Action<Array, int[]> action)
        {
            if (array.LongLength == 0) return;
            ArrayTraverse walker = new ArrayTraverse(array);
            do action(array, walker.Position);
            while (walker.Step());
        }

        public static T[] Slice<T> (this T[] source, int start, int end)
        {
            if (end < 0)
                end = source.Length + end;

            int len = end - start;

            T[] res = new T[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = source[i + start];
            }

            return res;
        }
    }

    internal class ArrayTraverse
    {
        public  int[] Position;
        private int[] maxLengths;

        public ArrayTraverse(Array array)
        {
            maxLengths = new int[array.Rank];
            for (int i = 0; i < array.Rank; ++i)
            {
                maxLengths[i] = array.GetLength(i) - 1;
            }
            Position = new int[array.Rank];
        }

        public bool Step()
        {
            for (int i = 0; i < Position.Length; ++i)
            {
                if (Position[i] < maxLengths[i])
                {
                    Position[i]++;
                    for (int j = 0; j < i; j++)
                    {
                        Position[j] = 0;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}

// TODO Split this up into multiple files like I should have done from the fucking beginning.