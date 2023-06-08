using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    private List<UnitStats> unitsStats;

    [SerializeField]
    private GameObject actionsMenu, enemyUnitsMenu;
    
    void Start()
    {
        unitsStats = new List<UnitStats>();
        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject playerUnit in playerUnits)
        {
            UnitStats currentUnitStats = playerUnit.GetComponent<UnitStats>();
            currentUnitStats.calculateNextActTurn(0);
            unitsStats.Add(currentUnitStats);
        }

        GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemyUnit in enemyUnits)
        {
            UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats>();
            currentUnitStats.calculateNextActTurn(0);
            unitsStats.Add(currentUnitStats);
        }

        unitsStats.Sort();

        this.actionsMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(false);
        this.nextTurn();
    }
    
    public void nextTurn()
    {
        UnitStats currentUnitStats = unitsStats[0];
        unitsStats.Remove(currentUnitStats);

        if (!currentUnitStats.isDead())
        {
            GameObject currentUnit = currentUnitStats.gameObject;

            currentUnitStats.calculateNextActTurn(currentUnitStats.nextActTurn);

            unitsStats.Add(currentUnitStats);
            unitsStats.Sort();

            if (currentUnit.tag == "Player")
            {
                Debug.Log("Player Turn");
            }
            else
            {
                Debug.Log("Enemy Turn");
            }
        }
        else
        {
            this.nextTurn();
        }
    }
}
