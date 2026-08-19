Console.Write("Digite uma palavra: ");
string palavra = Console.ReadLine() + "";

string invertida = "";
for (int i = palavra.Length - 1; i >= 0; i--)
{
    invertida += palavra[i];
}

if (palavra == invertida)
{
    Console.WriteLine("A palavra é um palíndromo!");
}
else
{
    Console.WriteLine("A palavra NÃO é um palíndromo.");
}
