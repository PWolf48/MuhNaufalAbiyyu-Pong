using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSizeUpController : MonoBehaviour
{
    public Collider2D ball;
    public Collider2D paddle;
    public Collider2D paddle2;
    public float sizeMultiplier;
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
            paddle.GetComponent<PaddleController>().ActivatePaddleSizeUp(sizeMultiplier, duration);
            paddle2.GetComponent<PaddleController>().ActivatePaddleSizeUp(sizeMultiplier, duration);
            manager.RemovePowerUp(gameObject);
        }
    }
    private IEnumerator despawnPowerUp(int despawnInterval)
    {
        yield return new WaitForSeconds(despawnInterval);
        manager.RemovePowerUp(gameObject);
    }
}
