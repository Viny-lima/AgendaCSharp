using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaCSharp
{
    class Funcs
    {
        static int Menu()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("            Agenda           ");
            Console.WriteLine("=============================");

            Console.WriteLine("[1] Busca por primeiro nome");
            Console.WriteLine("[2] Busca por nome completo");
            Console.WriteLine("[3] Busca por tipo de contato");
            Console.WriteLine("[4] Busca por cidade");
            Console.WriteLine("[5] Inserir um contato");
            Console.WriteLine("[6] Remover um contato");

            int opcao = Convert.ToInt32(Console.ReadLine());
            return opcao;
        }


        static void SearchFirstName()
        {

        }

        static void SerchFullName(object agenda)
        {

        }

        static void SerchTypeContact(object agenda)
        {

        }

        static void SerchCity(object agenda)
        {

        }

        static void AddAgenda(object agenda)
        {

        }

        static void RmAgenda(object agenda)
        {

        }

    }
}
