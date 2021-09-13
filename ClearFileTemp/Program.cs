using System;
using System.IO;
using ClearFileTemp.Entities;

namespace ClearFileTemp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sysPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);

                // temp folder of system and local
                string localTempPath = Path.GetTempPath();
                string sysPrefetchPath = sysPath + @"\Prefetch";
                string sysTempPath = sysPath + @"\Temp";

                FilesAndFolders fifoLocalTemp = new FilesAndFolders(localTempPath);
                FilesAndFolders fifoSysPrefetch = new FilesAndFolders(sysPrefetchPath);
                FilesAndFolders fifoSysTemp = new FilesAndFolders(sysTempPath);

                Console.WriteLine("Info: Esta aplicação foi feita para limpeza de arquivos e pastas temporários.");
                Console.WriteLine("As seguintes pastas serão limpas:");
                Console.WriteLine();
                Console.WriteLine($"[ {localTempPath} ]\n[ {sysPrefetchPath} ]\n[ {sysTempPath} ]");
                Console.WriteLine();

                while (true)
                {
                    Console.WriteLine("Deseja continuar com processo? (y/n): ");
                    char op = char.Parse(Console.ReadLine());
                    if (op == 'y' || op == 'Y')
                    {
                        Console.WriteLine("".PadRight(Console.WindowWidth, '-') + " ");
                        Console.Write("]".PadRight(10, '*'));
                        Console.Write("> " + localTempPath.ToUpper() + " <");
                        Console.WriteLine("".PadLeft(10, '*') + "[");
                        Console.WriteLine();
                        fifoLocalTemp.DeleteAllPath();

                        Console.WriteLine("".PadRight(Console.WindowWidth, '-') + " ");
                        Console.Write("]".PadRight(10, '*'));
                        Console.Write("> " + localTempPath.ToUpper() + " <");
                        Console.WriteLine("".PadLeft(10, '*') + "[");
                        Console.WriteLine();
                        fifoSysPrefetch.DeleteAllPath();
                        Console.WriteLine("".PadRight(Console.WindowWidth, '-') + " ");

                        Console.Write("]".PadRight(10, '*'));
                        Console.Write("> " + localTempPath.ToUpper() + " <");
                        Console.WriteLine("".PadLeft(10, '*') + "[");
                        Console.WriteLine();
                        fifoSysTemp.DeleteAllPath();
                        Console.WriteLine("".PadRight(Console.WindowWidth, '-') + " ");
                        Console.WriteLine("Processo concluido com sucesso!".ToUpper());
                        Console.WriteLine("FIM DA EXECUÇÃO!");
                        Console.ReadLine();

                        break;
                    }
                    else if (op == 'n' || op == 'N')
                    {
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida!");
                        continue;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
