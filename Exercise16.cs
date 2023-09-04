class Exercise16{
    public void manageAcronyms()
    {
        Console.WriteLine("Welcome to the Acronym Generator!");
        Console.WriteLine("Please enter a phrase to be converted into an acronym:");

        string? input = Console.ReadLine();
        while(true){
            if(string.IsNullOrEmpty(input))
                Console.WriteLine("Wrong or incorrect input, retry: ");
            else
              break;

        }
        string acronym = GenerateAcronym(input);

        Console.WriteLine($"The acronym for your phrase is: {acronym}");
    }

    static string GenerateAcronym(string phrase)
    {
        string[] words = phrase.Split(' ');
        char[] acronymChars = new char[words.Length];

        for (int i = 0; i < words.Length; i++)
        {
            if (!string.IsNullOrEmpty(words[i]))
            {
                acronymChars[i] = char.ToUpper(words[i][0]);
            }
        }

        return new string(acronymChars);
    }
}