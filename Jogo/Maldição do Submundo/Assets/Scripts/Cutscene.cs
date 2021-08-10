using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{

    public GameObject cameraCut;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") //se o Player colidir com o objeto
        {
           cameraCut.SetActive(true); //Cutscene começa
        }
    }
}
