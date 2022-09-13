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

        public virtual void Print2(ref int life, ref int damage, ref int protection) => Console.WriteLine($"Броня: {protection} Жизни:{life} Урон: {damage}");
        public virtual int Shot(ref int life, ref int damage, ref int protection, ref int projectile)
        {
            Console.WriteLine(projectile);
            if (projectile <= 0)
            {
                Console.WriteLine("Закончились боеприпасы! Не возможно произвести выстрел!");
            }
            else
            {
                life = (life + protection - damage);
                projectile--;
            }
            return life;
        }

        public void Repair(ref int life)
        {
            life++;

        }
        public virtual void BuyProjectile(ref int projectile)
        {
            projectile++;
        }
    }

    class PcTank : Tank
    {
        public int pc_life;
        public int pc_damage;
        public int pc_protection;
        public int pc_projectile;


        public PcTank()
        {
            pc_damage = 0;
            pc_life = 0;
            pc_protection = 0;
            pc_projectile = 0;
        }
        public override void Print2(ref int pc_life, ref int pc_damage, ref int pc_protection) => Console.WriteLine($"Броня противника: {pc_protection} Жизни противника:{pc_life} Урон противника: {pc_damage} Кол-во боеприпасов противника: {pc_projectile}");
        public override int Shot(ref int life, ref int damage, ref int protection, ref int pc_projectile)
        {
            if (pc_projectile <= 0)
            {
                Console.WriteLine("Закончились боеприпасы! Не возможно произвести выстрел! Следующим действием купите припасы! ");
            }
            else
            {
                life = (life + protection - damage);
                pc_projectile--;
            }
            return life;
        }
        public override void BuyProjectile(ref int pc_projecint)
        {
            pc_projectile++;
        }
    }

    class UserTank : Tank
    {
        public int life;
        public int damage;
        public int protection;
        public int projectile;


        public UserTank()
        {
            life = 0;
            damage = 0;
            protection = 0;
            projectile = 0;
        }
        public override void Print2(ref int life, ref int damage, ref int protection) => Console.WriteLine($"Ваша Броня: {protection} Ваши Жизни:{life} Ваш Урон: {damage} Ваши боеприпасы: {projectile}");


    }
}

