using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    public class MyTimer
    {
        public void Start(int interval)
        {
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(
               (r) => Console.WriteLine($"{(int)r}")
            );
            for (int i = 0; i < interval; i++)
            {
                Timer timer = new Timer(tm, i, 0, 2000);
            }
            return;
            Console.ReadLine();
        }
    }
}
