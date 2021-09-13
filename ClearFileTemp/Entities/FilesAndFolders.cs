using System;
using System.IO;
using System.Collections.Generic;

namespace ClearFileTemp.Entities
{
    class FilesAndFolders
    {
        public string PathFolder { get; set; }
        private IEnumerable<string> _paths;

        public FilesAndFolders(string pathFolder)
        {
            PathFolder = pathFolder;
            _paths = Directory.EnumerateFileSystemEntries(pathFolder, "*", SearchOption.TopDirectoryOnly);
        }

        public void DeleteAllPath()
        {
            NotFoundPath();
            if (!IsFolderEmpty())
            {
                foreach (string p in _paths)
                {
                    if (Directory.Exists(p))
                    {
                        try
                        {
                            Directory.Delete(p, true);
                            Console.WriteLine("Deletado: " + p);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Error ao deletar este Pasta!");
                            Console.WriteLine("Caminho: " + p);
                            Console.WriteLine($"Error ao deletar: {e.Message}");
                            Console.WriteLine();
                            continue;
                        }
                    }
                    else
                    {
                        try
                        {
                            File.Delete(p);
                            Console.WriteLine("Deletado: " + p);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Error ao deletar este arquivo!");
                            Console.WriteLine("Caminho: " + p);
                            Console.WriteLine($"Error: {e.Message}");
                            Console.WriteLine();
                            continue;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"Pasta Vazia path({PathFolder})");
            }
        }

        public void NotFoundPath()
        {
            if (!Directory.Exists(PathFolder))
            {
                throw new DirectoryNotFoundException($"Este path({PathFolder}) não existe!");
            }
        }

        public bool IsFolderEmpty()
        {
            DirectoryInfo dirInf = new DirectoryInfo(PathFolder);
            return dirInf.GetFiles().Length == 0 && dirInf.GetDirectories().Length == 0;
        }
    }
}
