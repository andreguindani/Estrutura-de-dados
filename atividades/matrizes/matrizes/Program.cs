/* Vetores Multi-Dimensionais */

//Vetor Bi-Dimensional
int[, ] numberBi = new int[5,2];

//Vetor Tri-Dimensional
int[,,] numbersTri = new int[5,4,3];

//Podemos combinar a declaração com a inicialização
//Exemplo de um 4x3
int[,] newNumbersBi = new int[,]{
    {9,5,-9},
    {-11,3,0},
    {6,115,3},
    {-12,-9,71},
    {1,-6,-1}
};

//Percorendo a Matriz
//Exemplo de repetição for encadeada
//Nested/Chained For

for (int i = 0; i < newNumbersBi.GetLength (0); i++)
{
    for(int j = 0; j < newNumbersBi.GetLength(1); j++)
    {
        Console.Write($"[{newNumbersBi[i,j]}]");
    }
    Console.WriteLine("");
}

// Jagged Arrays ou Array de Jegues
//Vetor de vetores

int[][] jaggedNumbers = new int[4][];

//Atribuindo valores
jaggedNumbers[0] = new int[]{9,5,-9};
jaggedNumbers[1] = new int[] {0,-3,12,51,-3};
jaggedNumbers[3] = new int[] {51};

//Declaração com inicialização

int[][] jaggedNumber2 =
{
  new int[] {0,1,2},
  new int[] {3,4,5,6},
  null,
  new int[] {7,8,9,10},
};

//Para acessar uma posição especifica
int n = jaggedNumbers[1][2];
jaggedNumbers[1][2] = 22;

Console.WriteLine("n = "+ n);
Console.WriteLine("jaggedNumbers[1][2]= " + jaggedNumbers[1][2]);







//tarefa pag 40 ate 42; 47 ate 50