using Microsoft.Xrm.Sdk;
using System;

namespace Trabalho1
{
    class Program
    {
        /*
        (X)1. Ao iniciar a Console o usuário deverá ser informado: “Por favor informe o nome da Conta”
        Recupere a informação digitada pelo usuário

        (X)2. Você deverá questionar o usuário para pelo menos outros 4 campos de tipos diferentes (Decimal, Inteiro,
        Lookup, Option) e recuperar os dados digitados. Após isso crie a conta no Dynamics CE 365 Sales com as
        informações recuperadas.

        (X)3. Após recuperar os dados da conta questione o usuário: “Você deseja criar um contato para essa conta? (S/N)”
        Recupere a informação digitada pelo usuário e só continue o código se ele tiver digitado “S”. Se o
        usuário digitar N, encerre a console.

        (X)4. Recupere pelo menos 3 campos de contato da digitação do usuário na console. Crie o contato no Dynamics CE
        Sales de acordo com as informações recuperadas. Relacione o contato com a conta na criação.

        ( )1. Disponibilizar a solution do Visual Studio para o orientador. Disponibilizar a solução em um gerenciador de
        versão é considerado um plus (GitHub/BitBucket).
        (X)2. Criar uma solution específica no seu ambiente, somente com as personalizações deste exercício
        ( )3. Desenvolver pensando nas melhores práticas de programação em C#.
        (X)4. Criar um novo ambiente do zero para ser utilizado nesse trabalho.
        (X)5. Dar as permissões necessárias no Azure AD!!!

        !!! Verificar a taxa de juros da conta !!!
         */
        static void Main(string[] args)
        {
            IOrganizationService service = ConnectionFactory.GetService();

            Entity conta = CriadorDeContas.GetConta();
            
            Guid idConta = service.Create(conta);
            Console.WriteLine("\nVocê deseja criar um contato para essa conta ? (S / N)");
            string criarContato = Console.ReadLine().ToUpper();

            switch (criarContato)
            {
                case "S":
                    Entity contato = CriadorDeContatos.GetContato(idConta);
                    service.Create(contato);
                    break;
                case "N":
                    Console.WriteLine("\nEncerrando o Programa...");
                    break;
                default:
                    Console.WriteLine("");
                    break;
            }

            Console.WriteLine("\nPresione qualquer tecla para encerra o programa...");
            Console.ReadLine();
        }
    }
}
