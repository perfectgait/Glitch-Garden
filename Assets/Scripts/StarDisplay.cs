using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;

        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        // Don't let the player spend more than they have
        if (amount > stars)
        {
            return;
        }

        stars -= amount;

        UpdateDisplay();
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }
}
