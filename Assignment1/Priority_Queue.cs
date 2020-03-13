using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Assignment1
{
    class Priority_Queue
    {
        public int count = 0;
        int front = 0;
        List<Node> list = new List<Node>();
        public void Enqueue(Node x)
        {
            if (count == 0)
            {
                list.Add(x);
                count++;
            }
            else
            {
                list.Add(x);
                list = list.OrderBy(o => o.cost).ToList();
                count++;
            }
        }
        public object Dequeue()
        {
            if (count == 1)
            {
                object x = list[front];
                count--;
                front = 0;
                list.Clear();
                return x;
            }
            else
            {
                object x = list[front];
                count--;
                front++;
                return x;
            }
        }
    }
}
