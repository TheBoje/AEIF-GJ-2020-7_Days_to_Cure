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
        solution = new Dictionary<string, string>();
        
        ingredients.Add("Test1", "Mmmmmh le bon test");
        ingredients.Add("Test2", "Encore du test ?");
        ingredients.Add("Test3", "Relou la en fait");
        ingredients.Add("Test4", "Relou la en fait");
        ingredients.Add("Test5", "Relou la en fait");
        ingredients.Add("Test6", "Relou la en fait");
        ingredients.Add("Test7", "Relou la en fait");
        ingredients.Add("Test8", "Relou la en fait");
        
        ChooseAntidote();
        
        /*solution.Add("Test1", "Mmmmmh le bon test");
        solution.Add("Test2", "Encore du test ?");
        solution.Add("Test3", "Relou la en fait");
        */
        
        printOnTvScreen();
    }

    public void ChooseAntidote()
    {
        Random random = new Random();
        List<int> nbrs = new List<int>();

        for (int i = 0; i < nbIngredients; i++)
        {
            int rand = random.Next(ingredients.Count);
            while (nbrs.Contains(rand))
            {
                rand = random.Next(ingredients.Count);
            }
            solution.Add(ingredients.ElementAt(rand).Key, ingredients.ElementAt(rand).Value);
        }
    }

    public void printOnTvScreen()
    {
        text.text = "";
        foreach (var key in solution)
        {
            text.text += "- " + key.Key + " : " + key.Value + "\n";
        }
    }

    public void nextDay()
    {
        
    }
    
    
}
