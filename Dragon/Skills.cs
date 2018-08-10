//#undef DEBUG
using System;
using SkillClassDesign;

namespace  Skills
{
    public class PhysicalSkill : Skill,IPhysicalSkill
    {
        public PhysicalSkill(string _name,int _attack,int _level):base(_name,_attack,_level)
        {
            //Console.WriteLine("PhysicalSkill_01======");
        }
        //Use the physical skill
        public override void UseSkill()
        {
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
            Attack += 5;
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

    public class MagicalSkill : Skill,IMagicalSkill
    {
        public MagicalSkill(string _name,int _attack,int _level):base(_name,_attack,_level)
        {
            //Console.WriteLine("PhysicalSkill_01======");
        }
        //Use the physical skill
        public override void UseSkill()
        {
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
            Attack += 5;
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