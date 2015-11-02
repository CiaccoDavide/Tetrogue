using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {


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
        transform.position = new Vector3(TileSize / 2 * x, TileSize / 2 * y,0);
        transform.localScale = new Vector2(TileSize,TileSize);

    }

    public void Move(Block.Direction dir)
    {
     
    }

}
