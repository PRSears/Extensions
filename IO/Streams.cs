using System.IO;

namespace Extender.IO
{
    public class Streams
    {
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using(MemoryStream ms = new MemoryStream())
            {
                int read;
                while((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);

                return ms.ToArray();
            }
        }

        [System.Obsolete]
        public FileStream TryOpenRead(string pathToFile)
        {
            if (!File.Exists(pathToFile)) return null;

            return new FileStream
            (
                pathToFile,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite
            );
        }
    }
}
