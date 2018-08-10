using System;
using PlayerClassDesign;

namespace ItemClassDesign
{
    public abstract class Item
    {
        //Reference no need to instantiation
        public Role User;
        private string name;

        public Item(string _name,Role _User)
        {
            name = _name;
            User = _User;
        }

        public string Name
        {
            get{return name;}
            //set{name = value;}
        }

        public abstract void UseItem();
        public abstract string Description();
    }

    public abstract class Equipment
    {
        public Equipment(){}
        public Equipment(string _name,Role _role)
        {
            Name = _name;
            User = _role;
        }
        public Role User;

        private string name;
        public string Name
        {
            get{return name;}
            set{name = value;}
        }

        public abstract void Equip();
        public abstract string Description();
    }

    public interface IAttackEnhance
    {
        void AttackEnhance();
    }
    public interface IDefenseEnhance
    {
        void DefenseEnhance();
    }
    public interface IHitEnhance
    {
        void HitEnhance();
    }
    public interface IDodgeEnhance
    {
        void DodgeEnhance();
    }
}