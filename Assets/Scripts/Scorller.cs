using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorller : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _speed);

        if(transform.position.y<-11f)
        {
            transform.position = new Vector2(transform.position.x, 11f);
        }
    }
}
