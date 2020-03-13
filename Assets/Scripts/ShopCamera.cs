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

    public static int unlocked1 = 0;
    public static int unlocked2 = 0;
    public static int unlocked3 = 0;

    public Text title;
    public Text goldText;
    private int localGold;

    public GameObject buyMenu;
    public Button selectButton;
    private int price;
    public Text priceText;

    private void Start()
    {
        sM = GameObject.FindObjectOfType<SettingsManager>();
        currentCannon = 0;
        UpdateCannons();
        localGold = PlayerPrefs.GetInt("gold");
        goldText.text = localGold.ToString();
    }

    public void moveRight()
    {
        if (transform.position.x < maximum)
        {
            transform.position = new Vector3(transform.position.x + increment, transform.position.y, transform.position.z);
            currentCannon++;
            UpdateCannons();
            Debug.Log("current: " + currentCannon);
        }
    }

    public void moveLeft()
    {
        if (transform.position.x > minimum)
        {
            transform.position = new Vector3(transform.position.x - increment, transform.position.y, transform.position.z);
            currentCannon--;
            UpdateCannons();
            Debug.Log("current: " + currentCannon);
        }
        else { }
    }

    public void Select()
    {
        selectedCannon = currentCannon;
        Debug.Log("Selected: " + selectedCannon);
        sM.SaveInt("selectedCannon", selectedCannon);
    }

    public void BuyCannon()
    {
        switch (currentCannon)
        {
            case 1:
                if (localGold >= price)
                {
                    unlocked1++;
                    sM.SaveInt("unlocked1", unlocked1);
                    localGold -= price;
                    sM.SaveInt("gold", localGold);
                    UpdateCannons();
                    Select();
                }
                else
                {
                    priceText.text = "Not Enough Gold!";
                }
                break;
            case 2:
                if (localGold >= price)
                {
                    unlocked2++;
                    sM.SaveInt("unlocked2", unlocked2);
                    localGold -= price;
                    sM.SaveInt("gold", localGold);
                    UpdateCannons();
                    Select();
                }
                else
                {
                    priceText.text = "Not Enough Gold!";
                }
                break;
            case 3:
                if (localGold >= price)
                {
                    unlocked3++;
                    sM.SaveInt("unlocked3", unlocked3);
                    localGold -= price;
                    sM.SaveInt("gold", localGold);
                    UpdateCannons();
                    Select();
                }
                else
                {
                    priceText.text = "Not Enough Gold!";
                }
                break;
            default:
                Debug.Log("no cannon selected");
                break;
        }
    }

    private void UpdateCannons()
    {
        switch (currentCannon)
        {
            case 0:
                title.text = ("Old Faithful");
                buyMenu.SetActive(false);
                selectButton.interactable = true;
                break;
            case 1:
                title.text = ("Silver Shooter");
                if (unlocked1 == 0)
                {
                    buyMenu.SetActive(true);
                    price = 100;
                    priceText.text = ("Buy for " + price + " gold?");
                    selectButton.interactable = false;
                }
                else if (unlocked1 > 0)
                {
                    buyMenu.SetActive(false);
                    selectButton.interactable = true;
                }
                break;
            case 2:
                title.text = ("Red Rocket");
                if (unlocked2 == 0)
                {
                    buyMenu.SetActive(true);
                    price = 100;
                    priceText.text = ("Buy for " + price + " gold?");
                    selectButton.interactable = false;
                }
                else if (unlocked2 > 0)
                {
                    buyMenu.SetActive(false);
                    selectButton.interactable = true;
                }
                break;
            case 3:
                title.text = ("Golden Gun");
                if (unlocked3 == 0)
                {
                    buyMenu.SetActive(true);
                    price = 1000;
                    priceText.text = ("Buy for " + price + " gold?");
                    selectButton.interactable = false;
                }
                else if (unlocked3 > 0)
                {
                    buyMenu.SetActive(false);
                    selectButton.interactable = true;
                }
                break;
            default:
                title.text = ("");
                Debug.Log("no cannon selected");
                break;
        }
    }
}
