using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int maxPowerUpAmount;
    public Transform spawnArea;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;
    public int spawnInterval;
    private float timer;
    // List dari power up yang dispawn
    private List<GameObject> powerUpList;
    // List dari template dimana power up disimpan
    public List<GameObject> powerUpTemplateList;
    private void Start() 
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }
    private void Update() 
    {
        timer += Time.deltaTime;

        if(timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer = 0;
        }    
    }
    public void GenerateRandomPowerUp()
    {
        GeneratePowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }
    public void GeneratePowerUp(Vector2 position)
    {
        if(powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }
        // Cek apakah posisi power up ada di luar spawn area
        if(position.x < powerUpAreaMin.x || position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y || position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);
        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        // Mengaktifkan template power up
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }
    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }
    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
}
