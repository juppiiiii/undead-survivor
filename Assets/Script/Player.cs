using UnityEngine;
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


    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {   
        // Control the position (current position + nextVec)
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }
}
