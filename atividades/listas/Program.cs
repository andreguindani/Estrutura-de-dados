//ArrayLists

using System.Collections;
using System.Globalization;

ArrayList arrayList = new ArrayList();

//adicionando itens a lista
arrayList.Add(5);

//adicionando quantias de itens a lista
arrayList.AddRange(new int[]{1,2,3});

arrayList.Insert(3,7.8);

//percorrendo itens da lista de forma generica
foreach (object obj in arrayList)
{
    Console.WriteLine(obj);
}

//Listas genéricas

List<double> numbers = new List<double>();
Console.WriteLine("Digite 'sair para encerrar.");

bool run = true;

do{
    Console.WriteLine("Digite um número:");
    string numberStr = Console.ReadLine();
    if (numberStr.Equals("Sair"))
    {
        run = false;
        Console.WriteLine("Processo encerrado");
    }
    else
    {
        //Validação da entrada do usuario para checar se de fato é um numero
        if(!double.TryParse(numberStr, System.Globalization.NumberStyles.Float, new NumberFormatInfo(), out double number))
        {
            Console.WriteLine("Você não digitou um número.");
            continue;
        }

        numbers.Add(number);
        Console.WriteLine("A média dos valores informados é: "+numbers.Average());
    }
}while(run);

//listas de tipos abstratos de dados(tad)

