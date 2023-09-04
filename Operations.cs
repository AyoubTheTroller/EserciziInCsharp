class Operations{
    public int[] populateArray(){
        Console.Write("Enter the size of the array: ");
        bool check = true;
        int[] numbers = new int[0];  
        while (check)
        {
            START1:
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int size))
            {
                numbers = new int[size];
                check = false; 
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number.");
                goto START1;
            }
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            bool validInput = false;
            while (!validInput)
            {
                Console.Write($"Enter element {i + 1}: ");
                START2:
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int num))
                {
                    numbers[i] = num;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                    goto START2;
                }
            }
        }
        return numbers;
    }
        
}