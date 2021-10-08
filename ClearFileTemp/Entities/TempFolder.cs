using System.IO;
using System.Collections.Generic;

namespace ClearFileTemp.Entities
{
    class TempFolder
    {
        private DirectoryInfo _dirInfo;
        private IEnumerable<FileSystemInfo> _paths;

        public TempFolder(string pathFolder)
        {
            EnumerationOptions enumOp = new EnumerationOptions();
            enumOp.AttributesToSkip = FileAttributes.Temporary;
            
            _dirInfo = new DirectoryInfo(pathFolder);
            //_paths = _dirInfo.EnumerateFileSystemInfos("*", SearchOption.TopDirectoryOnly);
            _paths = _dirInfo.EnumerateFileSystemInfos("*", enumOp);
        }

        public void DeleteItems(FileSystemInfo p)
        {
            NotFoundPath();
            IsEmpty();
            p.Delete();
        }

        public IEnumerable<FileSystemInfo> GetItems()
        {
            return _paths;
        }
        public string GetFullPath()
        {
            return _dirInfo.FullName;
        }

        public bool IsFolderEmpty()
        {
            return _dirInfo.GetFiles().Length == 0 && _dirInfo.GetDirectories().Length == 0;
        }
        public void NotFoundPath()
        {
            if (!_dirInfo.Exists)
            {
                throw new DirectoryNotFoundException($"Este path({_dirInfo.FullName}) não existe!");
            }
        }
        public void IsEmpty()
        {
            if (IsFolderEmpty())
            {
                throw new IOException("Esta pasta está vazia!");
            }
        }
    }
}
