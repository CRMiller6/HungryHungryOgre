using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ClickForScore : MonoBehaviour
{
    public float bugs = 0f;
    public TMP_Text bugsText;
    public GameObject bugsBox;

    public int ogrePow = 1;
    public TMP_Text ogrePowText;
    public GameObject ogrePowBox;
    public Button ogrePowButton;
    public TMP_Text ogrePowButtText;

    public int minion = 0;
    public TMP_Text minionText;
    public GameObject minionBox;
    public Button minionButton;
    public TMP_Text minionButtonText;

    public float second = 0.0f;
    public int secondInt = 1;

    public int village = 0;
    public TMP_Text villageText;
    public GameObject villageBox;
    public Button villageButton;
    public TMP_Text villageButtonText;
    private float villagePower;
    private float villagePrint;
    //add villages at 100 oger pow

    public int buyAmountMultiplier = 1;

    void Start()
    {
        ogrePowButton.interactable = false;
        minionButton.interactable = false;
        villageButton.interactable = false;
        CostAnalasis();
    }

    public void BuyOne()
    {
        buyAmountMultiplier = 1;
    }

    public void BuyFive()
    {
        buyAmountMultiplier = 5;
    }

    public void BuyTen()
    {
        buyAmountMultiplier = 10;
    }

    public void CostAnalasis()
    {
        ogrePowButtText.text = "cost: " + ogrePow * 10 * buyAmountMultiplier + " bugs";
        minionButtonText.text = "cost: " + (100 * minion + 100 * buyAmountMultiplier) + " bugs";

        villagePower = Mathf.Pow(village * buyAmountMultiplier, 2);
        villagePrint = villagePower * 10 + 10;
        villageButtonText.text = "cost: EVERYTHING & min" + villagePrint + " Ogre Power";

        if (bugs >= ogrePow * 10 * buyAmountMultiplier)
        {
            ogrePowButton.interactable = true;
        }
        else if (bugs < ogrePow * 10 * buyAmountMultiplier)
        {
            ogrePowButton.interactable = false;
        }

        if (bugs >= 100 * minion + 100 * buyAmountMultiplier)
        {
            minionButton.interactable = true;
        }
        else if (bugs < 100 * minion + 100 * buyAmountMultiplier)
        {
            minionButton.interactable = false;
        }
        if (ogrePow >= villagePrint)
        {
            villageButton.interactable = true;
        }
        else if (ogrePow < villagePrint)
        {
            villageButton.interactable = false;
        }
    }

    public void BugsOnClick()
    {
        bugs += ogrePow * (village + 1);
        bugsText.text = "Bugs: " + bugs;

        CostAnalasis();
    }

    public void OgrePowOnClick()
    {
        if (bugs >= ogrePow * 10 * buyAmountMultiplier)
        {
            bugs -= ogrePow * 10 * buyAmountMultiplier;
            ogrePow += 1 * buyAmountMultiplier;

            bugsText.text = "Bugs: " + bugs;
            ogrePowText.text = "Ogre Power: " + ogrePow;
            CostAnalasis();
        }

    }

    public void MinionOnClick()
    {
        if (bugs >= 100 * minion + 100 * buyAmountMultiplier)
        {
            bugs -= 100 * minion + 100 * buyAmountMultiplier;
            minion += 1 * buyAmountMultiplier;
            bugsText.text = "Bugs: " + bugs;
            minionText.text = "Minion: " + minion;
            CostAnalasis();
        }
    }

    //
    
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BuyOne();
            CostAnalasis();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BuyFive();
            CostAnalasis();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BuyTen();
            CostAnalasis();
        }


        second += Time.deltaTime;
        if (second >= secondInt)
        {
            bugs += minion;
            second -= 1;
            bugsText.text = "Bugs: " + bugs;

            CostAnalasis();          
        }

        
        
    }

    public void VillageOnClick ()
    {
        if (ogrePow >= villagePrint)
        {
            bugs = 0;
            ogrePow = 1;
            minion = 0;
            village += 1 * buyAmountMultiplier;
            bugsText.text = "Bugs: " + bugs;
            ogrePowText.text = "Ogre Power: " + ogrePow;
            minionText.text = "Minion: " + minion;
            villageText.text = "Village: " + village;


            CostAnalasis();


            ogrePowButton.interactable = false;
            minionButton.interactable = false;
            villageButton.interactable = false;
        }
    }

}
