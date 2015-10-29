using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Main : MonoBehaviour {

    private List<Ground> grounds;

    private string terrain_list = "./Assets/Resources/Data/terrains.txt";
    private string temp_string;

	// Use this for initialization
	void Start () {

        loadGrounds();

        GameObject camera = new GameObject();
        camera.transform.position = new Vector3(0, 0, -10);
        Camera cam_cmp = camera.AddComponent<Camera>();
        camera.name = "Camera";
        cam_cmp.orthographic =true;
        cam_cmp.orthographicSize = 300;
        for (int i = -5; i <= 5; i++)
        {
            for (int j = -5; j <= 5; j++)
            {
                GameObject tile_go = Instantiate(Resources.Load("Prefabs/Tile")) as GameObject;
                Tile tile_scr = tile_go.GetComponent<Tile>();
                tile_scr.SetTerrain(grounds[0]);
                tile_scr.SetPosition(i, j);
            }
        }
  	}
	
	// Update is called once per frame
	void Update () {

	}

    void loadGrounds(){
        Ground temp_ground;
        grounds = new List<Ground>();
        using (StreamReader r = new StreamReader(terrain_list)){
            while ((temp_string = r.ReadLine()) != null){
                string[] substrings = temp_string.Split(',');
                temp_ground=new Ground(substrings[0],float.Parse(substrings[1]));
                grounds.Add(temp_ground);
            }
        }
    }
}
