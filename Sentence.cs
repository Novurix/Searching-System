using System;
namespace SearchingSystem
{
    public class Sentence
    {
        public string sentence = "";
        public float accuracy = 0;

        public bool hasBeenListed = false;

        public Sentence(string sentence)
        {
            this.sentence = sentence;
        }

        public void increaseAccuracy(float accuracy)
        {
            this.accuracy += accuracy;
            //Console.WriteLine(sentence + " " + this.accuracy);
        }
    }
}
