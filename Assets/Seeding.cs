using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seeding : MonoBehaviour
{
    [Header("Seed Movement")]
    public float speedRandom;
    public Transform[] movePoints;
    public int pointRandom;

    [Header("Drop Seed")]
    public GameObject seed;
    public float timeDrop;
    public Image dropFill;

    public bool seedStart;
    void Start()
    {
        pointRandom = Random.Range(0, movePoints.Length);
        speedRandom = Random.Range(0.1f, 0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardPoint();
        
        float distanceWaypoint = Vector3.Distance(transform.position, movePoints[pointRandom].position);
        if (distanceWaypoint <= 2)
        {
            //print("point Change");
            pointRandom = Random.Range(0, movePoints.Length);
            speedRandom = Random.Range(0.07f, 0.2f);
        }

        timeDrop += Time.deltaTime;
        Vector3 posDrop = new Vector3(transform.position.x, transform.position.y+5, transform.position.z);
        if (timeDrop > 2) {
            if (Input.GetMouseButton(0)&& seedStart) { 
                Instantiate(seed, posDrop, Quaternion.identity);
                timeDrop = 0;
            }
        }

        dropFill.fillAmount = timeDrop / 2;
    }

    void MoveTowardPoint()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, movePoints[pointRandom].position, speedRandom);
    }
}
