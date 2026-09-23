using System;
using System.Globalization;
using System.Linq;
using System.Text;

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



namespace ArraysAndLists
{
    // ==========================================
    // PÁGINAS 40 ATÉ 42 (Exemplo: Game Map)
    // ==========================================

    public enum TerrainEnum
    {
        GRASS,
        SAND,
        WATER,
        WALL
    }

    public static class TerrainEnumExtensions
    {
        public static ConsoleColor GetColor(this TerrainEnum terrain)
        {
            switch (terrain)
            {
                case TerrainEnum.GRASS: return ConsoleColor.Green;
                case TerrainEnum.SAND: return ConsoleColor.Yellow;
                case TerrainEnum.WATER: return ConsoleColor.Blue;
                default: return ConsoleColor.DarkGray;
            }
        }

        public static char GetChar(this TerrainEnum terrain)
        {
            switch (terrain)
            {
                case TerrainEnum.GRASS: return '\u201c';
                case TerrainEnum.SAND: return '\u25cb';
                case TerrainEnum.WATER: return '\u2248';
                default: return '\u25cf';
            }
        }
    }

    // ==========================================
    // PÁGINAS 47 ATÉ 50 (Exemplo: Transport Plan & Selection Sort)
    // ==========================================

    public static class SelectionSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                T minValue = array[i];

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(minValue) < 0)
                    {
                        minIndex = j;
                        minValue = array[j];
                    }
                }

                Swap(array, i, minIndex);
            }
        }

        private static void Swap<T>(T[] array, int first, int second)
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }

    class Program
    {
        // Método auxiliar da página 48
        private static string[] GetMonthNames()
        {
            string[] names = new string[12];
            for (int month = 1; month <= 12; month++)
            {
                DateTime firstDay = new DateTime(DateTime.Now.Year, month, 1);
                string name = firstDay.ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
                names[month - 1] = name;
            }
            return names;
        }

        static void Main(string[] args)
        {
            // Código da página 42 (Renderização do Game Map)
            TerrainEnum[,] map =
            {
                {
                    TerrainEnum.SAND, TerrainEnum.SAND, TerrainEnum.SAND,
                    TerrainEnum.SAND, TerrainEnum.GRASS, TerrainEnum.GRASS,
                    TerrainEnum.GRASS, TerrainEnum.GRASS, TerrainEnum.GRASS,
                    TerrainEnum.GRASS
                },
                {
                    TerrainEnum.WATER, TerrainEnum.WATER, TerrainEnum.WATER,
                    TerrainEnum.WATER, TerrainEnum.WATER, TerrainEnum.WATER,
                    TerrainEnum.WATER, TerrainEnum.WALL, TerrainEnum.WATER,
                    TerrainEnum.WATER
                }
            };

            Console.OutputEncoding = UTF8Encoding.UTF8;

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int column = 0; column < map.GetLength(1); column++)
                {
                    Console.ForegroundColor = map[row, column].GetColor();
                    Console.Write(map[row, column].GetChar() + " ");
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}