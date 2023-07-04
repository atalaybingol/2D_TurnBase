using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public int healthPoints;
    public int attackPower;
    public int defense;
    public int manaPoints;

    private bool hasPerformedAction;
    
    public void PerformAttack(CharacterController target)
    {
        Debug.Log("Perform normal attack");
        int damage = CalculateDamage(target.defense);
        target.TakeDamage(damage);
        hasPerformedAction = true;
    }

    public void PerformPowerAttack(CharacterController target)
    {
        Debug.Log("Perform power attack");
        int damage = CalculateDamage(target.defense) + 10;
        target.TakeDamage(damage);
        manaPoints -= 10;
        hasPerformedAction = true;
    }

    public void Defend()
    {
        Debug.Log("Perform defense");
        defense += 10;
    }

    private int CalculateDamage(int targetDefense)
    {
        return attackPower - targetDefense;
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetTurn()
    {
        hasPerformedAction = false;
    }

    public bool HasPerformedAction()
    {
        return hasPerformedAction;
    }
}
