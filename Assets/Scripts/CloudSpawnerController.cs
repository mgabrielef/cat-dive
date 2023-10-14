using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabCloud;
    private float maxTime = 1.0f;
    private float timeIcre = 0;

    private float initialCloudSpeed = 2f; // Velocidade inicial das nuvens
    private float speedIncreaseRate = 0.5f; // Taxa de aumento de velocidade

    void Start()
    {
        SpawnCloud();
    }

    void Update()
    {
        timeIcre += Time.deltaTime;
        if (timeIcre >= maxTime)
        {
            SpawnCloud();

            // Aumente a velocidade das nuvens a cada nova nuvem
            initialCloudSpeed += speedIncreaseRate;

            timeIcre = 0;
        }
    }

    void SpawnCloud()
    {
        var x = Random.Range(-8.4f, 8.4f);
        var cloud = Instantiate(_prefabCloud, new Vector2(x, -6.3f), transform.rotation);

        // Configure a velocidade da nova nuvem
        CloudController cloudScript = cloud.GetComponent<CloudController>();
        cloudScript._speed = initialCloudSpeed;
    }
}
