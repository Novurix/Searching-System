using System;

namespace SearchingSystem
{
    class MainClass
    {
        static string[] sentences = {"Hello, how are you", "Bye! i will see you tomorrow"};
        static string input;

        public static void Main(string[] args)
        {

            for (int i = 0; i < sentences.Length; i++)
            {
                Console.WriteLine(sentences[i]);
            }
            getInput();
        }

        static void getInput() {
            input = Console.ReadLine();
            string result = ScanInput();

            Console.WriteLine(" ");
            Console.WriteLine(result);
            Console.WriteLine(" ");
            getInput();
        }

        static string ScanInput() {
            string[] inputWords = input.Split();
            string[] sentenceWords;

            if (inputWords.Length == 2) { 
                if (inputWords[0].ToLower() == "search") {
                    for (int i = 0; i < sentences.Length; i++)
                    {
                        sentenceWords = sentences[i].Split();

                        for (int iW = 0; iW < inputWords.Length-1; iW++){
                            for (int sW = 0; sW < sentenceWords.Length; sW++) {

                                string sWord = sentenceWords[sW].ToLower(); // gets a sentence word
                                string iWord = inputWords[iW+1].ToLower(); // gets an input word

                                if (sWord.StartsWith(iWord)) {
                                    return sentenceWords[sW] + " found in sentence: [" + (i+1) + "]";

                                }
                            }
                        }
                    }
                }
            }
            else if (inputWords.Length > 2)
            {
                string fullSentence = "";

                if (inputWords[0].ToLower() == "search") {
                    for (int i = 0; i < sentences.Length; i++) {
                        sentenceWords = sentences[i].Split();

                        for (int iW = 0; iW < inputWords.Length-1; iW++){
                            for (int sW = 0; sW < sentenceWords.Length; sW++) {

                                string sWord = sentenceWords[sW].ToLower(); // gets a sentence word
                                string iWord = inputWords[iW+1].ToLower(); // gets an input word

                                if (sWord.StartsWith(iWord)) {
                                fullSentence += sentenceWords[sW] + " found in sentence: [" + (i+1) + "] \n";
                                }
                            }
                        }
                    }

                    return fullSentence;
                }
            }
            return "result not found";
        }
    }
}
