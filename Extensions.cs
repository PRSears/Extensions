﻿using System;
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
        public static int CompareAreaTo(this Size a, Size b)
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
    }

    public static class Rectangles
    {
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
    {/// <summary>
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

            Size scaleFitWidth = Bitmaps.FitWidthSize(image.Size, targetSize);
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
            Bitmap final = (scaled.Size.Equals(targetSize)) ? scaled : scaled.CropCenteredFill(targetSize);
            scaled.Dispose();

            return final;
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
}