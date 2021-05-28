using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProducerConsumerOpgave
{
    public class Producer
    {
        public void ProduceProduct()
        {
            while (true)
            {
                lock (ProductBuffer.bufferLock)
                {
                    while (ProductBuffer.buffer.Count == 5)
                    {
                        Monitor.Wait(ProductBuffer.bufferLock);
                        Console.WriteLine("Producer is waiting to produce..");
                        Thread.Sleep(1000);
                    }

                    if (ProductBuffer.buffer.Count < 5)
                    {
                        Random rndm = new Random();
                        int rndmNumb = rndm.Next(1,3);
                        for (int i = 0; i < 3 - rndmNumb; i++)
                        {
                            if (ProductBuffer.buffer.Count >= 5)
                            {
                                break;
                            }
                            Console.WriteLine("Producer produces item: " + (ProductBuffer.buffer.Count + 1));
                            ProductBuffer.buffer.Add(i);
                        }
                        Thread.Sleep(2000);
                    }
                    Monitor.PulseAll(ProductBuffer.bufferLock);
                }
            }
        }
    }
}
