using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
    void Start()
    {
        
        //Load grounds from file
        List<Ground> grounds = FileLoader.LoadGrounds();

        //Create and initialize camera
        GameObject camera = new GameObject();
        camera.transform.position = new Vector3(0, 0, -10);
        Camera cam_cmp = camera.AddComponent<Camera>();
        camera.name = "Camera";
        cam_cmp.orthographic = true;
        cam_cmp.orthographicSize = 5;

        GameObject field = Instantiate(Resources.Load("Prefabs/Field")) as GameObject;
        field.name = "Field";

        //Just for testing purposes: generate a tile for each offset of each block
        for (int x = 0; x < 2; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                foreach (Block.Offset off in Block.Blueprints[(Block.Shape)(y * 2 + x)])
                {
                    GameObject tile_go = Instantiate(Resources.Load("Prefabs/Tile")) as GameObject;
                    tile_go.name = "Tile";
                    Tile tile_scr = tile_go.GetComponent<Tile>();
                    tile_scr.SetGround(grounds[0]);
                    tile_scr.SetPosition(off.x - 4 + 4 * x, off.y - 6 + 4 * y);
                }

            }
        }
    }
}
