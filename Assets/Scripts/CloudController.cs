using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float _speed = 2f;

    void Start()
    {
        Debug.Log("Velocidade atual da nuvem: " + _speed);
        Destroy(this.gameObject, 6f);
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.up * _speed) * Time.deltaTime;
    }
}