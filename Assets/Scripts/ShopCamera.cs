using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCamera : MonoBehaviour
{
    private SettingsManager sM;

    private float increment = 0.5f;
    private int currentCannon;
    public static int selectedCannon;
    private float maximum = 1.5f;
    private float minimum = 0f;

    public Text title;

    private void Start()
    {
        sM = GameObject.FindObjectOfType<SettingsManager>();
        currentCannon = 0;
        UpdateTitleText();
    }

    public void moveRight()
    {
        if (transform.position.x < maximum)
        {
            transform.position = new Vector3(transform.position.x + increment, transform.position.y, transform.position.z);
            currentCannon++;
            UpdateTitleText();
            Debug.Log("current: " + currentCannon);
        }
    }

    public void moveLeft()
    {
        if (transform.position.x > minimum)
        {
            transform.position = new Vector3(transform.position.x - increment, transform.position.y, transform.position.z);
            currentCannon--;
            UpdateTitleText();
            Debug.Log("current: " + currentCannon);
        }
        else { }
    }

    public void Select()
    {
        selectedCannon = currentCannon;
        Debug.Log("Selected: " + selectedCannon);
        sM.SaveCannon(selectedCannon);
    }

    public void UpdateTitleText()
    {
        switch (currentCannon)
        {
            case 0:
                title.text = ("Old Faithful");
                break;
            case 1:
                title.text = ("Silver Shooter");
                break;
            case 2:
                title.text = ("Red Rocket");
                break;
            case 3:
                title.text = ("Golden Gun");
                break;
            default:
                title.text = ("");
                Debug.Log("no cannon selected");
                break;
        }
    }
}
