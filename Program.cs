using System;

namespace SearchingSystem
{
    class MainClass
    {
        static string[] exampleSentences = {
            "Hello, how are you",
            "How to make a bot",
            "I made a twitter bot in c#",
            "C++ GUI tutorial",
            "Bye! i will see you tomorrow" };

        static string input;
        static char[] punctuation = {'!', ',', ':', ';', '?', '.', '[', ']', '(', ')' };
        static string searchCommand = "srch";

        static Sentence[] sentence;

        public static void Main(string[] args)
        {
            sentence = new Sentence[exampleSentences.Length];

            Console.WriteLine("EXAMPLE SEARCH SENTENCES \n");
            for (int i = 0; i < exampleSentences.Length; i++)
            {
                sentence[i] = new Sentence(exampleSentences[i]);
                Console.WriteLine(exampleSentences[i]);
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
                bool notFound = true;

                // ACTUAL SEARCHING

                if (inputWords[0].ToLower() == searchCommand) {


                    for (int i = 0; i < sentence.Length; i++) {
                        if (sentence[i] != null) {
                            sentence[i].hasBeenListed = false;
                            sentence[i].accuracy = 0;
                        }
                    }

                    for (int i = 0; i < sentence.Length; i++) {
                        sentenceWords = sentence[i].sentence.Split();

                        for (int inputWord = 0; inputWord < inputWords.Length-1; inputWord++){
                            for (int sW = 0; sW < sentenceWords.Length; sW++) {

                                string sWord = sentenceWords[sW].ToLower(); // gets a sentence word
                                string iWord = inputWords[inputWord+1].ToLower(); // gets an input word

                                if (sWord.TrimEnd(punctuation) == iWord.TrimEnd(punctuation)) {
                                    sentence[i].increaseAccuracy((float)1 / sentenceWords.Length);

                                    notFound = false;
                                    for (int j = 0; j < sentence.Length; j++) {
                                        if (sentence[j].accuracy > .5f && inputWords.Length > 2) {

                                            if (!sentence[j].hasBeenListed){
                                                sentence[j].hasBeenListed = true;
                                                fullSentence += sentence[j].sentence + " \n";
                                            }
                                        }
                                        else if (inputWords.Length == 2) {
                                            for (int sen = 0; sen < sentence.Length; sen++)
                                            {
                                                string[] newSentenceWords = sentence[sen].sentence.Split();
                                                foreach (string senWord in newSentenceWords) {

                                                    string SentenceWord = senWord.ToLower().TrimEnd(punctuation);
                                                    string cInputWord = inputWords[1].ToLower();

                                                    if (SentenceWord == cInputWord) {
                                                        fullSentence = sentence[sen].sentence;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (notFound) return "result not found";
                    return fullSentence;
                }
            }
            return "search command: <" + searchCommand + "> not used or there's nothing to search";
        }
    }
}
