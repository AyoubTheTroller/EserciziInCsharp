class Exercise1{
    public void populateAndSortArrayByUser(){
        Operations operations= new Operations();
        int[] numbers = operations.populateArray();

        Console.WriteLine("Original array:");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
        Array.Sort(numbers);
        Array.Reverse(numbers); // Reverse the array to sort it in descending order because the default behaivior of sorting is in ascending order

        Console.WriteLine("Sorted array in descending order:");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}