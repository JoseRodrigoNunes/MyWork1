using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1
{
    class CreateContactService
    {
        public static Entity GetContact(Guid conta)
        {
            Entity contact = new Entity("contact");

            Console.WriteLine("\nPor favor informe o primeiro nome do Contato");
            contact["firstname"] = Console.ReadLine();

            Console.WriteLine("\nPor favor informe o sobrenome do Contato");
            contact["lastname"] = Console.ReadLine();

            Console.WriteLine("\nPor favor informe o email do Contato");
            contact["emailaddress1"] = Console.ReadLine();

            Console.WriteLine("\nPor favor informe o telefone comercial do Contato");
            contact["telephone1"] = Console.ReadLine();

            contact["parentcustomerid"] = new EntityReference("account", conta);

            return contact;
        }
    }
}
