//This is the all items in the games
#define DEBUG
using System;
using ItemClassDesign;
using PlayerClassDesign;
using System.Runtime.Serialization;
using SkillClassDesign;
using Skills;

namespace Items
{

    //Resume Items , Player Resume
    public class ResumeItem : Item,ISerializable
    {
        private int resumCount;
        protected ResumeItem(SerializationInfo info,StreamingContext context)
        {
            Name = info.GetString("ItemName");
            ResumCount = info.GetInt16("ResumCount");
            SetUser((Role)info.GetValue("User",typeof(Role)));
            Num = info.GetInt16("Num");
        }
        public int ResumCount
        {
            get{return resumCount;}
            set{resumCount = value;}
        }
        public void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            info.SetType(typeof(ResumeItem));
            info.AddValue("ItemName",Name,typeof(string));
            info.AddValue("ResumCount",ResumCount,typeof(int));
            info.AddValue("User",GetUser().Name,typeof(string));
            info.AddValue("Num",Num,typeof(int));
        }
        public ResumeItem(string _name,Role _Role,int _resumCount,int _num):base(_name,_Role,_num)
        {
            ResumCount = _resumCount;
        }
        public override void UseItem()
        {
            GetUser().Life += ResumCount;
            Console.WriteLine("==================");
            Console.WriteLine("使用"+Name+" ,回复"+resumCount.ToString()+"生命值，现在生命值："+GetUser().Life);
            Console.WriteLine("==================");
        }

        public override string Description()
        {
            return "回复";
        }
    }

    public class AttackStrongItem : Item,IAttackEnhance,ISerializable
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
            set{attackEnhanceCount = value;}
        }
        public void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            info.SetType(typeof(AttackStrongItem));
            info.AddValue("Name",Name,typeof(string));
            info.AddValue("Count",AttackEnhanceCount,typeof(int));
            info.AddValue("ValidityPeriod",ValidityPeriod,typeof(int));
            info.AddValue("User",GetUser(),typeof(Role));
            info.AddValue("Num",Num,typeof(int));          
        }
        protected AttackStrongItem(SerializationInfo info,StreamingContext context)
        {
            Name = info.GetString("Name");
            AttackEnhanceCount = info.GetInt16("Count");
            ValidityPeriod = info.GetInt16("ValidityPeriod");
            SetUser((Role)info.GetValue("User",typeof(Role)));
            Num = info.GetInt16("Num");
        }
        public AttackStrongItem(string _name,Role _Role,int _attackEnhanceCount,int _validityPeriod,int _num):base(_name,_Role,_num)
        {
            attackEnhanceCount = _attackEnhanceCount;
            validityPeriod = _validityPeriod;
        }
        public override void UseItem()
        {
            AttackEnhance();
            #if DEBUG
                Console.WriteLine("=================");
                Console.WriteLine("使用"+Name+"攻击力强化:"+AttackEnhanceCount+" 现在攻击力:"+GetUser().Attack);
                Console.WriteLine("有效时长："+ValidityPeriod);
                Console.WriteLine("=================");
            #endif
        }
        public void AttackEnhance()
        {
            GetUser().Attack += AttackEnhanceCount;
        }
        public override string Description()
        {
            return "强化";
        }
    }

    public class DefenseStrongItem : Item,IDefenseEnhance,ISerializable
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
            set{defenseEnhanceCount = value;}
        }
        public DefenseStrongItem(string _name,Role _Role,int _defenseEnhanceCount,int _validityPeriod,int _num):base(_name,_Role,_num)
        {
            defenseEnhanceCount = _defenseEnhanceCount;
            validityPeriod = _validityPeriod;
        }
        public void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            info.SetType(typeof(DefenseStrongItem));
            info.AddValue("Name",Name,typeof(string));
            info.AddValue("Count",DefenseEnhanceCount,typeof(int));
            info.AddValue("ValidityPeriod",ValidityPeriod,typeof(int));
            info.AddValue("User",GetUser(),typeof(Role));
            info.AddValue("Num",Num,typeof(int));            
        }
        protected DefenseStrongItem(SerializationInfo info,StreamingContext context)
        {
            Name = info.GetString("Name");
            DefenseEnhanceCount = info.GetInt16("Count");
            ValidityPeriod = info.GetInt16("ValidityPeriod");
            SetUser((Role)info.GetValue("User",typeof(Role)));
            Num = info.GetInt16("Num");
        }
        public override void UseItem()
        {
            DefenseEnhance();
            #if DEBUG
                Console.WriteLine("=================");
                Console.WriteLine("使用"+Name+"防御力强化:"+DefenseEnhanceCount+" 现在防御力:"+GetUser().Defense);
                Console.WriteLine("有效时长："+ValidityPeriod);
                Console.WriteLine("=================");
            #endif
        }
        public void DefenseEnhance()
        {
            GetUser().Defense += DefenseEnhanceCount;
        }
        public override string Description()
        {
            return "强化防御";
        }
    }
    public class HitStrongItem : Item,IHitEnhance,ISerializable
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
            set{hitEnhanceCount = value;}
        }
        public HitStrongItem(string _name,Role _Role,int _hitEnhanceCount,int _validityPeriod,int _num):base(_name,_Role,_num)
        {
            hitEnhanceCount = _hitEnhanceCount;
            validityPeriod = _validityPeriod;
        }
        public void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            info.AddValue("Name",Name,typeof(string));
            info.AddValue("Count",HitEnhanceCount,typeof(int));
            info.AddValue("ValidityPeriod",ValidityPeriod,typeof(int));
            info.AddValue("User",GetUser(),typeof(Role));
            info.AddValue("Num",Num,typeof(int));
        }
        protected HitStrongItem(SerializationInfo info,StreamingContext context)
        {
            Name = info.GetString("Name");
            HitEnhanceCount = info.GetInt16("Count");
            ValidityPeriod = info.GetInt16("ValidityPeriod");
            SetUser((Role)info.GetValue("User",typeof(Role)));
            Num = info.GetInt16("Num");
        }
        public override void UseItem()
        {
            HitEnhance();
            #if DEBUG
                Console.WriteLine("=================");
                Console.WriteLine("使用"+Name+"命中率强化:"+HitEnhanceCount+" 现在命中:"+GetUser().Hit);
                Console.WriteLine("有效时长："+ValidityPeriod);
                Console.WriteLine("=================");
            #endif
        }
        public void HitEnhance()
        {
            GetUser().Hit += HitEnhanceCount;
        }
        public override string Description()
        {
            return "强化命中";
        }
    }
    public class DodgeStrongItem : Item,IDodgeEnhance,ISerializable
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
            set{dodgeEnhanceCount = value;}
        }
        public DodgeStrongItem(string _name,Role _Role,int _dodgeEnhanceCount,int _validityPeriod,int _num):base(_name,_Role,_num)
        {
            dodgeEnhanceCount = _dodgeEnhanceCount;
            validityPeriod = _validityPeriod;
        }
        public void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            info.AddValue("Name",Name,typeof(string));
            info.AddValue("Count",DodgeEnhanceCount,typeof(int));
            info.AddValue("ValidityPeriod",ValidityPeriod,typeof(int));
            info.AddValue("User",GetUser(),typeof(Role));
            info.AddValue("Num",Num,typeof(int));
        }
        protected DodgeStrongItem(SerializationInfo info,StreamingContext context)
        {
            Name = info.GetString("Name");
            DodgeEnhanceCount = info.GetInt16("Count");
            ValidityPeriod = info.GetInt16("ValidityPeriod");
            SetUser((Role)info.GetValue("User",typeof(Role)));
            Num = info.GetInt16("Num");
        }
        public override void UseItem()
        {
            DodgeEnhance();
            #if DEBUG
                Console.WriteLine("=================");
                Console.WriteLine("使用"+Name+"闪避强化:"+DodgeEnhanceCount+" 现在闪避:"+GetUser().Dodge);
                Console.WriteLine("有效时长："+ValidityPeriod);
                Console.WriteLine("=================");
            #endif
        }
        public void DodgeEnhance()
        {
            GetUser().Dodge += DodgeEnhanceCount;
        }
        public override string Description()
        {
            return "强化闪避";
        }
    }

    public class WeaponEquipment : Equipment,IAttackEnhance,ISerializable
    {
        private int attackEnhanceCount;
        public WeaponEquipment(){}
        public WeaponEquipment(string _name,Role _role,int _attackEnhanceCount):base(_name,_role)
        {
            attackEnhanceCount = _attackEnhanceCount;
        }
        protected WeaponEquipment(SerializationInfo info,StreamingContext context)
        {
            Name = info.GetString("Name");
            attackEnhanceCount = info.GetInt16("Count");
            SetUser((Role)info.GetValue("Role",typeof(Role)));
        }
        public void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            info.AddValue("Name",Name,typeof(String));
            info.AddValue("Count",attackEnhanceCount,typeof(int));
            info.AddValue("User",GetUser(),typeof(Role));
        }

        public void AttackEnhance()
        {
            GetUser().Attack += attackEnhanceCount;
            #if DEBUG
                Console.WriteLine("================");
                Console.WriteLine("装备"+Name+"攻击加强"+attackEnhanceCount+"攻击力变为=>"+GetUser().Attack);
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

    public class HeadEquipment : Equipment,IDefenseEnhance,ISerializable
    {
        private int defenseEnhanceCount;
        public HeadEquipment(){}
        public HeadEquipment(string _name,Role _role,int _defenseEnhanceCount):base(_name,_role)
        {
            defenseEnhanceCount = _defenseEnhanceCount;
        }
        protected HeadEquipment(SerializationInfo info,StreamingContext context)
        {
            Name = info.GetString("Name");
            defenseEnhanceCount = info.GetInt16("Count");
            SetUser((Role)info.GetValue("Role",typeof(Role)));
        }
        public void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            info.AddValue("Name",Name,typeof(String));
            info.AddValue("Count",defenseEnhanceCount,typeof(int));
            info.AddValue("User",GetUser(),typeof(Role));
        }

        public void DefenseEnhance()
        {
            GetUser().Defense += defenseEnhanceCount;
            #if DEBUG
                Console.WriteLine("================");
                Console.WriteLine("装备"+Name+"防御加强"+defenseEnhanceCount+"防御力变为=>"+GetUser().Defense);
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
    public class ShoeEquipment : Equipment,IDodgeEnhance,ISerializable
    {
        public ShoeEquipment(){}
        private int dodgeEnhanceCount;
        public ShoeEquipment(string _name,Role _role,int _dodgeEnhanceCount):base(_name,_role)
        {
            dodgeEnhanceCount = _dodgeEnhanceCount;
        }
        protected ShoeEquipment(SerializationInfo info,StreamingContext context)
        {
            Name = info.GetString("Name");
            dodgeEnhanceCount = info.GetInt16("Count");
            SetUser((Role)info.GetValue("Role",typeof(Role)));
        }
        public void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            info.AddValue("Name",Name,typeof(String));
            info.AddValue("Count",dodgeEnhanceCount,typeof(int));
            info.AddValue("User",GetUser(),typeof(Role));
        }
        public void DodgeEnhance()
        {
            GetUser().Dodge += dodgeEnhanceCount;
             #if DEBUG
                Console.WriteLine("================");
                Console.WriteLine("装备"+Name+"闪避加强"+dodgeEnhanceCount+"闪避变为=>"+GetUser().Dodge);
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
   public class ClothEquipment : Equipment,IDefenseEnhance,ISerializable
    {
        private int defenseEnhanceCount;
        public ClothEquipment(){}
        public ClothEquipment(string _name,Role _role,int _defenseEnhanceCount):base(_name,_role)
        {
            defenseEnhanceCount = _defenseEnhanceCount;
        }
        protected ClothEquipment(SerializationInfo info,StreamingContext context)
        {
            Name = info.GetString("Name");
            defenseEnhanceCount = info.GetInt16("Count");
            SetUser((Role)info.GetValue("Role",typeof(Role)));
        }
        public void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            info.AddValue("Name",Name,typeof(String));
            info.AddValue("Count",defenseEnhanceCount,typeof(int));
            info.AddValue("User",GetUser(),typeof(Role));
        }

        public void DefenseEnhance()
        {
            GetUser().Defense += defenseEnhanceCount;
            #if DEBUG
                Console.WriteLine("================");
                Console.WriteLine("装备"+Name+"防御加强"+defenseEnhanceCount+"防御力变为=>"+GetUser().Defense);
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
    public class HandguardEquipment : Equipment,IHitEnhance,ISerializable
    {
        private int hitEnhanceCount;
        public HandguardEquipment(){}
        public HandguardEquipment(string _name,Role _role,int _hitEnhanceCount):base(_name,_role)
        {
            hitEnhanceCount = _hitEnhanceCount;
        }
        protected HandguardEquipment(SerializationInfo info,StreamingContext context)
        {
            Name = info.GetString("Name");
            hitEnhanceCount = info.GetInt16("Count");
            SetUser((Role)info.GetValue("Role",typeof(Role)));
        }
        public void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            info.AddValue("Name",Name,typeof(String));
            info.AddValue("Count",hitEnhanceCount,typeof(int));
            info.AddValue("User",GetUser(),typeof(Role));
        }

        public void HitEnhance()
        {
            GetUser().Defense += hitEnhanceCount;
            #if DEBUG
                Console.WriteLine("================");
                Console.WriteLine("装备"+Name+"命中加强"+hitEnhanceCount+"命中变为=>"+GetUser().Hit);
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

    public class SkillBook : Item,ISerializable
    {
        private int skillType;
        public int SkillType
        {
            get{return skillType;}
            set{skillType = value;}
        }
        private int skillLevel;
        public int SkillLevel
        {
            get{return skillLevel;}
            set{skillLevel = value;}
        }
        private int skillAttack;
        public int SkillAttack
        {
            get{return skillAttack;}
            set{skillAttack = value;}
        }
        public Skill LearnSkill()
        {
            Console.WriteLine(Name+SkillLevel+SkillAttack);
            if(SkillType == 0)
            {
                return new PhysicalSkill(Name,SkillAttack,SkillLevel);
            }
            else if(SkillType == 1)
            {
                return new MagicalSkill(Name,SkillAttack,SkillLevel);
            }
            else
            {
                return new PhysicalSkill(Name,SkillAttack,SkillLevel);
            }
        }
        protected SkillBook(SerializationInfo info,StreamingContext context)
        {
            Name = info.GetString("ItemName");
            Num = info.GetInt16("Num");
            SkillType = info.GetInt16("SkillType");
            SkillLevel = info.GetInt16("SkillLevel");
            SkillAttack = info.GetInt16("SkillAttack");
        }
        public void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            info.SetType(typeof(SkillBook));
            info.AddValue("ItemName",Name,typeof(string));
            info.AddValue("SkillType",SkillType,typeof(int));
            info.AddValue("SkillLevel",SkillLevel,typeof(int));
            info.AddValue("SkillAttack",SkillAttack,typeof(int));
            info.AddValue("Num",Num,typeof(int));
        }
        
        public SkillBook(string _name,Role _Role,int _num,int _skillType,int _skillLevel,int _skillAttack):base(_name,_Role,_num)
        {   
            SkillType = _skillType;
            SkillLevel = _skillLevel;
            SkillAttack = _skillAttack;
        }
        public override void UseItem()
        {
            Role user = GetUser();
            foreach(Skill t in user.GetSkills())
            {
                if(String.Equals(this.Name,t.SkillName))
                {
                    Console.WriteLine("You Have learned this skill!");
                    return;
                }
            }
            user.GetSkills().Add(this.LearnSkill());
        }
        public override string Description()
        {
            return "书本";
        }
    }
}