using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float duracao;
    public ParticleSystem particulas;
    public bool destroicolide;
    float tempo = 0;

    private void Update()
    {
        tempo += Time.deltaTime;
        if (tempo >= duracao)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Inimigo")
        {
            Vida vida = collision.gameObject.GetComponent<Vida>();
            vida.vida = vida.vida - 10;
        }
        if (destroicolide)
        {
            Destroy(gameObject);
        }
        else
        {
            particulas.Play();
        }
    }
}
