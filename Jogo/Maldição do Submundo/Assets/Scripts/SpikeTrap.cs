using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpikeTrap : MonoBehaviour
{
    public bool isActive = false;
    public float time = 15f;

    private Animator animator;

    bool shouldAttack = false;

    public void setActive()
    {
        this.isActive = true;
    }


    void Start()
    {

        this.animator = GetComponent<Animator>();

        StartCoroutine(StartTrap());
    }

    IEnumerator StartTrap()
    {
        while (true)
        {

            this.shouldAttack = false;

            yield return new WaitForSeconds(this.time);

            this.LaunchSpikes();
            this.shouldAttack = true;

            yield return new WaitForSeconds(this.time);

            this.RetractSpikes();

        }
    }

    void RetractSpikes()
    {
        this.animator.SetTrigger("retractSpike");
    }

    void LaunchSpikes()
    {
        this.animator.SetTrigger("setSpike");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && this.shouldAttack)
        {
            Debug.Log("Player damaged by spike");
        }
    }
}