using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //biblioteca para trocar de cena

public class troca_cena : MonoBehaviour
{
    public Object cena; //variavel para trocar de cena
    public Object cena2 ; ////variavel para trocar para "saiba mais" 

    public int SceneValue;
    BoxCollider2D collider;

    void Start() //só faz uma vez
    {
        collider = GetComponent<BoxCollider2D>();
    }

    void Update() //faz mais de uma vez
    {
        
    }
    //---------------------troca de fase menu-----------------
    public void chamaCena() //troca
    {
        SceneManager.LoadScene(this.cena.name); //linha de cod para trocar de cena
    } 
    public void chamaCenaSaibaMais() //troca
    {
        SceneManager.LoadScene(this.cena2.name); //linha de cod para trocar de cena
    } 
    //-----------------------------------------
    //-----------------troca de fase - fase 1 -----------------------------------

    void OnCollisionEnter2D(Collision2D coll) {
    if (coll.gameObject.tag == "Player")
     {
        SceneManager.LoadScene(SceneValue);
     }
    }
}



