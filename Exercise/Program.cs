using System;

namespace Exercise
{
   //publisher
   public class EventTest
   {
       private int value;
       public delegate void NumMainpulationHandle();

       public event NumMainpulationHandle ChangeNum;
       protected virtual void OnNumChanged()
       {
           if( ChangeNum != null )
           {
               ChangeNum();
           }
           else
           {
               Console.WriteLine("event not fire");
               Console.ReadKey();
           }
       }
    public EventTest()
    {
        int n = 5;
        SetValue( n );
    }
    public void SetValue( int n )
    {
        if(value!=n)
        {
            value = n;
            OnNumChanged();
        }
    }
   }
   //订阅器
   public class subscribEvent
   {
       public void printf()
       {
           Console.WriteLine("event fire");
           Console.ReadKey();
       }
   }

   //触发
   public class Exercise
   {
       public static void Main()
       {
           EventTest e = new EventTest();
           subscribEvent v = new subscribEvent();
           e.ChangeNum += new EventTest.NumMainpulationHandle( v.printf );
           e.SetValue(7);
           e.SetValue(11);
       }
   }
}
