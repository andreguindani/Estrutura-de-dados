string firstName = "Andre";
string lastName = "Guindani";

string note = lastName.ToUpper() + " " + firstName;

string initials = lastName[0] + " " + firstName[0];

Console.WriteLine("" + initials);

//formatação de string

string texto = string.Format(
    "{0} {1} nascido em {2}", 
    firstName, 
    lastName, 
    "2007"
);

Console.WriteLine(texto);

//C# é uma linguagem filha do C++
//Totalmente orientada a objetos, portanto tudo dentro do C é descendente do tipo object

int age = 24;
object ageBoxing = age;
int ageUnboxing = (int)ageBoxing;

