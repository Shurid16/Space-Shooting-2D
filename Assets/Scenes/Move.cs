using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    private Vector3 movement;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        movement.x = x;
        movement.z = y;
        rb.AddForce(movement * speed*Time.deltaTime);


    }

    private void FixedUpdate()
    {
        
    }
}
