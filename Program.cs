using System;

namespace SearchingSystem
{
    class MainClass
    {
        static string[] sentences = {
            "Hello, how are you",
            "How to make a bot",
            "I made a twitter bot in c#",
            "C++ GUI tutorial",
            "Bye! i will see you tomorrow" };

        static string input;
        static char[] punctuation = {'!', ',', ':', ';', '?', '.', '[', ']', '(', ')' };
        static string searchCommand = "srch";

        public static void Main(string[] args)
        {
            Console.WriteLine("EXAMPLE SEARCH SENTENCES \n");
            for (int i = 0; i < sentences.Length; i++)
            {
                Console.WriteLine(sentences[i]);
            }
            Console.WriteLine("");
            Console.WriteLine("use the command: " + searchCommand + " <STRING> to search");
            Console.WriteLine("");
            getInput();
        }

        static void getInput() {
            input = Console.ReadLine();
            string result = ScanInput();

            Console.WriteLine(" ");

            Console.WriteLine(result);
            getInput();
        }

        static string ScanInput() {
            string[] inputWords = input.Split();
            string[] sentenceWords;

            if (inputWords.Length >= 2) {

                string fullSentence = "";
                string[] usedSentences = new string[100];
                int index = 0;

                bool hasSentence = false;
                bool notFound = true;

                // ACTUAL SEARCHING

                if (inputWords[0].ToLower() == searchCommand) {
                    for (int i = 0; i < sentences.Length; i++) {
                        sentenceWords = sentences[i].Split();

                        for (int iW = 0; iW < inputWords.Length-1; iW++){
                            for (int sW = 0; sW < sentenceWords.Length; sW++) {

                                string sWord = sentenceWords[sW].ToLower(); // gets a sentence word
                                string iWord = inputWords[iW+1].ToLower(); // gets an input word

                                if (sWord.TrimEnd(punctuation) == iWord) {
                                    hasSentence = false;
                                    for (int sen = 0; sen < usedSentences.Length; sen++) {
                                        if (sentences[i] == usedSentences[sen]) hasSentence = true;
                                    }

                                    if (!hasSentence) {
                                        notFound = false;
                                        fullSentence += sentences[i] + " \n";
                                        usedSentences[index] = sentences[i];
                                        index++;
                                    }
                                }
                            }
                        }
                    }
                    if (notFound) return "result not found";
                    return fullSentence;
                }
            }
            return "search command: <" + searchCommand + "> not used or nothing to search";
        }
    }
}
