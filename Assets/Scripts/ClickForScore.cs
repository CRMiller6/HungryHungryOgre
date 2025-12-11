using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class ClickForScore : MonoBehaviour
{
    public long bugs = 0;
    public TMP_Text bugsText;
    public GameObject bugsBox;

    public long ogrePow = 1;
    public TMP_Text ogrePowText;
    public GameObject ogrePowBox;
    public Button ogrePowButton;
    public TMP_Text ogrePowButtText;

    public long henchman = 0;
    public TMP_Text henchmanText;
    public GameObject henchmanBox;
    public Button henchmanButton;
    public TMP_Text henchmanButtonText;

    public float second = 0.0f;
    public float secondIntval = 0.1f;

    public long village = 0;
    public TMP_Text villageText;
    public GameObject villageBox;
    public Button villageButton;
    public TMP_Text villageButtonText;

    public long oPBuyAmountMultiplier = 1;
    public long henBuyAmountMultiplier = 1;
    public long vilBuyAmountMultiplier = 1;
    public long ogrePowMultiCost;
    public long ogrePowIterateCost;
    public long henchmanMultiCost = 1;
    public long henchmanIterateCost;
    public long villageMultiCost;
    public long villageIterateCost;
    public long vPowIterate;
    public long iterateNumber;
    private char multiCharValueIdentifyer = '1';

    void Start()
    {
        CostAnalasis();
        ogrePowButton.interactable = false;
        henchmanButton.interactable = false;
        villageButton.interactable = false;
        BuyCharManager();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            multiCharValueIdentifyer = '1';
            BuyCharManager();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            multiCharValueIdentifyer = '2';
            BuyCharManager();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            multiCharValueIdentifyer = '3';
            BuyCharManager();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            multiCharValueIdentifyer = '4';
            BuyCharManager();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            multiCharValueIdentifyer = '0';
            BuyCharManager();
        }
        if (multiCharValueIdentifyer == '0')
        {
            BuyMax();
        }

        second += Time.deltaTime;
        if (second >= secondIntval)
        {
            bugs += henchman + (henchman * village);
            second -= 1;
            bugsText.text = "Bugs: " + bugs;          
        }
        CostAnalasis();
    }

    public void BuyCharManager()
    {
        if (multiCharValueIdentifyer == '1')
        {
            oPBuyAmountMultiplier = 1;
            henBuyAmountMultiplier = 1;
            vilBuyAmountMultiplier = 1;
            BuyOne();
        }

        if (multiCharValueIdentifyer == '2')
        {
            iterateNumber = 5;
            oPBuyAmountMultiplier = 5;
            henBuyAmountMultiplier = 5;
            vilBuyAmountMultiplier = 5;
            BuyMulti();
        }

        if (multiCharValueIdentifyer == '3')
        {
            iterateNumber = 10;
            oPBuyAmountMultiplier = 10;
            henBuyAmountMultiplier = 10;
            vilBuyAmountMultiplier = 10;
            BuyMulti();
        }

        if (multiCharValueIdentifyer == '4')
        {
            iterateNumber = 100;
            oPBuyAmountMultiplier = 100;
            henBuyAmountMultiplier = 100;
            vilBuyAmountMultiplier = 100;
            BuyMulti();
        }

        if (multiCharValueIdentifyer == '0')
        {
            BuyMax();
        }
    }

    public void BuyOne()
    {
        ogrePowMultiCost = ogrePow * 10;

        henchmanMultiCost = 100 * henchman + 100;

        vPowIterate = village * village;
        villageMultiCost = vPowIterate * 10 + 10;
        
        CostAnalasis();
    }

    public void BuyMulti()
    {
        //ogre
        ogrePowMultiCost = 0;
        ogrePowIterateCost = ogrePow;

        //henchman
        henchmanMultiCost = 0;
        henchmanIterateCost = henchman;

        //village
        villageMultiCost = 0;
        villageIterateCost = village;
        vPowIterate = 0;

        for (int iterate = 0; iterate < iterateNumber; iterate++)
        {
            //bugs >= ogrePow * 10
            ogrePowMultiCost += ogrePowIterateCost * 10;
            ogrePowIterateCost += 1;
            oPBuyAmountMultiplier += 1;

            //bugs >= 100 * henchman + 100
            henchmanMultiCost += 100 * henchmanIterateCost + 100;
            henchmanIterateCost += 1;

            //villagePower = Mathf.Pow(village, 2);
            //villagePrint = villagePower * 10 + 10;
            vPowIterate = village * village;
            villageMultiCost += vPowIterate * 10 + 10;
            villageIterateCost += 1;
        }
        CostAnalasis();
    }

    public void BuyMax()
    {
        //ogre
        ogrePowMultiCost = 0;
        ogrePowIterateCost = ogrePow;

        //henchman
        henchmanMultiCost = 0;
        henchmanIterateCost = henchman;

        //village
        villageMultiCost = 0;
        villageIterateCost = village;
        vPowIterate = 0;

        while (bugs >= ogrePowMultiCost + ogrePowIterateCost * 10)
        {
            ogrePowMultiCost += ogrePowIterateCost * 10;
            ogrePowIterateCost += 1;
            oPBuyAmountMultiplier += 1;
        }

        while (bugs >= henchmanMultiCost + 100 * henchmanIterateCost + 100)
        {
            henchmanMultiCost += 100 * henchmanIterateCost + 100;
            henchmanIterateCost += 1;
            henBuyAmountMultiplier += 1;
        }
    }

    public void CostAnalasis()
    {
        ogrePowButtText.text = "cost: " + ogrePowMultiCost + " bugs";

        henchmanButtonText.text = "cost: " + henchmanMultiCost + " bugs";

        villageButtonText.text = "cost: EVERYTHING    Req: " + villageMultiCost + " Ogre Power";

        //OPw
        if (bugs >= ogrePowMultiCost)
        {
            ogrePowButton.interactable = true;
        }
        else if (bugs < ogrePowMultiCost)
        {
            ogrePowButton.interactable = false;
        }
        //Min
        if (bugs >= henchmanMultiCost)
        {
            henchmanButton.interactable = true;
        }
        else if (bugs < henchmanMultiCost)
        {
            henchmanButton.interactable = false;
        }
        //Vil
        if (ogrePow >= villageMultiCost)
        {
            villageButton.interactable = true;
        }
        else if (ogrePow < villageMultiCost)
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
        if (bugs >= ogrePowMultiCost)
        {
            bugs -= ogrePowMultiCost;
            ogrePow += 1 * oPBuyAmountMultiplier;

            bugsText.text = "Bugs: " + bugs;
            ogrePowText.text = "Ogre Power: " + ogrePow;
            BuyCharManager();
        }
    }

    public void HenchmanOnClick()
    {
        if (bugs >= henchmanMultiCost)
        {
            bugs -= henchmanMultiCost;
            henchman += 1 * henBuyAmountMultiplier;
            bugsText.text = "Bugs: " + bugs;
            henchmanText.text = "Henchman: " + henchman;
            BuyCharManager();
        }
    }

    public void VillageOnClick ()
    {
        if (ogrePow >= villageMultiCost)
        {
            bugs = 0;
            ogrePow = 1;
            henchman = 0;
            village += 1 * vilBuyAmountMultiplier;
            bugsText.text = "Bugs: " + bugs;
            ogrePowText.text = "Ogre Power: " + ogrePow;
            henchmanText.text = "Henchman: " + henchman;
            villageText.text = "Village: " + village;

            BuyCharManager();

            ogrePowButton.interactable = false;
            henchmanButton.interactable = false;
            villageButton.interactable = false;
            SceneManager.LoadScene("DestroyVillage");
        }
    }
}
