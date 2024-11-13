using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    Vector2 inputVec;    // have a direction
    Rigidbody2D rigid;   // have a physics
    float speed = 3.0f;  // have a speed


    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {   
        // Control the position (current position + nextVec)
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
