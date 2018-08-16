using System;
using PlayerClassDesign;
using ItemClassDesign;
using Items;
using SkillClassDesign;
using Skills;
using System.Threading.Tasks;
using StorageClass;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static string dirpath = "C:/Users/i343817/Desktop/Exercise/Dragon"+"/Save";
        static string fileName = dirpath + "/GameData.sav";
        static void Main(string[] args)
        {
            var binder = new GameSerializationBinder();
            //Storage.SetData(fileName,player,binder);
            //Player TestPlayer = (Player)Storage.GetData(fileName,typeof(Player),binder);
            Player TestPlayer = new Player("Nature",SEX.Man,1,10,10,100,10,100,15,10,0);
            Console.WriteLine("##############################################");
            Console.WriteLine(TestPlayer.ToString());
            Console.WriteLine("##############################################");

            Dragon D = new Dragon("露西亚",SEX.Feman,24,100,100,2000,100,0,1,100,20,20,null);
            Dragon D2 = new Dragon("伊蕾雅",SEX.Feman,40,400,400,2000,100,100,1,100,100,100,null);
            TestPlayer.CaptureDragon(D);
            TestPlayer.CaptureDragon(D2);

            AttackStrongItem Itmp2 = new AttackStrongItem("藏锋丹",TestPlayer,15,30,6);
            DefenseStrongItem Itmp3 = new DefenseStrongItem("宝象丹",TestPlayer,25,30,1);
            WeaponEquipment S = new WeaponEquipment("新手剑",TestPlayer,25);
            TestPlayer.AddItem(Itmp2);
            TestPlayer.AddItem(Itmp3);
            TestPlayer.Equip(S);

            SkillBook bbb = new SkillBook("剑荡八荒",TestPlayer,1,0,3,10);
            TestPlayer.AddItem(bbb);
            TestPlayer.UseItem(bbb);

            TestPlayer.UpgradeSkill(TestPlayer.GetSkills()[0]);

            Console.WriteLine("##############################################");
            Console.WriteLine(TestPlayer.ToString());
            Console.WriteLine("##############################################");

            Monster Gooo = new Monster("哥布林",SEX.Man,1,8,2,50,0,0,40,10,100);
            while(!TestPlayer.dead&&!Gooo.dead)
            {
                if(!TestPlayer.dead)
                {
                    TestPlayer.ATTACK(Gooo,TestPlayer.GetSkills()[0]);
                    TestPlayer.GetMyDragons()[0].ATTACK(Gooo);
                }
                else
                {
                    break;
                }
                if(!Gooo.dead)
                {
                    Gooo.ATTACK(TestPlayer);
                }
                else
                {
                    break;
                }
            }
            TestPlayer.KillMonster(Gooo);
            //TestPlayer.AddItem(bbb);
            //TestPlayer.UseItem(bbb);
            Console.WriteLine(TestPlayer.ToString());
            Console.WriteLine("===============");
            Storage.SetData(fileName,TestPlayer,binder);
            Player TestPlayer2 = (Player)Storage.GetData(fileName,typeof(Player),binder);
            Console.WriteLine("Reload!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine(TestPlayer2.ToString());

        }
    }
}