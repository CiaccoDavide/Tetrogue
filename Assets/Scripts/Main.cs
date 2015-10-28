using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject camera = new GameObject();
        camera.transform.position = new Vector3(0, 0, -10);
        camera.AddComponent<Camera>();
        camera.name = "Camera";
        GameObject player = new GameObject();
        Texture2D texture = Resources.Load("Textures/doge") as Texture2D;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width,texture.height), new Vector2(0, 0));
        SpriteRenderer sp = player.AddComponent<SpriteRenderer>();
        sp.sprite = sprite;
        player.name = "Player";
        player.transform.position = new Vector2(-sp.bounds.size.x / 2.0f, -sp.bounds.size.y / 2.0f);
  	}
	
	// Update is called once per frame
	void Update () {
	}
}
