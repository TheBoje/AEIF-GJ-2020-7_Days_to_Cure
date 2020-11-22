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
    private const int D_NOT_BAD = 0;
    private const int D_SHIT = 10;
    private const int D_VOMIT = 15;
    private const int D_DEATH = 30;


    public static bool firstStart = true;
    private static string indications = "";
    private static List<string> saves = new List<string>();
    private static List<string> saveseffects = new List<string>();
    
    private const int nbIngredients = 3;
    public Dictionary<string, string> ingredients;
    private static Dictionary<string, string> solution;
    private List<string> addedIngredients;
    private string printAddedIngredients;
    private string effect;
    
    public TextMeshPro text;
    public GameObject player;
    public GameObject bowl;
    public GameObject calendar;

    private Player playerScript;
    private BowlBehaviour bowlScript;
    private CalendrierManager calManager;

    private void Awake()
    {
        DontDestroyOnLoad(this);
       
        //Debug.Log(indications);
        //text.text = indications;
        
        playerScript = player.GetComponent<Player>();
        bowlScript = bowl.GetComponent<BowlBehaviour>();
        calManager = calendar.GetComponent<CalendrierManager>();
    }

    private void Start()
    {
        effect = "rien\n";
        printAddedIngredients = "";
        addedIngredients = new List<string>();
        text.SetText(indications);
        if (firstStart)
        {
            ingredients = new Dictionary<string, string>();
            solution = new Dictionary<string, string>();
            
            ingredients.Add("Huile usagée", "Mmmmmh le bon test");
            ingredients.Add("Ethanol", "Encore du test ?");
            ingredients.Add("urine", "Relou la en fait");
            
        
            ChooseAntidote();
            ComputeIndications();
            text.SetText(indications);
            firstStart = false;
        }
        UpdateCalendar();
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

    public void UpdateCalendar()
    {
        for(int i = 0; i < saves.Count; i++)
        {
            calManager.AddJour(saves[i] + saveseffects[i]);
        }
    }

    public void nextDay()
    {
        // reload la scene an gardant le game manager et le calendrier ? avec un fondu au noir ?
        saves.Add(printAddedIngredients);
        saveseffects.Add(effect);
        Destroy(text.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //UpdateCalendar();
    }

    public void PrintIngredient(string ingredientName)
    {
        printAddedIngredients += "- " + ingredientName + "\n";
        text.text += "- " + ingredientName + "\n";
        addedIngredients.Add(ingredientName);
    }

    private bool CmpSolutionIngredients()
    {
        for (int i = 0; i < solution.Count; i++)
        {
            if (!addedIngredients.Contains(solution.ElementAt(i).Key))
                return false;
        }

        return true;
    }

    public void Drink()
    {
        
        int danger = bowlScript.AverageDangerosity;
        bowlScript.Pour();
        Debug.Log("et glou et glou");
        
        if (CmpSolutionIngredients())
        {
            Debug.Log("Bravo c'est gagné");
        }
        else
        {
            //La condition sans fin que l'on attendez tous
        }
    }
}
