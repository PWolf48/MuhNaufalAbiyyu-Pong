using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    public Vector2 speed; 
    // speed tidak memiliki method agar bisa diatur nilai variablenya oleh dev

    private Rigidbody2D rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    // Update is called once per frame
    private void Update()
    {
        // Vector3 => class unity untuk object dengan 3 vector(x, y, z)
        transform.Translate(speed * Time.deltaTime);
    }
}
