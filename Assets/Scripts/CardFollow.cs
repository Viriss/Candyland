using UnityEngine;
using System.Collections;

public class CardFollow : MonoBehaviour {

    public float FollowSpeed;
    public Vector3 FollowTarget;
    public float SnapRange;

    private Vector3 _startPoint;
    private float _dist;
    private bool bStartFollow;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (FollowTarget != Vector3.zero)
        {
            if (bStartFollow)
            {
                Follow();
            }
        }
	}

    public void SetTarget(Vector3 Target)
    {
        bStartFollow = true;
        FollowTarget = Target;
        _dist = 0;
    }

    private void Follow()
    {
        Vector3 curPos = this.transform.position;
        float diffX = FollowTarget.x - curPos.x;
        float diffY = FollowTarget.y - curPos.y;

        if (Vector3.Distance(curPos, FollowTarget) > SnapRange)
        {
            _dist += FollowSpeed * Time.deltaTime;
            curPos = Vector3.Lerp(_startPoint, FollowTarget, _dist);
        }
        else
        {
            curPos = FollowTarget;
            _startPoint = FollowTarget;
            bStartFollow = false;
        }

        this.transform.localPosition = curPos;
    }
}
