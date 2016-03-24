using UnityEngine;
using System.Collections;

public class CardBob : MonoBehaviour {

    public bool Bob;
    public float amplitude; //0.0015
    public float speed;     //4

	// Use this for initialization
	void Start () {
        Bob = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Bob)
        {
            Vector3 pos = transform.position;
            Vector3 v = new Vector3(pos.x, pos.y, pos.z);

            v.y = v.y + amplitude * Mathf.Sin(speed * Time.time);

            //transform.position.y = y0 + amplitude * Mathf.Sin(speed * Time.time);
            transform.position = v;
        }
    }
}
