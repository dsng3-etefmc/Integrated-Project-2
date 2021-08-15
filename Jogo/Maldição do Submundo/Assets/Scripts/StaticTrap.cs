using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTrap : MonoBehaviour
{
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("dale");
        }
    }

 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("dele");
        }
    }
}
