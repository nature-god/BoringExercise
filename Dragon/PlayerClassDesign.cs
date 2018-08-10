using System;
using System.Collections.Generic;
using ItemClassDesign;
using SkillClassDesign;
using Items;

namespace PlayerClassDesign
{
    public enum SEX
    {
        Man = 1,
        Feman = 2,
        Midium = 3
    };
    
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
        private int hit;
        private int dodge;
        //
        private int essence;


        public IList<Skill> Skills = new List<Skill>();
        //Constructor
        public Role(string _name,SEX _sex,int _level,int _attack,int _defense,
                    int _life,int _magic_capacity,int _essence,int _hit,int _dodge)
        {
            name = _name;
            sex = _sex;
            level = _level;
            attack = _attack;
            defense = _defense;
            life = _life;
            magic_capacity = _magic_capacity;
            essence = _essence;
            hit = _hit;
            dodge = _dodge;
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

        public int Hit
        {
            get{return hit;}
            set{hit = value;}
        }
        public int Dodge
        {
            get{return dodge;}
            set{dodge = value;}
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
                        int _essence,
                        int _hit,
                        int _dodge):
        base(_name,_sex,_level,_attack,_defense,_life,_magic_capacity,_essence,_hit,_dodge)
        {
            Head = new HeadEquipment();
            Handguard = new HandguardEquipment();
            Cloth = new ClothEquipment();
            Shoe = new ShoeEquipment();
            Weapon = new WeaponEquipment();
        }


        public IList<Item> items = new List<Item>();

        public HeadEquipment Head;
        public HandguardEquipment Handguard;
        public ClothEquipment Cloth;
        public ShoeEquipment Shoe;
        public WeaponEquipment Weapon;

        public void UseItem(Item item)
        {
            item.UseItem();
        }
        public void UpgradeSkill(Skill skill)
        {
            skill.UpgradeSkill();
        }
        public void Equip(Equipment equipment)
        {
            equipment.Equip();
            switch(equipment.GetType().ToString())
            {
                case "Items.HeadEquipment":
                {
                    Head = (HeadEquipment)equipment;
                    break;
                }
                case "Items.ClothEquipment":
                {
                    Cloth = (ClothEquipment)equipment;
                    break;
                }
                case "Items.WeaponEquipment":
                {
                    Weapon = (WeaponEquipment)equipment;
                    break;
                }
                case "Items.HandguardEquipment":
                {
                    Handguard = (HandguardEquipment)equipment;
                    break;
                }
                case "Items.ShoeEquipment":
                {
                    Shoe = (ShoeEquipment)equipment;
                    break;
                }
                default:
                {
                    Console.WriteLine(equipment.GetType().ToString());
                    break;
                }
            }
        }
    }

    class Dragon : Role
    {
        //name,sex,level,attack,defense,life,magic_capacity,essence
        private int dragonType;
        private int loyalty;
        public Dragon(string _name,SEX _sex,
                        int _level,int _attack,
                        int _defense,int _life,
                        int _magic_capacity,
                        int _essence,
                        int _dragonType,
                        int _loyalty,
                        int _hit,
                        int _dodge):
        base(_name,_sex,_level,_attack,_defense,_life,_magic_capacity,_essence,_hit,_dodge)
        {
            dragonType = _dragonType;
            loyalty = _loyalty;
        }

        public int DragonType
        {
            //read only
            get{return dragonType;}
        }
        public int Loyalty
        {
            get{return loyalty;}
            set
            {
                //loyalty: -100 -- 100
                if(loyalty > 100)
                {
                    loyalty = 100;
                }
                else if(loyalty < -100)
                {
                    loyalty = -100;
                }
                else
                {
                    loyalty = value;
                }
            }
        }
    }
}
