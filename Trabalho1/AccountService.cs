using System;

namespace Trabalho1
{
    internal class AccountService
    {

        public static int SetCategory(string s)
        {
            int iCategory = Convert.ToInt32(s);
            while (iCategory != 1 && iCategory != 2)
            {
                Console.WriteLine("\nPor favor certifique-se que está digitando um valor numérico inteiro entre as opções disponíveis" +
                    "\n1 - Cliente Preferencial | 2 - Padrão");
                iCategory = Convert.ToInt32(Console.ReadLine());
            }
            return iCategory;
        }

        public static int SetNumberOfEmployees(string s)
        {
            string sNumberOfEmployees = s;
            int iNumberOfEmployees;
            while ((!int.TryParse(sNumberOfEmployees, out iNumberOfEmployees)))
            {
                Console.WriteLine("\nPor favor certifique-se que está digitando um valor numérico inteiro");
                sNumberOfEmployees = Console.ReadLine();
            }

            return iNumberOfEmployees;
        }

        public static decimal SetSaldoAtual(string s)
        {
            decimal dSaldo = Convert.ToDecimal(s);
            while (dSaldo <= -100000000000 || 100000000000 <= dSaldo)
            {
                Console.WriteLine("\nPor favor certifique-se que está digitando um valor numérico no intervalo entre " +
                    "-100.000.000.000 e 100.000.000.000");
                dSaldo = Convert.ToDecimal(Console.ReadLine());
            }
            return dSaldo;
        }
    }
}