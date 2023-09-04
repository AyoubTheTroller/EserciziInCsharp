class Exercise7{
    // The Fibonacci sequence is a series of numbers in which each number is the sum of the two preceding ones, usually starting with 0 and 1. So the sequence starts: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, ... and so on.
    public void printFibonacciSequence(){
        Console.WriteLine("How many Fibonacci numbers would you like to generate?");

        START:
        if (int.TryParse(Console.ReadLine(), out int n))
        {
            long a = 0;
            long b = 1;
            
            Console.WriteLine("The first " + n + " Fibonacci numbers are:");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(a);
                long temp = a;
                a = b;
                b = temp + b;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter an int.");
            goto START;
        }
    }
}