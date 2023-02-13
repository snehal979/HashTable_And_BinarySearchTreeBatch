namespace HashTableAndBinaryTree
{
    class Program
    {
        public static void Main(string[] args)
        {
            MyNodeClass<string, int> hashTabe = new MyNodeClass<string, int>(6);
            string para = "To be or not to be";
            string paragraph = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";

            Console.WriteLine("HashTable Program");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Hint 1.FindFequencyIn Sentence 2.FindFequencyParagraph 3.Remove Word 4.Exist");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CountNumbOfOccurence(para, hashTabe);
                        break;
                    case 2:
                        CountNumbOfOccurence(paragraph, hashTabe);
                        break;
                    case 3:
                        RemoveWord(paragraph, hashTabe);
                        break;
                    case 4:
                        flag =false;
                        Console.WriteLine("Exist");
                        break;
                }
            }
        }
        /// <summary>
        /// Uc1,2-Find fequency word in sentenance
        /// </summary>
        /// <param name="paragraph"></param>
        /// <param name="hashTable"></param>
        public static void CountNumbOfOccurence(string paragraph, MyNodeClass<string, int> hashTable)
        {
            string[] words = paragraph.Split(' ');

            foreach (string word in words)
            {
                if (hashTable.Exists(word.ToLower()))
                    hashTable.Add(word.ToLower(), hashTable.Get(word.ToLower()) + 1);
                else
                    hashTable.Add(word.ToLower(), 1); //to,1 
            }
            Console.WriteLine(" Frequency of words in sentence");
            hashTable.Display();
        }
        /// <summary>
        /// Uc3-Remove Word
        /// </summary>
        /// <param name="paragraph"></param>
        /// <param name="hashTable"></param>
        public static void RemoveWord(string paragraph, MyNodeClass<string, int> hashTable)
        {
            CountNumbOfOccurence(paragraph,hashTable);
            Console.WriteLine("--------------------");
            string word = "avoidable";
            hashTable.Remove(word);
            hashTable.Display();
        }
    }
}
