using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAinimigo : MonoBehaviour
{
    public enum IAestado { Atacando, Andando, }

    public float dano;
    public Animator animator;
    IAestado estado;
    NavMeshAgent agent;
    Vida vida;
    Vida vidajogador;
     
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        vida = GetComponent<Vida>();
        vidajogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>();
    }

    private void Update()
    {
        if (vida.vida <= 0)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject, 1);
            enabled = false;
        }
        else if (agent.isStopped)
        {
            estado = IAestado.Atacando;
            animator.SetBool("Walk Forward", false);
            animator.SetTrigger("Stab Attack");
            vidajogador.vida -= dano * Time.deltaTime;
        }
        else
        {
            estado = IAestado.Andando;
            animator.SetBool("Walk Forward", true);
        }
    }
}
