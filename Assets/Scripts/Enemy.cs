using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            ScoreManager.instance.IncreaseScore(10);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {           
            Destroy(this.gameObject);
        }
    }
}
