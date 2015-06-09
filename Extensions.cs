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
    }

    public static class Sizes
    {
        public static bool WidthIsLongEdge(this System.Drawing.Size size)
        {
            return (size.Width > size.Height) ? true : false;
        }

        public static bool WidthIsLongEdge(this System.Windows.Size size)
        {
            return (size.Width > size.Height) ? true : false;
        }
        
        public static double AspectRatio(this System.Windows.Size size)
        {
            return ((double)size.Width / (double)size.Height);
        }

        public static double AspectRatio(this System.Drawing.Size size)
        {
            return ((double)size.Width / (double)size.Height);
        }
        
        /// <returns>
        /// Returns the length of the longest edge of this size.
        /// </returns>
        public static double LongEdge(this System.Windows.Size size)
        {
            return (size.WidthIsLongEdge()) ? size.Width : size.Height;
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
            int a_area = a.Width * a.Height;
            int b_area = b.Width * b.Height;

            if (a_area > b_area)
                return 1;
            else if (a_area == b_area)
                return 0;
            else
                return -1;
        }
        public static int CompareAreaTo(this System.Windows.Size a, System.Windows.Size b)
        {
            double a_area = a.Width * a.Height;
            double b_area = b.Width * b.Height;

            if (a_area > b_area)
                return 1;
            else if (a_area == b_area)
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

        /// <returns>Returns true if the Width of this Rect is greater than its height.</returns>
        public static bool IsHorizontal(this System.Windows.Rect rect)
        {
            if (rect.Width > rect.Height)   return true;
            else                            return false;
        }

        /// <returns>Returns true if the Height of this Rectangle is greater than its width.</returns>
        public static bool IsVertical(this Rectangle rect)
        {
            return !IsHorizontal(rect);
        }

        /// <returns>Returns true if the Height of this Rect is greater than its width.</returns>
        public static bool IsVertical(this System.Windows.Rect rect)
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

        /// <returns>Returns a point representing the center of this Rect.</returns>
        public static System.Windows.Point GetCenter(this System.Windows.Rect rect)
        {
            return new System.Windows.Point
            (
                rect.Width / 2d,
                rect.Height / 2d
            );
        }
        
        /// <summary>
        /// Compares the area of this rectangle to another. 
        /// </summary>
        public static int CompareAreaTo(this Rectangle a, Rectangle b)
        {
            return a.Size.CompareAreaTo(b.Size);
        }

        /// <summary>
        /// Compares the area of this rectangle to another. 
        /// </summary>
        public static int CompareAreaTo(this System.Windows.Rect a, System.Windows.Rect b)
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

    public static class Bitmaps
    {
        /// <summary>
        /// Returns the length of the longest edge of this image, in pixels.
        /// </summary>
        public static int LongEdge(this Bitmap image)
        {
            return (image.Width > image.Height) ? image.Width : image.Height;
        }

        /// <summary>
        /// Creates a copy of this Bitmap and resizes it.
        /// Does not presevce aspect ratio, or performs any translations.
        /// </summary>
        /// <param name="newSize">The target size to scale the new Bitmap to.</param>
        /// <returns>Resized copy of this Bitmap.</returns>
        public static Bitmap Resize(this Bitmap image, Size newSize)
        {
            if (image.Size.Equals(newSize))
                return image;

            return new Bitmap(image, newSize);
        }

        /// <summary>
        /// Creates a copy of this Bitmap and resizes it.
        /// Preserves the original aspect ratio while resizing and cropping
        /// to fill the target size.
        /// </summary>
        /// <param name="targetSize">
        /// The target size to scale the new bitmap to.
        /// The resulting bitmap will fill the entire area of targetSize.
        /// </param>
        /// <returns>Resized copy of this Bitmap</returns>
        public static Bitmap ResizeFill(this Bitmap image, Size targetSize)
        {
            if (image.Size.Equals(targetSize))
                return image;

            Size scaleFitWidth  = Bitmaps.FitWidthSize(image.Size, targetSize);
            Size scaleFitHeight = Bitmaps.FitHeightSize(image.Size, targetSize);

            Bitmap scaled;

            //
            // Scale to...
            // Try to fit width
            if (targetSize.Width > targetSize.Height)
            {
                // Make sure the scaled dimensions are tall enough
                if (!(scaleFitWidth.Height < targetSize.Height))
                    scaled = new Bitmap(image, scaleFitWidth);
                else
                    scaled = new Bitmap(image, scaleFitHeight);
            }
            // Try to fit height
            else
            {
                // Make sure the scaled dimensions are wide enough
                if (!(scaleFitHeight.Width < targetSize.Width))
                    scaled = new Bitmap(image, scaleFitHeight);
                else
                    scaled = new Bitmap(image, scaleFitWidth);
            }

            //
            // Crop to fit targetSize if neccessary
            Bitmap final = (scaled.Size.Equals(targetSize)) ? (Bitmap)scaled.Clone() : scaled.CropCenteredFill(targetSize);
            scaled.Dispose();

            return final;
        }

        /// <summary>
        /// Resizes the Bitmap so the longest edge matches targetLength.
        /// </summary>
        /// <param name="targetLength">The length, in pixels, of the longest side after resize.</param>
        /// <returns>Copy of this Bitmap resized to fit the longest edge inside targetLength.</returns>
        public static Bitmap ResizeToLongEdge(this Bitmap image, double targetLength)
        {
            if (image.Size.WidthIsLongEdge()) // make sure resizing is neccessary
            {
                if (image.Width == targetLength) return image;
            }
            else
            {
                if (image.Height == targetLength) return image;
            }

            return image.ResizeFill(
                         FitLongEdgeSize(image.Size, targetLength));
        }

        /// <summary>
        /// Resizes the Bitmap so the longest edge matches targetLength.
        /// </summary>
        /// <param name="targetLength">The length, in pixels, of the longest side after resize.</param>
        /// <returns>Copy of this Bitmap resized to fit the longest edge inside targetLength.</returns>
        public static Bitmap ResizeToLongEdge(this Bitmap image, int targetLength)
        {
            return ResizeToLongEdge(image, (double)targetLength);
        }

        /// <summary>
        /// Resizes the Bitmap so the longest edge matches targetLength.
        /// </summary>
        /// <param name="targetLength">The length, in pixels, of the longest side after resize.</param>
        /// <returns>Copy of this Bitmap resized to fit the longest edge inside targetLength.</returns>
        public static Bitmap ResizeToLongEdge(this Bitmap image, float targetLength)
        {
            return ResizeToLongEdge(image, (double)targetLength);
        }

        /// <summary>
        /// Creates a copy of this Bitmap, cropped and centered to fill as much of
        /// targetDimensions as possible.
        /// Does not perform any scaling.
        /// </summary>
        /// <param name="targetDimensions">The target size to crop the copied Bitmap to.</param>
        /// <returns>Cropped copy of this Bitmap.</returns>
        public static Bitmap CropCenteredFill(this Bitmap image, Size targetDimensions)
        {
            return image.Clone
                (
                    GetCropBoundsCentered(image, targetDimensions),
                    image.PixelFormat
                );
        }

        /// <summary>
        /// Creates a copy of the specified portion of this bitmap.
        /// </summary>
        /// <param name="cropArea">Rectangle specifying the desired portion of the bitmap</param>
        /// <returns>A new bitmap created from the area of this bitmap specified
        /// by the cropArea Rectangle.</returns>
        public static Bitmap Slice(this Bitmap image, Rectangle cropArea)
        {
            return image.Clone
                (
                    cropArea,
                    image.PixelFormat
                );
        }


        /// <summary>
        /// Calculates the bounds of a rectangle representing the selection to crop to
        /// in order to center the image inside the target size.
        /// </summary>
        /// <param name="targetSize"></param>
        /// <returns>
        /// Rectangle located at the point to start cropping, with the width and height of 
        /// the crop area.
        /// </returns>
        public static Rectangle GetCenteredCropBounds(this Bitmap image, Size targetSize)
        {
            return GetCropBoundsCentered(image, targetSize);
        }

        /// <summary>
        /// Uses a stream to open the file at the specified path, while allowing reads and writes
        /// to occur from other proccesses. Creates a copy of the image, and returns it as a Bitmap.
        /// </summary>
        /// <param name="path">Full path to the image file being loaded.</param>
        /// <returns>Bitmap copied from the bytes read from the image file at the specified path.</returns>
        public static Bitmap FromFile(string path)
        {
            using (Stream fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var buffer = IO.Streams.ReadFully(fileStream);
                var memory_stream = new MemoryStream(buffer);
                var image = System.Drawing.Image.FromStream(memory_stream);

                return (Bitmap)image;
            }
        }

        private static Rectangle GetCropBoundsCentered(Rectangle imageBounds, Rectangle targetBounds)
        {
            if (imageBounds.CompareAreaTo(targetBounds) < 0)
                throw new ArgumentOutOfRangeException("imageBounds is smaller than the targetBounds.");
            else if (imageBounds.CompareAreaTo(targetBounds) == 0)
                return imageBounds;

            Extender.Drawing.Offset offset = new Extender.Drawing.Offset(imageBounds, targetBounds);

            return new Rectangle
                (
                    imageBounds.X + offset.HalfX,
                    imageBounds.Y + offset.HalfY,
                    targetBounds.Width,
                    targetBounds.Height
                );
        }

        private static Rectangle GetCropBoundsCentered(Bitmap image, Size targetSize)
        {
            return GetCropBoundsCentered
                (
                    new Rectangle(0, 0, image.Width, image.Height),
                    new Rectangle(0, 0, targetSize.Width, targetSize.Height)
                );
        }

        private static Size FitWidthSize(Size imageSize, Size targetSize)
        {
            float multiplier = ((float)targetSize.Width) / ((float)imageSize.Width);

            return new Size
                (
                    targetSize.Width,
                    (int)(Math.Round(imageSize.Height * multiplier))
                );
        }

        private static Size FitHeightSize(Size imageSize, Size targetSize)
        {
            float multiplier = ((float)targetSize.Height) / ((float)imageSize.Height);

            return new Size
                (
                    (int)Math.Round(imageSize.Width * multiplier),
                    targetSize.Height
                );
        }

        private static Size FitLongEdgeSize(Size imageSize, double targetLength)
        {
            if(imageSize.AspectRatio() >= 0)
            {
                // Width is longer than height
                double multiplier = ((double)targetLength / (double)imageSize.Width);

                return new Size
                (
                    (int)Math.Round(targetLength),
                    (int)Math.Round(imageSize.Height * multiplier)
                );
            }
            else
            {
                // Height is longer than width
                double multiplier = ((double)targetLength / (double)imageSize.Height);

                return new Size
                (
                    (int)Math.Round(imageSize.Width * multiplier),
                    (int)Math.Round(targetLength)
                );
            }
        }
    }

    public static class Images
    {
        /// <summary>
        /// Gets this image's ImageFormat through brute force comparisons.
        /// </summary>
        /// <returns>The ImageFormat for this image.</returns>
        public static System.Drawing.Imaging.ImageFormat GetImageFormat(this System.Drawing.Image img)
        {
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                return System.Drawing.Imaging.ImageFormat.Jpeg;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                return System.Drawing.Imaging.ImageFormat.Bmp;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                return System.Drawing.Imaging.ImageFormat.Png;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Emf))
                return System.Drawing.Imaging.ImageFormat.Emf;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Exif))
                return System.Drawing.Imaging.ImageFormat.Exif;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                return System.Drawing.Imaging.ImageFormat.Gif;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Icon))
                return System.Drawing.Imaging.ImageFormat.Icon;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp))
                return System.Drawing.Imaging.ImageFormat.MemoryBmp;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
                return System.Drawing.Imaging.ImageFormat.Tiff;
            else
                return System.Drawing.Imaging.ImageFormat.Wmf;    
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

    // Most of Objects, Arrays, and ArrayTraverse classes are from of Alexey Burtsev from StackOverflow
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
    }

    public static class Maths
    {
        public static bool RoughEquals(this double a, double b, double sigma)
        {
            return Math.Abs(a - b) < sigma;
        }

        public static bool RoughEquals(this int a, double b, double sigma)
        {
            return Math.Abs(a - b) < sigma;
        }

        public static bool RoughEquals(this double a, int b, double sigma)
        {
            return Maths.RoughEquals(b, a, sigma);
        }

        public static bool RoughEquals(this long a, double b, double sigma)
        {
            return Math.Abs(a - b) < sigma;
        }

        public static bool RoughEquals(this double a, long b, double sigma)
        {
            return Maths.RoughEquals(b, a, sigma);
        }

        public static bool RoughEquals(this float a, double b, double sigma)
        {
            return Math.Abs(a - b) < sigma;
        }

        public static bool RoughEquals(this double a, float b, double sigma)
        {
            return Maths.RoughEquals(b, a, sigma);
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
        public int[] Position;
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
