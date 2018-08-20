//#undef DEBUG
using System;
using PlayerClassDesign;
using SkillClassDesign;
using System.Runtime.Serialization;

namespace  Skills
{
    public class PhysicalSkill : Skill,IPhysicalSkill,ISerializable
    {
        protected PhysicalSkill(SerializationInfo info,StreamingContext context)
        {
            SkillName = info.GetString("SkillName");
            Level = info.GetInt16("SkillLevel");
            Attack = info.GetInt16("SkillAttack");
            UpgradeCost = info.GetInt16("UpgradeCost");
            UpgradeNum = info.GetInt16("UpgradeNum");
            Cost = info.GetInt16("Cost");
        }
        public PhysicalSkill(string _name,int _attack,int _level,int _cost,int _upgradeNum,int _upgradeCost):
                                base(_name,_attack,_level,_cost,_upgradeNum,_upgradeCost)
        {
            //Console.WriteLine("PhysicalSkill_01======");
        }
        public void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            info.AddValue("SkillName",SkillName,typeof(string));
            info.AddValue("SkillLevel",Level,typeof(int));
            info.AddValue("SkillAttack",Attack,typeof(int));
            info.AddValue("UpgradeNum",UpgradeNum,typeof(int));
            info.AddValue("UpgradeCost",UpgradeCost,typeof(int));
            info.AddValue("Cost",Cost,typeof(int));
        }

        //Use the physical skill
        public override void UseSkill(Role role)
        {
            role.Physical_Capacity -= Cost;
            UsePhsical();
        }
        public override void UpgradeSkill()
        {
            UpgradePhysical();
        }
        public void UsePhsical()
        {
            #if DEBUG
                Console.WriteLine("==============");
                Console.WriteLine(PhysicalDescription()+ SkillName + "造成" + Attack + "伤害");
            #endif
        }
        //Upgrade the physical skill
        public void UpgradePhysical()
        {
            Attack += UpgradeNum;
            Cost += UpgradeCost;
            #if DEBUG
                Console.WriteLine("================");
                Console.WriteLine(PhysicalDescription()+ SkillName + "升级: " + (Attack-5)+" => "+Attack);
            #endif
        }
        //Descriptions of the physical skill
        public string PhysicalDescription()
        {
            return "物理攻击";
        }
    }    

    public class MagicalSkill : Skill,IMagicalSkill,ISerializable
    {
        protected MagicalSkill(SerializationInfo info,StreamingContext context)
        {
            SkillName = info.GetString("SkillName");
            Level = info.GetInt16("SkillLevel");
            Attack = info.GetInt16("SkillAttack");
            UpgradeCost = info.GetInt16("UpgradeCost");
            UpgradeNum = info.GetInt16("UpgradeNum");
            Cost = info.GetInt16("Cost");
        }
        public MagicalSkill(string _name,int _attack,int _level,int _cost,int _upgradeNum,int _upgradeCost):
                            base(_name,_attack,_level,_cost,_upgradeNum,_upgradeCost)
        {
            //Console.WriteLine("PhysicalSkill_01======");
        }
        public void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            info.AddValue("SkillName",SkillName,typeof(string));
            info.AddValue("SkillLevel",Level,typeof(int));
            info.AddValue("SkillAttack",Attack,typeof(int));
            info.AddValue("UpgradeNum",UpgradeNum,typeof(int));
            info.AddValue("UpgradeCost",UpgradeCost,typeof(int));
            info.AddValue("Cost",Cost,typeof(int));
        }
        //Use the physical skill
        public override void UseSkill(Role role)
        {
            role.Magic_capacity -= Cost;
            UseMagic();
        }
        public override void UpgradeSkill()
        {
            UpgradeMagic();
        }
        public void UseMagic()
        {
            #if DEBUG
                Console.WriteLine("==============");
                Console.WriteLine(MagicDescription()+ SkillName + "造成" + Attack + "伤害");
            #endif
        }
        //Upgrade the physical skill
        public void UpgradeMagic()
        {
            Attack += UpgradeNum;
            Cost += UpgradeCost;
            #if DEBUG
                Console.WriteLine("================");
                Console.WriteLine(MagicDescription()+ SkillName + "升级: " + (Attack-5)+" => "+Attack);
            #endif
        }
        //Descriptions of the physical skill
        public string MagicDescription()
        {
            return "魔法技能";
        }
    }
}