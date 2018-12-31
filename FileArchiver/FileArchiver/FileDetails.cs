using System;
using System.IO;
namespace FileArchiver
{
    internal class FileDetails
    {
        public string Name { get; private set; }
        public DateTime CreationTime { get; private set; }
        public string FullName { get; private set; }
        public string extension { get; private set; }

        public FileDetails(FileInfo file)
        {
            Name = file.Name;
            CreationTime = file.CreationTime;
            FullName = file.FullName;
            extension = file.Extension;
        }
    }
}