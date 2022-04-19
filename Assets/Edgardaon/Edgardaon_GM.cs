using System;
using UnityEditor.U2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Edgardaon
{
    public class Edgardaon_GM : MonoBehaviour
    {
        private List<int> input_list = new List<int>();
        private List<int> task_list = new List<int>();

        public List<AudioClip> sounds_list = new List<AudioClip>();

        public List<List<Color32>> colors_list = new List<List<Color32>>();

        public List<Button> buttons_list;

        public AudioClip lose_sound;
        public AudioSource audio_source;

        public CanvasGroup buttons;

        private MicrogameInternal.GameManager gm;
        private int _level;
        public GameObject instructions;  // Texto das instruções


        bool IsListsEqual(List<int> a, List<int> b)
        {
            if (a.Count == b.Count)
            {
                for (int i = 0; i < b.Count; ++i)
                {
                    if (a[i] != b[i]) return false;
                }
                return true;
            }
            else return false;
        }

        IEnumerator HighlightButton(int button_id)
        {
            buttons_list[button_id].GetComponent<Image>().color = colors_list[button_id][1];
            audio_source.PlayOneShot(sounds_list[button_id]);
            yield return new WaitForSeconds(0.5f);
            buttons_list[button_id].GetComponent<Image>().color = colors_list[button_id][0];
        }

        void Awake()
        {
            colors_list.Add(new List<Color32> { new Color32(255,100,100,255), new Color32(255,0,0,255) }); // red color
            colors_list.Add(new List<Color32> { new Color32(255,187,109,255), new Color32(255,136,0,255) }); // orange color
            colors_list.Add(new List<Color32> { new Color32(162,255,124,255), new Color32(72,248,0,255) }); // green color
            colors_list.Add(new List<Color32> { new Color32(57,111,255,255), new Color32(0,70,255,255) }); // blue color
            for (int i = 0; i < 4; ++i)
            {
                buttons_list[i].GetComponent<Image>().color = colors_list[i][0];
            }
        }

        void Start()
        {
            //Debug.Log("Start");
            gm = MicrogameInternal.GameManager.GetInstance();
            _level = gm.ActiveLevel <= 2 ? gm.ActiveLevel : 2;
            //Debug.Log("Level: "+_level);
            Invoke(nameof(Begin), 0.5f);                         
        }

        void Begin()
        {
            //Debug.Log("Start Game");
            instructions.SetActive(false);  // Tira tela de instruções
            if (task_list.Count > 0) task_list.Clear();
            StartCoroutine(StartNextRound());
            //start_button.SetActive(false);
             // Rotina do start
            //Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            //gm.StartTimer();
        }

        IEnumerator LostGame()
        {
            audio_source.PlayOneShot(lose_sound);
            input_list.Clear();
            task_list.Clear();
            yield return new WaitForSeconds(2f);
            //start_button.SetActive(true);
            gm.GameLost();
        }

        IEnumerator StartNextRound()
        {
            input_list.Clear();
            buttons.interactable = false;
            yield return new WaitForSeconds(1f);
            // Gera sequência aleatória
            for (int i = 0; i < 2*(_level+1); ++i)
            {
                task_list.Add(Random.Range(0,4));
            }
            
            foreach (int item in task_list)
            {
                yield return StartCoroutine(HighlightButton(item));
            }
            buttons.interactable = true;
             // Rotina do start
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            gm.StartTimer();
            yield return null;
        }

        public void AddInputList(int button_id)
        {
            input_list.Add(button_id);
            StartCoroutine(HighlightButton(button_id));
            for (int i = 0; i < input_list.Count; ++i)
            {
                if (input_list[i] == task_list[i])
                    continue;
                else
                {
                    //Debug.Log("Lost");
                    StartCoroutine(LostGame());
                    return;
                }
            }
            if (input_list.Count == task_list.Count)
            {
                //Debug.Log("Ganhou");
                buttons.interactable = false;
                //StartCoroutine(StartNextRound());
            }
        }

        void EndCheck()
        {
            if (!IsListsEqual(input_list,task_list)) gm.GameLost();
        }
    }
}

