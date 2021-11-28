using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] float _speed;
    [SerializeField] float _jumpSpeed;

    [SerializeField] bool _grounded;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(_grounded)
            {
                _rigidbody2D.velocity += new Vector2(0f, _jumpSpeed);
            }         
        }


        if (_rigidbody2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
        }
        else if(_rigidbody2D.velocity.x <0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, _rigidbody2D.velocity.y);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.up);
        if(dot > 0.5f)
        {
            _grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _grounded = false;
    }

}
