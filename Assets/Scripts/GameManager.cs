using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool gameOver = true;
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private AudioSource audioSource;
    private SpawnManager spawnManager;
    [SerializeField]
    private GameObject turret;



    private void Start()
    {
        Cursor.visible = false;
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                gameOver = false;
                uiManager.HideTitleScreen();
                audioSource.Play();
                spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
                if (spawnManager != null)
                {
                    spawnManager.StartSpawnRoutines();
                    spawnManager.SpawnLeftFish();
                    turret.SetActive(true);
                    uiManager.StartClock();

                }
            } 
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {

            SceneManager.LoadScene(0);
        }

    }

}