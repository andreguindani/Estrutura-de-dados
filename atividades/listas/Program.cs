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

List<Person> people = new List<Person>();

//criar uma variavel do tipo Person

Person p1 = new Person();

p1.Name = "João";
p1.Age = 42;
p1.Nationality = CountryEnum.BR;

people.Add(p1);

//Adicionando a lista inline
people.Add(new Person(){Name= "Maria", Age = 39, Nationality = CountryEnum.US});

people.Add(new Person(){Name= "Carlitos", Age = 24, Nationality = CountryEnum.AR});

people.Add(new Person(){Name= "Juanito", Age = 28, Nationality = CountryEnum.PY});

//Exeplo de ordenação de lista generica utilizando o LINQ


List<Person> results = people.OrderBy(p => p.Name).ToList();

//Percorremos a lista
foreach(Person p in results)
{
    Console.WriteLine($"Nome: {p.Name}, Idade: {p.Age}, Nac:{p.Nationality}");
}

//ATV 67,68,69