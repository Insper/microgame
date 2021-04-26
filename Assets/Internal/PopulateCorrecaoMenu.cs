using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PopulateCorrecaoMenu : MonoBehaviour
{
    public GameObject btnPrefab;
    private void Awake()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        for (int i = 0; i < sceneCount; i++)
        {
            
            GameObject newButton = Instantiate(btnPrefab);
            //Capturo o Path para as cenas  
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            //Caputuro apenas o nome da cena
            Group matchGroup = Regex.Match(scenePath, @"Microjogos\/(\w+)").Groups[1];
            // Defino o texto do botão com o nome da cena
            newButton.GetComponentInChildren<Text>().text = $"{matchGroup}";

            //Defino o id para o funcionamneot do botão
            newButton.GetComponent<LoadTargetScene>().sceneID = i;

            newButton.GetComponent<Button>().onClick.AddListener(newButton.GetComponent<LoadTargetScene>().Load);



            //Defino o botão como filho do canvas, que está regido por um GridLayout
            newButton.transform.SetParent(transform);
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
