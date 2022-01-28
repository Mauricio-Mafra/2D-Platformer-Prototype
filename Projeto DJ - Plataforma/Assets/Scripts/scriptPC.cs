using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    public float altPulo;
    public float velocidade;
    private float lado;
    private bool dir = true;
    private Rigidbody2D rbd;
    private Animator anim;
    public float velPulo;
    public float altPuloBaixo;
    public float altPuloAlto;
    private bool chao;
    public GameObject pe;
    public LayerMask contato;
    public GameObject deathAnim;
    private GameObject pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = this.gameObject;
        anim = GetComponent<Animator>();
        rbd = GetComponent<Rigidbody2D>();
        chao = true;

        altPuloBaixo = 4f;
        altPuloAlto = 1.1f;
        velocidade = 5f;
        velPulo = 11.5f;
    }

    // Update is called once per frame
    void Update()
    {
        lado = Input.GetAxisRaw("Horizontal");
        if (lado == 0)
            anim.SetBool("isMoving", false);
        else
            anim.SetBool("isMoving", true);

        if (lado < 0 && dir || lado > 0 && !dir)
        {
            transform.Rotate(new Vector2(0, 180));
            dir = !dir;
        }

        Collider2D col;

        if (col = Physics2D.OverlapCircle(pe.transform.position,
                                                  0.3f, contato))
        {
            transform.parent = col.transform;
            chao = true;
        }
        else
        {
            transform.parent = null;
            chao = false;
        }

        movimento(lado);
    }

    void movimento(float lado)
    {
        rbd.velocity = new Vector2(lado*velocidade, rbd.velocity.y);
        

        if (Input.GetKeyDown(KeyCode.Space) && chao)
        {
            rbd.velocity = Vector2.up * velPulo;
        }
        if (rbd.velocity.y < 0)
        {
            rbd.velocity += Vector2.up * Physics2D.gravity.y * (altPuloAlto - 1) * Time.deltaTime;
        }
        else if (rbd.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rbd.velocity += Vector2.up * Physics2D.gravity.y * (altPuloBaixo - 1) * Time.deltaTime;
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Finish")
        {
            velocidade = 0f;
            velPulo = 0f;
            anim.SetBool("isMoving", false);
            anim.SetBool("end", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Limit")
        {
            Instantiate(deathAnim, rbd.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
