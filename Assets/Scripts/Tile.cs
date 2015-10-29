using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    private Ground terrain;
    private float speed;
    
    public void SetTerrain(Ground t)
    {
        GetComponent<SpriteRenderer>().sprite = t.sprite;
        terrain = t;
    }
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
