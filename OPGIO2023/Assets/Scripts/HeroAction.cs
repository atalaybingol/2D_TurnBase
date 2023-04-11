using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject hero;

    [SerializeField]
    private GameObject meleePrefab;

    [SerializeField]
    private GameObject rangePrefab;

    [SerializeField]
    private Sprite faceIcon;

    private GameObject currentAttack;
    private GameObject meleeAttack;
    private GameObject rangeAttack;

    public void SelectAttack(string btn)
    {
        GameObject victim = hero;
        if(tag == "Hero")
        {
            victim = enemy;
        }

        if(btn.CompareTo("Melee") == 0)
        {
            Debug.Log("Melee Attack");
        } else if(btn.CompareTo("Defence") == 0)
        {
            Debug.Log("Shield Up");
        }else if(btn.CompareTo("Slash") == 0)
        {
            Debug.Log("Slash Attack");
        }else if(btn.CompareTo("Item") == 0)
        {
            Debug.Log("Item Used");
        } else
        {
            Debug.Log("Fire!");
        }
    }
}
