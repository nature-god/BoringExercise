using System;

namespace ItemClassDesign
{
    public abstract class Item
    {
        private string name;

        public Item(string _name)
        {
            name = _name;
        }

        public string Name
        {
            get{return name;}
            //set{name = value;}
        }

        public abstract void UseItem();
        public abstract string Description();
    }

    public class ResumeItem : Item
    {
        private int resumCount;
        public int ResumCount
        {
            get{return resumCount;}
            set{resumCount = value;}
        }
        public ResumeItem(string _name,int _resumCount):base(_name)
        {
            ResumCount = _resumCount;
        }

        public override void UseItem()
        {
            Console.WriteLine("使用"+Name+" ,回复"+resumCount.ToString()+"生命值");
        }

        public override string Description()
        {
            return "回复";
        }
    }
}