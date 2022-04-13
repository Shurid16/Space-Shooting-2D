using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _waitTime;

    private float _decreaseTime = 5;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        _decreaseTime -= Time.deltaTime;

        if(_decreaseTime < 0)
        {
            _waitTime -= 0.15f;
           
            _waitTime = Mathf.Clamp(_waitTime, 1.25f, 2f);

            _decreaseTime = 5f;
        }
    
    }



    IEnumerator Spawn()
    {
        while (true)
        {
            float randomPos = Random.Range(-7.5f, 7.5f);
            yield return new WaitForSeconds(_waitTime);
            Instantiate(_enemyPrefab, new Vector2(randomPos, 8f), Quaternion.identity);
        }

    }
}
