using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_script : MonoBehaviour {

    public int maxHealth = 100;
    public int health = 100;
    
    public int maxActionPoints = 4;
    public int actionPoints = 4;
    
    public int maxSpellPoints = 4;
    public int spellPoints = 4;
    public int spellAttackDamage = 30;
    
    public int lightAttackDamage = 10;
    public int hardAttackDamage = 30;
    
    public float avoidChance = 0.2f; // 20% chance to avoid damage

    private bool isTurn = false;

    private Dice d6 = new Dice(6);

    void Start () {
        int rollResult = d6.RollM(2);
        Debug.Log("The 2d6 roll result is " + rollResult);        // Initialize player stats
        health = maxHealth;
        actionPoints = maxActionPoints;
        spellPoints = maxSpellPoints;
    }

    void Update () {
        if (isTurn) {
            // If it's the player's turn, allow them to take actions
            // TODO: Add input detection for actions
        }
    }

    public void StartTurn() {
        // Player starts turn, enable isTurn flag
        isTurn = true;
    }

    public void EndTurn() {
        // Regenerate action points and end turn
        actionPoints = maxActionPoints;
        isTurn = false;
    }

    public void TakeDamage(int damage) {
        // Check if player avoids damage
        if (Random.value > avoidChance) {
            // Player did not avoid damage, take damage and check if dead
            health -= damage;
            if (health <= 0) {
                // Player died, game over
                Debug.Log("Game over");
            }
        } else {
            // Player avoided damage, do nothing
        }
    }

    public void LightAttack() {
        if (actionPoints >= 2) {
            // Deduct action points and apply light attack damage to the enemy
            actionPoints -= 2;
            Debug.Log("Player used light attack");
        } else {
            Debug.Log("Not enough action points");
        }
    }

    public void HardAttack() {
        if (actionPoints >= 3) {
            // Deduct action points and apply hard attack damage to the enemy
            actionPoints -= 3;
            Debug.Log("Player used hard attack");
        } else {
            Debug.Log("Not enough action points");
        }
    }

    public void SpellAttack() {
        if (actionPoints >= 2 && spellPoints > 0) {
            // Deduct action points and spell points, and apply spell attack damage to the enemy
            actionPoints -= 2;
            spellPoints--;
            Debug.Log("Player used spell attack");
        } else {
            Debug.Log("Not enough action points or spell points");
        }
    }

    public void Defend() {
        if (actionPoints >= 3) {
            // Deduct action points and apply defence bonus
            actionPoints -= 3;
            Debug.Log("Player used defence");
        } else {
            Debug.Log("Not enough action points");
        }
    }

    public void UseItem() {
        if (actionPoints >= 1) {
            // Deduct action points and apply item effect
            actionPoints -= 1;
            Debug.Log("Player used item");
        } else {
            Debug.Log("Not enough action points");
        }
    }   
}