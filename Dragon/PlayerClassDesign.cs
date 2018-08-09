using System;
using System.Collections.Generic;
using ItemClassDesign;

namespace PlayerClassDesign
{
    public enum SEX
    {
        Man = 1,
        Feman = 2,
        Midium = 3
    };

    public interface IMagicalSkill
    {
        //Use the magic skill
        void UseMagic();
        //Upgrade the magic skill
        void UpgradeMagic();
        //Descriptions of the magic skill
        string MagicDescription();
    }

    public interface IPhysicalSkill
    {
        //Use the physical skill
        void UsePhsical();
        //Upgrade the physical skill
        void UpgradePhysical();
        //Descriptions of the physical skill
        string PhysicalDescription();
    }


    public class Role
    {
        private string name;
        private int level;
        private SEX sex;
        //Attack power
        private int attack;
        //Defense power
        private int defense; 
        //Life
        private int life;
        //Magic capacity
        private int magic_capacity;
        //
        private int essence;


        public IList<Skill> Skills = new List<Skill>();
        //Constructor
        public Role(string _name,SEX _sex,int _level,int _attack,int _defense,int _life,int _magic_capacity,int _essence)
        {
            name = _name;
            sex = _sex;
            level = _level;
            attack = _attack;
            defense = _defense;
            life = _life;
            magic_capacity = _magic_capacity;
            essence = _essence;
        }
        
        #region Accessor
        //read only
        public string Name
        {
            get{return name;}
            //set{name = value;}
        }
        //read only
        public SEX Sex
        {
            get{return sex;}
            //set{sex = value;}
        }
        public int Level
        {
            get{return level;}
            set{level = value;}
        }
        public int Attack
        {
            get{return attack;}
            set{attack = value;}
        }
        public int Defense
        {
            get{return defense;}
            set{defense = value;}
        }
        public int Life
        {
            get{return life;}
            set{life = value;}
        }
        public int Magic_capacity
        {
            get{return magic_capacity;}
            set{magic_capacity = value;}
        }
        public int Essence
        {
            get{return essence;}
            set{essence = value;}
        }
        #endregion

        #region  Method
        public void UseSkill(Skill skill)
        {
            skill.UseSkill();
        }
        public new string ToString()
        {
            return name;
        }
        #endregion
    }

    class Player : Role
    {
        public Player(string _name,SEX _sex,
                        int _level,int _attack,
                        int _defense,int _life,
                        int _magic_capacity,
                        int _essence):
        base(_name,_sex,_level,_attack,_defense,_life,_magic_capacity,_essence)
        {
            
        }

        public IList<Item> items = new List<Item>();

        public void UseItem(Item item)
        {
            item.UseItem();
        }
    }

    class Dragon : Role
    {
        //name,sex,level,attack,defense,life,magic_capacity,essence
        private int dragonType;
        public Dragon(string _name,SEX _sex,
                        int _level,int _attack,
                        int _defense,int _life,
                        int _magic_capacity,
                        int _essence,
                        int _dragonType):
        base(_name,_sex,_level,_attack,_defense,_life,_magic_capacity,_essence)
        {
            dragonType = _dragonType;
        }
    }

    public abstract class Skill
    {
        enum Effect
        {
            dizziness = 1,
            flame = 2,
            frozen = 3,
            poison = 4,
            cure = 5,
            blessing =6
        }
        private string skillName;
        private int attack;
        private int level;

        public Skill(string _name,int _attack,int _level)
        {
            skillName = _name;
            attack = _attack;
            level = _level;
        }

        public string SkillName
        {
            get{return skillName;}
            set{skillName = value;}
        }

        public int Attack
        {
            get{return attack;}
            set{attack = value;}
        }

        public int Level
        {
            get{return level;}
            set{level = value;}
        }

        public abstract void UseSkill();
    }

    public class PhysicalSkill_01 : Skill,IPhysicalSkill
    {

        public PhysicalSkill_01(string _name,int _attack,int _level):base(_name,_attack,_level)
        {
            //Console.WriteLine("PhysicalSkill_01======");
        }
        //Use the physical skill
        public override void UseSkill()
        {
            UsePhsical();
        }
        public void UsePhsical()
        {
            Console.WriteLine(PhysicalDescription() + "造成" + Attack + "伤害");
        }
        //Upgrade the physical skill
        public void UpgradePhysical()
        {
            Attack += 5;
            Console.WriteLine(PhysicalDescription() + "造成" + Attack + "伤害");
        }
        //Descriptions of the physical skill
        public string PhysicalDescription()
        {
            return SkillName;
        }
    }
}
