using System;

namespace AgendaCSharp
{
    //Usamos o Tipo de telefone para evitar confução com a estrutura maior
    //Que tem o nome de contato
    public enum Status
    {
        Offline,
        Active
    }
    public enum TypePhone
    {
        NaoDeclarado = 0,
        Celular = 1,
        Trabalho = 2,
        Casa = 3,
        Principal = 4,
        Pager = 5,
        FaxTrabalho = 6,
        FaxCasa = 7,
        Outro = 8,
    }

    public struct Contact
    {
        public Status StatusContact;
        public string Fullname;
        public string Firstname;
        public TypePhone Typephone;
        public string Phone;
        public string Email;
        public string[] Address;
        public DateTime BirthDay;
        public string Obs;

        public Contact
            (
                
                string name,
                string phone,
                string email,
                string[] address,
                string obs,
                TypePhone typephone = TypePhone.Celular,
                DateTime birthday = new DateTime(),
                Status estado = Status.Offline
            )

        {
            string[] nameArray = name.Split(" ");
            this.StatusContact = estado;
            this.Fullname = name;
            this.Firstname = nameArray[0];
            this.Typephone = typephone;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
            this.BirthDay = birthday;
            this.Obs = obs;
        }

        public int QuantosDiasParaOAniversario()
        {
            DateTime Aniversario = new (DateTime.Today.Year, this.BirthDay.Month, this.BirthDay.Day);

            return (int)Aniversario.Subtract(DateTime.Today).TotalDays;
        }

        public void ExibirContato()
        {
            
            Console.WriteLine($"\n[Nome] {this.Fullname}");            
            Console.WriteLine($"[Tipo de Contato] {this.Typephone}");
            Console.WriteLine($"[Telefone] {this.Phone}");
            Console.WriteLine($"[E-mail] {this.Email}");

            //Código indentificador se o aniversário já passou, senão quantos dias faltam
            if (QuantosDiasParaOAniversario() > 0)
            {
                int diasQueFaltam = QuantosDiasParaOAniversario();

                Console.WriteLine($"[Aniversário] Faltam {diasQueFaltam} dias");
            }
            
        }

    }
}
