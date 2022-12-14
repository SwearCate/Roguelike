using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 targetPos;
    public float dashRange;
    public float speed;
    private Vector2 direction;
    private Animator animator;
    private Rigidbody2D rb;
    private TrailRenderer tr;
    private enum Facing {UP, DOWN, LEFT, RIGHT};
    private Facing FacingDir = Facing.LEFT;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = 8;
    }


    void Update()
    {
        TakeInput();
        Move();

    }

    private void Move()
    {
        this.rb.MovePosition(this.rb.position + (direction * speed * Time.deltaTime));
        SetAnimatorMovement(direction);
    }

    private void TakeInput()
    {
        direction = Vector2.zero;

        if(Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
            FacingDir = Facing.UP;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            FacingDir = Facing.LEFT;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
            FacingDir = Facing.DOWN;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            FacingDir = Facing.RIGHT;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 currentPos = rb.position;
            targetPos = Vector2.zero;

            if (FacingDir == Facing.UP)
            {
                targetPos.y = 1;
            }
            else if (FacingDir == Facing.DOWN)
            {
                targetPos.y = -1;
            }
            else if (FacingDir == Facing.LEFT)
            {
                targetPos.x = -1;
            }
            else if (FacingDir == Facing.RIGHT)
            {
                targetPos.x = 1;
            }

            rb.AddForce(targetPos * dashRange);
        }
    }


    private void SetAnimatorMovement(Vector2 direction)
    {
        animator.SetFloat("xDir", direction.x);
        animator.SetFloat("yDir", direction.y);
       
    }

}
