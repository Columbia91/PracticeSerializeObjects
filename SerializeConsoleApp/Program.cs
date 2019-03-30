using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib;

namespace SerializeConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            PC first = new PC("Delux", "CB08273383", "Intel Pentium");
            PC second = new PC("HP", "WVG1L97JIOX1", "AMD");
            PC third = new PC("Dell", "004RMRH5Y182", "Intel Celeron");
            PC fourth = new PC("Lenovo", "604PNJC1S548", "Xeon");

            List<PC> pcList = new List<PC>
            {
                first, second, third, fourth
            };

            DriveInfo[] drives = DriveInfo.GetDrives();

            bool check = false;
            int number = 0;
            while (!check)
            {
                Console.Clear();
                for (int i = 0; i < drives.Length; i++)
                {
                    if (drives[i].IsReady)
                        Console.WriteLine($"{i}.{drives[i].Name}");
                }
                Console.Write("Выберите диск в котором хотите создать файл, написав его букву: ");
                string letter = Console.ReadLine();

                for (int i = 0; i < drives.Length; i++)
                {
                    if (drives[i].IsReady)
                        if (drives[i].Name.ToLower().Contains(letter))
                        {
                            number = i;
                            check = true;
                            break;
                        }
                }
                if (!check)
                {
                    Console.Write("Вы выбрали не существующий диск. Нажмите Enter чтобы ввести заново...");
                    Console.ReadLine();
                }

            }
            string path = drives[number].Name;
            Console.WriteLine("Выбран диск {0}", path);

            foreach (var directory in drives[number].RootDirectory.EnumerateDirectories())
            {
                Console.WriteLine($"Папка {directory}");
            }

            Console.Write("Укажите папку, в которую хотите сохранить данные: ");
            var directoryName = Console.ReadLine();
            path += directoryName;

            Console.Clear();
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            path += @"\" + "listSerial.txt";
            if(File.Exists(path))
                Console.WriteLine("Файл был перезаписан!");

            using(BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (var pc in pcList)
                {
                    writer.Write(pc.Brand);
                    writer.Write(pc.SerialNumber);
                    writer.Write(pc.CPU);
                }
            }

            Console.WriteLine("\nДесериализация:");
            List<PC> newPcList = new List<PC>();

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                for (int i = 0; reader.PeekChar() > -1; i++)
                {
                    PC pc = new PC();
                    pc.Brand = reader.ReadString();
                    pc.SerialNumber = reader.ReadString();
                    pc.CPU = reader.ReadString();

                    newPcList.Add(pc);
                }
            }

            foreach (var pc in newPcList)
            {
                Console.WriteLine($"{pc.Brand} {pc.SerialNumber} {pc.CPU}");
            }
            
            Console.ReadLine();
        }
    }
}       