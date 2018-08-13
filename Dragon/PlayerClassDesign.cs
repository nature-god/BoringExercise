using System;
using System.Collections.Generic;
using ItemClassDesign;
using SkillClassDesign;
using Items;
using Newtonsoft.Json;
using System.Runtime.Serialization;

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

        public bool dead = false;
    
        private IList<Skill> skills;
        //For serialization Use function to get and set
        public void SetSkills(IList<Skill> tmp)
        {
            skills = tmp;
        }
        public IList<Skill> GetSkills()
        {
            return skills;
        }

        //Constructor
        public Role()
        {
            skills = new List<Skill>();
        }
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
            skills = new List<Skill>();
        }
        
        #region Accessor
        //read only
        public string Name
        {
            get{return name;}
            set{name = value;}
        }
        //read only
        public SEX Sex
        {
            get{return sex;}
            set{sex = value;}
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
            set
            {
                life = value;
                if(life <= 0)
                {
                    this.dead = true;
                    Console.WriteLine(name+"死亡");
                }
            }
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
            string tmp = String.Empty;
            tmp = "================\nPlayerInfo:\nName: "+Name
                        +"\nLevel: "+Level
                        +"\nSex: "+Sex
                        +"\nLife: "+Life
                        +"\nAttack: "+Attack
                        +"\nDefense: "+Defense
                        +"\nHit: "+Hit
                        +"\nDodge: "+Dodge
                        +"\nSkills: "+GetSkills().Count;
            return tmp;
        }
        public void ATTACK(Role role)
        {
            int hurt = 0;
            int offset = new Random().Next(0,(((Hit-role.Dodge)>1)?(Hit-role.Dodge):0));
            hurt = Attack - role.Defense + offset; 
            if(hurt <= 0)
            {
                hurt = 1;
            }
            role.Life -= hurt;
            #if DEBUG
                Console.WriteLine("=========================");
                if(offset >= (Hit-role.Dodge)/2)
                {
                    Console.WriteLine("暴击!");
                }
                Console.WriteLine(Name +"攻击"+role.name+"造成了" + hurt+"伤害");
                Console.WriteLine(Name +"剩余生命："+life);
                Console.WriteLine(role.name+"剩余生命"+role.life);
            #endif
        }
        #endregion
    }

    [Serializable]
    class Player : Role,ISerializable
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
            head = new HeadEquipment();
            handguard = new HandguardEquipment();
            cloth = new ClothEquipment();
            shoe = new ShoeEquipment();
            weapon = new WeaponEquipment();
            items = new List<Item>();
        }

        protected Player(SerializationInfo info,StreamingContext context)
        {
            try
            {
                Name = info.GetString("Name");
                Sex = (SEX)info.GetValue("Sex",typeof(SEX));
                Life = info.GetInt16("Life");
                Attack = info.GetInt16("Attack");
                Defense = info.GetInt16("Defense");
                Hit = info.GetInt16("Hit");
                Dodge = info.GetInt16("Dodge");

                head = new HeadEquipment();
                handguard = new HandguardEquipment();
                cloth = new ClothEquipment();
                shoe = new ShoeEquipment();
                weapon = new WeaponEquipment();
                items = new List<Item>();

                SetItems((List<Item>)info.GetValue("Items",typeof(List<Item>)));
                SetSkills((IList<Skill>)info.GetValue("Skills",typeof(IList<Skill>)));
                SetHead((HeadEquipment)info.GetValue("HeadEquipment",typeof(HeadEquipment)));
                SetHandguard((HandguardEquipment)info.GetValue("HandguardEquipment",typeof(HandguardEquipment)));
                SetCloth((ClothEquipment)info.GetValue("ClothEquipment",typeof(ClothEquipment)));
                SetShoe((ShoeEquipment)info.GetValue("ShoeEquipment",typeof(ShoeEquipment)));
                SetWeapon((WeaponEquipment)info.GetValue("Weapon",typeof(WeaponEquipment)));
            }
            catch(SerializationException)
            {
                Console.WriteLine("Serialization Exception!");
            }
        }
        private IList<Item> items;
        public void SetItems(IList<Item> tmp)
        {
            items = tmp;
        }
        public IList<Item> GetItems()
        {
            return items;
        }
        private HeadEquipment head;
        public void SetHead(HeadEquipment tmp)
        {
            head = tmp;
        }
        public HeadEquipment GetHead()
        {
            return head;
        }
        private HandguardEquipment handguard;
        public void SetHandguard(HandguardEquipment tmp)
        {
            handguard = tmp;
        }
        public HandguardEquipment GetHandguard()
        {
            return handguard;
        }

        private ClothEquipment cloth;
        public void SetCloth(ClothEquipment tmp)
        {
            cloth = tmp;
        }
        public ClothEquipment GetCloth()
        {
            return cloth;
        }
        private ShoeEquipment shoe;
        public ShoeEquipment GetShoe()
        {
            return shoe;
        }
        public void SetShoe(ShoeEquipment tmp)
        {
            shoe = tmp;
        }
        private WeaponEquipment weapon;
        public WeaponEquipment GetWeapon()
        {
            return weapon;
        }
        public void SetWeapon(WeaponEquipment tmp)
        {
            weapon = tmp;
        }

        public void UseItem(Item item)
        {
            item.UseItem();
        }
        public void UpgradeSkill(Skill skill)
        {
            skill.UpgradeSkill();
        }

        public new string ToString()
        {
            string tmp = String.Empty;
            tmp = base.ToString();
            tmp += "\nHeadEquipment: "+GetHead().Name
                    +"\nHandguardEquipment: "+GetHandguard().Name
                    +"\nClothEquipment: "+GetCloth().Name
                    +"\nShoeEquipment: "+GetShoe().Name
                    +"\nWeqponEquipment: "+GetWeapon().Name
                    +"\nItemsCount: "+GetItems().Count;
            return tmp;
        }
        public void Equip(Equipment equipment)
        {
            equipment.Equip();
            switch(equipment.GetType().ToString())
            {
                case "Items.HeadEquipment":
                {
                    SetHead((HeadEquipment)equipment);
                    break;
                }
                case "Items.ClothEquipment":
                {
                    SetCloth((ClothEquipment)equipment);
                    break;
                }
                case "Items.WeaponEquipment":
                {
                    SetWeapon((WeaponEquipment)equipment);
                    break;
                }
                case "Items.HandguardEquipment":
                {
                    SetHandguard((HandguardEquipment)equipment);
                    break;
                }
                case "Items.ShoeEquipment":
                {
                    SetShoe((ShoeEquipment)equipment);
                    break;
                }
                default:
                {
                    Console.WriteLine(equipment.GetType().ToString());
                    break;
                }
            }
        }

        public void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            info.AddValue("Name",Name,typeof(String));
            info.AddValue("Sex",Sex,typeof(SEX));
            info.AddValue("Level",Level,typeof(int));
            info.AddValue("Life",Life,typeof(int));
            info.AddValue("Attack",Attack,typeof(int));
            info.AddValue("Defense",Defense,typeof(int));
            info.AddValue("Hit",Hit,typeof(int));
            info.AddValue("Dodge",Dodge,typeof(int));
            info.AddValue("Items",GetItems(),typeof(IList<Item>));
            info.AddValue("Skills",GetSkills(),typeof(List<Skill>));
            info.AddValue("HeadEquipment",GetHead(),typeof(HeadEquipment));
            info.AddValue("HandguardEquipment",GetHandguard(),typeof(HandguardEquipment));
            info.AddValue("ClothEquipment",GetCloth(),typeof(ClothEquipment));
            info.AddValue("ShoeEquipment",GetShoe(),typeof(ShoeEquipment));
            info.AddValue("WeaponEquipment",GetWeapon(),typeof(WeaponEquipment));
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
    class Monster : Role
    {
        private int exercise;
        public int Exercise
        {
            get{return exercise;}
        }
        public Monster(string _name,SEX _sex,
                        int _level,int _attack,
                        int _defense,int _life,
                        int _magic_capacity,
                        int _essence,
                        int _hit,
                        int _dodge,
                        int _exercise):
        base(_name,_sex,_level,_attack,_defense,_life,_magic_capacity,_essence,_hit,_dodge)
        {
            exercise = _exercise;
        }
    }
}
