using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserStack
{
    class Program
    {
        static void Main(string[] args)
        {
            UserStack<int> userStack = new UserStack<int>(2);
            userStack.Push(25);
            userStack.Push(1);
            userStack.Push(31);
            
            foreach (var item in userStack)
            {
                Console.WriteLine(item + " ");
            }
        }
    }
}
