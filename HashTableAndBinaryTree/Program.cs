namespace HashTableAndBinaryTree
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("HashTable Program");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Hint 1.FindFequencyIn Sentence 2.FindFequencyParagraph3.Exist");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        string para = "To be or not to be";
                        CountNumbOfOccurence(para);
                        break;
                    case 2:
                        string paragraph = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
                        CountNumbOfOccurence(paragraph);
                        break;
                    case 3:
                        flag =false;
                        Console.WriteLine("Exist");
                        break;
                }
            }
        }
        public static void CountNumbOfOccurence(string paragraph)
        {
            MyNodeClass<string, int> hashTabe = new MyNodeClass<string, int>(6);
            string[] words = paragraph.Split(' ');

            foreach (string word in words)
            {
                if (hashTabe.Exists(word.ToLower()))
                    hashTabe.Add(word.ToLower(), hashTabe.Get(word.ToLower()) + 1);
                else
                    hashTabe.Add(word.ToLower(), 1); //to,1 
            }
            Console.WriteLine(" Frequency of words in sentence");
            hashTabe.Display();
        }
    }
}
