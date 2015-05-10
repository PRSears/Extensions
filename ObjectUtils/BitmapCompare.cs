using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Extender.ObjectUtils
{
    public static class BitmapCompare
    {

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int memcmp(IntPtr b1, IntPtr b2, long count);

        // From Erik Forbes on StackOverflow: https://stackoverflow.com/questions/2031217/what-is-the-fastest-way-i-can-compare-two-equal-size-bitmaps-to-determine-whethe
        public static bool CompareWithMemCmp(Bitmap b1, Bitmap b2)
        {
            if ((b1 == null) != (b2 == null)) return false;
            if (b1.Size != b2.Size) return false;

            var bmp1Data = b1.LockBits(new Rectangle(new Point(0, 0), b1.Size), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var bmp2Data = b2.LockBits(new Rectangle(new Point(0, 0), b2.Size), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            try
            {
                IntPtr bmp1Scan0 = bmp1Data.Scan0;
                IntPtr bmp2Scan0 = bmp2Data.Scan0;

                int stride = bmp1Data.Stride;
                int len = stride * b1.Height;

                return memcmp(bmp1Scan0, bmp2Scan0, len) == 0;
            }
            finally
            {
                b1.UnlockBits(bmp1Data);
                b2.UnlockBits(bmp2Data);
            }
        }
    }
}
