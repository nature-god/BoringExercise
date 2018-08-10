using System;

namespace SkillClassDesign
{
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
        public abstract void UpgradeSkill();
    }

}