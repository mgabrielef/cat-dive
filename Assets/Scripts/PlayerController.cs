using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 8f;
    private float _h, _v;

    private Rigidbody2D _rb2d;
    private SpriteRenderer _sprite;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") < 0){
            _sprite.flipX = true;
        }else if(Input.GetAxisRaw("Horizontal") > 0){
            _sprite.flipX = false;
        }
        _rb2d.MovePosition(_rb2d.position + new Vector2(_h, _v) * _speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cloud")){
            Destroy(this.gameObject);
            Time.timeScale = 0;
        }
        
    }
}