using System;
using PlayerClassDesign;
using System.Runtime.Serialization;

namespace ItemClassDesign
{
    public abstract class Item
    {
        //Reference no need to instantiation
        private Role User;
        public void SetUser(Role user)
        {
            User = user;
        }
        public Role GetUser()
        {
            return User;
        }
        private string name;


        public Item()
        {

        }
        public Item(string _name,Role _User)
        {
            name = _name;
            User = _User;
        }

        public string Name
        {
            get{return name;}
            set{name = value;}
        }

        public abstract void UseItem();
        public abstract string Description();
    }

    public abstract class Equipment
    {
        public Equipment()
        {
            Name = "No Equipment";
        }
        public Equipment(string _name,Role _role)
        {
            Name = _name;
            User = _role;
        }
        private Role User;
        public void SetUser(Role user)
        {
            User = user;
        }
        public Role GetUser()
        {
            return User;
        }


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
    public class GameSerializationBinder : SerializationBinder
    {
        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.Name;
            Console.WriteLine("****************"+typeName);
        }
        public override Type BindToType(string assemblyName, string typeName)
        {
            Console.WriteLine("=================="+typeName);
           return Type.GetType(string.Format(typeName),true);
        }
    }

}