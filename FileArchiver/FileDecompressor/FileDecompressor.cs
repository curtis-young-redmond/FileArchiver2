using System;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Globalization;

namespace FileDecompressor
{
    class FileDecompressor
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter Full UNC Folder path for .gz files to decompress");
            var path = Console.ReadLine();
            foreach (var file in Directory.GetFiles(path, "*.gz"))
            {
                DeCompressMyFile(file);
                File.Delete(file);
            }
            foreach (var file in Directory.GetFiles(path, "*.csv"))
            {
                SetFileDate(file);
            }
        }
        private static void SetFileDate(string file)
        {
            Regex dx = new Regex(@"_[1-2][0-1][0-9][0-9][0-1][0-9][0-3][0-9]_");
            Regex tx = new Regex(@"_[0-2][0-9][0-9][0-9][0-5][0-9]\.");
            var datenumber = dx.Match(file).Value.Substring(1, 8);
            var timenumber = tx.Match(file).Value.Substring(1, 6);
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "yyyyMMddHHmmss";
            DateTime mydate = DateTime.ParseExact(datenumber + timenumber, format, provider);
            File.SetCreationTime(file, mydate);
            File.SetLastAccessTime(file, mydate);
        }
        private static Boolean DeCompressMyFile(string fullname)
        {
            FileInfo info = null;
            FileInfo fileToDeCompress = new FileInfo(fullname);
            var getOriginalFilearray = fileToDeCompress.FullName.Split('.');
            string OriginalFileName = null;
            foreach (var myfile in getOriginalFilearray)
                if (myfile != "gz")
                    OriginalFileName += "." + myfile;
            OriginalFileName = OriginalFileName.Substring(1);

            using (FileStream originalFileStream = fileToDeCompress.OpenRead())
            {
                if ((File.GetAttributes(fileToDeCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    using (FileStream compressedFileStream = File.Create(OriginalFileName))
                    {
                        using (GZipStream mydecompressionStream = new GZipStream(originalFileStream,
                           CompressionMode.Decompress))
                        {
                            mydecompressionStream.CopyTo(compressedFileStream);
                        }
                    }

                    info = new FileInfo(fileToDeCompress.FullName);
                    Console.WriteLine("DeCompressed {0} from {1} to {2} bytes.",
                    fileToDeCompress.Name, fileToDeCompress.Length.ToString(), info.Length.ToString());
                }
                if (info == null)
                    return false;
                else
                    return true;
            }
        }
    }
}
