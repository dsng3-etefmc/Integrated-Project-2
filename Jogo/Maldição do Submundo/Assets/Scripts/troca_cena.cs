using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //biblioteca para trocar de cena

public class troca_cena : MonoBehaviour {
    public Object scene;
    BoxCollider2D collider;

    void Start() {
        collider = GetComponent<BoxCollider2D>();
    }

    void Update() {
        
    }

    // Change scene to target scene
    public void chamaCena() {
        try {
            SceneManager.LoadScene(this.scene.name);
        } catch {}
    } 
    //-----------------------------------------
    //-----------------troca de fase - fase 1 -----------------------------------

    // void OnCollisionEnter2D(Collision2D coll) {
    //     if (coll.gameObject.tag == "Player") {
    //         SceneManager.LoadScene(SceneValue);
    //     }
    // }
}