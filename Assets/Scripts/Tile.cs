using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{

    public static int TileSize = 64;

    public short x, y;

    private Ground ground;
    private float speed;
    public bool walkable = true;


    public static void InitializePool()
    {
        Pool.Initialize();
    }

    //"Constructor"
    public static Tile Create()
    {
        return Pool.GetTile();
    }

    public void SetGround(Ground t)
    {
        GetComponent<SpriteRenderer>().sprite = t.sprite;
        ground = t;
    }

    public void SetPosition(short _x, short _y)
    {
        x = _x;
        y = _y;
        float conversion = TileSize * 1.0f / Global.PixelToUnit;
        transform.localPosition = new Vector3(x * conversion, y * conversion, 0);
    }

    public void GoDown(int times)
    {
        y = (short)(y - times);
        float conversion = TileSize * 1.0f / Global.PixelToUnit;
        transform.localPosition = new Vector3(x * conversion, y * conversion, 0);
    }
}
