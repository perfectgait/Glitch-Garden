using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    const string DEFENDER_PARENT_NAME = "Defenders";

    Defender defender;
    GameObject defenderParent;

    // Start is called before the first frame update
    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);

        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetGridPositionClicked());
    }

    private Vector2 GetGridPositionClicked()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);

        return SnapToGrid(worldPosition);
    }

    private Vector2 SnapToGrid(Vector2 worldPosition)
    {
        float newX = Mathf.RoundToInt(worldPosition.x);
        float newY = Mathf.RoundToInt(worldPosition.y);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 worldPosition)
    {
        if (!defender)
        {
            return;
        }

        Defender newDefender = Instantiate(defender, worldPosition, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPosition)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();

        if (!starDisplay.HaveEnoughStars(defenderCost))
        {
            return;
        }

        SpawnDefender(gridPosition);
        starDisplay.SpendStars(defenderCost);
    }
}
