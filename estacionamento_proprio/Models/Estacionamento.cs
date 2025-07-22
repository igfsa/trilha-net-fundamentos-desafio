using System;

namespace estacionamento_proprio.Models
{
    // Classe que representa o estacionamento, com funções para alterar a tarifa e parâmetros de tarifa e veículos.
    class Estacionamento
    {
        public decimal precoInicial = 0;
        public decimal precoPorHora = 0;
        public List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // Função para validar a entrada de dados como decimal
        public static decimal ValidaPreco()
        {
            decimal auxPreco = 0;
            do
            {
                try
                {
                    auxPreco = decimal.Parse(Console.ReadLine());
                    return auxPreco;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entre com um valor valido.");
                    return ValidaPreco();
                }
            } while (auxPreco == 0);
        }

        // Função para alterar o valor da tarifa inicial e por hora
        public static void AlteraTarifa(Estacionamento tarifa)
        {
            Console.WriteLine("Entre com o valor inicial de tarifa: ");
            tarifa.precoInicial = ValidaPreco();
            Console.WriteLine("Entre com o valor de tarifa por hora: ");
            tarifa.precoPorHora = ValidaPreco();
        }


    }
}