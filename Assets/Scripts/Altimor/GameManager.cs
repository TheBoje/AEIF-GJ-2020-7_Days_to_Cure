using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    private const int nbIngredients = 3;
    public Dictionary<string, string> ingredients;
    private Dictionary<string, string> solution;

    public TextMeshPro text;
    public GameObject player;
    public GameObject bowl;

    private void Start()
    {
        ingredients = new Dictionary<string, string>();
        
        ingredients.Add("Test1", "Mmmmmh le bon test");
        ingredients.Add("Test2", "Encore du test ?");
        ingredients.Add("Test3", "Relou la en fait");
    }

    public Dictionary<String, String> ChooseAntidote()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        
        Random random = new Random();

        for (int i = 0; i < nbIngredients; i++)
        {
            int rand = random.Next(ingredients.Count);
            dic.Add(ingredients.ElementAt(rand).Key, ingredients.ElementAt(rand).Value);
        }

        return dic;
    }

    public void printOnTvScreen()
    {
        
    }
    
    
}
