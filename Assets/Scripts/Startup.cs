﻿using UnityEngine;
using System.Collections;

public class Startup : MonoBehaviour {

    public GameObject StartButton;
    public GameObject NumPlayersSelect;
    public GameObject GameBoard;
    public GameObject Backdrop;
    public CanvasRenderer PlayButtonHint;

    public float HintDelay;
    public float HintPulse;
    public int PulseNum;
    public float SlideUpPlayerNumSpeed;

    private bool IsWaitingToStart;
    private bool IsShowHint;
    private float _hintTimer;
    private Color _hintColor;
    private int _repeatCount;

    void Start () {
        IsWaitingToStart = true;
        _hintColor = PlayButtonHint.GetColor();
        _hintColor.a = 0;
        PlayButtonHint.SetColor(_hintColor);

        Vector3 pos = new Vector3(-0.7f, -5.5f, 18f);
        NumPlayersSelect.transform.localPosition = pos;
    }
	
	// Update is called once per frame
	void Update () {
        DoStartHint();
	}

    public void StartGame()
    {
        IsWaitingToStart = false;
        StartButton.SetActive(false);

        NumPlayersSelect.SetActive(true);
        StartCoroutine(SlideUpPlayerNum());
    }

    IEnumerator PulseHint()
    {
        while (_repeatCount < PulseNum)
        {
            _hintColor = PlayButtonHint.GetColor();
                        
            //pulse 1
            for (float f = 0f; f <= 1; f += HintPulse)
            {
                _hintColor.a = f;
                PlayButtonHint.SetColor(_hintColor);
                yield return null;
            }

            _hintColor.a = 1;
            PlayButtonHint.SetColor(_hintColor);
            yield return new WaitForSeconds(0.2f);

            for (float f = 1f; f >= 0; f -= HintPulse)
            {
                _hintColor.a = f;
                PlayButtonHint.SetColor(_hintColor);
                yield return null;
            }

            _hintColor.a = 0;
            PlayButtonHint.SetColor(_hintColor);
            yield return new WaitForSeconds(0.2f);

            _repeatCount++;
        }

        _hintColor.a = 0;
        PlayButtonHint.SetColor(_hintColor);
        _hintTimer = 0;
        IsShowHint = false;
    }
    IEnumerator SlideUpPlayerNum()
    {
        Vector3 pos = NumPlayersSelect.transform.position;
        while(pos.y < -3.0f)
        {
            pos = new Vector3(pos.x, pos.y + (SlideUpPlayerNumSpeed * Time.deltaTime), pos.z);
            NumPlayersSelect.transform.localPosition = pos;
            yield return null;
        }
        //something here?
    }

    private void DoStartHint()
    {
        if (IsWaitingToStart)
        {
            if (!IsShowHint && _hintTimer < HintDelay)
            {
                _hintTimer += Time.deltaTime;
                if (_hintTimer >= HintDelay)
                {
                    _repeatCount = 0;
                    IsShowHint = true;
                    StartCoroutine(PulseHint());
                }
            }
        }
    }
}
