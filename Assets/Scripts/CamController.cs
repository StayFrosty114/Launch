using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private Vector3 origin;
    private Vector3 lastPosition;
    public GameObject cannon;
    private float t = 0.0f;
    private bool raising = false;
    private bool resetCam = false;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (raising)
        {
            resetCam = false;
            transform.position = Vector3.Lerp(lastPosition, new Vector3(transform.position.x, cannon.transform.position.y, transform.position.z), t);
            t += 0.5f * Time.deltaTime;

            if (t >= 1)
            {
                t = 0;
                raising = false;
            }
        }

        if (resetCam)
        {
            raising = false;
            transform.position = Vector3.Lerp(lastPosition, origin, t);
            t += 0.5f * Time.deltaTime;

            if (t >= 1)
            {
                t = 0;
                resetCam = false;
            }
        }
    }

    public void RaiseCam()
    {
        raising = true;
        lastPosition = transform.position;
        t = 0;
    }

    public void LowerCam()
    {
        resetCam = true;
        lastPosition = transform.position;
        t = 0;
    }
}
