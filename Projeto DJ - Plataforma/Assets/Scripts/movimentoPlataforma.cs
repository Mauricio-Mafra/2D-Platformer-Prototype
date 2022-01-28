using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPlataforma : MonoBehaviour
{
    private Rigidbody2D rbd;
    private Vector2 posInicial;
    public float altura;
    public float largura;
    public float velocidade;
    private float count;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        posInicial = transform.position;
        altura = 0;
        largura = 3f;
        velocidade = 1;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
         count += (velocidade * Time.deltaTime);
         float x = Mathf.Cos(count) * largura;
         float y = Mathf.Sin(count) * altura;
         Vector2 pos = new Vector2(posInicial.x + x, posInicial.y + y);
         transform.position = pos;
         if (count >= 2 * Mathf.PI)
             count = 0;
        //movimento();
    }

    void movimento()
    {
        count += (velocidade * Time.deltaTime);
        float x = Mathf.Cos(count) * largura * Time.deltaTime;
        float y = Mathf.Sin(count) * largura * Time.deltaTime;
        Vector2 pos = new Vector2(posInicial.x + x, posInicial.y + y);
        transform.position = pos;
        if(count >= 2 * Mathf.PI)
        {
            count = 0;
            if (altura == 0)
                altura *= -1;
            else altura = 0;
            if (largura == 0)
                largura *= -1;
            else largura = 0;
        }
    }
}
