using System.Globalization;

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





/* Exemplo dos nomes dos meses do ano */
string[] months = new string[12];

for(int i = 1; i <= 12; i++)
{
    DateTime firstDay = new DateTime(DateTime.Now.Year, i, 1);

    DateTime lastDayMonthBefore = firstDay.AddDays(-1);

    string monthName = firstDay.ToString("MMMM", CultureInfo.CreateSpecificCulture("pt-br"));

    months[i - 1] = monthName;
}

foreach(string monthName in months)
{
    Console.WriteLine($"---> {monthName}");
};

