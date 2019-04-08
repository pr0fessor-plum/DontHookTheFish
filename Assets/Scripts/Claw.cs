using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour {


 
    public Transform origin;
    public float speed = 4f;
    public Gun gun;
    public UIManager uiManager;
    public SpawnManager spawnManager;
    [SerializeField]
    private AudioSource audioSource;
    private int lives = 3;
    private Vector2 target;
    private int treasureValue = 100;
    private int junkValue = 25;
    private GameObject childObject;
    private LineRenderer lineRenderer;
    private bool hitTreasure;
    private bool hitJunk;
    private bool hitLeftFish;
    private bool hitRightFish;
    private bool retracting;
    [SerializeField]
    private GameObject leftFishPrefab;
    [SerializeField]
    private GameObject rightFishPrefab;

    
    

	void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
	}

    void Update ()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, transform.position);
        if ( transform.position == origin.position && retracting)
        {
            gun.CollectedObject();
            if (hitTreasure)
            {
                uiManager.AddPoints(treasureValue);
                hitTreasure = false;
                spawnManager.treasuresInScene--;
                spawnManager.SpawnTreasure();
            }
            else if (hitJunk)
            {
                uiManager.AddPoints(junkValue);
                hitJunk = false;
            }
            else if (hitLeftFish)
            {   
                if (lives == 0)
                {
                    uiManager.CheckGameOver(lives);
                }
                Instantiate(leftFishPrefab, new Vector3(10.1f, Random.Range(3f, -4f), transform.position.z), Quaternion.identity);
                hitLeftFish = false;
            }
            else if (hitRightFish)
            {
                if (lives == 0)
                {
                    uiManager.CheckGameOver(lives);
                }
                Instantiate(rightFishPrefab, new Vector3(-10.1f, Random.Range(3f, -4f), transform.position.z), Quaternion.identity);
                hitRightFish = false;
            }

            Destroy(childObject);
            gameObject.SetActive(false);
            
        }
	}

    public void ClawTarget(Vector2 pos)
    {
        target = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        retracting = true;
        target = origin.position;

        if (other.gameObject.CompareTag("Treasure"))
        {
            if(childObject == null)
            {
                hitTreasure = true;
                gun.playGotItem();
                childObject = other.gameObject;
                other.transform.SetParent(this.transform);
            }
            else
            {
                return;
            } 
        }
        if (other.gameObject.CompareTag("LeftFish"))
        {   if (childObject == null)
            {
                hitLeftFish = true;
                lives--;
                gun.playOuch();
                uiManager.UpdateLives(lives);
                childObject = other.gameObject;
                other.transform.SetParent(this.transform);
            }
            else
            {
                //do nothing
                return; 
            }
            
        }
        if (other.gameObject.CompareTag("RightFish"))
        {
            if (childObject == null)
            {
                hitRightFish = true;
                lives--;
                gun.playOuch();
                uiManager.UpdateLives(lives);
                childObject = other.gameObject;
                other.transform.SetParent(this.transform);
            }
            else
            {
                //do nothing
                return;
            }
            
        }
    }
}
