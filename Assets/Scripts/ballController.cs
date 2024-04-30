using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    public Vector2 speed; 
    // speed tidak memiliki method agar bisa diatur nilai variablenya oleh dev

    private Rigidbody2D rig;
    public Vector2 resetPosition;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
    }
}
