using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar : MonoBehaviour
{
    public Vector2 aceleracao;
    public float velocidade;
    public LayerMask camada;
    public float altura;
    public static Vector3 posicaojogador;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.zero;
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotation = transform.eulerAngles;
        rotation.y += mouseX * aceleracao.x * Time.deltaTime;
        rotation.x += -mouseY * aceleracao.y * Time.deltaTime;
        rotation.z = 0;
        transform.eulerAngles = rotation;

        float movHori = Input.GetAxis("Horizontal");
        float movVert = Input.GetAxis("Vertical");

        Vector3 posi = transform.position;
        transform.Translate(movHori * velocidade * Time.deltaTime, 0, 
            movVert * velocidade * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, camada))
        {
            posicaojogador = hit.point;
            posi.y = hit.point.y + altura;
        }

        transform.position = new Vector3(transform.position.x, posi.y, transform.position.z);
    }
}
