using System.Globalization;

namespace TrainingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            do
            {
                Console.WriteLine("Enter a string (or press q to quit):");
                string? input = Console.ReadLine();
                if (input!.Equals("q", StringComparison.OrdinalIgnoreCase))
                {
                    quit = true;
                    break;
                }

                bool operationsMenu = true;
                while (operationsMenu)
                {
                    Console.WriteLine("Select an operation:");
                    Console.WriteLine("a. Convert to uppercase");
                    Console.WriteLine("b. Reverse string");
                    Console.WriteLine("c. Count vowels");
                    Console.WriteLine("d. Count words");
                    Console.WriteLine("e. Convert to title case");
                    Console.WriteLine("f. Check palindrome");
                    Console.WriteLine("g. Find longest and shortest words");
                    Console.WriteLine("h. Find most frequent word");
                    Console.WriteLine("i. Enter new string");
                    Console.WriteLine("q. Quit");

                    ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                    Console.WriteLine();

                    switch (keyInfo.KeyChar)
                    {
                        case 'a':
                            Console.WriteLine($"Uppercase string: {input.ToUpper()}");
                            break;
                        case 'b':
                            char[] chars = input.ToCharArray();
                            Array.Reverse(chars);
                            string reversed = new string(chars);
                            Console.WriteLine($"Reversed string: {reversed}");
                            break;
                        case 'c':
                            int vowelCount = input.Count(c => "aeiouAEIOU".Contains(c));
                            Console.WriteLine($"Number of vowels: {vowelCount}");
                            break;
                        case 'd':
                            int wordCount = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
                            Console.WriteLine($"Number of words: {wordCount}");
                            break;
                        case 'e':
                            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                            string titleCase = textInfo.ToTitleCase(input.ToLower());
                            Console.WriteLine($"Title case string: {titleCase}");
                            break;
                        case 'f':
                            bool isPalindrome = input.SequenceEqual(input.Reverse());
                            Console.WriteLine($"Is palindrome: {isPalindrome}");
                            break;
                        case 'g':
                            List<string> words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                            string? longest = words.OrderByDescending(w => w.Length).FirstOrDefault();
                            string? shortest = words.OrderBy(w => w.Length).FirstOrDefault();
                            Console.WriteLine($"Longest word: {longest}");
                            Console.WriteLine($"Shortest word: {shortest}");
                            break;
                        case 'h':
                            Dictionary<string, int> wordCountMap = new Dictionary<string, int>();
                            foreach (string word in input.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                            {
                                if (wordCountMap.ContainsKey(word))
                                {
                                    wordCountMap[word]++;
                                }
                                else
                                {
                                    wordCountMap[word] = 1;
                                }
                            }
                            string mostFrequent = wordCountMap.OrderByDescending(w => w.Value).FirstOrDefault().Key;
                            Console.WriteLine($"Most frequent word: {mostFrequent}");
                            break;
                        case 'i':
                            operationsMenu = false;
                            break;
                        case 'q':
                            operationsMenu = false;
                            quit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            } while (!quit);
        }
    }
}


