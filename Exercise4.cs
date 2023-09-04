class Exercise4{
    public void isAnagram(){
        Console.WriteLine("Enter the first word:");
        string? word1 = Console.ReadLine();

        Console.WriteLine("Enter the second word:");
        string? word2 = Console.ReadLine();
        
        if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2) || word1.Length != word2.Length)
        {
            Console.WriteLine("Not anagrams or one of the words is null or empty.");
            return;
        }
        else
        {
            /* CONVERTING THE STRINGS TO CHAR THEN SORTING IT. THE IDEA BEHIND IT IS THAT THEY WILL BE TREATED AS NUMERICAL VALUES (CHAR ENCODING) SO WHEN CONVERTED BACK TO STRINGS THEY WILL BE THE SAME IF ANAGRAMS
            char[] char1 = word1.ToCharArray();
            char[] char2 = word2.ToCharArray();
    
            Array.Sort(char1);
            Array.Sort(char2);*/
            
            // USING DICTIONARIES to check for anagrams is to count the occurrences of each character in both words and then compare these counts.

            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach (var ch in word1)
            {
                if (counts.ContainsKey(ch))
                {
                    counts[ch]++;
                }
                else
                {
                    counts[ch] = 1;
                }
            }

            foreach (var ch in word2)
            {
                if (counts.ContainsKey(ch))
                {
                    counts[ch]--;
                }
                else
                {
                    Console.WriteLine("Not anagrams or one of the words is null or empty.");
                    return;
                }
            }            

            if (counts.Values.All(count => count == 0))
            {
                Console.WriteLine($"{word1} is an anagram of {word2}");
            }
            else
            {
                Console.WriteLine("Not anagrams or one of the words is null or empty.");
            }

        }
    }   
}