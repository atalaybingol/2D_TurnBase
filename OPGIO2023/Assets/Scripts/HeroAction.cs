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

    private GameObject currentAttack;
    //private GameObject meleeAttack;
    //private GameObject rangeAttack;

    public void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    public void SelectAttack(string btn)
    {
        GameObject victim = hero;
        if(tag == "Hero")
        {
            victim = enemy;
        }

        if(btn.CompareTo("Melee") == 0)
        {
            if(meleePrefab == null)
            {
                Debug.Log(this.gameObject.name);
                meleePrefab = this.gameObject.transform.GetChild(0).gameObject;
            } else
            {
                Debug.Log("Not null");
            }
            meleePrefab.GetComponent<AttackScript>().Attack(victim);

        } else if(btn.CompareTo("Range") == 0)
        {

            rangePrefab.GetComponent<AttackScript>().Attack(victim);
        
        } else
        {
            Debug.Log("Fire!");
        }
    }
}
