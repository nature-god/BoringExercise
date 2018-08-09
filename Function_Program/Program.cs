using System;

namespace Function_Program
{
    class Program
    {
        public Func<int,int,decimal> SquareForCivil()
        {
            return (width,height) => width*height;
        }
        public Func<int,int,decimal> SquareForBusiness()
        {
            return (width,height) => width*height*1.2m;
        }
        public decimal PropertyFee(decimal price,int width,int height, Func<int,int,decimal> square)
        {
            return price*square(width,height);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Func<double,double,double> DoAddtion = calculate.addtion;
            double result = DoAddtion(20,30);
            Console.WriteLine("Func带回参数委托做加法结果：{0}",DoAddtion(10,20));
            calculate c = new calculate();
            Action<double,double> DoSubstraction = c.substraction;
            DoSubstraction(19,20);
        }

        class calculate
        {
            public static double addtion(double x,double y)
            {
                return x + y;
            }
            public void substraction(double x,double y)
            {
                Console.WriteLine("Action不带参数委托做减法结果:{0}",x-y);
            }
        }
    }
}
