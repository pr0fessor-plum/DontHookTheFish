using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFish : MonoBehaviour
{

    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private LeftFish leftFishPrefab;



    // Use this for initialization
    void Start()
    {
        StartCoroutine(FishSpeedRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x > 10.1f)
        {
            Instantiate(leftFishPrefab, new Vector2(10.1f, Random.Range(-4f, 3f)), Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
    public void setSpeed()
    {
        speed = Random.Range(1f, 4f);
    }
    IEnumerator FishSpeedRoutine()
    {
        while (1 == 1)
        {
            setSpeed();
            yield return new WaitForSeconds(2.5f);
        }
    }
}
