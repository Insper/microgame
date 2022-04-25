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
        public AudioSource ding;
        private bool victory = false;
        public Canvas buttons;
        private MicrogameInternal.GameManager gm;

        // Start is called before the first frame update
        void Start(){
            gm = MicrogameInternal.GameManager.GetInstance();
            init_words();
            Generate_Challenge();
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            gm.StartTimer();
        }

        void EndCheck(){
            // If player hasn't won by end of time, they lose.
            if(!this.victory) gm.GameLost();
        }

        Word select_word(){
            int difficulty = gm.ActiveLevel;
            int index;
            if (difficulty <= 1){
                index = Random.Range(0,13); // [0-12] = Easy
            } else if(difficulty <= 2) {
                index = Random.Range(13,28); // [13-27] = Easy-Medium
            } else if(difficulty <= 3) {
                index = Random.Range(28,44); // [28-43] = Medium-Hard
            } else if( difficulty <= 5) {
                index = Random.Range(44,57); // [44-56] = Hard
            } else if( difficulty <= 6) {
                index = Random.Range(57,this.word_list.Count); // [57-73] = GLHF
            } else {
                // Should not happen, just in case
                index = Random.Range(0,this.word_list.Count);
            }
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
            // Generated using python
            
            // Easy [0-12]
            word_list.Add(construct_anagramed_word("pena", "epna", "npee", "ppen", "aaen"));
            word_list.Add(construct_anagramed_word("taco", "toac", "actt", "ttca", "ttao"));
            word_list.Add(construct_anagramed_word("tubo", "btuo", "butt", "oobt", "touu"));
            word_list.Add(construct_anagramed_word("pano", "pona", "ppan", "oaap", "ppao"));
            word_list.Add(construct_anagramed_word("rede", "ered", "eede", "eedd", "rdee"));
            word_list.Add(construct_anagramed_word("mito", "oitm", "mtti", "imtt", "tmmo"));
            word_list.Add(construct_anagramed_word("caos", "caso", "coos", "accs", "aooc"));
            word_list.Add(construct_anagramed_word("auge", "aeug", "auug", "gauu", "eauu"));
            word_list.Add(construct_anagramed_word("suma", "smua", "ssmu", "mmua", "saam"));
            word_list.Add(construct_anagramed_word("fase", "fsea", "sffe", "aaef", "feaa"));
            word_list.Add(construct_anagramed_word("rima", "aimr", "immr", "riaa", "rria"));
            word_list.Add(construct_anagramed_word("pose", "epos", "poee", "ospp", "opss"));
            word_list.Add(construct_anagramed_word("deus", "seud", "uedd", "dssu", "euud"));
            word_list.Add(construct_anagramed_word("alma", "mala", "amml", "aaml", "allm"));

            // Medium [13-27]
            word_list.Add(construct_anagramed_word("arroz", "arorz", "oorrz", "aazor", "aorrr"));
            word_list.Add(construct_anagramed_word("abaco", "acabo", "aaaob", "abboa", "abcaa"));
            word_list.Add(construct_anagramed_word("palco", "paocl", "aalco", "aacpo", "paalc"));
            word_list.Add(construct_anagramed_word("ritmo", "itmor", "ritoo", "oritt", "iirom"));
            word_list.Add(construct_anagramed_word("sopro", "ooprs", "sooop", "sporr", "rsopp"));
            word_list.Add(construct_anagramed_word("sagaz", "saazg", "agaas", "aggaz", "szaaa"));
            word_list.Add(construct_anagramed_word("senso", "ensos", "sseno", "sssoe", "nsess"));
            word_list.Add(construct_anagramed_word("nobre", "bonre", "neoor", "boeen", "obeen"));
            word_list.Add(construct_anagramed_word("fazer", "fzera", "azfee", "zffer", "farzz"));
            word_list.Add(construct_anagramed_word("sutil", "siutl", "iutss", "tusii", "ssiul"));
            word_list.Add(construct_anagramed_word("honra", "hrona", "hhora", "haorr", "hharo"));
            word_list.Add(construct_anagramed_word("moral", "moarl", "molrr", "mrral", "amool"));
            word_list.Add(construct_anagramed_word("lapso", "olaps", "ppaso", "laaps", "oappl"));
            word_list.Add(construct_anagramed_word("digno", "dgnoi", "gdiio", "odiin", "niggd"));
            word_list.Add(construct_anagramed_word("mundo", "dmuno", "mondd", "nuoom", "mddou"));

            // Medium-Hard [28-43]
            word_list.Add(construct_anagramed_word("banana", "aananb", "nnanaa", "bbnnaa", "aaanna"));
            word_list.Add(construct_anagramed_word("moinho", "mohino", "moonhh", "omminh", "oomnho"));
            word_list.Add(construct_anagramed_word("cortar", "cartor", "ortraa", "ctorra", "caotrr"));
            word_list.Add(construct_anagramed_word("espada", "edpasa", "eapdaa", "eedaap", "ssaade"));
            word_list.Add(construct_anagramed_word("alcool", "lcaool", "accool", "lloloa", "olcloo"));
            word_list.Add(construct_anagramed_word("mantra", "namtra", "rannma", "tmnnra", "mnartt"));
            word_list.Add(construct_anagramed_word("utopia", "utipao", "utaoop", "uoiita", "oittua"));
            word_list.Add(construct_anagramed_word("casual", "acsual", "ccasal", "llsuca", "ascall"));
            word_list.Add(construct_anagramed_word("anseio", "aonsei", "ansiio", "aseinn", "insaee"));
            word_list.Add(construct_anagramed_word("idiota", "idotai", "iiotda", "ioiita", "aidott"));
            word_list.Add(construct_anagramed_word("hostil", "hsoitl", "soltti", "hlliot", "hhilts"));
            word_list.Add(construct_anagramed_word("solene", "olense", "lsoone", "seelne", "esslen"));
            word_list.Add(construct_anagramed_word("eficaz", "cfieaz", "eziccf", "cfiize", "eeicfa"));
            word_list.Add(construct_anagramed_word("rotina", "otirna", "otiaar", "nrtioo", "rraino"));
            word_list.Add(construct_anagramed_word("objeto", "jboeto", "obbtoe", "oojeob", "oojeet"));
            word_list.Add(construct_anagramed_word("apatia", "paatia", "aatiaa", "aaatip", "aatpii"));

            // Hard [44-56]
            word_list.Add(construct_anagramed_word("rebarba", "berarba", "rbareea", "ebarrra", "reeaarb"));
            word_list.Add(construct_anagramed_word("nitidez", "enitidz", "nitdeei", "znntiei", "iiidezt"));
            word_list.Add(construct_anagramed_word("empatia", "emataip", "meaaiap", "pemaaai", "tmaeiia"));
            word_list.Add(construct_anagramed_word("sucinto", "suicnto", "ccinsto", "ssnitoc", "sunoitt"));
            word_list.Add(construct_anagramed_word("cultura", "cuultra", "tuucura", "ucuutar", "caultrr"));
            word_list.Add(construct_anagramed_word("estigma", "mestiga", "mseiita", "esttami", "gsetiia"));
            word_list.Add(construct_anagramed_word("virtude", "vietudr", "itrrdev", "itvruue", "vrtdeii"));
            word_list.Add(construct_anagramed_word("mitigar", "miigatr", "iitmgaa", "rimigaa", "ritgamm"));
            word_list.Add(construct_anagramed_word("imputar", "mpuiatr", "imuprra", "timuarr", "ippuamr"));
            word_list.Add(construct_anagramed_word("alegria", "leariag", "gleeraa", "igelrra", "laageia"));
            word_list.Add(construct_anagramed_word("contudo", "toncudo", "uontcdd", "coutddn", "codnoot"));
            word_list.Add(construct_anagramed_word("sensato", "esnsato", "seonsaa", "sesntoo", "seesnao"));
            word_list.Add(construct_anagramed_word("excesso", "excosse", "eoceesx", "oxeessc", "exeecos"));

            // GLHF [57-73]
            word_list.Add(construct_anagramed_word("torrente", "teorrtne", "orteerte", "treentre", "otrereet"));
            word_list.Add(construct_anagramed_word("escaldar", "aelscadr", "sllcadar", "eeslacar", "caldarss"));
            word_list.Add(construct_anagramed_word("inerente", "ieernten", "irenneee", "eeentnei", "renentii"));
            word_list.Add(construct_anagramed_word("peculiar", "puecrlia", "ppuiaerl", "pceeulra", "aecciurp"));
            word_list.Add(construct_anagramed_word("respeito", "respieto", "eerspiio", "iespreoo", "reetsieo"));
            word_list.Add(construct_anagramed_word("prudente", "ptredenu", "ppuneetr", "peunndte", "tprunnde"));
            word_list.Add(construct_anagramed_word("invasivo", "onvasivi", "invaaovi", "issvinvo", "iisaivno"));
            word_list.Add(construct_anagramed_word("alienado", "aaienldo", "adllieao", "ailaeeod", "aaeadnol"));
            word_list.Add(construct_anagramed_word("abstrato", "aboratst", "bboaratt", "rbbstoat", "obbstraa"));
            word_list.Add(construct_anagramed_word("ardiloso", "oarilsdo", "aaldsioo", "oadirsoo", "oidrlaas"));
            word_list.Add(construct_anagramed_word("conserto", "scontero", "csonttro", "oseccton", "cotnssoe"));
            word_list.Add(construct_anagramed_word("relativo", "oelrativ", "vreattol", "erolaiit", "aellrvio"));
            word_list.Add(construct_anagramed_word("demagogo", "oemadogg", "gemaoood", "damoegoo", "emaadggo"));
            word_list.Add(construct_anagramed_word("complexo", "cmolpexo", "cemmlpxo", "opmleeoc", "pomxlcoo"));
            word_list.Add(construct_anagramed_word("instigar", "insigtar", "tnsgiiaa", "iastinnr", "ingtiraa"));
            word_list.Add(construct_anagramed_word("refletir", "eefltrir", "efretirr", "efiietlr", "lrrfetie"));
            word_list.Add(construct_anagramed_word("paralelo", "laparelo", "llraoelp", "paeallro", "rrlelaop"));
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
            validate_input(button0_word);
        }

        public void button1(){
            validate_input(button1_word);
        }
        
        public void button2(){
            validate_input(button2_word);
        }
        
        public void button3(){
            validate_input(button3_word);
        }

        void validate_input(Anagram anag){
            if(this.victory) return;
            if(anag.real){
                ding.Play();
                Debug.Log("Correct!");
                this.victory = true;
                buttons.gameObject.SetActive(false);
                Goal.text = "Muito bem!";
            } else {
                // Perdeu, vai pro GameLost
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