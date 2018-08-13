using System;
using PlayerClassDesign;
using ItemClassDesign;
using Items;
using SkillClassDesign;
using Skills;
using System.Threading.Tasks;
using StorageClass;

namespace Test
{
    class Program
    {
        static string dirpath = "C:/Users/i343817/Desktop/Exercise/Dragon"+"/Save";
        static string fileName = dirpath + "/GameData.sav";
        static void Main(string[] args)
        {
            Storage.CreateDirectory(dirpath);
            
            Player player = new Player("Nature",SEX.Man,1,10,10,100,10,100,15,10);
            Monster Gooo = new Monster("哥布林",SEX.Man,1,8,2,50,0,0,40,10,100);

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

            player.GetSkills().Add(tmp1);
            player.GetSkills().Add(tmp2);
            player.GetSkills().Add(tmp3);

            player.GetItems().Add(Itmp1);
            player.GetItems().Add(Itmp2);
            player.GetItems().Add(Itmp3);
            player.GetItems().Add(Itmp4);
            player.GetItems().Add(Itmp5);

            //Console.WriteLine(player.Skills.Count.ToString());
            foreach(Skill t in player.GetSkills())
            {
                player.UseSkill(t);
                player.UpgradeSkill(t);
            }

            foreach(Item t in player.GetItems())
            {
                player.UseItem(t);
            } 

            player.Equip(Etmp1);
            player.Equip(Etmp2);
            player.Equip(Etmp3);
            player.Equip(Etmp4); 
            player.Equip(Etmp5); 

            Console.WriteLine("玩家装备:");
            Console.WriteLine("头部: "+player.GetHead().Name);
            Console.WriteLine("武器: "+player.GetWeapon().Name);
            Console.WriteLine("鞋子: "+player.GetShoe().Name);
            Console.WriteLine("衣服: "+player.GetCloth().Name);
            Console.WriteLine("护手: "+player.GetHandguard().Name);

            while(!player.dead&&!Gooo.dead)
            {
                if(!player.dead)
                {
                    player.ATTACK(Gooo);
                }
                else
                {
                    break;
                }
                if(!Gooo.dead)
                {
                    Gooo.ATTACK(player);
                }
                else
                {
                    break;
                }
            }
            var binder = new GameSerializationBinder();
            Storage.SetData(fileName,player,binder);
            Player TestPlayer = (Player)Storage.GetData(fileName,typeof(Player),binder);

            Console.WriteLine(TestPlayer.ToString());
            Console.WriteLine("===============");
        }
    }
}