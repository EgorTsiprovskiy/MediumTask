using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumTask
{
    /*
     Классс для создания экземпляров танка. Содержит в себе методы управления действиями
    */
    class Tank
    {
        //Свойство танка броня
        private int armor;
        //Свойство танка жизни
        private int life;
        //Свойство танка урон
        private int damage;
        //Свойство кол-во патронов
        private int cartridge;
        public int Armor
        {
            get { return armor; }
            set { armor = value; }
        }
        public int Life
        {
            get { return life; }
            set { life = value; }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public int Cartridge
        {
            get { return cartridge; }
            set { cartridge = value; }
        }

        //Конструктор класса
        public Tank(int armor, int life, int damage, int catridge) { this.Armor = armor; this.Life = life; this.Damage = damage; this.Cartridge = catridge; }

        //Метод для стрельбы
        //При вызове метода от запаса жизни танка отнимается четыре(значение урона)
        public void Shot()
        {

            int life = Life; //Переменная, в которой будет храниться обновленное значение жизней

            if (life > 0)
            {
                life = Life - Damage + Armor;
                Console.WriteLine("Нанесено 4 урона");
                Console.WriteLine("Осталось жизней: " + life);
                Life = life;
            }
            else Console.WriteLine("Поражение!");
        }

        //Метод для починки
        //При вызове метода к счетчику жизни прибавляется единица
        public void Repair()
        {
            int life = Life;
            Console.WriteLine(Life);
            if (Life < life)
            { 
                life ++;
                Console.WriteLine("Жизнь восстановленна!" + "\n" + "Текущее кол-во жизней:" + life);
            }
            else { Console.WriteLine("Максимальный запас здоровья! Починка не требуется"); }
            Life = life;
        }
        //Метод купить патроны
        //При вызове метода к запасу снарядов добавляется один патрон
        public void Buycartridge()
        {
            Cartridge++;
        }

        //Метод для вывода ко-во жизней и патронов
        public void PrintIndicators()
        {
            Console.WriteLine($"Кол-во жизней {life}");
            Console.WriteLine($"Кол-во патронов {cartridge}");

        }
    }
}
