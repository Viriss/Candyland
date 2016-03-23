using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {

    public oTiles Tiles;
    public GameObject GameBoard;
    public GameObject Marker_Red;
    public GameObject Marker_Blue;
    public GameObject Marker_Green;
    public GameObject Marker_Purple;
    public GameObject Card;
    public int NumPlayers;

    public string GameState;

    private CameraFollow _cameraFollow;
    private CardFollow _cardFollow;

	// Use this for initialization
	void Start () {
        GameState = "";

        Tiles = new oTiles();
        Tiles.Initialize();

        _cameraFollow = Camera.main.GetComponent<CameraFollow>();
        _cameraFollow.FollowTargetPoint = Vector3.zero;

        _cardFollow = Card.GetComponent<CardFollow>();
        _cardFollow.FollowTarget = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
	    switch(GameState)
        {
            case "Start":
                GameState = "ShowCard";
                _cameraFollow.ZoomIn();
                Vector3 startPoint = new Vector3(-3.6f, -3.6f, 1);
                _cameraFollow.FollowTargetPoint = startPoint;
                Marker_Red.transform.localPosition = startPoint;

                _cardFollow.SetTarget(startPoint + new Vector3(0, 1.5f, 0));
                //_cardFollow.FollowTarget = startPoint;
                break;
        }
	}



}
