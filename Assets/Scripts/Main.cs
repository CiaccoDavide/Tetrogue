using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject camera = new GameObject();
        camera.transform.position = new Vector3(0, 0, -10);
        camera.AddComponent<Camera>();
        camera.name = "Camera";
        Ground terrain_scr = new Ground("doge", 2.0f);
        GameObject tile_go = Instantiate(Resources.Load("Prefabs/Tile")) as GameObject;
        Tile tile_scr = tile_go.GetComponent<Tile>();
        tile_scr.SetTerrain(terrain_scr);
        tile_go.transform.position = new Vector2(0,0);
  	}
	
	// Update is called once per frame
	void Update () {
	}
}
