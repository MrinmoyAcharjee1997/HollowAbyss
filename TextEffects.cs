using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HollowAbyssEngine
{
    internal static class TextEffects
    {
        public static void TypeText(string text, int delay = 25)
        {
            foreach (char c in text)
            {
                Console.Write(c);

                if (c == '.' || c == '!' || c == '?')
                {
                    Thread.Sleep(delay * 4);
                }
                else
                {
                    Thread.Sleep(delay);
                }
            }

            Console.WriteLine();
        }
    }
}
