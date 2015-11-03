﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {

    //List of grounds loaded from file
    public static List<Ground> grounds = FileLoader.LoadGrounds();

    public static int TileSize = 64;

    public int x, y;

    private Ground ground;
    private float speed;

    //"Constructor"
    public static Tile Create()
    {
        GameObject tile_go = Instantiate(Resources.Load("Prefabs/Tile")) as GameObject;
        tile_go.name = "Tile";
        return tile_go.GetComponent<Tile>();

    }

    public void SetGround(Ground t)
    {
        GetComponent<SpriteRenderer>().sprite = t.sprite;
        ground = t;
    }

    public void SetPosition(int x, int y)
    {
        float conversion =  TileSize * 1.0f/Global.PixelToUnit;
        transform.position = new Vector3(x * conversion, y * conversion, 0);
    }
}
