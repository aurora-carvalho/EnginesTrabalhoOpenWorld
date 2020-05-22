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
