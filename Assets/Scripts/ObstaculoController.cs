using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    public GameObject ponto1, ponto2;
    private Vector3 nextPos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = ponto2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoverObstaculo();
    }

    void MoverObstaculo()
    {
        if(transform.position == ponto1.transform.position)
        {
            nextPos = ponto2.transform.position;
        }
        if (transform.position == ponto2.transform.position)
        {
            nextPos = ponto1.transform.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
