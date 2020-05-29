using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movimentoinimigo : MonoBehaviour
{
    public float distanciadojogador;
    private NavMeshAgent agente;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Vector3 posicaojogador = Andar.posicaojogador;
        agente.SetDestination(posicaojogador);
        float distancia = Vector3.Distance(transform.position, posicaojogador);
        if (distancia < distanciadojogador)
        {
            agente.isStopped = true;
        }
        else
        {
            agente.isStopped = false;
        }
    }
}
