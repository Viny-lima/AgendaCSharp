using System;

namespace AgendaCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool Flag = true;
            Contact[] Agenda = new Contact[100];

            while (Flag)
            {
                FunctionSystem.Menu(ref Flag, ref Agenda);
            }            
        }
    }
}
