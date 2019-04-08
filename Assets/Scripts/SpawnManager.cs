using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public Bubbles bubbleScript;
    public int treasuresInScene = 0;
 

    [SerializeField]
    private LeftFish leftFishPrefab;
    [SerializeField]
    private GameObject bubblePrefab;
    [SerializeField]
    private GameObject[] treasures;


    public void StartSpawnRoutines()
    {
        StartCoroutine(BubbleSpawnRoutine());
        StartCoroutine(TreasureSpawnRoutine());
    }

    IEnumerator BubbleSpawnRoutine()
    {  while (1 == 1)
        {
            float random = Random.Range(9f, -9f);
            float randomScale = Random.Range(0.25f, 1.5f);
            float randomSeconds = Random.Range(.5f, 1.25f);
            Instantiate(bubblePrefab, new Vector2(random, -6.0f), Quaternion.identity);
            bubblePrefab.transform.localScale = new Vector2(randomScale, randomScale);
            bubbleScript.setSpeed();
            yield return new WaitForSeconds(randomSeconds);
        } 
    
        
    }

    IEnumerator TreasureSpawnRoutine()
    { while (treasuresInScene < 3)
        {
            float randomX = Random.Range(-8f, 8f);
            float randomY = Random.Range(-4f, -1f);
            Instantiate(treasures[Random.Range(0, 3)], new Vector2(randomX, randomY), Quaternion.identity);
            treasuresInScene++;
            yield return new WaitForSeconds(.5f);
        }

    }

    public void SpawnTreasure()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(-4f, -1f);
        Instantiate(treasures[Random.Range(0, 3)], new Vector2(randomX, randomY), Quaternion.identity);
        treasuresInScene++;
    }

    public void SpawnLeftFish()
    {
        Instantiate(leftFishPrefab, new Vector2(10.1f, Random.Range(-4f, 3f)), Quaternion.identity);
    }
}
	
