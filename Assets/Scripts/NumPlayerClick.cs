using UnityEngine;
using System.Collections;

public class NumPlayerClick : MonoBehaviour {

    public int NumberPlayers;
    private Startup _script;

	void Start () {
        _script = Camera.main.GetComponent<Startup>();
	}

    void OnMouseUp()
    {
        _script.SelectNumberOfPlayers(NumberPlayers);
    }
}
