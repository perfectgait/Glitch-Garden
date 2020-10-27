using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();

        if (costText)
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
        else
        {
            Debug.LogError(name + " has no cost, add some!");
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();

        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = Color.black;
        }

        GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
