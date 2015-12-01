using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pool : MonoBehaviour
{
    private static Queue<GameObject> pool;

    public static void Initialize()
    {
        pool = new Queue<GameObject>();
        for (int i = 0; i < (Field.Width * (Field.Height - 4) + 4); i++)
        {
            pool.Enqueue(Instantiate(Resources.Load("Prefabs/Tile")) as GameObject);
        }
    }

    public static Tile GetTile()
    {
        pool.Peek().SetActive(true);
        return pool.Dequeue().GetComponent<Tile>();
    }
    public static void RecycleTile(Tile tile)
    {
        tile.x = -1;
        tile.y = -1;
        tile.gameObject.SetActive(false);
        pool.Enqueue(tile.gameObject);
    }
}
