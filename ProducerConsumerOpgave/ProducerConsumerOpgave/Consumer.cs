using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProducerConsumerOpgave
{
    public class Consumer
    {
        //ProductBuffer _prdct = new ProductBuffer();
        public void ConsumeProduct()
        {
            while (true)
            {
                lock (ProductBuffer.bufferLock)
                {
                    while (ProductBuffer.buffer.Count == 0)
                    {
                        Monitor.Wait(ProductBuffer.bufferLock);
                        Console.WriteLine("Consumer is waiting to consume..");
                        Thread.Sleep(1000);
                    }

                    if (ProductBuffer.buffer.Count > 0)
                    {
                        Random rndm = new Random();
                        int rndmNumb = rndm.Next(1, 5);
                        for (int i = 0; i < rndmNumb; i++)
                        {
                            if (ProductBuffer.buffer.Count <= 0)
                            {
                                break;
                            }
                            Console.WriteLine("Consumer consumes item:  " + ProductBuffer.buffer.Count);
                            ProductBuffer.buffer.RemoveAt(0);
                        }
                        Thread.Sleep(2000);
                    }
                    Monitor.PulseAll(ProductBuffer.bufferLock);
                }
            }
        }
    }
}
