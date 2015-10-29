using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block : MonoBehaviour {

    private List<Tile> tiles = new List<Tile>();

	// Use this for initialization
	void Start () {
	  
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void MoveRight()
    {
        foreach (Tile t in tiles)
            t.MoveRight();
    }
    void MoveLeft()
    {
        foreach (Tile t in tiles)
            t.MoveLeft();
    }
    void MoveDown()
    {
        foreach (Tile t in tiles)
            t.MoveDown();
    }
}
