using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoCamera : MonoBehaviour
{
    private GameObject pc;
    public float yOffset;
    public float xOffset;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Scott");
        yOffset = -0.37f;
        xOffset = -3f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(pc.transform.position.x - xOffset,
                                        pc.transform.position.y - yOffset, -10);
    }
}
