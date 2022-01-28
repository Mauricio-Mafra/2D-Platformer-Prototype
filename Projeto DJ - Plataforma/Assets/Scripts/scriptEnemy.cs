using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptEnemy : MonoBehaviour
{
    public float velIni;
    public Rigidbody2D rbd;
    public GameObject head;
    public GameObject deathAnim;
    public LayerMask contato;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        velIni = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        rbd.velocity = new Vector2(velIni, 0);

        Collider2D col;

        if (col = Physics2D.OverlapCircle(head.transform.position, 0.4f, contato))
        {
            Instantiate(deathAnim, rbd.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Enemy")
        {
            velIni *= -1f;
            transform.Rotate(new Vector2(0, 180));
        }
        if (col.gameObject.tag == "Player")
        {
            Instantiate(deathAnim, col.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Limit")
        {
            velIni *= -1f;
            transform.Rotate(new Vector2(0, 180));
        }
    }

}
