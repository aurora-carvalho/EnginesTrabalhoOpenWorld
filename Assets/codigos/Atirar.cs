using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public GameObject tiro;
    public Transform posicaotiro;
    public float forca;
    public float intervalo;
    public bool automatico;

    float comeco, fim;

    private void Start()
    {
        comeco = Time.deltaTime;
        fim = comeco;
    }

    private void Update()
    {
        fim += Time.deltaTime;
        if (fim - comeco < intervalo)
        {
            return;
        }

        bool shoot = false;

        if (automatico)
        {
            shoot = Input.GetMouseButton(0);
        }
        else
        {
            shoot = Input.GetMouseButtonDown(0);
        }

        if (shoot)
        {
            fim = comeco;
            GameObject bulletGb = Instantiate<GameObject>(tiro, posicaotiro.position, transform.rotation);
            Rigidbody bulleRb = bulletGb.GetComponent<Rigidbody>();
            bulleRb.AddForce(transform.forward * forca, ForceMode.Impulse);
        }
    }
}
