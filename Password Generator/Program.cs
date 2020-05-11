using System;
using System.Text;
using System.Threading;

class RandomNumberSample
{
    static void Main(string[] args)
    {

        Thread.Sleep(1000);
        Console.WriteLine($"Random Password Generator");
        Console.WriteLine($"-------------------------");
        Thread.Sleep(1500);


        // Generate a random number  
        Random random = new Random();
        // Any random integer   
        int num = random.Next();

        RandomNumberGenerator generator = new RandomNumberGenerator();

        string pass = generator.RandomPassword();

        Console.ReadKey();
    }
}

public class RandomNumberGenerator
{
    // Generate a random number between two numbers    
    public int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }

    // Generate a random string with a given size and case.   
    // If second parameter is true, the return string is lowercase  
    public string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }

    // Generate a random password of a given length (optional)  
    public string RandomPassword()
    {
        int number1 = 0;
        Console.Write("Enter password length > ");
        number1 = Int32.Parse(Console.ReadLine());
        Thread.Sleep(1500);
        Console.WriteLine($"Generating random password..");
        Thread.Sleep(1500);
        Console.WriteLine($"Please wait..");
        Thread.Sleep(1500);

        while (number1 < 6)
        {

            Console.WriteLine("Sorry, your password is too short.");
            Thread.Sleep(1000);
            Console.WriteLine("Minimum amount is 6 characters. Try again.");
            Thread.Sleep(1000);
            Console.Write("Enter password length > ");
            number1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Generating random password..");
            Thread.Sleep(1500);
            Console.WriteLine($"Please wait..");
            Thread.Sleep(1500);
        }

        StringBuilder builder = new StringBuilder();
        builder.Append(RandomString(number1 - 5, true));
        builder.Append(RandomNumber(100, 999));
        builder.Append(RandomString(2, false));
        Console.WriteLine($"Your generated random password is: " + builder.ToString());

        Thread.Sleep(1500);
        Console.WriteLine("           ");
        Console.WriteLine("Do you want to generate another password?");
        Console.WriteLine("\ty - Yes");
        Console.WriteLine("\tn - No");

        Thread.Sleep(1500);

        Console.WriteLine("           ");
        Console.Write("Your option? > ");

        Thread.Sleep(1500);

        switch (Console.ReadLine())
        {
            case "y":
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                Console.WriteLine("           ");
                Console.Clear();
                Environment.Exit(0);
                break;
            case "n":
                Environment.Exit(0);
                break;
        }
        return builder.ToString();
    }
}