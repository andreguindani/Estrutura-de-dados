int[] numeros = new int[10];
int[] pares = new int[10];
int[] impares = new int[10];
int qtdPares = 0;
int qtdImpares = 0;

for (int i = 0; i < 10; i++)
{
    Console.Write("Digite o {0}º número: ", i + 1);
    numeros[i] = Convert.ToInt32(Console.ReadLine());

    if (numeros[i] % 2 == 0)
    {
        pares[qtdPares] = numeros[i];
        qtdPares++;
    }
    else
    {
        impares[qtdImpares] = numeros[i];
        qtdImpares++;
    }
}


Console.WriteLine("\nNúmeros pares:");
for (int i = 0; i < qtdPares; i++)
{
    Console.Write(pares[i] + " ");
}

Console.WriteLine("\n\nNúmeros ímpares:");
for (int i = 0; i < qtdImpares; i++)
{
    Console.Write(impares[i] + " ");
}