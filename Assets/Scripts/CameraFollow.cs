using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public float MaxCameraSize;
    public float MinCameraSize;
    public float ZoomSpeed;
    public bool IsZoomedOut;
    public Vector3 FollowTargetPoint;
    public float FollowSpeed_H;
    public float FollowSpeed_V;
    public float SnapRange;

    private float TargetZoom;
    private float CameraSize;

    // Use this for initialization
    void Start () {
        IsZoomedOut = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if (!IsZoomedOut && FollowSpeed_H > 0 && FollowSpeed_V > 0)
        {
            if (FollowTargetPoint != Vector3.zero)
            {
                MoveCameraTowardsTarget();
            }
        }
	}

    public void ZoomOut()
    {
        IsZoomedOut = true;
        TargetZoom = MaxCameraSize;
        StartCoroutine(DoZoom());
    }
    public void ZoomIn()
    {
        IsZoomedOut = false;
        TargetZoom = MinCameraSize;
        StartCoroutine(DoZoom());

    }

    IEnumerator DoZoom()
    {
        CameraSize = this.GetComponent<Camera>().orthographicSize;

        if (IsZoomedOut)
        {
            while(CameraSize < TargetZoom)
            {
                CameraSize += Time.deltaTime * ZoomSpeed;
                this.GetComponent<Camera>().orthographicSize = CameraSize;
                yield return null;
            }
            this.GetComponent<Camera>().orthographicSize = TargetZoom;
        }
        else
        {
            while (CameraSize > TargetZoom)
            {
                CameraSize -= Time.deltaTime * ZoomSpeed;
                this.GetComponent<Camera>().orthographicSize = CameraSize;
                yield return null;
            }
            this.GetComponent<Camera>().orthographicSize = TargetZoom;
        }
    }

    private void MoveCameraTowardsTarget()
    {
        Vector3 curPos = Camera.main.transform.position;
        float diffX = FollowTargetPoint.x - curPos.x;
        float diffY = FollowTargetPoint.y - curPos.y;

        if (Mathf.Abs(diffX) < SnapRange)
        {
            curPos.x = FollowTargetPoint.x;
        }
        else
        {
            curPos.x = curPos.x + (diffX * FollowSpeed_H * Time.deltaTime);
        }
        if (Mathf.Abs(diffY) < SnapRange)
        {
            curPos.y = FollowTargetPoint.y;
        }
        else
        {
            curPos.y = curPos.y + (diffY * FollowSpeed_V * Time.deltaTime);
        }

        Camera.main.transform.localPosition = curPos;
    }
}
