﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Portal : MonoBehaviour
{
    //Na podstawie projektu Brackeys https://www.youtube.com/watch?v=cuQao3hEKfs
    public Camera myCamera;
    public GameObject player;
    public Transform myRenderPlane;
    public Transform myCollidPlane;
    public Portal otherPortal;

    PortalCamera portalCamera;
    PortalTeleport portalTeleport;

    public Material material;
    float myAngle;
    

    private void Awake()
    {
        portalCamera = myCamera.GetComponent<PortalCamera>();
        portalTeleport = myCollidPlane.gameObject.GetComponent<PortalTeleport>();
        player = GameObject.FindGameObjectWithTag("Player");

        portalCamera.playerCamera = player.gameObject.transform.GetChild(0);
        portalCamera.otherPortal = otherPortal.transform;
        portalCamera.portal = this.transform;

        portalTeleport.player = player.transform;
        portalTeleport.receiver = otherPortal.transform;

        myRenderPlane.gameObject.GetComponent<Renderer>().material = Instantiate(material);
        if (myCamera.targetTexture != null)
        {
            myCamera.targetTexture.Release();
        }
        myCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

        myAngle = transform.localEulerAngles.y % 360;
        portalCamera.SetMyAngle(myAngle);

    }

    private void Start()
    {
        myRenderPlane.gameObject.GetComponent<Renderer>().material.mainTexture = otherPortal.myCamera.targetTexture;
        CheckAngle();

    }

    void CheckAngle()
    {
        if (Mathf.Abs(otherPortal.ReturnMyAngle() - ReturnMyAngle()) != 180)
        {
            Debug.LogWarning("Portale nie są odpowiednio ustawione: " + gameObject.name);
            Debug.Log("Angle: " + (otherPortal.ReturnMyAngle() - ReturnMyAngle()));
        }

    }

    public float ReturnMyAngle()
    {
        return myAngle;
    }

}
