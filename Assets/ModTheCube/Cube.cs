using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Color cor;

    float velocidade;
    float tempo = 0f;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.localScale = Vector3.one * 1.3f;

        cor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Renderer.material.color = cor;

        velocidade = Random.Range(5f, 50f); // velocidade inicial
    }

    void Update()
    {
        transform.Rotate(velocidade * Time.deltaTime, 0.0f, 0.0f);

        tempo += Time.deltaTime;

        // muda a velocidade a cada 2 segundos
        if (tempo > 2f)
        {
            velocidade = Random.Range(5f, 50f);
            tempo = 0f;
        }
    }
}