using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProducerConsumerOpgave
{
    class Program
    {

        static void Main(string[] args)
        {
            Producer prod = new Producer();
            Consumer cons = new Consumer();

            Thread producer = new Thread(prod.ProduceProduct);
            Thread consumer = new Thread(cons.ConsumeProduct);

            producer.Start();
            consumer.Start();
        }
    }
}
