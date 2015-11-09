using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {


    public static int TileSize = 64;

    public short x, y;

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

    public void SetPosition(short _x, short _y)
    {
        x=_x;
        y=_y;
        float conversion =  TileSize * 1.0f/Global.PixelToUnit;
        transform.localPosition = new Vector3(x * conversion, y * conversion, 0);
    }
}
