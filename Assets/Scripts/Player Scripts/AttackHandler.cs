using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    public static bool Attackable = false;
    public static EnemyStatus GrabbedEnemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckIfAttackable(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Attackable = false;
    }

    void CheckIfAttackable(GameObject checkedObject)
    {
        if (checkedObject.TryGetComponent<EnemyStatus>(out EnemyStatus enemyStatus) == true)
        {
            Attackable = true;
            GrabbedEnemy = enemyStatus;
            Debug.Log("Collided with hostile");
        }
    }
}
