using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {

    public oTiles Tiles;
    public GameObject Backdrop;
    public GameObject GameBoard;
    public GameObject Marker_Red;
    public GameObject Marker_Blue;
    public GameObject Marker_Green;
    public GameObject Marker_Purple;
    public GameObject Card;
    public int NumPlayers;

	// Use this for initialization
	void Start () {
        Tiles = new oTiles();
        Tiles.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
