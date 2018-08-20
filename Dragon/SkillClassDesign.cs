using System;
using PlayerClassDesign;

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

        private int cost;

        public int Cost
        {
            get{return cost;}
            set{cost = value;}
        }

        private int upgradeNum;
        public int UpgradeNum
        {
            get{return upgradeNum;}
            set{upgradeNum = value;}
        }
        private int upgradeCost;
        public int UpgradeCost
        {
            get{return upgradeCost;}
            set{upgradeCost = value;}
        }
        public Skill()
        {

        }
        public Skill(string _name,int _attack,int _level,int _cost,int _upgradeNum,int _upgradeCost)
        {
            skillName = _name;
            attack = _attack;
            level = _level;
            cost = _cost;
            upgradeNum = _upgradeNum;
            upgradeCost = _upgradeCost;
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

        public abstract void UseSkill(Role role);
        public abstract void UpgradeSkill();
    }

}