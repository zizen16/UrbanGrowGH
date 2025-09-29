using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Placement : MonoBehaviour
{
    CameraManager camManager;

    public bool isValid;
    public bool isInteracted;
    public LayerMask placementMask;
    int blockedObjects;
    public float timeHold = 0;

    public Transform cameraLoc;
    public RectTransform Buttons;
    public GameObject ButtonsUI;


    private void Awake()
    {
        camManager = BuilderManager.Instance.GetComponent<CameraManager>();
        cameraLoc = camManager.followCam.transform;
        isValid = true;
        isInteracted = false;
        timeHold = 0;

    }

    private void Update()
    {
        Vector3 rotates = cameraLoc.position - transform.position;
        Quaternion lookR = Quaternion.LookRotation(rotates*-1);
        Vector3 rotateTrack = Quaternion.Lerp(Buttons.rotation, lookR, Time.deltaTime * 10).eulerAngles;
        Buttons.rotation = Quaternion.Euler(rotateTrack.x, rotateTrack.y, rotateTrack.z);

        if (isInteracted && Input.GetKeyDown(KeyCode.Backspace)) {
            camManager.switchCam(camManager.mainCam);
            isInteracted=false;
            ButtonsUI.SetActive(false);
        }
    }

    public void MovePlacement() {

        BuilderManager.Instance.selectedBuild = this.gameObject;
        BuilderManager.Instance.toBuild = this.gameObject;

        camManager.switchCam(camManager.mainCam);
        isInteracted = false;
        ButtonsUI.SetActive(false);
    }

    public void StorePlacement() { 
        Destroy(this.gameObject);
        camManager.switchCam(camManager.mainCam);
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
