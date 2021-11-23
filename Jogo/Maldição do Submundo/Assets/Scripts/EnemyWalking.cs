using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalking : MonoBehaviour
{
    public float velocidadeDoInimigo;
    private Transform posicaoDoJogador;

    void Start()
    {
        posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").transform; //detectar a tag do jogador e depois acessa o componente transform
    }

 
    void Update()
    {
        if(posicaoDoJogador.gameObject != null){
            //mivimntar o game object ate algum lugar, a segunda parte diz qual é esse lugar 
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoJogador.position, velocidadeDoInimigo * Time.deltaTime);

        }
    }
}
