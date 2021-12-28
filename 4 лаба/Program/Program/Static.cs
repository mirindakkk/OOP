using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap4
{
    static class Static
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int MediumElemStack(ExtendedStack stack)
        {
            int medium = stack.Count / 2;
            int[] temp = new int[stack.Count];
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                temp[i] = stack.Pop();
            }
            for (int i = 0; i < temp.Length; i++)
            {
                stack.Push(temp[i]);
            }
            return temp[medium];
        }

        public static int GetMaxElement(ExtendedStack stack1)
        {
            int[] temp = new int[stack1.Count];
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                temp[i] = stack1.Pop();
            }
            return temp.Max();
        }

        public static int GetMinElement(ExtendedStack stack)
        {
            int[] temp = new int[stack.Count];
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                temp[i] = stack.Pop();
            }
            return temp.Min();
        }

        public static ExtendedStack IncrementN(ExtendedStack stack, int N)
        {
            int[] temp = new int[stack.Count];
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                temp[i] = stack.Pop();
            }
            for (int i = 0; i < temp.Length; i++)
            {
                stack.Push(temp[i] + N);
            }
            return stack;
        }

    }
}