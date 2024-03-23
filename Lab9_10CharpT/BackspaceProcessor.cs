using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT
{
    class BackspaceProcessor
    {
        public string ProcessStringWithBackspace(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                if (c != '#')
                {
                    stack.Push(c);
                }
                else if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }

            char[] resultArray = stack.ToArray();
            Array.Reverse(resultArray);
            return new string(resultArray);
        }
        public string ProcessStringWithBackspaceArrayList(string str)
        {
            ArrayList stack = new ArrayList();
            foreach (char c in str)
            {
                if (c != '#')
                {
                    stack.Add(c);
                }
                else if (stack.Count > 0)
                {
                    stack.RemoveAt(stack.Count - 1);
                }
            }

            char[] chars = new char[stack.Count];
            for (int i = 0; i < stack.Count; i++)
            {
                chars[i] = (char)stack[i];
            }

            return new string(chars);
        }
        public void Run()
        {
            Console.WriteLine("Task1:");
            Console.WriteLine("Input Text (# = Backspace):");
            string input = Console.ReadLine();
            BackspaceProcessor processor = new BackspaceProcessor();
            string result = processor.ProcessStringWithBackspace(input);
            Console.WriteLine("Результат: " + result);
        }
        public void RunArrayList()
        {
            Console.WriteLine("Task1:");
            Console.WriteLine("Input Text (# = Backspace):");
            string input = Console.ReadLine();;
            string result = ProcessStringWithBackspaceArrayList(input);
            Console.WriteLine(result); // Очікуваний результат: "ac"
        }
    }
}
