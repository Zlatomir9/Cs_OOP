using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());

            stack.Push("1");
            stack.Push("2");
            stack.Push("3");

            Console.WriteLine(stack.IsEmpty());

            Stack<string> stack2 = new Stack<string>();
            stack2.Push("5");
            stack2.Push("4");
            stack.AddRange(stack2);
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
