using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float enemyRange;
    [SerializeField] private float GizmosHeight;

    [SerializeField] private Timer cooldown;


    void Update()
    {
        DoEnemyAttack();
    }
    /// <summary>
    /// Hanterar banditens/fienders attack
    /// </summary>
    private void DoEnemyAttack()
    {
        if (cooldown.CooldownFinished())
        {
            return;
        }

        // Samma sak som i interact systemet som jag har snott med lite utbytta saker
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, enemyRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent<PlayerStatus>(out PlayerStatus status))
            {
                Debug.Log("Attacked with player");
                Global.PlayerStatus.healthPoints -= 10;
            }
        }
        cooldown.SetCooldown();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y + GizmosHeight), enemyRange);
    }
}
