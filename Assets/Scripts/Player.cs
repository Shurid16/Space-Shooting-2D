using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private int _health;   
    [SerializeField]
    private GameObject _bullletPrefab;
    [SerializeField]
    private float _bulletAdjustment;

    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private Text _healthText;

    


    void Start()
    {

        _audioSource = GetComponent<AudioSource>();
        _healthText.text = _health.ToString();     

    }

    
    // Update is called once per frame

    void Update()
    {
        Move();
        Shoot();

    }


    public void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_bullletPrefab,transform.position + new Vector3(0, _bulletAdjustment,0),Quaternion.identity);
            _audioSource.Play();
        }
       
    }

  


    public void Move()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2();

        movement.x = xMove;
        movement.y = yMove;

        transform.Translate(movement * Time.deltaTime * _speed);

        if (transform.position.x > 8.5f)
        {
            transform.position = new Vector2(8.5f, transform.position.y);
        }

        if (transform.position.x < -8.5f)
        {
            transform.position = new Vector2(-8.5f, transform.position.y);
        }

        if (transform.position.y > 4.5f)
        {
            transform.position = new Vector2(transform.position.x, 4.5f);
        }

        if (transform.position.y < -4.5f)
        {
            transform.position = new Vector2(transform.position.x, -4.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
        
    }

    public void TakeDamage(int damageAmount)
    {
        
        _health = _health - damageAmount; //_health-- _health++
        _healthText.text = _health.ToString();
        if (_health <= 0)
        {
            UIManager.instance.ShowGameOverText();
            Destroy(this.gameObject);
        }
    }
   

}

