using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CiceroValentim
{
    public class Controller : MonoBehaviour
    {
        public GameObject ingredientsSource;

        public CiceroValentim.GameManager gm;

        GameObject[] ingredients;

        GameObject currentObject;

        int selected = 0;

        List<GameObject> children = new List<GameObject>();

        void Start()
        {
            this.ingredients = gm.ingredients;
            this.currentObject =
                Instantiate(ingredients[selected],
                this.ingredientsSource.transform.position,
                Quaternion.identity);
        }

        void Update()
        {
            if (Input.GetKeyDown("up"))
            {
                this.SelectNext();
            }
            else if (Input.GetKeyDown("down"))
            {
                this.SelectPrevious();
            }
            else if (Input.GetKeyDown("space"))
            {
                GameObject selectedIngredient = this.ingredients[selected];
                GameObject child =
                    Instantiate(selectedIngredient,
                    this.ingredientsSource.transform.position,
                    Quaternion.identity);
                child.GetComponent<Rigidbody2D>().gravityScale = 1;
                this.children.Add(child);
                this.Replace();
                this.Compare();
            }
        }

        void SelectPrevious()
        {
            selected -= 1;
            if (selected <= -1)
            {
                selected = this.ingredients.Length - 1;
            }
            this.Replace();
        }

        void SelectNext()
        {
            selected += 1;
            if (selected >= this.ingredients.Length)
            {
                selected = 0;
            }

            this.Replace();
        }

        void Replace()
        {
            Destroy (currentObject);
            currentObject =
                Instantiate(ingredients[selected],
                this.ingredientsSource.transform.position,
                Quaternion.identity);

            currentObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        void Compare()
        {
            if (!this.CheckConditions()) gm.GameLost();
        }

        Boolean CheckConditions()
        {
            int expectedSize = gm.orderedBurger.Count;
            int currentSize = children.Count;

            if (currentSize > expectedSize) return false;

            for (int i = 0; i < currentSize; i++)
            {
                CiceroValentim.IngredientDescriptor chosenType =
                    children[i]
                        .GetComponent<CiceroValentim.IngredientBehavior>()
                        .type;
                CiceroValentim.IngredientDescriptor correctType =
                    gm
                        .orderedBurger[i]
                        .GetComponent<CiceroValentim.IngredientBehavior>()
                        .type;
                if (chosenType != correctType)
                {
                    return false;
                }
            }

            return true;
        }

        public Boolean LastCheck()
        {
            return gm.orderedBurger.Count == children.Count &&
            CheckConditions();
        }
    }
}
