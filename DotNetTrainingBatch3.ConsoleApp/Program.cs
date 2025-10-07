// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Hello, World!");

// ------------------------ Enum and Switch ----------------------------------------
using DotNetTrainingBatch3.ConsoleApp;

string bankName = "KBZ_Error";
Bank bank1 = Enum.Parse<Bank>(bankName); // Throws an exception if the string does not match any enum name
Bank bank = Bank.KBZ;
switch (bank1)
{
    case Bank.KBZ:
        break;
    case Bank.AYA:
        break;
    case Bank.CB:
        break;
    case Bank.UAB:
        break;
    case Bank.MAB:
        break;
    //case Month.January: // Error: Type 'Month' cannot be used as a switch expression with type 'Bank'.
    //    break;
    default:
        break;
}

Month month = Month.January;
switch (month)
{
    case Month.January:
        break;
    case Month.February:
        break;
    case Month.March:
        break;
    case Month.April:
        break;
    case Month.May:
        break;
    case Month.June:
        break;
    case Month.July:
        break;
    case Month.August:
        break;
    case Month.September:
        break;
    case Month.October:
        break;
    case Month.November:
        break;
    case Month.December:
        break;
    default:
        break;
}

// ----------------------------------------------------------------

// Create an instance of the Student class
Student student = new Student();

Console.WriteLine(student.CallTest("Khant"));

// ----------------------------------------------------------------

// Abstract class and method implementation
class Pig : Animal, IAnimal
{
    public override void animalSound()
    {
        throw new NotImplementedException();
    }

    public void animalSound(string voice)
    {
        throw new NotImplementedException();
    }

    public void run()
    {
        throw new NotImplementedException();
    }
}

// ----------------------------------------------------------------

interface IAnimal
{
    void animalSound(string voice); // interface method (does not have a body)
    void run(); // interface method (does not have a body)
}

// ---------------- Enum Declaration ----------------------------------------
enum Month
{
    January = 1,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December
}

enum Bank
{
    KBZ = 1,
    AYA,
    CB,
    UAB,
    MAB
}