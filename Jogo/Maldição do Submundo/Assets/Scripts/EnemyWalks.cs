using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class EnemyWalks : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private float radiousOfSight;
 
    void Start()
    {
    }
 
    void Update()
    {
        float distance = Vector2.Distance(Player.current.transform.position, transform.position);
        if (distance <= radiousOfSight) {
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        var playerPos = Player.current.transform.position;

        // Moves enemy towards the player
        transform.position = Vector2.MoveTowards(
            transform.position, 
            playerPos,
            enemySpeed * Time.deltaTime
        );
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiousOfSight);
    }
}
