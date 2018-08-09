using System;
using PlayerClassDesign;
using ItemClassDesign;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Nature",SEX.Man,1,10,10,100,10,100);

            PhysicalSkill_01 tmp1 = new PhysicalSkill_01("小刀突击",10,1);
            PhysicalSkill_01 tmp2 = new PhysicalSkill_01("酒鬼战意",6,1);
            PhysicalSkill_01 tmp3 = new PhysicalSkill_01("小刀暴击",15,1);

            ResumeItem Rtmp1 = new ResumeItem("回春丹",10);
            ResumeItem Rtmp2 = new ResumeItem("金创药",20);
            ResumeItem Rtmp3 = new ResumeItem("藏锋丹",25);
            
            player.Skills.Add(tmp1);
            player.Skills.Add(tmp2);
            player.Skills.Add(tmp3);

            player.items.Add(Rtmp1);
            player.items.Add(Rtmp2);
            player.items.Add(Rtmp3);

            //Console.WriteLine(player.Skills.Count.ToString());
            foreach(Skill t in player.Skills)
            {
                player.UseSkill(t);
            }

            foreach(Item t in player.items)
            {
                player.UseItem(t);
            }
        }
    }
}