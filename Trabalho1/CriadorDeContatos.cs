using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1
{
    class CriadorDeContatos
    {
        public static Entity GetContato(Guid conta)
        {
            Entity contato = new Entity("contact");

            Console.WriteLine("\nPor favor informe o primeiro nome do Contato");
            contato["firstname"] = Console.ReadLine();

            Console.WriteLine("\nPor favor informe o email do Contato");
            contato["emailaddress1"] = Console.ReadLine();

            Console.WriteLine("\nPor favor informe o telefone comercial do Contato");
            contato["telephone1"] = Console.ReadLine();

            contato["parentcustomerid"] = new EntityReference("account", conta);

            return contato;
        }
    }
}
