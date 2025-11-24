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

    public float buyMultiplier;

    void Start()
    {
        ogrePowButton.interactable = false;
        minionButton.interactable = false;
        villageButton.interactable = false;
        ogrePowButtText.text = "cost: " + ogrePow * 10 + " bugs";
        minionButtonText.text = "cost: " + (100 * minion + 100) + " bugs";
        //villageButtonText.text = "DESTROY VILLAGE \n" + "cost: 20 Ogre Power";
    }

    public void BugsOnClick()
    {
        bugs += ogrePow * (village + 1);
        bugsText.text = "Bugs: " + bugs;

        if (bugs >= ogrePow * 10)
        {
            ogrePowButton.interactable = true;
        }

        if (bugs >= 100 * minion + 100)
        {
            minionButton.interactable = true;
        }
    }

    public void OgrePowOnClick()
    {
        if (bugs >= ogrePow * 10)
        {
            bugs -= ogrePow * 10;
            ogrePow += 1;

            bugsText.text = "Bugs: " + bugs;
            ogrePowText.text = "Ogre Power: " + ogrePow;
            ogrePowButtText.text = "cost: " + ogrePow * 10 + " bugs";

            villagePower = Mathf.Pow(village, village);
            villagePrint = villagePower * 10 + 10;
            villageButtonText.text = "cost: EVERYTHING & min" + villagePrint + " Ogre Power";

            if (ogrePow >= villagePower * 10 + 10)
            {
                villageButton.interactable = true;
            }

            if (bugs <= 100 * minion + 100)
            {
                minionButton.interactable = false;
            }

            if (bugs < ogrePow * 10)
            {
                ogrePowButton.interactable = false;
            }
        }

    }

    public void MinionOnClick()
    {
        if (bugs >= 100 * minion + 100)
        {
            bugs -= 100 * minion + 100;
            minion += 1;
            bugsText.text = "Bugs: " + bugs;
            minionText.text = "Minion: " + minion;
            minionButtonText.text = "cost: " + (100 * minion + 100) + " bugs";

            if (bugs <= ogrePow * 10)
            {
                ogrePowButton.interactable = false;
            }

            if (bugs < 100 * minion + 100)
            {
                minionButton.interactable = false;
            }
        }
    }

    //
    
    public void Update()
    {
        second += Time.deltaTime;
        if (second >= secondInt)
        {
            bugs += minion;
            second -= 1;
            bugsText.text = "Bugs: " + bugs;

            if (bugs < ogrePow * 10)
            {
                ogrePowButton.interactable = false;
            }

            if (bugs > 100 * minion + 100)
            {
                minionButton.interactable = true;
            }            
        }
        
    }

    public void VillageOnClick ()
    {
        if (ogrePow >= villagePower * 10 + 10)
        {
            bugs = 0;
            ogrePow = 1;
            minion = 0;
            village += 1;
            bugsText.text = "Bugs: " + bugs;
            ogrePowText.text = "Ogre Power: " + ogrePow;
            minionText.text = "Minion: " + minion;
            villageText.text = "Village: " + village;
            ogrePowButtText.text = "cost: " + ogrePow * 10 + " bugs";
            minionButtonText.text = "cost: " + (100 * minion + 100) + " bugs";

            villagePower = Mathf.Pow(village, village);
            villagePrint = villagePower * 10 + 10;
            villageButtonText.text = "cost: EVERYTHING & min" + villagePrint + " Ogre Power";
            


            ogrePowButton.interactable = false;
            minionButton.interactable = false;
            villageButton.interactable = false;
        }
    }
}
