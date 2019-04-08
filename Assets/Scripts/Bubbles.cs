using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour {
    [SerializeField]
    private float speed = 3f;
	
    //Start...
	void Start () {
		
	}
	
	//Update...
	void Update ()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime );
        if (transform.position.y > 6f)
        {
            Destroy(this.gameObject);
        }
	}

    public void setSpeed()
    {
        speed = Random.Range(1f, 3f);
    }
}
