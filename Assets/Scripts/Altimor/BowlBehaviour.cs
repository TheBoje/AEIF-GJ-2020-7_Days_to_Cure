using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlBehaviour : MonoBehaviour
{
    private bool dailyTest;
    private bool hasContent;
    [SerializeField] private int averageDangerosity;

    public GameObject gm;
    private GameManager gmScript;

    private List<Color> ingredientsColors;
    private List<String> ingredientsName;
    
    private Color colorAverage;
    public GameObject content;
    
    private void Start()
    {
        dailyTest = false;
        hasContent = false;
        content.GetComponent<MeshRenderer>().enabled = hasContent;
        ingredientsColors = new List<Color>();
        ingredientsName = new List<string>();
        gmScript = gm.GetComponent<GameManager>();
    }

    public void toogleContent()
    {
        content.GetComponent<MeshRenderer>().enabled = hasContent;
    }
    
    public void ComputeColor()
    {
        float r = 0f;
        float g = 0f;
        float b = 0f;
        float a = 0f;
        
        foreach (Color c in ingredientsColors)
        {
            r += c.r;
            g += c.g;
            b += c.b;
            a += c.a;
        }

        r /= (float)ingredientsColors.Count;
        g /= (float)ingredientsColors.Count;
        b /= (float)ingredientsColors.Count;
        a /= (float)ingredientsColors.Count;

        colorAverage.r = r;
        colorAverage.g = g;
        colorAverage.b = b;
        colorAverage.a = a;
        
        content.GetComponent<Renderer>().material.SetColor("_Color", colorAverage);
    }

    public void Fill(string ingredientName, Color color, int dangerosity)
    {
        ingredientsName.Add(ingredientName);
        ingredientsColors.Add(color);
        averageDangerosity += dangerosity;
        ComputeColor();
        hasContent = true;
        toogleContent();
        gmScript.PrintIngredient(ingredientName);
    }

    public int AverageDangerosity => averageDangerosity;

    public List<string> IngredientsName => ingredientsName;

    public void Pour()
    {
        dailyTest = true;
        hasContent = false;
    }

    public bool DailyTested => dailyTest;
        
    public bool IsFull()
    {
        return ingredientsName.Count == 3;
    }
}
