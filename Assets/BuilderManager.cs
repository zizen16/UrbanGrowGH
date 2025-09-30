using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuilderManager : MonoBehaviour
{
    public static BuilderManager Instance;
    public CameraManager CameraManager;

    public GameObject selectedBuild;
    public GameObject toBuild;

    public LayerMask groundMask;
    public LayerMask placementMask;
    Camera cam;
    public Ray ray;
    public RaycastHit hit;

    private void Awake()
    {
        Instance = this;
        cam = Camera.main;
        selectedBuild = null;
    }
    
    private void Update()
    {
        if (selectedBuild != null)
        {
            //ui hide furniture selected
            if (EventSystem.current.IsPointerOverGameObject())
            {
                if (toBuild.activeSelf) toBuild.SetActive(false);
            }
            //disable/remove furniture
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(toBuild);
                selectedBuild = null;
                toBuild = null;
            }
            //rotate furniture
            if (Input.GetKeyDown(KeyCode.Space))
            {
                toBuild.transform.Rotate(Vector3.up, 45);
            }
            //furniture follow mouse
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000, groundMask))
            {
                Placement p = toBuild.GetComponent<Placement>();

                if (!toBuild.activeSelf) toBuild.SetActive(true);
                toBuild.transform.position = hit.point;
                //place furniture
                if (Input.GetMouseButtonDown(0))
                {
                    if (p.isValid)
                    {
                        selectedBuild = null;
                        toBuild = null;
                    }
                    else
                    {
                        print("Not Valid");
                    }
                }
            }
            else if (toBuild.activeSelf) toBuild.SetActive(false);
        }
        //interact object
        Ray placeRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit placeHit;
        if (Physics.Raycast(placeRay, out placeHit, 1000, placementMask))
        {
            if (placeHit.collider.gameObject.tag == "Placements") { //hovered

                Placement p = placeHit.collider.gameObject.GetComponent<Placement>();

                if (p != null) { 
                    if (Input.GetMouseButton(0) && !p.isInteracted)
                    {
                    p.timeHold += Time.deltaTime;
                    if (p.timeHold >= 1)
                        {   
                            //interaction/furniture is selected
                            print(p.timeHold);
                            p.isInteracted = true;
                            p.ButtonsUI.SetActive(true);

                            //camera position after interacted
                            Collider boxOffset = p.GetComponent<Collider>();
                            Vector3 offsetPos = p.transform.position + new Vector3(19 ,boxOffset.bounds.size.y+6, 19);
                            CameraManager.switchCam(CameraManager.followCam);
                            CameraManager.followCam.transform.position = offsetPos;
                        }
                }
                else
                {
                    p.timeHold = 0;
                }
                }
                
            }
            
        }

    }

    public void setBuild(GameObject prefab) { 
        selectedBuild = prefab;
        showBuild();
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void showBuild() { 
        toBuild = Instantiate(selectedBuild);
        toBuild.SetActive(false);
    }

}
