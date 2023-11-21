using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabCloud;

    [SerializeField]
    private GameObject _prefabCoin;

    private float checkRadius = 0.2f;

    private float initialSpeed = 2f; // Velocidade inicial das nuvens
    private float speedIncreaseRate = 1f; // Taxa de aumento de velocidade

    private float minSpawnInterval = 1f; // Intervalo mínimo entre a criação de nuvens
    private float maxSpawnInterval = 4f; // Intervalo máximo entre a criação de nuvens
    private float secondSpawn = 1f;
    private float currentSpawnInterval; // Intervalo de tempo atual entre a criação de nuvens

    private float nextSpawnTime = 1f; // Momento em que a próxima nuvem será criada (inicia com um atraso)

    void Start()
    {
        // Inicialize o intervalo de criação de nuvens com um valor maior
        currentSpawnInterval = maxSpawnInterval;
    }

    void Update()
    {
        // Verifique se é hora de criar uma nuvem
        if (Time.time >= nextSpawnTime)
        {
            SpawnCloud();
            // Aumente a velocidade das nuvens a cada nova nuvem
            initialSpeed += speedIncreaseRate;

            // Reduza o intervalo de criação de nuvens com base no tempo
            currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - 0.1f);

            // Atualize o tempo da próxima criação de nuvem
            nextSpawnTime = Time.time + currentSpawnInterval;
            
            //yield return new WaitForSeconds(secondSpawn);
            SpawnCoin();
        }
    }

    Vector2 ChooseRandomPosition()
    {
        var x = Random.Range(-2.7f, 2.7f);
        return new Vector2(x, transform.position.y);
    }

    void SpawnCloud()
    {
        Vector2 position = ChooseRandomPosition();

        Collider2D result = Physics2D.OverlapCircle(position, checkRadius);
        
        if (!result){
            var cloud = Instantiate(_prefabCloud, position, transform.rotation);
            CloudController cloudScript = cloud.GetComponent<CloudController>();
            cloudScript._speed = initialSpeed;
        }
        // Configure a velocidade da nova nuvem
        
    }

    void SpawnCoin()
    {
        Vector2 position = ChooseRandomPosition();

        Collider2D result = Physics2D.OverlapCircle(position, checkRadius);
        
        if (!result){
            var coin = Instantiate(_prefabCoin, position, transform.rotation);
            CoinController coinScript = coin.GetComponent<CoinController>();
            coinScript._speed = initialSpeed;
        }

        // Configure a velocidade da nova nuvem

    }
}
