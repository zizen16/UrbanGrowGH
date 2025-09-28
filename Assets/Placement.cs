using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public bool isValid;
    public bool isInteracted;
    public LayerMask placementMask;
    int blockedObjects;
    public float timeHold = 0;



    private void Awake()
    {

        isValid = true;
        isInteracted = false;
        timeHold = 0;

    }

    private void Update()
    {   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag== "Placements" || other.gameObject.tag == "Wall") { 
            isValid = false;
            blockedObjects++;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Placements" || other.gameObject.tag == "Wall")
        {
            blockedObjects--;
            if (blockedObjects <= 0) {
                blockedObjects = 0;
                isValid = true;
            }

        }
    }

}
