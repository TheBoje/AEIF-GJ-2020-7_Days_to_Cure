using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    private const int nbIngredients = 3;
    
    [SerializeField] private Dictionary<string, string> ingredients;
    private Dictionary<string, string> solution;
    
    public Dictionary<String, String> ChooseAntidote()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        
        Random random = new Random();

        for (int i = 0; i < nbIngredients; i++)
        {
            int rand = random.Next(ingredients.Count);
            
        }

        return dic;
    }
}
