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

    public Sprite Red1;
    public Sprite Red2;
    public Sprite Blue1;
    public Sprite Blue2;
    public Sprite Green1;
    public Sprite Green2;
    public Sprite Orange1;
    public Sprite Orange2;
    public Sprite Yellow1;
    public Sprite Yellow2;
    public Sprite Purple1;
    public Sprite Purple2;

    public string GameState;

    public oDeck Deck;

    private CameraFollow _cameraFollow;
    private CardFollow _cardFollow;

	// Use this for initialization
	void Start () {
        GameState = "";

        Deck = new oDeck();
        Deck.Create();

        Tiles = new oTiles();
        Tiles.Initialize();

        _cameraFollow = Camera.main.GetComponent<CameraFollow>();
        _cameraFollow.FollowTargetPoint = Vector3.zero;

        _cardFollow = Card.GetComponent<CardFollow>();
        _cardFollow.FollowTarget = Vector3.zero;

        HideAllMarkers();
    }
	
	// Update is called once per frame
	void Update () {
	    switch(GameState)
        {
            case "Start":
                GameState = "ShowCard";
                //_cameraFollow.ZoomIn();
                Vector3 startPoint = new Vector3(-3.6f, -3.6f, 1);
                _cameraFollow.FollowTargetPoint = startPoint;
                Marker_Red.transform.localPosition = startPoint;
                ShowMarker(MarkerColor.Red);

                _cardFollow.SetTarget(startPoint + new Vector3(0, 1.5f, 0));
                //_cardFollow.FollowTarget = startPoint;
                break;
        }
	}

    private void HideMarker(MarkerColor Color) { ToggleMarker(Color, false); }
    private void ToggleMarker(MarkerColor Color, bool Show)
    {
        GameObject obj = null;

        Debug.Log(Color.ToString());

        switch (Color)
        {
            case MarkerColor.Red:
                obj = Marker_Red;
                break;
            case MarkerColor.Blue:
                obj = Marker_Blue;
                break;
            case MarkerColor.Green:
                obj = Marker_Green;
                break;
            case MarkerColor.Purple:
                obj = Marker_Purple;
                break;
        }

        obj.SetActive(Show);
        if (!Show)
        {
            obj.transform.localPosition = new Vector3(-20, -20, 1);
        }
    }
    private void HideAllMarkers()
    {
        HideMarker(MarkerColor.Red);
        HideMarker(MarkerColor.Blue);
        HideMarker(MarkerColor.Green);
        HideMarker(MarkerColor.Purple);
    }
    private void ShowMarker(MarkerColor Color)
    {
        ToggleMarker(Color, true);
    }
    private void ShowAllMarkers()
    {
        ShowMarker(MarkerColor.Red);
        ShowMarker(MarkerColor.Blue);
        ShowMarker(MarkerColor.Green);
        ShowMarker(MarkerColor.Purple);
    }


}
