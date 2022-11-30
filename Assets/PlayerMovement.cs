using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Vector2 direction;
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        speed = 2;
    }


    void Update()
    {
        TakeInput();
        Move();

    }

    private void Move()
    {
        transform.Translate(speed * Time.deltaTime * direction);
        SetAnimatorMovement(direction);
    }

    private void TakeInput()
    {
        direction = Vector2.zero;

        if(Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

    }


    private void SetAnimatorMovement(Vector2 direction)
    {
        animator.SetFloat("xDir", direction.x);
        animator.SetFloat("yDir", direction.y);
       
    }

}