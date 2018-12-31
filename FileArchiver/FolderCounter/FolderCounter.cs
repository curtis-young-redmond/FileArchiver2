using System;
using System.Linq;
using System.IO;

namespace FolderCounter
{
    class FolderCounter
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter top folder for statistics count of files");
            var RootFolder = Console.ReadLine();
            DirSearch(RootFolder);
            Console.WriteLine("Done: press any key");
            Console.ReadKey();

        }

        private static void DirSearch(string RootFolder)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(RootFolder))
                {
                    Console.Write(d);
                    Console.Write(" ");
                    //Console.WriteLine(Directory.GetFiles(d).Length);

                    var fileCount = (from file in Directory.EnumerateFiles(d,"*.*", SearchOption.TopDirectoryOnly)
                                     select file).Count();
                    Console.WriteLine(fileCount);
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
    }
}
