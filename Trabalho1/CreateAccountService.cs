using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1
{
    class CreateAccountService
    {
        public static Entity GetAccount()
        {
            Entity account = new Entity("account");

            Console.WriteLine("Por favor informe o nome da Conta");
            account["name"] = Console.ReadLine();

            Console.WriteLine("\nPor favor informe o número de funcionarios da Conta");
            int iNumberOfEmployees = CreateAccountServiceHandler.SetNumberOfEmployees(Console.ReadLine());
            account["numberofemployees"] = iNumberOfEmployees;

            Console.WriteLine("\nPor favor informe a categoria da Conta");
            Console.WriteLine("1 - Cliente Preferencial | 2 - Padrão");
            int iCategory = CreateAccountServiceHandler.SetCategory(Console.ReadLine());
            account["accountcategorycode"] = new OptionSetValue(iCategory);

            Console.WriteLine("\nPor favor informe o saldo atual da Conta");
            string sSaldo = Console.ReadLine();
            decimal dSaldo = CreateAccountServiceHandler.SetSaldoAtual(sSaldo);
            account["dyp_saldoatualdaconta"] = dSaldo;

            Console.WriteLine("\nPor favor informe o id do contato da Conta");
            // id: 79ae8582-84bb-ea11-a812-000d3a8b3ec6
            Guid gContactId = Guid.Parse(Console.ReadLine());
            account["primarycontactid"] = new EntityReference("contact", gContactId);
            return account;
        }
    }
}
