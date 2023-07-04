using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ActionType
{
    NormalAttack,
    Defense,
    PowerAttack
}

public class ActionButton : MonoBehaviour
{
    public CharacterController character;

    public ActionType actionType;

    /*
    public void SetCharacter(CharacterController characterController)
    {
        character = characterController;
    }
    */

    public void OnClick()
    {
        if (!character.HasPerformedAction())
        {
            switch (actionType)
            {
                case ActionType.NormalAttack:
                    PerformNormalAttack();
                    break;
                case ActionType.Defense:
                    PerformDefense();
                    break;
                case ActionType.PowerAttack:
                    PerformPowerAttack();
                    break;
            }
        }
    }

    public void PerformNormalAttack()
    {
        Debug.Log("Normal Attack");
        CharacterController target = GetRandomEnemy();
        character.PerformAttack(target);
    }

    public void PerformDefense()
    {
        Debug.Log("Defense");
        character.Defend();
    }

    public void PerformPowerAttack()
    {
        Debug.Log("Power Attack");
        CharacterController target = GetRandomEnemy();
        character.PerformPowerAttack(target);
    }

    public CharacterController GetRandomEnemy()
    {
        CharacterController[] enemies = GameObject.FindObjectsOfType<CharacterController>();
        if (enemies.Length > 0)
        {
            int randomIndex = Random.Range(0, enemies.Length);
            return enemies[randomIndex];
        }

        return null;
    }

}
