using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    static int PixelToUnit = 100; //Default in Unity, don't change
    static int TileSize = 64;

    public int x, y;

    private Ground ground;
    private float speed;


    public Tile(int _x, int _y)
    {
        x = _x;
        y = _y;
    }


    
   	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetGround(Ground t)
    {
        GetComponent<SpriteRenderer>().sprite = t.sprite;
        ground = t;
    }

    public void SetPosition(int x, int y)
    {
        transform.position = new Vector3(x * TileSize * 1.0f/PixelToUnit, y * TileSize * 1.0f/PixelToUnit, 0);
    }

    public void Move(Block.Direction dir)
    {
     
    }

}
