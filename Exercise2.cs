class Exercise2{
    public void getLargestNumberInArray(){
        Operations operations= new Operations();
        int[] numbers = operations.populateArray();

        Console.WriteLine("Original array:");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }

        /* TRADITIONAL way looping the array
        int largestNumber = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > largestNumber)
            {
                largestNumber = numbers[i];
            }
        }*/

        // USING LINQ
        int largestNumberLINQ = numbers.Max(); // Using LINQ Max method
        Console.WriteLine("The largest number is: " + largestNumberLINQ);
    }
}