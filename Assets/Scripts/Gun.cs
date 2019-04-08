using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject claw;
    public bool isShooting;
    public Animator turretAnimator;
    public Claw clawScript;

    [SerializeField]
    private AudioSource splash;
    [SerializeField]
    private AudioSource gotFish;
    [SerializeField]
    private AudioSource gotItem;


    void Start()
    {
        
        
    }

	void Update () {
		
        if (Input.GetButton("Fire1") && !isShooting)
        {
            LaunchClaw();
        }

	}

    void LaunchClaw()
    {
        isShooting = true;
        turretAnimator.speed = 0;
        Vector2 down = transform.TransformDirection(Vector2.down);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, down);

        if (hit.collider != null)
        {
            claw.SetActive(true);
            splash.Play();
            clawScript.ClawTarget(hit.point);


        }
    }

    public void playOuch()
    {
        gotFish.Play();
    }

    public void playGotItem()
    {
        gotItem.Play();
    }

    public void CollectedObject()
    {
        isShooting = false;
        turretAnimator.speed = 1;
    }
}
