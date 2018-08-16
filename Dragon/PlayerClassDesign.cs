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
        private int experience;
        public int Experience
        {
            get{return experience;}
            set{experience = value;}
        }

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
                        +"\nExperience: "+Experience
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
        public void ATTACK(Role role,Skill skill)
        {
            int hurt = 0;
            int offset = new Random().Next(0,(((Hit-role.Dodge)>1)?(Hit-role.Dodge):0));
            hurt = skill.Attack - role.Defense + offset; 
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
        public Player()
        {
            
        }
        public Player(string _name,SEX _sex,
                        int _level,int _attack,
                        int _defense,int _life,
                        int _magic_capacity,
                        int _essence,
                        int _hit,
                        int _dodge,
                        int _experience):
        base(_name,_sex,_level,_attack,_defense,_life,_magic_capacity,_essence,_hit,_dodge)
        {
            head = new HeadEquipment();
            handguard = new HandguardEquipment();
            cloth = new ClothEquipment();
            shoe = new ShoeEquipment();
            weapon = new WeaponEquipment();
            items = new List<Item>();
            Experience = _experience;
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
                Essence = info.GetInt16("Essence");
                Experience = info.GetInt16("Experience");

                head = new HeadEquipment();
                handguard = new HandguardEquipment();
                cloth = new ClothEquipment();
                shoe = new ShoeEquipment();
                weapon = new WeaponEquipment();
                items = new List<Item>();

                SetItems((List<Item>)info.GetValue("Items",typeof(List<Item>)));
                SetSkills((List<Skill>)info.GetValue("Skills",typeof(List<Skill>)));
                SetMyDragons((List<Dragon>)info.GetValue("Dragons",typeof(List<Dragon>)));
                SetHead((HeadEquipment)info.GetValue("HeadEquipment",typeof(HeadEquipment)));
                SetHandguard((HandguardEquipment)info.GetValue("HandguardEquipment",typeof(HandguardEquipment)));
                SetCloth((ClothEquipment)info.GetValue("ClothEquipment",typeof(ClothEquipment)));
                SetShoe((ShoeEquipment)info.GetValue("ShoeEquipment",typeof(ShoeEquipment)));
                SetWeapon((WeaponEquipment)info.GetValue("WeaponEquipment",typeof(WeaponEquipment)));

            }
            catch(SerializationException)
            {
                Console.WriteLine("Serialization Exception!");
            }
        }
        public void AddItem(Item i)
        {
            for(int t=0;t<items.Count;t++)
            {
                if(items[t].Name == i.Name)
                {
                    items[t].Num += i.Num;
                    return;
                }
            }
            items.Add(i);
        }
        private IList<Dragon> MyDragons = new List<Dragon>();
        public void SetMyDragons(IList<Dragon> tmp)
        {
            foreach(Dragon i in tmp)
            {
                i.SetMaster(this);
            }
            MyDragons = tmp;
        }
        public IList<Dragon> GetMyDragons()
        {
            return MyDragons;
        }



        private IList<Item> items;
        public void SetItems(IList<Item> tmp)
        {
            foreach(Item i in tmp)
            {
                i.SetUser(this);
            }
            items = tmp;
        }
        public IList<Item> GetItems()
        {
            return items;
        }
        private HeadEquipment head;
        public void SetHead(HeadEquipment tmp)
        {
            tmp.SetUser(this);
            head = tmp;
        }
        public HeadEquipment GetHead()
        {
            return head;
        }
        private HandguardEquipment handguard;
        public void SetHandguard(HandguardEquipment tmp)
        {
            tmp.SetUser(this);
            handguard = tmp;
        }
        public HandguardEquipment GetHandguard()
        {
            return handguard;
        }

        private ClothEquipment cloth;
        public void SetCloth(ClothEquipment tmp)
        {
            tmp.SetUser(this);
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
            tmp.SetUser(this);
            shoe = tmp;
        }
        private WeaponEquipment weapon;
        public WeaponEquipment GetWeapon()
        {
            return weapon;
        }
        public void SetWeapon(WeaponEquipment tmp)
        {
            tmp.SetUser(this);
            weapon = tmp;
        }

        public void UseItem(Item i)
        {
            for(int t=0;t<items.Count;t++)
            {
                if(string.Equals(items[t].Name,i.Name)&&items[t].Num != 0)
                {
                    items[t].UseItem();
                    items[t].Num--;
                    if(items[t].Num == 0)
                    {
                        items.RemoveAt(t);
                    }
                }
            }
        }
        public void UpgradeSkill(Skill skill)
        {
            skill.UpgradeSkill();
            skill.Level++;
        }

        public new string ToString()
        {
            string tmp = String.Empty;
            tmp = base.ToString();
            tmp += "\nHeadEquipment: "+GetHead().Name
                    +"\nHandguardEquipment: "+GetHandguard().Name
                    +"\nClothEquipment: "+GetCloth().Name
                    +"\nShoeEquipment: "+GetShoe().Name
                    +"\nWeaponEquipment: "+GetWeapon().Name
                    +"\nItemsCount: "+GetItems().Count;
            foreach(Item i in GetItems())
            {
                tmp += "\n  +ItemName: "+i.Name
                        +"\n    ItemNum: "+i.Num;
            }
            foreach(Skill s in GetSkills())
            {
                tmp += "\n  +SkillName: "+s.SkillName
                        +"\n    SkillLevel: "+s.Level
                        +"\n    SkillAttack: "+s.Attack;
            }
            foreach(Dragon d in GetMyDragons())
            {
                tmp += "\n +Dragons:"+d.ToString();
            }
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
            info.AddValue("Essence",Essence,typeof(int));
            info.AddValue("Items",GetItems(),typeof(List<Item>));
            info.AddValue("Skills",GetSkills(),typeof(List<Skill>));
            info.AddValue("HeadEquipment",GetHead(),typeof(HeadEquipment));
            info.AddValue("HandguardEquipment",GetHandguard(),typeof(HandguardEquipment));
            info.AddValue("ClothEquipment",GetCloth(),typeof(ClothEquipment));
            info.AddValue("ShoeEquipment",GetShoe(),typeof(ShoeEquipment));
            info.AddValue("WeaponEquipment",GetWeapon(),typeof(WeaponEquipment));
            info.AddValue("Dragons",MyDragons,typeof(List<Dragon>));
            info.AddValue("Experience",Experience,typeof(int));
        }
        public void CaptureDragon(Dragon d)
        {
            MyDragons.Add(d);
            d.SetMaster(this);
        }
        public void KillMonster(Monster m)
        {
            this.Experience += m.Exercise;
        }
    }

    class Dragon : Role,ISerializable
    {
        //name,sex,level,attack,defense,life,magic_capacity,essence
        private int dragonType;
        private int loyalty;
        private Role master;
        public void SetMaster(Role tmp)
        {
            master = tmp;
        }
        public Dragon(string _name,SEX _sex,
                        int _level,int _attack,
                        int _defense,int _life,
                        int _magic_capacity,
                        int _essence,
                        int _dragonType,
                        int _loyalty,
                        int _hit,
                        int _dodge,
                        Role _master):
        base(_name,_sex,_level,_attack,_defense,_life,_magic_capacity,_essence,_hit,_dodge)
        {
            dragonType = _dragonType;
            loyalty = _loyalty;
            master = _master;
        }
        protected Dragon(SerializationInfo info,StreamingContext contsext)
        {
                Name = info.GetString("Name");
                Sex = (SEX)info.GetValue("Sex",typeof(SEX));
                Life = info.GetInt16("Life");
                Attack = info.GetInt16("Attack");
                Defense = info.GetInt16("Defense");
                Hit = info.GetInt16("Hit");
                Dodge = info.GetInt16("Dodge");
                Essence = info.GetInt16("Essence");
                Loyalty = info.GetInt16("Loyalty");
                SetSkills((IList<Skill>)info.GetValue("Skills",typeof(List<Skill>)));
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
            info.AddValue("Essence",Essence,typeof(int));
            info.AddValue("Loyalty",Loyalty,typeof(int));
            info.AddValue("Skills",GetSkills(),typeof(List<Skill>));
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
        public new string ToString()
        {
            string tmp = "\n    Name: "+Name
                        +"\n    Level: "+Level
                        +"\n    Sex: "+Sex
                        +"\n    Life: "+Life
                        +"\n    Attack: "+Attack
                        +"\n    Defense: "+Defense;
            return tmp;
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
