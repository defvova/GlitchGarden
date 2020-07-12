using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int currentStars = 100;
    private Text starDisplay;

    private void Start()
    {
        starDisplay = GetComponent<Text>();
        UpdateStarsText();
    }

    private void UpdateStarsText()
    {
        starDisplay.text = currentStars.ToString();
    }

    public void AddingStars(int amount)
    {
        currentStars += amount;
        UpdateStarsText();
    }

    public void SpendingStars(int amount)
    {
        if (currentStars >= amount)
        {
            currentStars -= amount;
            UpdateStarsText();
        }
    }

    public bool HaveEnoughStars(int amount)
    {
        return amount <= currentStars;
    }
}