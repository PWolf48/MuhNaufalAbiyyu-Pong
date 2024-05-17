using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSpeedUpController : MonoBehaviour
{
    public Collider2D ball;
    public Collider2D paddle;
    public Collider2D paddle2;
    public int speedMultiplier;
    public int duration;
    public PowerUpManager manager;
    public int despawnInterval;
    private void Update() {
        StartCoroutine(despawnPowerUp(despawnInterval));
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision == ball)
        {
            paddle.GetComponent<PaddleController>().ActivatePaddleSpeedUp(speedMultiplier, duration);
            paddle2.GetComponent<PaddleController>().ActivatePaddleSpeedUp(speedMultiplier, duration);
            manager.RemovePowerUp(gameObject);
        }
    }
    private IEnumerator despawnPowerUp(int despawnInterval)
    {
        yield return new WaitForSeconds(despawnInterval);
        manager.RemovePowerUp(gameObject);
    }
}
