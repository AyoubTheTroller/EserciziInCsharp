class Exercise3{
    public void getSumOfArray(){
        Operations operations= new Operations();
        int[] numbers = operations.populateArray();

        /* USING FOR LOOP
        for (int i = 0; i < numbers.Length; i++){
                sum += numbers[i];
        }

        Console.WriteLine("The sum of array elements is: " + sum);
        */

        // USING LINQ SUM
        int sum = numbers.Sum(); // Using LINQ Sum method to get the sum
        Console.WriteLine("The sum of array elements is: " + sum);
    }
}