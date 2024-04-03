using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveH;
    public float moveV;

    public float playerSpeed;

    Rigidbody rb;

    [SerializeField] GameController controller;

    [SerializeField] Transform SpawnPoint;
    [SerializeField] Transform SpawnPointFinal;
    [SerializeField] Transform PlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerPosition.position = SpawnPoint.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(moveH, 0, moveV);
        rb.velocity = new Vector3(moveH * playerSpeed, rb.velocity.y, moveV * playerSpeed);

        if (dir != Vector3.zero)
        {
            transform.LookAt(transform.position + dir);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstaculo")
        {
            PlayerPosition.position = SpawnPoint.position;
        }

        if (collision.gameObject.tag == "Alavanca")
        {
            controller.Porta.transform.Translate(new Vector3(0,2,0));
            controller.Alavanca.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckpointFinal")
        {
            PlayerPosition.position = SpawnPointFinal.position;
        }
        if (other.gameObject.tag == "Checkpoint")
        {
            SceneManager.LoadScene("Fase2");
        }
    }
}
