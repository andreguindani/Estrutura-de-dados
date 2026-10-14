using System.Globalization;

namespace CadastroAutomoveis
{

    public class Program
    {
        private static Dictionary<string, Automovel> automoveis = new Dictionary<string, Automovel>();

        static void Main(string[] args)
        {
            bool run = true;

            do
            {
                Console.WriteLine("");
                Console.WriteLine("SISTEMA DE CONTROLE DE AUTOMÓVEIS");
                Console.WriteLine("");
                Console.WriteLine("1 - Cadastrar automóvel");
                Console.WriteLine("2 - Buscar automóvel pela placa");
                Console.WriteLine("3 - Listar todos os automóveis");
                Console.WriteLine("4 - Buscar automóveis por marca");
                Console.WriteLine("5 - Sair");
                string opcao = Ler("Escolha uma opção: ");
                Console.WriteLine("");

                switch (opcao)
                {
                    case "1":
                        Cadastrar();
                        break;
                    case "2":
                        BuscarPorPlaca();
                        break;
                    case "3":
                        Listar();
                        break;
                    case "4":
                        BuscarPorMarca();
                        break;
                    case "5":
                        run = false;
                        Console.WriteLine("Programa encerrado");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            } while (run);
        }

        private static string Ler(string texto)
        {
            Console.Write(texto);
            return Console.ReadLine() + "";
        }

        private static void Mostrar(Automovel carro)
        {
            Console.WriteLine($"Placa:  {carro.Placa}");
            Console.WriteLine($"Marca:  {carro.Marca}");
            Console.WriteLine($"Modelo: {carro.Modelo}");
            Console.WriteLine($"Ano:    {carro.Ano}");
            Console.WriteLine($"Cor:    {carro.Cor}");
            Console.WriteLine($"Valor:  R$ {carro.Valor}");
            Console.WriteLine("------------------------------");
        }

        private static void Cadastrar()
        {
            string placa = Ler("Placa: ").ToUpper();
            if (placa == "")
            {
                Console.WriteLine("A placa não pode ficar vazia.");
                return;
            }

            if (automoveis.ContainsKey(placa))
            {
                Console.WriteLine("Já existe um automóvel cadastrado com essa placa.");
                return;
            }

            Automovel carro = new Automovel();
            carro.Placa = placa;
            carro.Marca = Ler("Marca: ");
            carro.Modelo = Ler("Modelo: ");

            if (!int.TryParse(Ler("Ano: "), out int ano))
            {
                Console.WriteLine("Ano inválido. Cadastro cancelado.");
                return;
            }
            carro.Ano = ano;

            carro.Cor = Ler("Cor: ");

            string valorStr = Ler("Valor (ex: 78900,50): R$ ");
            if (!double.TryParse(valorStr, out var valor));
            {
                Console.WriteLine("Valor inválido. Cadastro cancelado.");
                return;
            }
            carro.Valor = valor;

            automoveis.Add(placa, carro);
            Console.WriteLine("Automóvel cadastrado com sucesso!");
        }

        private static void BuscarPorPlaca()
        {
            string placa = Ler("Placa: ").ToUpper();

            if (automoveis.ContainsKey(placa))
            {
                Mostrar(automoveis[placa]);
            }
            else
            {
                Console.WriteLine("Nenhum automóvel encontrado com essa placa.");
            }
        }

        private static void Listar()
        {
            if (automoveis.Count == 0)
            {
                Console.WriteLine("Nenhum automóvel cadastrado.");
                return;
            }

            foreach (KeyValuePair<string, Automovel> pair in automoveis)
            {
                Mostrar(pair.Value);
            }
        }

        private static void BuscarPorMarca()
        {
            string marca = Ler("Marca: ").ToUpper();
            bool encontrou = false;

            foreach (KeyValuePair<string, Automovel> pair in automoveis)
            {
                if (pair.Value.Marca.ToUpper() == marca)
                {
                    Mostrar(pair.Value);
                    encontrou = true;
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("Nenhum automóvel encontrado dessa marca.");
            }
        }
    }
}
