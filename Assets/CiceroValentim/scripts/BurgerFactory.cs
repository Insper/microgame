using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Random = UnityEngine.Random;

namespace CiceroValentim
{
    public class BurgerFactory
    {
        public static List<GameObject>
        GetBurger(GameObject[] ingredients, int difficulty)
        {
            List<GameObject> burger = new List<GameObject>();
            burger.Add(ingredients[0]); // pão

            for (int i = 0; i < 3 + difficulty; i++)
            {
                int randomIndex = Random.Range(1, ingredients.Length - 1);
                burger.Add(ingredients[randomIndex]);
            }

            burger.Add(ingredients[ingredients.Length - 1]); // pão
            return burger;
        }
    }
}
