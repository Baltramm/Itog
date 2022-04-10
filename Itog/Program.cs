using System;

namespace Itog
{
    class Program
    {
        static void Main(string[] args)
        {
            var anketa = Anketa();
            Print(anketa);
        }


        static (string name, string lastname, int age, bool haveapet, int petamount, string[] petarr, byte colors, string[] colorarr) Anketa()
        {
            (string name, string lastname, int age, bool haveapet, int petamount, string[] petarr, byte colors, string[] colorarr) anketa;
            Console.WriteLine("Ваше имя:");
            anketa.name = Console.ReadLine();
            Console.WriteLine("Ваша фамилия:");
            anketa.lastname = Console.ReadLine();
            string age;
            int intage;
            do
            {
                Console.WriteLine("Ваш возраст:");
                age = Console.ReadLine();
            }
            while (!CheckNum(age, out intage));
            anketa.age = intage;
            Console.WriteLine("У вас есть питомец,да или нет?");
            string havepet = Console.ReadLine();
            if (havepet == "Да" || havepet == "да")
            {
                do
                {
                    anketa.haveapet = true;
                    Console.WriteLine("Сколько у вас питомцев");
                    anketa.petamount = int.Parse(Console.ReadLine());
                }
                while (!CheckNum(age, out intage));
                anketa.petarr = CreateArrPets(anketa.petamount);
            }
            else
            {

                anketa.haveapet = false;
                anketa.petamount = 0;
                anketa.petarr = new string[0];
            }
            Console.WriteLine("Количество ваших любимых цветов");

            anketa.colors = byte.Parse(Console.ReadLine());
            Console.WriteLine("Введите ваши любимые цвета");
            anketa.colorarr = CreateArrColors(anketa.colors);
            return anketa;
        }
        static bool CheckNum(string number, out int corrnumber)
        {
            corrnumber = 0;
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return true;
                }
                else
                {
                    corrnumber = 0;
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Ведите корректные данные");
                return false;
            }
        }
        static string[] CreateArrPets(int num)
        {
            var result = new string[num];
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Ваш питомец номер {0}:", i + 1);
                result[i] = Console.ReadLine();
            }
            return result;
        }
        static string[] CreateArrColors(int num)
        {
            var result = new string[num];
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Ваш цвет номер {0}:", i + 1);
                result[i] = Console.ReadLine();
            }
            return result;
        }
        static void Print((string name, string lastname, int age, bool haveapet, int petamount, string[] petarr, byte colors, string[] colorarr) anketa)
        {
            Console.WriteLine("\nВаше имя:{0}\nВаша фамилия:{1}\nВаш возраст {2}\n", anketa.name, anketa.lastname, anketa.age);
            if (anketa.haveapet == false)
                Console.WriteLine("У вас нет питомцев");
            else
                Console.WriteLine("Количество ваших питомцев:{0}\n", anketa.petamount);
            for (int i = 0; i < anketa.petamount; i++)
                Console.WriteLine("Ваш питомец номер {0}:{1}", i + 1, anketa.petarr[i]);
            Console.WriteLine("Колчество ваших любимых цветов {0}\n", anketa.colors);
            for (int i = 0; i < anketa.colors; i++)
                Console.WriteLine("Ваш любимый цвет номер {0}:{1}", i + 1, anketa.colorarr[i]);
        }
    }
}
