using System;

namespace MediumTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int action; // переменная, которая будет отвечать за действие пользователя 
            //Создаем два танка, первый для пользователя, второй для компьютера
            Tank tank1 = new Tank(2, 6, 4, 1);
            Tank tank2 = new Tank(2, 6, 4, 4);
            Console.WriteLine("Правила игры:" + "\n");
            Console.WriteLine("Игра представляет собой текстовый бой двух танков");
            Console.WriteLine("Цель игры: свести жизни вражеского танка к нулю");
            Console.WriteLine("В данной версии игры предоставляется два варианта действий: выстрел и перезарядка" + "\n");

            Console.WriteLine("Начало игры!");
            //Вызываем метод для отображения кол-во жизней
            Console.WriteLine($"Начальные характеристики игрока:");
            tank1.PrintIndicators();
            Console.WriteLine($"Начальные характеристики компьютера:");
            tank2.PrintIndicators();
            Console.WriteLine();

            //Цикл который выполняется, пока у вражеского танка есть жизни, игра добрая, в данной версии проиграть нельзя)
            while (tank1.Life >= 0)
            {
                Console.WriteLine("Выберете дейсвтие:" + "\n" + "1.Выстрел" + "\n" + "2.Починка" + "\n" + "3.Покупка патронов");
                action = Convert.ToInt32(Console.ReadLine()); //Переменная для хранения выбранного действия
                //Цикл обработки выбора действия, если пользователем была введена еденица, то вызовется метод выстрела, если двойка, то метод ремонта
                if (action == 1)
                {
                    if (tank1.Cartridge > 0)
                    {
                        if (tank2.Life > 0)
                        {
                            tank2.Shot();
                            tank1.Cartridge--;
                            //Рандом кривой, на одно действие
                            Console.WriteLine();
                            Console.WriteLine("Ход компьютера!");
                            //Задается рандомное число от 1 до 2, для выбора действия
                            Random rand = new Random();
                            float actionComp = rand.Next(1,3);
                            //Если 1 - выстрел, 2 - ремонт, 3 - покупка патронов
                            if (actionComp == 1)
                            {
                                if (tank2.Cartridge > 0)
                                { tank1.Shot(); }
                                else { tank2.Buycartridge(); }
                                
                            }
                            else if (actionComp == 2)
                            {
                                tank2.Repair();
                            }
                            else
                            {
                                tank2.Buycartridge();
                            }
                            Console.WriteLine();
                            actionComp = 0;
                        }
                        else Console.WriteLine("Вы выиграли!!");
                    }
                    else 
                    {
                        Console.WriteLine("Не хватает патронов для выстрела!");
                    }
                    
                }
                else if (action == 2)
                {
                    tank1.Repair(); 

                    Console.WriteLine("Ход компьютера!");
                    Random rand = new Random();
                    int actionComp = rand.Next(1, 2);
                    if (actionComp == 1)
                    {
                        tank1.Shot();
                    }
                    else
                    {
                        tank2.Repair();
                    }
                   
                }
                else if (action == 3)
                {
                    tank1.Buycartridge();
                    Console.WriteLine("Ход компьютера!");
                    Random rand = new Random();
                    int actionComp = rand.Next(1, 2);
                    if (actionComp == 1)
                    {
                        tank1.Shot();
                    }
                    else
                    {
                        tank2.Repair();
                    }
                }    
                else
                {
                    Console.WriteLine("Вы не правильно ввели действие (выберете действие цифрой 1 или 2)");
                }
                //Конструкция для продолжения игры, взял с интернета
                //Ломается при выборе не символа
                //Предлагается выбрать, продолжить игру или закончить, при вводе символа отличного от n игра будет продолжена
                Console.WriteLine("Продолжить? y-да, n-нет (y/n)");
                ConsoleKeyInfo c = Console.ReadKey();
                Console.WriteLine();
                if (c.KeyChar == 'n') break;
            }
            Console.ReadKey();
        }
    }
}
