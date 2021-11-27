using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int SceneValue;
    BoxCollider2D coll;


    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(SceneValue);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        print("touching");
        if (coll.gameObject.tag == "Player")
        {
            print("Player touching");
            SceneManager.LoadScene(SceneValue);
        }
    }

}