using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class enemy_script : MonoBehaviour {

    public int health = 100;
    public int attackDamage = 10;
    public float avoidChance = 0.1f; // 10% chance to avoid damage

    private bool isTurn = false;

    void Start () {
        // Player not yet implemented, no need to find it
    }

    void Update () {
        if (isTurn) {
            // If it's the enemy's turn, attack the player and end turn
            if (Random.value > avoidChance) {
                // Player did not avoid damage, do nothing
            } else {
                // Player avoided damage, do nothing
            }
            EndTurn();
        }
    }

    public void StartTurn() {
        // Enemy starts turn, enable isTurn flag
        isTurn = true;
    }

    public void EndTurn() {
        // Enemy ends turn, disable isTurn flag
        isTurn = false;
    }

    public void TakeDamage(int damage) {
        // Check if enemy avoids damage
        if (Random.value > avoidChance) {
            // Enemy did not avoid damage, take damage and check if dead
            health -= damage;
            if (health <= 0) {
                Destroy(gameObject);
            }
        } else {
            // Enemy avoided damage, do nothing
        }
    }
}
