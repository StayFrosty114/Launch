using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Camera mainCam;

    public bool moving = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.touchCount == 0)
        //     return;
        // Touch touch = Input.GetTouch(0);

        #region Aiming
        if (Input.GetMouseButton(0))
        {

            Plane plane = new Plane(Vector3.back, transform.position);
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            float hitPoint = 0.0f;

            if (plane.Raycast(ray, out hitPoint))
            {
                Vector3 targetPoint = ray.GetPoint(hitPoint);

                Vector3 pos = transform.position;
                pos.z = 0.0f;
                targetPoint.z = transform.position.z;


                transform.LookAt(targetPoint, transform.up);

                Vector3 erik = transform.localRotation.eulerAngles;
                erik.x = Mathf.Clamp(erik.x, 0, 360);
                erik.y = Mathf.Clamp(erik.y, 90, 271);
                erik.z = Mathf.Clamp(erik.z, 0, 0);
                transform.localRotation = Quaternion.Euler(erik);

                Debug.Log(transform.localRotation.eulerAngles);
            }
        }
        #endregion

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            Debug.Log("Hit the ground");
            GameObject.FindGameObjectWithTag("Overlord").GetComponent<Overlord>().Death();
        }
    }
}
