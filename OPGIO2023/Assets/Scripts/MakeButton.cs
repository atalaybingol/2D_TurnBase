using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{

    [SerializeField] private bool physical;

    private GameObject hero;


    // Start is called before the first frame update
    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        hero = GameObject.FindGameObjectWithTag("Hero");
    }

    private void AttachCallback(string btn)
    {
        if(btn.CompareTo("MeleeBtn") == 0)
        {
            Debug.Log("sadfg");
            //hero.GetComponent<HeroAction>().SelectAttack("Melee");
        } else if(btn.CompareTo("DefenceBtn") == 0)
        {
            hero.GetComponent<HeroAction>().SelectAttack("Defence");
        }else if(btn.CompareTo("SlashBtn") == 0)
        {
            hero.GetComponent<HeroAction>().SelectAttack("Slash");
        }else if(btn.CompareTo("ItemBtn") == 0)
        {
            hero.GetComponent<HeroAction>().SelectAttack("Item");
        } else
        {
            hero.GetComponent<HeroAction>().SelectAttack("Fire");
        }
    }
}
