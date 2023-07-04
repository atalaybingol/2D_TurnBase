using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public CharacterController[] players;

    public CharacterController[] enemies;

    //public GameObject[] actionButtons; // Add this line to declare the actionButtons variable


    public CharacterController CurrentPlayer { get; private set; }

    private int currentTurnIndex;

    private Coroutine turnCoroutine;

    public void Start()
    {
        Debug.Log("Turn manager started");
        StartTurnCycle();
    }

    public void StartTurnCycle()
    {
        currentTurnIndex = 0;
        turnCoroutine = StartCoroutine(TurnCycle());
    }

    private IEnumerator TurnCycle()
    {
        Debug.Log("Turn Cycle");
        while (true)
        {
            bool allPlayersActioned = true;
            foreach (CharacterController player in players)
            {
                if (!player.HasPerformedAction())
                {
                    allPlayersActioned = false;
                    break;
                }
            }

            if (allPlayersActioned)
            {
                foreach (CharacterController player in players)
                {
                    player.ResetTurn();
                }

                /*
                foreach (GameObject button in actionButtons)
                {
                    ActionButton actionButton = button.GetComponent<ActionButton>();
                    actionButton.SetCharacter(players[currentTurnIndex]);
                }
                */  
                foreach (CharacterController enemy in enemies)
                {
                    enemy.PerformAttack(RandomPlayer());
                    yield return new WaitForSeconds(1f);
                }
            }
            
            Debug.Log(CurrentPlayer);
            CurrentPlayer = players[currentTurnIndex];

            currentTurnIndex = (currentTurnIndex + 1) % players.Length;
            yield return null;
        }
    }

    private CharacterController RandomPlayer()
    {
        int randomIndex = Random.Range(0, players.Length);
        return players[randomIndex];
    }
}
