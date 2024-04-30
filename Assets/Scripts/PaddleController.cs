using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;

    // Deklarasi costum key
    public KeyCode upKey;
    public KeyCode downKey; 
    private Rigidbody2D rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        MoveObject(GetInput());
    }

    private Vector2 GetInput(){
        // input
        if(Input.GetKey(upKey)){
            return Vector2.up * speed; // Gunakan vector3 untuk menentukan arah gerakan player
        }
        else if(Input.GetKey(downKey)){
            return Vector2.down * speed;
        }
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement){
        // transform.Translate(movement * Time.deltaTime);
        Debug.Log("TEST: " + movement);
        rig.velocity = movement;
    }
}
