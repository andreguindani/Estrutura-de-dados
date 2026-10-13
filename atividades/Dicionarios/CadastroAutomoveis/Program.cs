using System.Globalization;

//Dicionario com os automoveis: a chave e a placa e o valor e o automovel
Dictionary<string, Automovel> automoveis = new Dictionary<string, Automovel>();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("SISTEMA DE CONTROLE DE AUTOMÓVEIS");
    Console.WriteLine();
    Console.WriteLine("1 - Cadastrar automóvel");
    Console.WriteLine("2 - Buscar automóvel pela placa");
    Console.WriteLine("3 - Listar todos os automóveis");
    Console.WriteLine("4 - Buscar automóveis por marca");
    Console.WriteLine("5 - Sair");
    string opcao = Ler("Escolha uma opção: ");
    Console.WriteLine();

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
            Console.WriteLine("Encerrando o programa...");
            return;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}

//Mostra um texto e le o que o usuario digitar
string Ler(string texto)
{
    Console.Write(texto);
    return (Console.ReadLine() ?? "").Trim();
}

void Mostrar(Automovel carro)
{
    Console.WriteLine($"Placa:  {carro.Placa}");
    Console.WriteLine($"Marca:  {carro.Marca}");
    Console.WriteLine($"Modelo: {carro.Modelo}");
    Console.WriteLine($"Ano:    {carro.Ano}");
    Console.WriteLine($"Cor:    {carro.Cor}");
    Console.WriteLine($"Valor:  R$ {carro.Valor:N2}");
    Console.WriteLine("------------------------------");
}

void Cadastrar()
{
    string placa = Ler("Placa: ").ToUpper();
    if (placa == "")
    {
        Console.WriteLine("A placa não pode ficar vazia.");
        return;
    }

    //Nao permite duas placas iguais
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

    //Aceita o valor com virgula ou ponto (ex: 25000,50 ou 25000.50)
    string textoValor = Ler("Valor: R$ ").Replace(",", ".");
    if (!decimal.TryParse(textoValor, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal valor))
    {
        Console.WriteLine("Valor inválido. Cadastro cancelado.");
        return;
    }
    carro.Valor = valor;

    automoveis.Add(placa, carro);
    Console.WriteLine("Automóvel cadastrado com sucesso!");
}

void BuscarPorPlaca()
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

void Listar()
{
    if (automoveis.Count == 0)
    {
        Console.WriteLine("Nenhum automóvel cadastrado.");
        return;
    }

    foreach (Automovel carro in automoveis.Values)
    {
        Mostrar(carro);
    }
}

void BuscarPorMarca()
{
    string marca = Ler("Marca: ").ToLower();
    bool encontrou = false;

    foreach (Automovel carro in automoveis.Values)
    {
        if (carro.Marca.ToLower() == marca)
        {
            Mostrar(carro);
            encontrou = true;
        }
    }

    if (!encontrou)
    {
        Console.WriteLine("Nenhum automóvel encontrado dessa marca.");
    }
}
