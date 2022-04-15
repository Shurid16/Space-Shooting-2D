using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _collectPrefab;

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _waitTime;
    [SerializeField]
    private float _totalTime;
    [SerializeField]
    public int _totalCollectables;
    private int _collectableCounter = 0;

    private float _decreaseTime = 5;

    private float _intervalTime;
    public float coinSpawnTimeStart;
    public float coinSpawnTimeEnd;

    public static SpawnManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(SpawnCoin());
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

    IEnumerator SpawnCoin()
    {
        while (true)
        {
            float randomPos = Random.Range(-7.5f, 7.5f);
            yield return new WaitForSeconds(Random.Range(coinSpawnTimeStart, coinSpawnTimeEnd));
            Instantiate(_collectPrefab, new Vector2(randomPos, 8f), Quaternion.identity);
            _collectableCounter++;
            if (_collectableCounter == _totalCollectables)
            {
                break;
            }
        }

    }

    public void StopSpawning()
    {
        StopAllCoroutines();
    }
}
