using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class PC
    {
        public string Brand { get; set; }
        public string SerialNumber { get; set; }
        public string CPU { get; set; }

        public PC()
        {

        }
        public PC(string brand, string number, string cpu)
        {
            Brand = brand; SerialNumber = number; CPU = cpu;
        }

        public void SwitchOnOff()
        {
            Console.WriteLine("Метод включения/выключения ПК");
        }
        public void Restart()
        {
            Console.WriteLine("Метод перезагрузки ПК");
        }
    }
}
/*■	3–4 поля (марка, серийный номер и т.д.),  
■	свойства (к каждому полю),  
■	конструкторы (по умолчанию, с параметрами),  
■	методы, моделирующие функционирование ПЭВМ (включение/выключение, перегрузку). 
○	Создать новый проект (тип — консольное приложение) с именем «SerializConsolApp». Добавить ссылку на библиотеку «ClassLib».
*/
