using UnityEngine;
using System.Collections;

public class TapHint : MonoBehaviour {

    public bool Enabled;
    public float PulseRate;
    public float Delay;
    public float RepeatTime;

    private float _time;
    private SpriteRenderer _renderer;
    private Color _color;
    private int _repeatCount;
    private bool isRunning;

	// Use this for initialization
	void Start () {
        Enabled = true;
        _renderer = this.GetComponent<SpriteRenderer>();
        _color = _renderer.material.color;
        _color.a = 0;
        _renderer.material.color = _color;
    }
	
	// Update is called once per frame
	void Update () {
	    if (Enabled)
        {
            _time += Time.deltaTime;
            if (_time > Delay && !isRunning)
            {
                _repeatCount = 0;
                isRunning = true;
                StartCoroutine(DoPulse());
            }
        }
        else
        {
            if (_time > 0) { _time = 0; }
        }
	}

    IEnumerator DoPulse()
    {
        while (_repeatCount < RepeatTime)
        {
            _color = _renderer.material.color;

            //pulse 1
            for (float f = 0f; f <= 1; f += PulseRate)
            {
                _color.a = f;
                _renderer.material.color = _color;
                yield return null;
            }

            _color.a = 1;
            _renderer.material.color = _color;
            yield return new WaitForSeconds(0.2f);

            for (float f = 1f; f >= 0; f -= PulseRate)
            {
                _color.a = f;
                _renderer.material.color = _color;
                yield return null;
            }

            _color.a = 0;
            _renderer.material.color = _color;
            yield return new WaitForSeconds(0.2f);

            _repeatCount++;
        }

        _color.a = 0;
        _renderer.material.color = _color;
        _time = 0;
        isRunning = false;
    }

}
