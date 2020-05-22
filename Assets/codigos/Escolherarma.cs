using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escolherarma : MonoBehaviour
{
    public GameObject[] listaarmas;
    public int armaatual = 0;

    private void Awake()
    {
        listaarmas[0].SetActive(true);
        for (int i = 1; i < listaarmas.Length; i++)
        {
            listaarmas[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            listaarmas[armaatual].SetActive(false);
            armaatual = ++armaatual % listaarmas.Length;
            listaarmas[armaatual].SetActive(true);

        }
    }
}
