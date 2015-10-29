using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    public enum Direction { Right, Left, Down }

    static int TileSize = 64;
    private Ground terrain;
    private float speed;
    
   	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetTerrain(Ground t)
    {
        GetComponent<SpriteRenderer>().sprite = t.sprite;
        terrain = t;
    }

    public void SetPosition(int x, int y)
    {
        transform.position = new Vector3(TileSize / 2 * x, TileSize / 2 * y,0);
        transform.localScale = new Vector2(TileSize,TileSize);

    }

    public void MoveRight()
    {

    }
    public void MoveLeft()
    {

    }
    public void MoveDown()
    {

    }
}
