using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public Collider2D ball;
    public float magnitude;
    public int duration;
    public PowerUpManager manager;
    public int despawnInterval;
    private void Awake() {
        StartCoroutine(despawnPowerUp(despawnInterval));
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision == ball)
        {
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude, duration);
            manager.RemovePowerUp(gameObject);
        }
    }
    private IEnumerator despawnPowerUp(int despawnInterval)
    {
        yield return new WaitForSeconds(despawnInterval);
        manager.RemovePowerUp(gameObject);
    }
}
