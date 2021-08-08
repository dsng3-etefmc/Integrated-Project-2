using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //biblioteca para trocar de cena

public class troca_cena : MonoBehaviour
{
    public Object cena; //variavel para trocar de cena
   
    void Start() //só faz uma vez
    {
        
    }

    void Update() //faz mais de uma vez
    {
        
    }
    public void chamaCena() //troca
    {
        SceneManager.LoadScene(this.cena.name); //linha de cod para trocar de cena
    } 
 

}
