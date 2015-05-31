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

        public static bool IsFileInUse(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            return false;
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
