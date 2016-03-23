using UnityEngine;
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

    //[HideInInspector]
    public int NumberOfPlayers;

    private bool IsWaitingToStart;
    private bool IsShowHint;
    private float _hintTimer;
    private Color _hintColor;
    private int _repeatCount;
    private string CurrentStep;

    void Start () {
        CurrentStep = "Start";

        NumberOfPlayers = 0;

        IsWaitingToStart = true;
        _hintColor = PlayButtonHint.GetColor();
        _hintColor.a = 0;
        PlayButtonHint.SetColor(_hintColor);

        Vector3 pos = new Vector3(-0.7f, -6.5f, 18f);
        NumPlayersSelect.transform.localPosition = pos;

        pos = new Vector3(0, 7, 0);
        GameBoard.transform.localPosition = pos;

        GameBoard.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        switch(CurrentStep)
        {
            case "Start":
                DoStartHint();
                break;
            case "SlideUp":

                break;
            case "ChooseNumber":
                if (NumberOfPlayers > 0)
                {
                    StartCoroutine(ShowGameboard());
                }
                break;
            case "StartEngine":
                Engine e = GameBoard.GetComponent<Engine>();
                e.GameState = "Start";
                CurrentStep = "GameStarted";
                break;
        }
	}

    public void StartGame()
    {
        CurrentStep = "SlideUp";
        IsWaitingToStart = false;
        StartButton.SetActive(false);

        NumPlayersSelect.SetActive(true);
        StartCoroutine(SlideUpPlayerNum());
    }
    public void SelectNumberOfPlayers(int NumPlayers)
    {
        this.NumberOfPlayers = NumPlayers;
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
        while(pos.y < -3.5f)
        {
            pos = new Vector3(pos.x, pos.y + (SlideUpPlayerNumSpeed * Time.deltaTime), pos.z);
            NumPlayersSelect.transform.localPosition = pos;
            yield return null;
        }

        CurrentStep = "ChooseNumber";
    }
    IEnumerator ShowGameboard()
    {
        Vector3 pos = NumPlayersSelect.transform.position;
        Color col = new Color(1, 1, 1, 1);
        Renderer bdRenderer = Backdrop.GetComponent<Renderer>();

        while (pos.y > -10.0f)
        {
            pos = new Vector3(pos.x, pos.y - (SlideUpPlayerNumSpeed * Time.deltaTime), pos.z);
            NumPlayersSelect.transform.localPosition = pos;

            if (col.a > 0.5f)
            {
                col.a -= Time.deltaTime;
                bdRenderer.material.color = col;
            }

            yield return null;
        }

        GameBoard.SetActive(true);
        pos = GameBoard.transform.position;
        while(pos.y > 0)
        {

            pos = new Vector3(pos.x, pos.y - (SlideUpPlayerNumSpeed * Time.deltaTime), pos.z);
            GameBoard.transform.localPosition = pos;

            yield return null;
        }


        CurrentStep = "StartEngine";
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
