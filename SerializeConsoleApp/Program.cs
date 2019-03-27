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
        public static string path;
        //public static List<PC> pcList;
        static void Main(string[] args)
        {
            PC first = new PC("Delux", "CB08273383", "Intel Pentium");
            PC second = new PC("HP", "WVG1L97JIOX1", "AMD");
            PC third = new PC("Dell", "004RMRH5Y182", "Intel Celeron");
            PC fourth = new PC("Lenovo", "604PNJC1S548", "Xeon");

            List<PC> pcList = new List<PC>();
            pcList.Add(first); pcList.Add(second);
            pcList.Add(third); pcList.Add(fourth);

            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                if(drives[i].IsReady)
                    Console.WriteLine($"{i}.{drives[i].Name}");
            }
            Console.Write("Выберите диск в котором хотите создать файл, написав его порядковый номер: ");
            int number = int.Parse(Console.ReadLine());

            path = drives[number].Name;
            Console.WriteLine("Выбран диск {0}", path);

            foreach (var directory in drives[number].RootDirectory.EnumerateDirectories())
            {
                Console.WriteLine($"Папка {directory}");
            }

            Console.Write("Укажите папку, в которую хотите сохранить данные: ");
            var directoryName = Console.ReadLine();
            path += directoryName;

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
        }
    }
}       