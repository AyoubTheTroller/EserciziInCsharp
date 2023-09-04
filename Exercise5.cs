using System.Text;

class Exercise5{
    public void invertString(){
        Console.WriteLine("Enter a string:");
        string? input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("The input is empty or null.");
            return;
        }

        /* Reverse method of arrays
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        string reversed1 = new string(charArray);*/

        // StringBuilder populating using the for loop and reading the orginal array from the end of it
        StringBuilder sb = new StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            sb.Append(input[i]);
        }
        string reversed1 = sb.ToString();

        Console.WriteLine($"Reversed String: {reversed1}");
    }
}