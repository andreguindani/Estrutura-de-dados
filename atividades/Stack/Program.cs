using System.Collections.Generic;

Stack<char> chars = new Stack<char>();

string text= String.Empty;

Console.WriteLine("Digite uma palavra:");
text = Console.ReadLine();

string reversedText= String.Empty;

foreach(char c in text)
    chars.Push(c);

while(chars.Count > 0)
        reversedText += chars.Pop();

Console.Write(reversedText);

Console.WriteLine(" ");

String isPalindromo =
    text == reversedText
    ? "É palindromo"
    : "Não é palindromo";


Console.Write(isPalindromo);

Console.WriteLine(" ");
