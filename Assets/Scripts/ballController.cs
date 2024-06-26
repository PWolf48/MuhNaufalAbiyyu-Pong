using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed; 
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
    public void ActivatePUSpeedUp(float magnitude, int duration)
    {
        rig.velocity *= magnitude;
        StartCoroutine(DeactivatePowerUp(magnitude, duration));
    }
    public IEnumerator DeactivatePowerUp(float magnitude, int duration)
    {
        yield return new WaitForSeconds(duration);
        rig.velocity /= magnitude;
    }
}
