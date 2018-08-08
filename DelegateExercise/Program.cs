using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateExercise
{
   public class Heater
   {
       private int temperature;
       public string type = "RealFire 001";
       public string area = "China Xian";

       public delegate void BoiledEventHandle(Object sender, BoiledEventArgs e);
       public event BoiledEventHandle Boiled;

        public class BoiledEventArgs : EventArgs
        {
            public readonly int temperature;
            public BoiledEventArgs(int temperature)
            {
                this.temperature = temperature;
            }
        }
        public virtual void OnBoiled(BoiledEventArgs e)
        {
            if(Boiled != null)
            {
                Boiled(this,e);
            }
        }
        public void BoilWater()
        {
            for(int  i = 0;i<=100;i++)
            {
                temperature = i;
                if(temperature > 95)
                {
                    BoiledEventArgs e = new BoiledEventArgs(temperature);
                    OnBoiled(e);
                }
            }
        }
   }
   public class Alarm
   {
       public void MakeAlert(Object sender, Heater.BoiledEventArgs e)
       {
           Heater heater = (Heater)sender;
           Console.WriteLine("Alarm:{0} - {1}",heater.area,heater.type);
           Console.WriteLine("Alarm:DI DI DI,the water is {0} temperature",e.temperature);
           Console.WriteLine();
       }
   }
   public class Display
   {
       public static void ShowMsg(Object sender,Heater.BoiledEventArgs e)
       {
           Heater heater = (Heater)sender;
           Console.WriteLine("Display: {0} - {1}: ",heater.area,heater.type);
           Console.WriteLine("Display: water would be boiled, the temperature is : {0}",e.temperature);
           Console.WriteLine();
       }
   }
  
   class Program
   {
       static void Main()
       {
           Heater heater = new Heater();
           Alarm alarm = new Alarm();

           heater.Boiled += alarm.MakeAlert;
           heater.Boiled += (new Alarm()).MakeAlert;
           heater.Boiled += new Heater.BoiledEventHandle(alarm.MakeAlert);
           heater.Boiled += Display.ShowMsg;

           heater.BoilWater();
       }
   }

}
