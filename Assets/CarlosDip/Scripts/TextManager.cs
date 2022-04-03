using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dip {
    public class TextManager : MonoBehaviour
    {
        
        private class Word {
            public string word; 
            public List<Anagram> anags;
            public Word(string word){
                this.word = word;
                anags = new List<Anagram>();
            }        
        }
        private class Anagram {
            public string word;
            public bool real;
            public Anagram(string word){
                this.word = word;
                this.real = false;
            }
            public Anagram(string word, bool real){
                this.word = word;
                this.real = real;
            }
        }
        public Text Goal;
        public Text Option0,Option1,Option2,Option3;
        private List<Word> word_list = new List<Word>();
        private Anagram button0_word, button1_word, button2_word, button3_word;
        private bool victory = false;
        private MicrogameInternal.GameManager gm;

        // Start is called before the first frame update
        void Start(){
            gm = MicrogameInternal.GameManager.GetInstance();
            init_words();
            Generate_Challenge();
        }

        Word select_word(){
            // TODO: Implemente dificulty
            int index = Random.Range(0,this.word_list.Count);
            return this.word_list[index];
        }

        void Generate_Challenge(){
            Word selected_word = this.select_word();
            Goal.text = selected_word.word;
            Option0.text = selected_word.anags[0].word;
            Option1.text = selected_word.anags[1].word;
            Option2.text = selected_word.anags[2].word;
            Option3.text = selected_word.anags[3].word;
            button0_word = selected_word.anags[0];
            button1_word = selected_word.anags[1];
            button2_word = selected_word.anags[2];
            button3_word = selected_word.anags[3];
        }

        void init_words(){
            // generated using pyhton
            word_list.Add(construct_anagramed_word("taco", "cato", "ttoa", "actt", "otaa"));
            word_list.Add(construct_anagramed_word("tubo", "btuo", "ttob", "ottb", "utto"));
            word_list.Add(construct_anagramed_word("pano", "napo", "poaa", "aano", "anpp"));
            word_list.Add(construct_anagramed_word("pena", "pnae", "aaen", "nppa", "pann"));
            word_list.Add(construct_anagramed_word("rede", "eder", "eedd", "eree", "reee"));
            word_list.Add(construct_anagramed_word("abaco", "abaoc", "cabaa", "oobac", "bacoo"));
            word_list.Add(construct_anagramed_word("arroz", "oarrz", "rrooz", "aaorz", "aaror"));
            word_list.Add(construct_anagramed_word("palco", "aplco", "opaac", "pcloo", "cappo"));
            word_list.Add(construct_anagramed_word("ritmo", "rotmi", "oiimr", "ttimo", "riomm"));
            word_list.Add(construct_anagramed_word("sopro", "soopr", "ppsro", "rsopp", "roppo"));
            word_list.Add(construct_anagramed_word("banana", "aanbna", "nbaaaa", "bnnaaa", "abnaaa"));
            word_list.Add(construct_anagramed_word("moinho", "minoho", "moniio", "ommnhi", "iinhmo"));
            word_list.Add(construct_anagramed_word("cortar", "coatrr", "rcortt", "caorrr", "ortacc"));
            word_list.Add(construct_anagramed_word("espada", "easpda", "speeda", "aessad", "sppead"));
            word_list.Add(construct_anagramed_word("mantra", "mntara", "aaantr", "mmnara", "mmntar"));
            word_list.Add(construct_anagramed_word("alcool", "aloocl", "llccoa", "aoccol", "aclool"));
            word_list.Add(construct_anagramed_word("rebarba", "rbaerba", "rerabba", "rebbraa", "eeaarbr"));
            word_list.Add(construct_anagramed_word("nitidez", "neitidz", "niizdee", "ittidzn", "eiidtzn"));
            word_list.Add(construct_anagramed_word("torrente", "troreent", "eerrntet", "trreeoet", "otrreeet"));
            word_list.Add(construct_anagramed_word("escaldar", "ecsldaar", "earssdac", "eddalcsr", "eacdallr"));
            word_list.Add(construct_anagramed_word("explosivo", "xpolesivo", "oolpesivo", "eeposixlo", "eollxsivo"));
        }

        private Word construct_anagramed_word(string word, string a1, string a2, string a3, string a4){
            Word w = new Word(word);
            w.anags.Add(new Anagram(a1, true));
            w.anags.Add(new Anagram(a2));
            w.anags.Add(new Anagram(a3));
            w.anags.Add(new Anagram(a4));
            w.anags = shuffle(w.anags);
            return w;
        }

        public void button0(){
            validate_input(button0_word.real);
        }

        public void button1(){
            validate_input(button1_word.real);
        }
        
        public void button2(){
            validate_input(button2_word.real);
        }
        
        public void button3(){
            validate_input(button3_word);
        }

        void validate_input(Anagram anag){
            if(this.victory) return;
            if(anag.real){
                Debug.Log("Correct!");
                this.victory = true;
            } else {
                MicrogameInternal.GameManager.GetInstance().GameLost();
            }
        }

        // Adapted from https://forum.unity.com/threads/clever-way-to-shuffle-a-list-t-in-one-line-of-c-code.241052/
        // Fischer-Yates shuffle
        private List<Anagram> shuffle(List<Anagram> inputList)
        {    //take any list of Anagrams and return it with Fischer-Yates shuffle
            int i = 0;
            int t = inputList.Count;
            int r = 0;
            Anagram p = null;
            List<Anagram> tempList = new List<Anagram>();
            tempList.AddRange(inputList);
        
            while (i < t)
            {
                r = Random.Range(i,tempList.Count);
                p = tempList[i];
                tempList[i] = tempList[r];
                tempList[r] = p;
                i++;
            }
        
            return tempList;
        }
    }
}