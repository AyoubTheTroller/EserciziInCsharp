using System.Text;

class Exercise9{
    public void generateRandomPassword(){
        Console.WriteLine("Enter length of the randowm password that will be generated");
        START1:
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int size))
        {
            Console.WriteLine($"Generated password: {generate(size)}");
        }
        else
        {
            Console.WriteLine("Invalid input, please enter a number.");
            goto START1;
        }
        
    }

    public string generate(int length){
        // Define the characters that the password will consist of (you can change this)
        string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&_-:*()";
        
        StringBuilder sb = new StringBuilder();
        Random rand = new Random();

        for (int i = 0; i < length; i++)
        {
            int index = rand.Next(validChars.Length);
            sb.Append(validChars[index]);
        }

        return sb.ToString();
    }

}