using System;
using PlayerClassDesign;
using ItemClassDesign;
using Items;
using SkillClassDesign;
using Skills;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Nature",SEX.Man,1,10,10,100,10,100,15,10);

            PhysicalSkill tmp1 = new PhysicalSkill("小刀突击",10,1);
            PhysicalSkill tmp2 = new PhysicalSkill("酒鬼战意",6,1);
            MagicalSkill tmp3 = new MagicalSkill("龙契约符咒",15,1);

            ResumeItem Itmp1 = new ResumeItem("回春丹",player,10);
            AttackStrongItem Itmp2 = new AttackStrongItem("藏锋丹",player,15,30);
            DefenseStrongItem Itmp3 = new DefenseStrongItem("宝象丹",player,25,30);
            HitStrongItem Itmp4 = new HitStrongItem("天仙造化丹",player,50,60);
            DodgeStrongItem Itmp5 = new DodgeStrongItem("闪避灵灵丹",player,20,40);
            
            HeadEquipment Etmp1 = new HeadEquipment("头盔",player,20);
            WeaponEquipment Etmp2 = new WeaponEquipment("新手剑",player,40);
            ClothEquipment Etmp3 = new ClothEquipment("灰袍",player,25);
            ShoeEquipment Etmp4 = new ShoeEquipment("布鞋",player,20);
            HandguardEquipment Etmp5 = new HandguardEquipment("灰护手",player,10);

            player.Skills.Add(tmp1);
            player.Skills.Add(tmp2);
            player.Skills.Add(tmp3);

            player.items.Add(Itmp1);
            player.items.Add(Itmp2);
            player.items.Add(Itmp3);
            player.items.Add(Itmp4);
            player.items.Add(Itmp5);

            //Console.WriteLine(player.Skills.Count.ToString());
            foreach(Skill t in player.Skills)
            {
                player.UseSkill(t);
                player.UpgradeSkill(t);
            }

            foreach(Item t in player.items)
            {
                player.UseItem(t);
            }

            player.Equip(Etmp1);
            player.Equip(Etmp2);
            player.Equip(Etmp3);
            player.Equip(Etmp4);
            //player.Equip(Etmp5);

            Console.WriteLine("玩家装备:");
            Console.WriteLine("头部: "+player.Head.Name);
            Console.WriteLine("武器: "+player.Weapon.Name);
            Console.WriteLine("鞋子: "+player.Shoe.Name);
            Console.WriteLine("衣服: "+player.Cloth.Name);
            Console.WriteLine("护手: "+player.Handguard.Name);
        }
    }
}