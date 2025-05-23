using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector2 nextvec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextvec);
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        if (inputVec.x != 0 )
        {
            spriter.flipX = inputVec.x < 0;
        }
    }
}
