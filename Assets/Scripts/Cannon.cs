using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Camera mainCam;

    private Overlord overlord;

    private void Start()
    {
        overlord = GameObject.FindGameObjectWithTag("Overlord").GetComponent<Overlord>();
    }

    // Update is called once per frame
    void Update()
    {
        // On mouse input, cannon rotates to faces mouse position. Disabled if player dies.
        #region Aiming
        if (overlord.deathScreen.activeInHierarchy == false)
        {
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

                    // Clamps the cannon's rotation to one axis.
                    Vector3 erik = transform.localRotation.eulerAngles;
                    erik.x = Mathf.Clamp(erik.x, 0, 360);
                    erik.y = Mathf.Clamp(erik.y, 90, 271);
                    erik.z = Mathf.Clamp(erik.z, 0, 0);
                    transform.localRotation = Quaternion.Euler(erik);
                }
            }
        }
        
        #endregion   
    }

    // If cannon hits the death floor, game over.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            Debug.Log("Hit the ground");
            overlord.Death();
        }
    }
}
