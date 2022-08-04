using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1
{
    class CriadorDeContas
    {
        /*
        (X)2. Você deverá questionar o usuário para pelo menos outros 4 campos de tipos diferentes(Decimal, Inteiro,
        Lookup, Option) e recuperar os dados digitados.Após isso crie a conta no Dynamics CE 365 Sales com as
        informações recuperadas.

        Desenvolver pensando nas melhores práticas de programação em C#.
        1 - Renomiar as variaveis
        2 - renomiar as classes
        3 - Refatorar o codigo para melhor legibilidade e performance (criar pastas seria bom para uma melhor organização do projeto)
        4 - implementar tratamento de erros
        5 - me certificar de que tudos está funcionando
        
        */
        public static Entity GetConta()
        {
            Entity conta = new Entity("account");

            Console.WriteLine("Por favor informe o nome da Conta");
            conta["name"] = Console.ReadLine();

            Console.WriteLine("\nPor favor informe o número de funcionarios da Conta");
            string sNumeroDeFuncionarios = Console.ReadLine();
            int iNumeroDeFuncionarios = AtribuirNumeroDeFuncionario(sNumeroDeFuncionarios);
            conta["numberofemployees"] = iNumeroDeFuncionarios;

            // categoria - option | falta tratamento de erro
            // 1 - se certificar que é digitado um número
            // 2 - esse número só pode ser 1 ou 2
            Console.WriteLine("\nPor favor informe a categoria da Conta");
            Console.WriteLine("1 - Cliente Preferencial | 2 - Padrão");
            string sCategoria = Console.ReadLine();
            int iCategoria = AtribuirCategoria(sCategoria);
            conta["accountcategorycode"] = new OptionSetValue(iCategoria);

            //saldo atual (coluna criada) - decimal | falta tratamento de erro
            Console.WriteLine("\nPor favor informe o saldo atual da Conta");
            string sSaldo = Console.ReadLine();
            decimal dSaldo = AtribuirDecimal(sSaldo);
            conta["dyp_saldoatualdaconta"] = dSaldo;

            // contato primario - lookup
            Console.WriteLine("\nPor favor informe o id do contato da Conta");
            // id: 79ae8582-84bb-ea11-a812-000d3a8b3ec6
            Guid gIdDoContado = Guid.Parse(Console.ReadLine());
            conta["primarycontactid"] = new EntityReference("contact", gIdDoContado);
            
            return conta;
        }

        private static int AtribuirCategoria(string s)
        {
            string sCategoria = s;
            int iCategoria;
            while(!int.TryParse(sCategoria, out iCategoria))// while com if
            {
                Console.WriteLine("\nPor favor certifique-se que está digitando um valor numérico e entre as opções disponíveis" +
                    "\n1 - Cliente Preferencial | 2 - Padrão");
                sCategoria = Console.ReadLine();
            }
            return iCategoria;
        }

        private static int AtribuirNumeroDeFuncionario(string s)
        {
            string sNumeroDeFuncionarios = s;
            int iNumeroDeFuncionarios;
            while ((!int.TryParse(sNumeroDeFuncionarios, out iNumeroDeFuncionarios)))
            {
                Console.WriteLine("\nPor favor certifique-se que está digitando um valor numérico \nou um numero no intervalo entre -2,147,483,648 e 2,147,483,647");
                sNumeroDeFuncionarios = Console.ReadLine();
            }

            return iNumeroDeFuncionarios;
        }

        private static decimal AtribuirDecimal(string s)
        {
            string sSaldo = s;
            decimal dSaldo;
            while (!decimal.TryParse(sSaldo, out dSaldo))
            {
                Console.WriteLine("\nPor favor certifique-se que está digitando um valor numérico " +
                    "\nou um numero no intervalo entre -100.000.000.000 e 100.000.000.000");
                sSaldo = Console.ReadLine();
            }
            return dSaldo;
        }
        
    }
}
