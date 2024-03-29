﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
    private Field field;

    void Start()
    {
        //Create and initialize camera
        Camera camera =  CreateCamera();
        
        //Create field
        field = Field.Create();
      
    }
     
    void Update(){
        field.HandleInput();
    }

    Camera CreateCamera()
    {
        GameObject camera = new GameObject();
        camera.transform.position = new Vector3(0, 0, -10);
        Camera camera_scr = camera.AddComponent<Camera>();
        camera.name = "Camera";
        camera_scr.orthographic = true;
        camera_scr.orthographicSize = 5;
        return camera_scr;
    }
}
