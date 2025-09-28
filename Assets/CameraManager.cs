using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera mainCam;
    public CinemachineVirtualCamera followCam;
    public CinemachineVirtualCamera startCam;
    public CinemachineVirtualCamera currentCam;

    public CinemachineVirtualCamera[] cams;
    void Start()
    {
        currentCam = startCam;

        for (int i = 0; i < cams.Length; i++) {
            if (cams[i] == currentCam)
            {
                cams[i].Priority = 20;
            }
            else {
                cams[i].Priority = 10;
            }
        }
    }

    public void switchCam(CinemachineVirtualCamera newCam) { 
        currentCam = newCam;
        currentCam.Priority = 20;

        for (int i = 0; i < cams.Length; i++)
        {
            if (cams[i] != currentCam)
            {
                cams[i].Priority = 10;
            }
        }
    }
}
