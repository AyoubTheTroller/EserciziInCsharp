class Exercise12{
    public void simulateDiceThrows(){
        int numberOfRolls;
        while (true)
        {
            Console.WriteLine("How many dice throws u wanna do?:");
            string? diceRolls = Console.ReadLine();

            if (int.TryParse(diceRolls,out numberOfRolls))
            {
                Console.WriteLine($"You chose to roll {numberOfRolls} times!\nLet's start!");
                break; 
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        Random random = new Random();
        Dictionary<int, int> frequencyCounter = new Dictionary<int, int>();

        for (int i = 1; i <= 6; i++)
        {
            frequencyCounter[i] = 0;
        }

        for (int i = 0; i < numberOfRolls; i++)
        {
            int roll = random.Next(1, 7);
            Console.WriteLine($"Roll n°{i} = {roll}");
            frequencyCounter[roll]++;
        }

        Console.WriteLine("Frequencies after " + numberOfRolls + " rolls:");
        for (int i = 1; i <= 6; i++)
        {
            Console.WriteLine($"Side {i}: {frequencyCounter[i]} times");
        }
    }
}