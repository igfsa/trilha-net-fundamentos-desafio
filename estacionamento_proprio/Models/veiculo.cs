using System;

namespace estacionamento_proprio.Models
{
    // Classe que representa o estacionamento, com funções para manipulação dos e veículos.
    class Veiculo
    {
        public string Placa { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public decimal Valor { get; set; }

        // Função para receber unidades de entrada para data e hora
        // TODO: A função receber no formato dd/MM/yyyy hh:mm em apenas uma entrada
        public static DateTime RecebeHoras()
        {
            Console.WriteLine("Entre com o dia: ");
            int dd = ValidaInt();
            Console.WriteLine("Entre com o mês: ");
            int mm = ValidaInt();
            Console.WriteLine("Entre com o ano: ");
            int aa = ValidaInt();
            Console.WriteLine("Entre com as horas: ");
            int HH = ValidaInt();
            Console.WriteLine("Entre com os minutos: ");
            int MM = ValidaInt();

            var dataHora = new DateTime(aa, mm, dd, HH, MM, 00, DateTimeKind.Local);

            return dataHora;
        }

        // Função para validação de entrada inteira, usada nas entradas de unidades de tempo
        public static int ValidaInt()
        {
            try
            {
                return Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Entre com um valor valido.");
                return ValidaInt();
            }
        }

        // Função para dar entrada em um veículo
        public static void EntrarVeiculo(List<Veiculo> veiculos)
        {
            Veiculo auxVeiculo = new Veiculo();

            Console.WriteLine("Entre com a placa do veículo: ");
            auxVeiculo.Placa = Console.ReadLine();

            Console.WriteLine("Agora com os dados de hora de entrada do veículo: ");
            auxVeiculo.Entrada = RecebeHoras();

            veiculos.Add(auxVeiculo);
            Console.WriteLine($"Veículo de placa {veiculos.Last().Placa} com entrada às {veiculos.Last().Entrada.ToString("dd-MM-yyyy HH:mm")} cadastrado com sucesso.");
        }

        // Função para dar saída em um veículo
        public static void SairVeiculo(string placa, Estacionamento estac)
        {
            var match = estac.veiculos.FindLast(v => v.Placa == placa);

            if (match != null && match.Entrada > match.Saida)
            {
                do
                {
                    Console.WriteLine("Entre com a hora de saída do veículo: ");
                    DateTime auxSaida = RecebeHoras();

                    if (auxSaida < match.Entrada)
                    {
                        Console.WriteLine("O horário de saída deve ser maior que o horário de entrada.");
                    }
                    else
                    {
                        match.Saida = auxSaida;
                    }
                } while (match.Saida < match.Entrada);
                var tempo = (match.Saida - match.Entrada).TotalHours;
                match.Valor = ((decimal)tempo * estac.precoInicial) + estac.precoPorHora;
                Console.WriteLine($"O veículo {match.Placa} ficou {TimeSpan.FromHours(tempo)} entre {match.Entrada.ToString("dd-MM-yyyy HH:mm")}"
                + $" e {match.Saida.ToString("dd-MM-yyyy HH:mm")}. o motorista deve pagar R$ {match.Valor.ToString("0.00")}");
            }
            else
            {
                Console.WriteLine("Veículo Não estacionado no momento.");
            }
        }

        // Função para listar os veículos
        public static void ListarVeiculos(List<Veiculo> veiculos)
        {
            foreach (Veiculo veiculo in veiculos)
            {
                Console.WriteLine(veiculo.Placa);
                Console.WriteLine(veiculo.Entrada.ToString("dd-MM-yyyy HH:mm"));
                Console.WriteLine(veiculo.Saida.ToString("dd-MM-yyyy HH:mm"));
                Console.WriteLine(veiculo.Valor.ToString("0.00"));
            }
        }

    }
}


