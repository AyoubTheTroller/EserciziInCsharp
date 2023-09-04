class Exercise15
{
    public void manageConversion()
    {
        Console.WriteLine("Welcome to the Unit Converter!");
        Console.WriteLine("Choose an option to convert:");
        Console.WriteLine("1. Centimeters to Inches");
        Console.WriteLine("2. Inches to Centimeters");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 1)
                {
                    ConvertCentimetersToInches();
                    break;
                }
                else if (choice == 2)
                {
                    ConvertInchesToCentimeters();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }

    static void ConvertCentimetersToInches()
    {
        Console.WriteLine("Enter the value in centimeters:");
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double centimeters))
            {
                double inches = centimeters / 2.54;
                Console.WriteLine($"{centimeters} cm is equal to {inches} inches.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    static void ConvertInchesToCentimeters()
    {
        Console.WriteLine("Enter the value in inches:");
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double inches))
            {
                double centimeters = inches * 2.54;
                Console.WriteLine($"{inches} inches is equal to {centimeters} cm.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
