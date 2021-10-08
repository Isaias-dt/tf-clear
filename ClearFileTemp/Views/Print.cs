using System;
using System.Collections.Generic;
using System.IO;
using ClearFileTemp.Entities;

namespace ClearFileTemp.Views
{
    class Print
    {
        private List<TempFolder> _list = new List<TempFolder>();

        public void AddPath(TempFolder path)
        {
            _list.Add(path);
        }

        public void Remove(TempFolder path)
        {
            _list.Remove(path);
        }
        public int ToContinueWithProcess(char op)
        {
            if (op == 'y' || op == 'Y')
            {
                return 1;
            }
            else if (op == 'n' || op == 'N')
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        public void Show()
        {
            Console.Title = "ClearFileTemp";
            Console.WriteLine("Info: Esta aplicação foi feita para limpeza de arquivos e pastas temporários.");
            Console.WriteLine("As Seguintes pastas serão limpas:");
            Console.WriteLine();
            foreach (TempFolder tf in _list)
            {
                Console.WriteLine($"[ {tf.GetFullPath()} ]");
            }
            Console.WriteLine();
            Console.Write("Deseja continuar? (y/n): ");
            char op = char.Parse(Console.ReadLine());
            if (ToContinueWithProcess(op) == 1)
            {
                AllDelete();
                Console.WriteLine("\nProcesso concluido com sucesso!");
            }
            else
            {
                Console.WriteLine("O processo de deletação não foi inicializado!");
            }
            Console.ReadLine();
        }

        public void ShowHeading(TempFolder tf)
        {
            Console.WriteLine();
            Console.WriteLine("".PadRight(Console.WindowWidth, '-') + " ");
            Console.Write("]".PadRight(10, '*'));
            Console.Write("> " + tf.GetFullPath().ToUpper() + " <");
            Console.WriteLine("".PadLeft(10, '*') + "[");
            Console.WriteLine();
        }

        public void ShowDeletionError(FileSystemInfo p, Exception e)
        {
            Console.WriteLine($"ERROR: " + p.FullName);
            Console.WriteLine($"Error ao deletar: {e.Message}");
        } 

        public void AllDelete()
        {
            foreach (TempFolder tf in _list)
            {
                ShowHeading(tf);
                foreach (FileSystemInfo p in tf.GetItems())
                {
                    try
                    {
                        tf.DeleteItems(p);
                        Console.WriteLine("Deletado: " + p.FullName);
                    }
                    catch (Exception e)
                    {
                        ShowDeletionError(p, e);
                        continue;
                    }
                }
            }
        }
    }
}
