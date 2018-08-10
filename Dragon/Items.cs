//This is the all items in the games
#define DEBUG
using System;
using ItemClassDesign;
using PlayerClassDesign;

namespace Items
{

    //Resume Items , Player Resume
    public class ResumeItem : Item
    {
        private int resumCount;
        public int ResumCount
        {
            get{return resumCount;}
            set{resumCount = value;}
        }
        public ResumeItem(string _name,Role _Role,int _resumCount):base(_name,_Role)
        {
            ResumCount = _resumCount;
        }

        public override void UseItem()
        {
            User.Life += ResumCount;
            #if DEBUG
                #warning Debug State
                Console.WriteLine("==================");
                Console.WriteLine("使用"+Name+" ,回复"+resumCount.ToString()+"生命值，现在生命值："+User.Life);
                Console.WriteLine("==================");
            #endif
        }

        public override string Description()
        {
            return "回复";
        }
    }

    public class AttackStrongItem : Item,IAttackEnhance
    {
        private int attackEnhanceCount;
        private int validityPeriod;

        public int ValidityPeriod
        {
            get{return validityPeriod;}
            set{validityPeriod = value;}
        }
        public int AttackEnhanceCount
        {
            get{return attackEnhanceCount;}
        }
        public AttackStrongItem(string _name,Role _Role,int _attackEnhanceCount,int _validityPeriod):base(_name,_Role)
        {
            attackEnhanceCount = _attackEnhanceCount;
            validityPeriod = _validityPeriod;
        }
        public override void UseItem()
        {
            AttackEnhance();
            #if DEBUG
                Console.WriteLine("=================");
                Console.WriteLine("使用"+Name+"攻击力强化:"+AttackEnhanceCount+" 现在攻击力:"+User.Attack);
                Console.WriteLine("有效时长："+ValidityPeriod);
                Console.WriteLine("=================");
            #endif
        }
        public void AttackEnhance()
        {
            User.Attack += AttackEnhanceCount;
        }
        public override string Description()
        {
            return "强化";
        }
    }

    public class DefenseStrongItem : Item,IDefenseEnhance
    {
        private int defenseEnhanceCount;
        private int validityPeriod;

        public int ValidityPeriod
        {
            get{return validityPeriod;}
            set{validityPeriod = value;}
        }
        public int DefenseEnhanceCount
        {
            get{return defenseEnhanceCount;}
        }
        public DefenseStrongItem(string _name,Role _Role,int _defenseEnhanceCount,int _validityPeriod):base(_name,_Role)
        {
            defenseEnhanceCount = _defenseEnhanceCount;
            validityPeriod = _validityPeriod;
        }
        public override void UseItem()
        {
            DefenseEnhance();
            #if DEBUG
                Console.WriteLine("=================");
                Console.WriteLine("使用"+Name+"防御力强化:"+DefenseEnhanceCount+" 现在防御力:"+User.Defense);
                Console.WriteLine("有效时长："+ValidityPeriod);
                Console.WriteLine("=================");
            #endif
        }
        public void DefenseEnhance()
        {
            User.Defense += DefenseEnhanceCount;
        }
        public override string Description()
        {
            return "强化防御";
        }
    }
    public class HitStrongItem : Item,IHitEnhance
    {
        private int hitEnhanceCount;
        private int validityPeriod;

        public int ValidityPeriod
        {
            get{return validityPeriod;}
            set{validityPeriod = value;}
        }
        public int HitEnhanceCount
        {
            get{return hitEnhanceCount;}
        }
        public HitStrongItem(string _name,Role _Role,int _hitEnhanceCount,int _validityPeriod):base(_name,_Role)
        {
            hitEnhanceCount = _hitEnhanceCount;
            validityPeriod = _validityPeriod;
        }
        public override void UseItem()
        {
            HitEnhance();
            #if DEBUG
                Console.WriteLine("=================");
                Console.WriteLine("使用"+Name+"命中率强化:"+HitEnhanceCount+" 现在命中:"+User.Hit);
                Console.WriteLine("有效时长："+ValidityPeriod);
                Console.WriteLine("=================");
            #endif
        }
        public void HitEnhance()
        {
            User.Hit += HitEnhanceCount;
        }
        public override string Description()
        {
            return "强化命中";
        }
    }
    public class DodgeStrongItem : Item,IDodgeEnhance
    {
        private int dodgeEnhanceCount;
        private int validityPeriod;

        public int ValidityPeriod
        {
            get{return validityPeriod;}
            set{validityPeriod = value;}
        }
        public int DodgeEnhanceCount
        {
            get{return dodgeEnhanceCount;}
        }
        public DodgeStrongItem(string _name,Role _Role,int _dodgeEnhanceCount,int _validityPeriod):base(_name,_Role)
        {
            dodgeEnhanceCount = _dodgeEnhanceCount;
            validityPeriod = _validityPeriod;
        }
        public override void UseItem()
        {
            DodgeEnhance();
            #if DEBUG
                Console.WriteLine("=================");
                Console.WriteLine("使用"+Name+"闪避强化:"+DodgeEnhanceCount+" 现在闪避:"+User.Dodge);
                Console.WriteLine("有效时长："+ValidityPeriod);
                Console.WriteLine("=================");
            #endif
        }
        public void DodgeEnhance()
        {
            User.Dodge += DodgeEnhanceCount;
        }
        public override string Description()
        {
            return "强化闪避";
        }
    }

    public class WeaponEquipment : Equipment,IAttackEnhance
    {
        private int attackEnhanceCount;
        public WeaponEquipment(){}
        public WeaponEquipment(string _name,Role _role,int _attackEnhanceCount):base(_name,_role)
        {
            attackEnhanceCount = _attackEnhanceCount;
        }

        public void AttackEnhance()
        {
            User.Attack += attackEnhanceCount;
            #if DEBUG
                Console.WriteLine("================");
                Console.WriteLine("装备"+Name+"攻击加强"+attackEnhanceCount+"攻击力变为=>"+User.Attack);
                Console.WriteLine("================");
            #endif
        }
        public override void Equip()
        {
            Console.WriteLine("===============");
            Console.WriteLine("装备"+Name);
            AttackEnhance();
        }
        public override string Description()
        {
            return "武器装备";
        }
    }

    public class HeadEquipment : Equipment,IDefenseEnhance
    {
        private int defenseEnhanceCount;
        public HeadEquipment(){}
        public HeadEquipment(string _name,Role _role,int _defenseEnhanceCount):base(_name,_role)
        {
            defenseEnhanceCount = _defenseEnhanceCount;
        }

        public void DefenseEnhance()
        {
            User.Defense += defenseEnhanceCount;
            #if DEBUG
                Console.WriteLine("================");
                Console.WriteLine("装备"+Name+"防御加强"+defenseEnhanceCount+"防御力变为=>"+User.Defense);
                Console.WriteLine("================");
            #endif
        }
        public override void Equip()
        {
            Console.WriteLine("===============");
            Console.WriteLine("装备"+Name);
            DefenseEnhance();
        }
        public override string Description()
        {
            return "头部装备";
        }
    }
    public class ShoeEquipment : Equipment,IDodgeEnhance
    {
        public ShoeEquipment(){}
        private int dodgeEnhanceCount;
        public ShoeEquipment(string _name,Role _role,int _dodgeEnhanceCount):base(_name,_role)
        {
            dodgeEnhanceCount = _dodgeEnhanceCount;
        }
        public void DodgeEnhance()
        {
            User.Dodge += dodgeEnhanceCount;
             #if DEBUG
                Console.WriteLine("================");
                Console.WriteLine("装备"+Name+"闪避加强"+dodgeEnhanceCount+"闪避变为=>"+User.Dodge);
                Console.WriteLine("================");
            #endif
        }
        public override void Equip()
        {
            Console.WriteLine("===============");
            Console.WriteLine("装备"+Name);
            DodgeEnhance();
        }
        public override string Description()
        {
            return "鞋部装备";
        }
    }
   public class ClothEquipment : Equipment,IDefenseEnhance
    {
        private int defenseEnhanceCount;
        public ClothEquipment(){}
        public ClothEquipment(string _name,Role _role,int _defenseEnhanceCount):base(_name,_role)
        {
            defenseEnhanceCount = _defenseEnhanceCount;
        }

        public void DefenseEnhance()
        {
            User.Defense += defenseEnhanceCount;
            #if DEBUG
                Console.WriteLine("================");
                Console.WriteLine("装备"+Name+"防御加强"+defenseEnhanceCount+"防御力变为=>"+User.Defense);
                Console.WriteLine("================");
            #endif
        }
        public override void Equip()
        {
            Console.WriteLine("===============");
            Console.WriteLine("装备"+Name);
            DefenseEnhance();
        }
        public override string Description()
        {
            return "衣服装备";
        }
    }
    public class HandguardEquipment : Equipment,IHitEnhance
    {
        private int hitEnhanceCount;
        public HandguardEquipment(){}
        public HandguardEquipment(string _name,Role _role,int _hitEnhanceCount):base(_name,_role)
        {
            hitEnhanceCount = _hitEnhanceCount;
        }

        public void HitEnhance()
        {
            User.Defense += hitEnhanceCount;
            #if DEBUG
                Console.WriteLine("================");
                Console.WriteLine("装备"+Name+"命中加强"+hitEnhanceCount+"命中变为=>"+User.Hit);
                Console.WriteLine("================");
            #endif
        }
        public override void Equip()
        {
            Console.WriteLine("===============");
            Console.WriteLine("装备"+Name);
            HitEnhance();
        }
        public override string Description()
        {
            return "护手装备";
        }
    }
}