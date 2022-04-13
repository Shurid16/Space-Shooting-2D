using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.CompareTag("Enemy"))
            {
                if(_player!=null)
                {
                    _player.TakeDamage(1);
                }
               
                Destroy(collision.gameObject);
            }
        

       
        
    }

}
