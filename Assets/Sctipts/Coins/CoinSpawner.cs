using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    [SerializeField] private Vector2 _minPosition;
    [SerializeField] private Vector2 _maxPosition;

    [SerializeField] private float _spawnTime;
    [SerializeField] private bool _isOn = true;

    private ObjectPool<Coin> _pool;
    private int _poolCpacity = 5;
    private int _poolMaxSize = 5;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
            createFunc: () => Instantiate(_prefab, GetRandomPosition(), Quaternion.identity),
            actionOnGet: (obj) => GetCoin(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true, 
            defaultCapacity: _poolCpacity,
            maxSize: _poolMaxSize
            );
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void GetCoin(Coin coin)
    {
        coin.Colected += Relese;
        coin.gameObject.SetActive(true);
        coin.transform.position = GetRandomPosition();
    }

    private void Relese(Coin coin)
    {
        _pool.Release(coin);
        coin.Colected -= Relese;
    }

    private Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(_minPosition.x, _maxPosition.x), Random.Range(_minPosition.y, _maxPosition.y));
    }

    private IEnumerator Spawn()
    {
        var waitForSeconds = new WaitForSeconds(_spawnTime);

        while (_isOn)
        {
            _pool.Get();
            yield return waitForSeconds;
        }
    }
}
