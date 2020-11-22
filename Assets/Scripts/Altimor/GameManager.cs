using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    public static bool firstStart = true;
    private static string indications = "";
    
    private const int nbIngredients = 3;
    public Dictionary<string, string> ingredients;
    private Dictionary<string, string> solution;

    

    public TextMeshPro text;
    public GameObject player;
    public GameObject bowl;

    private Player playerScript;
    private BowlBehaviour bowlScript;

    private void Awake()
    {
        DontDestroyOnLoad(this);
       
        
        //Debug.Log(indications);
        //text.text = indications;
        
        playerScript = player.GetComponent<Player>();
        bowlScript = bowl.GetComponent<BowlBehaviour>();
    }

    private void Start()
    {
        text.SetText(indications);
        if (firstStart)
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
            ComputeIndications();
            text.SetText(indications);
            firstStart = false;
        }
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
            nbrs.Add(rand);
            solution.Add(ingredients.ElementAt(rand).Key, ingredients.ElementAt(rand).Value);
        }
    }

    public void ComputeIndications()
    {
        indications = "On sait que le virus SHRARS-32 n'aime pas : \n";
        foreach (var key in solution)
        {
            indications += "- " + key.Value + "\n";
        }

        indications += "Vous avez ajouté :\n";
    }

    public void nextDay()
    {
        // reload la scene an gardant le game manager et le calendrier ? avec un fondu au noir ?
        Destroy(text.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void PrintIngredient(string ingredientName)
    {
        text.text += "- " + ingredientName + "\n";
    }
    
    
}
