using System;

namespace MediumTask
{
    class Program
    {
        enum Action
        {
            Damage = 1,
            Repair = 2,
            Buy = 3
        }


        static void Main(string[] args)
        {

            Console.WriteLine("Правила игры:" + "\n");
            Console.WriteLine("Игра представляет собой текстовый бой двух танков");
            Console.WriteLine("Цель игры: свести жизни вражеского танка к нулю");
            Console.WriteLine("В данной версии игры предоставляется два варианта действий: выстрел и перезарядка" + "\n");


            Random rnd = new Random();

            //Создаем два танка, первый для пользователя, второй для компьютера
            Console.WriteLine("Введите броню игрока:");
            int armor = GetCharacteristics();
            Console.WriteLine("Введите урон игрока:");
            int damage = GetCharacteristics();
            Console.WriteLine("Введите жизни игрока:");
            int life = GetCharacteristics();
            Console.WriteLine("Введите броню компьютера:");
            int pc_armor = GetCharacteristics();
            Console.WriteLine("Введите урон компьютера:");
            int pc_damage = GetCharacteristics();
            Console.WriteLine("Введите жизни компьютера:");
            int pc_life = GetCharacteristics();


            PcTank pcTank = new PcTank();
            UserTank userTank = new UserTank();
            pcTank.Print2(ref pc_life, ref pc_damage, ref pc_armor);
            userTank.Print2(ref life, ref damage, ref armor);

            int initialUserLife = life;
            int initialPcLife = pc_life;


            Console.WriteLine("Доступные действия:" + "\n");
            Console.WriteLine("1 - Выстрел" + "\n" + "2 - Ремонт(Получаем 1 жизнь)" + "\n" + "3 - Покупка снарядов");

            while (pc_life > 0 || life > 0)
            {
                for (int i = 0; i < 1; i++)
                {
                    int user_action = GetAction();
                    ChoiceUserAction((Action)user_action);
                    Console.WriteLine("#################" + "\n");
                    if (life <= 0)
                    {
                        Console.WriteLine("Вы проиграли( ");
                        Environment.Exit(0);
                    }
                    if (pc_life <= 0)
                    {
                        Console.WriteLine("Вы победили!");
                        Environment.Exit(0);
                    }
                    for (int j = 0; j < 1; j++)
                    {
                        Console.WriteLine("Ход компьютера!");
                        int pc_action = rnd.Next(1, 3);
                        Console.WriteLine(pc_action);
                        ChoicePCAction((Action)pc_action);
                        pcTank.Print2(ref pc_life, ref pc_damage, ref pc_armor);
                        userTank.Print2(ref life, ref damage, ref armor);
                    }
                }
            }

            void ChoiceUserAction(Action action)
            {
                switch (action)
                {
                    case Action.Damage:
                        userTank.Shot(ref pc_life, ref damage, ref pc_armor, ref userTank.projectile);
                        break;
                    case Action.Repair:
                        if (life < initialUserLife)
                        {
                            userTank.Repair(ref life);
                        }
                        else
                        {
                            Console.WriteLine("Вы достигли максимального запаса здоровья!");
                        }
                        break;
                    case Action.Buy:

                        userTank.BuyProjectile(ref userTank.projectile);
                        break;

                }

            }

            void ChoicePCAction(Action action)
            {
                switch (action)
                {
                    case Action.Damage:
                        Console.WriteLine("Компьютер применяет действие - выстрел");
                        pcTank.Shot(ref life, ref pc_damage, ref armor, ref pcTank.pc_projectile);
                        if (pcTank.pc_projectile <= 0)
                        {
                            Console.WriteLine("Ход компьютера! Покупка боеприпасов!");
                            pcTank.BuyProjectile(ref pcTank.pc_projectile);
                        }
                        Console.WriteLine();
                        break;
                    case Action.Repair:
                        Console.WriteLine("Компьютер применяет действие - лечение");
                        if (pc_life < initialPcLife)
                        {
                            pcTank.Repair(ref pc_life);
                        }
                        else
                        {
                            Console.WriteLine("Максимальный запас здоровья! Перевыбор действия!");
                            int pc_action = rnd.Next(1, 3);
                            ChoicePCAction((Action)pc_action);
                        }
                        Console.WriteLine();
                        break;
                    case Action.Buy:
                        Console.WriteLine("Компьютер применяет действие - покупка боеприпасов");
                        pcTank.BuyProjectile(ref pcTank.pc_projectile);
                        break;

                }
            }

            static int GetCharacteristics()
            {
                int number;
                string input = Console.ReadLine();
                bool isConverted = int.TryParse(input, out number);
                if (isConverted)
                {
                    if (number < 1)
                    {
                        isConverted = false;
                    }

                }
                while (!isConverted)
                {
                    Console.WriteLine("Нужно ввести число!");
                    input = Console.ReadLine();
                    isConverted = int.TryParse(input, out number);
                    if (!isConverted)
                    {
                        if (number < 1 || number > 100)
                        {
                            isConverted = false;

                        }
                    }
                }
                return number;

            }
            static int GetAction()
            {
                int number;
                Console.WriteLine("Введите действие:");
                string input = Console.ReadLine();
                bool isConverted = int.TryParse(input, out number);
                Console.WriteLine(number);
                if (isConverted)
                {
                    if (number < 1 || number > 3)
                    {
                        isConverted = false;
                    }

                }

                while (!isConverted)
                {
                    Console.WriteLine("Для выбора действия введите число (1-выстрел, 2-ремонт)");
                    input = Console.ReadLine();
                    isConverted = int.TryParse(input, out number);
                    if (!isConverted)
                    {
                        if (number < 1 || number > 3)
                        {
                            isConverted = false;
                        }
                    }
                }
                return number;
            }

        }
    }
}
