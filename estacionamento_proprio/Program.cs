using System;
using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using estacionamento_proprio.Models;


namespace estacionamento_proprio
    {
    class Program
        {
        public static string ObterOpcao()
        {
            Console.Clear();
            Console.WriteLine("1 - Entrada de Veículo");
            Console.WriteLine("2 - Saida de Veículo");
            Console.WriteLine("3 - Listar Veículos");
            Console.WriteLine("4 - Alterar Preço");
            Console.WriteLine("X - Sair");

            return Console.ReadLine();

        }
        

        static void Main()
        {
            string opcao;
            Estacionamento estac = new Estacionamento(0, 0);

            Console.WriteLine("Boas vindas ao nosso sistema de estacionamento!");
            Estacionamento.AlteraTarifa(estac);

            do
            {
                opcao = ObterOpcao().ToUpper();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("----- Entrada de Veículo -----");

                        Veiculo.EntrarVeiculo(estac.veiculos);
                        break;
                    case "2":
                        Console.WriteLine("----- Saída de Veículo -----");

                        Console.WriteLine("Entre com a placa do veículo:");
                        Veiculo.SairVeiculo(Console.ReadLine(), estac);

                        break;
                    case "3":
                        Console.WriteLine("----- Listar Veículos -----");
                        Veiculo.ListarVeiculos(estac.veiculos);
                        break;
                    case "4":
                        Console.WriteLine("----- Alterar Tarifa -----");
                        Console.WriteLine($"A tarifa inicial atual é R$ {estac.precoInicial} e a tarifa por hora é R$ {estac.precoPorHora}");

                        Estacionamento.AlteraTarifa(estac);

                        break;
                    case "X":
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine("Para continuar, pressione uma tecla: ");
                Console.ReadLine();
            } while (opcao.ToUpper() != "X");
        }
    }
}