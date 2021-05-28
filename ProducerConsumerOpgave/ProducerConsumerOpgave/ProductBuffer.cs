using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumerOpgave
{
    class ProductBuffer
    {
        public static List<int> buffer = new List<int>();
        public static object bufferLock = new object();
    }
}
