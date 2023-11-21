using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public LogicScript logicScript;

    public float _speed = 2f;

    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Destroy(this.gameObject, 6f);
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.up * _speed) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            Destroy(this.gameObject);
            logicScript.addScore();
        }
    }
}
