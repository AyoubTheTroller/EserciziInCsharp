class Exercise6{
    public void isPrimeNumber(){
        Console.WriteLine("Enter a number to check if it is prime:");
        
        if (int.TryParse(Console.ReadLine(), out int num))
        {
            if (IsPrime(num))
            {
                Console.WriteLine($"{num} is a prime number.");
            }
            else
            {
                Console.WriteLine($"{num} is not a prime number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter an int.");
        }
    }

    /*Prime numbers are natural numbers greater than 1 that have exactly two distinct positive divisors: 1 and the number itself. In other words, a prime number can be divided evenly only by 1 and by itself. The first few prime numbers are:

        (2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, ecc)

        Here are some characteristics of prime numbers:

        1. 2 is the only even prime number.
        2. Every prime number greater than 2 is odd.
        3. Prime numbers are not multiples of any other numbers (other than 1 and the number itself).
        4. The number 1 is not considered a prime number, as it has only one divisor (1 itself).

        Prime numbers are fundamental in number theory and have applications in various fields of science and engineering, including cryptography, computer science, and signal processing.
    */
    static bool IsPrime(int num)
    {
        if (num <= 1)
        {
            return false;
        }
        /*
            So, if num is not a prime number (i.e., it has factors other than 1 and itself), then it must have at least one factor "i" such that 1 < "i" ≤ Math.Sqrt(num)
            If it doesn't have such a factor, then n must be a prime number
            The easier way is to loop until the num itself and dividing everytime expecting always a quotient different than 0
        */
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}