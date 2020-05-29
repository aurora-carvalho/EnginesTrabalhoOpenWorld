using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float intervalo;
    public float quantidade;
    public GameObject prefabs;
    private float tempo;

    private void Start()
    {
        tempo = intervalo;
    }

    private void Update()
    {
        tempo += Time.deltaTime;
        if (tempo >= intervalo)
        {
            tempo = 0;
            for (int i = 0; i < quantidade; i++)
            {
                Instantiate(prefabs, transform.position, transform.rotation);
            }
        }
    }
}
