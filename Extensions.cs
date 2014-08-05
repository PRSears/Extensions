using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string ext = Path.GetExtension(path);
            
            return string.Format("{0}{1}{2}",
                Path.GetFileNameWithoutExtension(path),
                insertionString,
                ext);
        }

        public static string EscapeForHTML(this string text)
        {
            return text.Replace(@"&", @"&amp;")
                       .Replace(@"""", @"&#34;")
                       .Replace(@"<", @"&lt;")
                       .Replace(@">", @"&gt;")
                       .Replace(@"!", @"&#33;");
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
        public static bool IsHorizontal(this Rectangle rect)
        {
            if (rect.Width > rect.Height)   return true;
            else                            return false;
        }

        public static bool IsVertical(this Rectangle rect)
        {
            return !IsHorizontal(rect);
        }

        public static Point GetCenter(this Rectangle rect)
        {
            return new Point
                    (
                        (int)Math.Round(rect.Width / 2d),
                        (int)Math.Round(rect.Height / 2d)
                    );
        }

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

    public static class Bitmaps
    {
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
        /// Removes all items in a collection based on a predicate.
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
    }
}
