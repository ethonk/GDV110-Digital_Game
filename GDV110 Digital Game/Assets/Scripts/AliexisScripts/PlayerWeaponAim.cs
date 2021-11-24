﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponAim : MonoBehaviour
{
    public GameObject UI;

    private Transform aimTransform;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    private void Update()
    {
        if (UI.GetComponent<UIHandler>().isPaused == false)
        {
            Vector3 mousePos = GetMouseWorldPos();
            //only want the Z angle to be modified so looking into euler angles

            Vector3 aimDirection = (mousePos - transform.position).normalized;
            //using maths to find euler angles
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            aimTransform.eulerAngles = new Vector3(0, 0, angle);
            //Debug.Log(angle);
            
            Vector3 weplocalScale = aimTransform.localScale;
            if (angle > 90 || angle < -90) 
            {
                weplocalScale.y = -2.5268f;
            }
            else
            {
                weplocalScale.y = +2.5268f;
            }
            aimTransform.localScale = weplocalScale;
        }
    }

    #region custom functions
    // getting the mouse position in the World using Z = 0f

    public static Vector3 GetMouseWorldPos()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCam)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCam);
    }

    //takes world camera and does screen to world point on mouse position
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCam)
    {
        Vector3 worldPos = worldCam.ScreenToWorldPoint(screenPosition);
        return worldPos;
    }


    #endregion

    void Start()
    {
        UI = GameObject.Find("UI");
    }
}
