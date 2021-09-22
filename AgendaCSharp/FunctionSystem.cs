using System;

namespace AgendaCSharp
{
    //Aqui estão separados todos os métodos do nosso sistema
    public class FunctionSystem
    {
        //Menu Principal
        public static void Menu(ref bool flag, ref Contact[] Agenda)
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("                Agenda                 ");
            Console.WriteLine("=======================================");

            Console.WriteLine("[1] Inserir um contato");
            Console.WriteLine("[2] Remover um contato");
            Console.WriteLine("[3] Buscar Contato");
            Console.WriteLine("[4] Sair do Programa");
            Console.Write("Opção: ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            //O switch define as rotas tomadas pelos nosso usuários
            switch (opcao)
            {
                case 1:
                    AddAgenda(ref Agenda);
                    break;
                case 2:
                    RmAgenda(ref Agenda);
                    break;
                case 3:
                    //Mecanismo de Busca da Aplicação
                    Console.WriteLine(" ");
                    Console.WriteLine("          Buscando...        ");
                    Console.WriteLine(" ");
                    Console.WriteLine("[1] Busca por primeiro nome");
                    Console.WriteLine("[2] Busca por nome completo");
                    Console.WriteLine("[3] Busca por tipo de contato");
                    Console.WriteLine("[4] Busca por cidade");
                    Console.WriteLine("[5] Voltar");
                    Console.Write("Opção: ");
                    int opcao2 = Convert.ToInt32(Console.ReadLine());

                    //Switch de opções de Busca 
                    switch (opcao2) {
                        case 1:
                            SearchFirstName(ref Agenda);
                            break;
                        case 2:
                            SerchFullName(ref Agenda);
                            break;
                        case 3:
                            SerchTypeContact(ref Agenda);
                            break;
                        case 4:
                            SerchCity(ref Agenda);
                            break;
                        case 5:
                            //Voltar ao menu principal
                            break;
                        default:
                            Console.WriteLine("Nenhuam opção válida! Digite novamente.");
                            break;
                    }                   
                    break;
                case 4:
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Nenhuam opção válida! Digite novamente.");
                    break;
            }                      
        }

        public static void AddAgenda(ref Contact[] Agenda)
        {
            //Escolhendo tipo de Conatato
            Console.WriteLine("\nEscolha um dos tipos de contato: ");
            Console.WriteLine("[1] Celular");
            Console.WriteLine("[2] Trabalho");
            Console.WriteLine("[3] Casa");
            Console.WriteLine("[4] Principal");
            Console.WriteLine("[5] Pager");
            Console.WriteLine("[6] Fax Trabalho");
            Console.WriteLine("[7] Fax Casa");
            Console.WriteLine("[8] Outro");
            Console.Write("Opção: ");
            int opTypePhone = int.Parse(Console.ReadLine());
            TypePhone typephone = (TypePhone)opTypePhone;

            //Recolhendo o Telefone
            Console.Write("\nTelefone[DDD XXXXXXXXX]: ");
            string phone = (Console.ReadLine()).Trim();

            
            //Recolhendo ao nome do Contato
            Console.Write("\nNome Completo: ");
            string nome = (Console.ReadLine()).Trim();

            //Recolhendo email
            Console.Write("\nEmail[seudominio@gmail.com]: ");
            string email = (Console.ReadLine()).Trim();

            //Recolhendo o endereço
            Console.WriteLine("\n================Endereço===============");
            Console.Write($"\nBairro: ");
            string bairro = (Console.ReadLine()).Trim();
            Console.Write($"Cidade: ");
            string cidade = (Console.ReadLine()).Trim();
            Console.Write($"Estado [UF]: ");
            string estado = (Console.ReadLine()).Trim();
            //A array a seguir indica o endereço com correspondência de valores 0 1 2
            string[] address = new string[3] { bairro, cidade, estado};
            

            //Recolhendo o Data de Aniversário
            Console.Write("\nData de Aniversário[dia/mês]: ");
            string dateString = (Console.ReadLine()).Trim();
            string[] dateEmArray = dateString.Split("/");
            DateTime birthday = new DateTime(DateTime.Today.Year, int.Parse(dateEmArray[1]), int.Parse(dateEmArray[0]));

            //Recolhendo observção
            Console.Write("\nObservação: ");
            string obs = (Console.ReadLine()).Trim();
            
           
            for(int i = 0; i < Agenda.Length; i++)
            {
                if (Agenda[i].StatusContact == Status.Offline)
                {
                    Agenda[i] = new Contact(
                        nome, 
                        phone, 
                        email, 
                        address, 
                        obs, 
                        typephone, 
                        birthday, 
                        Status.Active);
                    break;
                }
                
            }

        }

        public static void RmAgenda(ref Contact[] Agenda)
        {
            Console.WriteLine("\nINFORME O CONTATO QUE DESEJA DELETAR");
            Console.Write("[DDD XXXXXXXXX]: ");
            string phoneDel = (Console.ReadLine()).Trim();

            for (int i = 0; i < Agenda.Length; i++)
            {
                if (Agenda[i].StatusContact == Status.Active)
                {
                    if (Agenda[i].Phone == phoneDel)
                    {                        
                        Console.WriteLine("=======================================");
                        Agenda[i].ExibirContato();
                        Console.WriteLine("\nContato deletado com sucesso ; )");
                        Console.WriteLine("=======================================\n");
                        Agenda.SetValue(new Contact(), i);
                        break;
                    }
                }
            }
        }

        public static void SearchFirstName(ref Contact[] Agenda)
        {
            Console.Write("\n[Digite o primeiro nome]: ");
            string objectSearch = (Console.ReadLine()).Trim();

            foreach (Contact contato in Agenda)
            {
                if (contato.StatusContact == Status.Active)
                {
                    if ((contato.Firstname).ToLower() == (objectSearch).ToLower())
                    {                       
                        Console.WriteLine("=======================================");
                        Console.WriteLine("\n            >>>Resultado<<<            ");
                        contato.ExibirContato();
                        Console.WriteLine("\n=======================================");
                    }
                }
            }

        }

        public static void SerchFullName(ref Contact[] Agenda)
        {
            Console.Write("\n[Digite o nome completo]: ");
            string objectSearch = (Console.ReadLine()).Trim();

            foreach (Contact contato in Agenda)
            {
                if (contato.StatusContact == Status.Active)
                {
                    if ((contato.Fullname).ToLower() == (objectSearch).ToLower())
                    {
                        Console.WriteLine("=======================================");
                        Console.WriteLine("\n            >>>Resultado<<<            ");
                        contato.ExibirContato();
                        Console.WriteLine("\n=======================================");
                    }
                }
            }
        }

        public static void SerchTypeContact(ref Contact[] Agenda)
        {
            Console.WriteLine("\nSELECIONE O TIPO DE CONTATO");
            Console.WriteLine("[1] Celular");
            Console.WriteLine("[2] Trabalho");
            Console.WriteLine("[3] Casa");
            Console.WriteLine("[4] Principal");
            Console.WriteLine("[5] Pager");
            Console.WriteLine("[6] Fax Trabalho");
            Console.WriteLine("[7] Fax Casa");
            Console.WriteLine("[8] Outro");
            Console.Write("Opção: ");
            int opTypePhone = int.Parse(Console.ReadLine());
            TypePhone objectSearch = (TypePhone)opTypePhone;

            foreach (Contact contato in Agenda)
            {
                if (contato.StatusContact == Status.Active)
                {                    
                    if (contato.Typephone == objectSearch)
                    {
                        Console.WriteLine("=======================================");
                        Console.WriteLine("\n            >>>Resultado<<<            ");
                        contato.ExibirContato();
                        Console.WriteLine("\n=======================================");
                    }
                }                
            }
        }

        public static void SerchCity(ref Contact[] Agenda)
        {
            Console.Write("\n[Digite a cidade]: ");
            string objectSearch = (Console.ReadLine()).Trim();

            foreach (Contact contato in Agenda)
            {
                if (contato.StatusContact == Status.Active)
                {                    
                    //1 Corresponde a cidade no Array de Address
                    if ((contato.Address[1]).ToLower() == (objectSearch).ToLower())
                    {
                        Console.WriteLine("=======================================");
                        Console.WriteLine("\n            >>>Resultado<<<            ");
                        contato.ExibirContato();
                        Console.WriteLine("\n=======================================");
                    }
                }
            }
        }
    }
}
