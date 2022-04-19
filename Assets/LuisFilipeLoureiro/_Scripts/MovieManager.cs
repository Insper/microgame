using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MovieManager : MonoBehaviour
{


    public SpriteRenderer sr;
    public List<Sprite> movies = new List<Sprite>();
    private int selectedMovie = 0;
    public GameObject playermovie;
    public GameObject question;
    public GameObject instructions;
    private int randomNumber;
    private Dictionary<int, int> dictionary = new Dictionary<int, int>();

    private bool check_instructions = false;

    private MicrogameInternal.GameManager gm;

    public GameObject result;
    public float keyDelay = 0.3f;  // 0.3 second
    private float timePassed = 0f;
    
    
    public GameObject selectButton;

    private List<string> questions = new List<string>();

    

    
    

    public void NextOption(){
    
        selectedMovie = selectedMovie + 1;       
        
        if(selectedMovie == movies.Count){
            selectedMovie = 0;
        }
        sr.sprite = movies[selectedMovie];
        
        Debug.Log(selectedMovie);        
    }

    

    
    public void BackOption(){
        
        selectedMovie = selectedMovie -1;
        
        if(selectedMovie < 0){
            selectedMovie = movies.Count - 1;
        }
        sr.sprite = movies[selectedMovie];
        Debug.Log(selectedMovie);
            
    }
    // Start is called before the first frame update
    void Start()
    {

        gm = MicrogameInternal.GameManager.GetInstance();
        Invoke(nameof(Begin), 0.5f);

        randomNumber = Random.Range(0, 8);
        //Debug.Log(randomNumber);
        questions.Add("Qual o filme mais arrecadou na abertura?"); //era uma vez
        questions.Add("Qual o filme com mais bilheteria do Tarantino?");  //django
        questions.Add("Qual o filme mais sangrento do Tarantino?");  //kill bill 
        questions.Add("Qual o filme com mais palavrão do Tarantino?"); //pulp fiction
        questions.Add("Qual o filme com menos palavrão do Tarantino?"); //hateful
        questions.Add("Qual o filme com maior número de prêmios BAFTA?"); //once upon
        questions.Add("Qual o filme com maior número de prêmios Golden Globes?"); //  pulp
        questions.Add("Qual o filme foi inspirado em uma missão do serviço secreto americano?"); //  bastardos


        dictionary.Add(0,2);
        dictionary.Add(1,0);
        dictionary.Add(2,3);
        dictionary.Add(3,5);
        dictionary.Add(4,1);
        dictionary.Add(5,2);
        dictionary.Add(6,5);
        dictionary.Add(7,4);                 
        
        question.GetComponent<Text>().text = questions[randomNumber];        
        
    }

    public void SelectOption(){


        
        if(selectedMovie != dictionary[randomNumber]){
            result.GetComponent<Text>().text = "Incorreto ...";
            Debug.Log("ERRO");
            gm.GameLost();
        }else{
            result.GetComponent<Text>().text = "Correto !!!";
            Debug.Log("ACERTO");
            selectButton.SetActive(false);
            
        }
        


    }
    void Begin() {
        Invoke(nameof(SelectOption), gm.MaxTime-0.1f);
        gm.StartTimer();

    }
    // Update is called once per frame
    void Update()
    {

        timePassed += Time.deltaTime;

        if(Input.GetKey(KeyCode.RightArrow) && timePassed >= keyDelay){
            NextOption();
            timePassed = 0f;
            if(check_instructions == false){
                instructions.SetActive(false);
                check_instructions = true;
            }
        }
        if(Input.GetKey(KeyCode.LeftArrow) && timePassed >= keyDelay){
            BackOption();
            timePassed = 0f;
             if(check_instructions == false){
                instructions.SetActive(false);
                check_instructions = true;
            }
        }

        if(Input.GetKey(KeyCode.Space) && timePassed >= keyDelay){
            SelectOption();
            timePassed = 0f;
        }

        
        
    }
}


//Referencias:

// [1] - https://forum.unity.com/threads/how-to-make-a-button-that-disappears-when-clicked.545304/
// [2] - https://www.youtube.com/watch?v=ZzcyREamMUo
// [3] - https://www.youtube.com/watch?v=thqNYDOOLF8&t=181s
// [4] - https://www.youtube.com/watch?v=8ogyT842otg&t=316s



