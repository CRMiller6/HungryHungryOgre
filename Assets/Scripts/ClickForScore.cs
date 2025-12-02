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
    public float secondIntval = 0.06f;

    public int village = 0;
    public TMP_Text villageText;
    public GameObject villageBox;
    public Button villageButton;
    public TMP_Text villageButtonText;
    private float villagePower;
    private float villagePrint;
    //add villages at 100 oger pow?
    //maybe not?
    //dunno

    public int buyAmountMultiplier = 1;
    public float ogrePowMultiCost;
    public float ogrePowIterateCost;
    public float minionMultiCost = 1;
    public float minionIterateCost;
    public float villageMultiCost;
    public float villageIterateCost;
    public float vPowIterate;
    private char multiCharValueIdentifyer = '1';
    public int multiBuyIterate;

    void Start()
    {
        CostAnalasis();
        ogrePowButton.interactable = false;
        minionButton.interactable = false;
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
            bugs += minion + (minion * village);
            second -= 1;
            bugsText.text = "Bugs: " + bugs;

            CostAnalasis();          
        }   
    }

    public void BuyCharManager()
    {
        if (multiCharValueIdentifyer == '1')
        {
            BuyOne();
        }

        if (multiCharValueIdentifyer == '2')
        {
            BuyFive();
        }

        if (multiCharValueIdentifyer == '3')
        {
            BuyTen();
        }

        if (multiCharValueIdentifyer == '4')
        {
            BuyOneHundred();
        }

        if (multiCharValueIdentifyer == '0')
        {
            BuyMax();
        }
    }

    public void BuyOne()
    {
        buyAmountMultiplier = 1;

        ogrePowMultiCost = ogrePow * 10;

        minionMultiCost = 100 * minion + 100;

        vPowIterate = Mathf.Pow(village, 2);
        villageMultiCost = vPowIterate * 10 + 10;
        
        CostAnalasis();
    }

    public void BuyFive()
    {
        buyAmountMultiplier = 5;

        //ogre
        ogrePowMultiCost = 0;
        ogrePowIterateCost = ogrePow;

        //minion
        minionMultiCost = 0;
        minionIterateCost = minion;

        //village
        villageMultiCost = 0;
        villageIterateCost = village;
        vPowIterate = 0;

        for (int iterateFive = 0; iterateFive < 5; iterateFive++)
        {
            //bugs >= ogrePow * 10
            ogrePowMultiCost += ogrePowIterateCost * 10;
            ogrePowIterateCost += 1;

            //bugs >= 100 * minion + 100
            minionMultiCost += 100 * minionIterateCost + 100;
            minionIterateCost += 1;

            //villagePower = Mathf.Pow(village, 2);
            //villagePrint = villagePower * 10 + 10;
            vPowIterate = Mathf.Pow(villageIterateCost, 2);
            villageMultiCost += vPowIterate * 10 + 10;
            villageIterateCost += 1;
        }
        CostAnalasis();
    }

    public void BuyTen()
    {
        buyAmountMultiplier = 10;

        //ogre
        ogrePowMultiCost = 0;
        ogrePowIterateCost = ogrePow;

        //minion
        minionMultiCost = 0;
        minionIterateCost = minion;

        //village
        villageMultiCost = 0;
        villageIterateCost = village;
        vPowIterate = 0;

        for (int iterateTen = 0; iterateTen < 10; iterateTen++)
        {
            //bugs >= ogrePow * 10
            ogrePowMultiCost += ogrePowIterateCost * 10;
            ogrePowIterateCost += 1;

            //bugs >= 100 * minion + 100
            minionMultiCost += 100 * minionIterateCost + 100;
            minionIterateCost += 1;

            //villagePower = Mathf.Pow(village, 2);
            //villagePrint = villagePower * 10 + 10;
            vPowIterate = Mathf.Pow(villageIterateCost, 2);
            villageMultiCost += vPowIterate * 10 + 10;
            villageIterateCost += 1;
        }
        CostAnalasis();
    }

    public void BuyOneHundred()
    {
        buyAmountMultiplier = 100;

        //ogre
        ogrePowMultiCost = 0;
        ogrePowIterateCost = ogrePow;

        //minion
        minionMultiCost = 0;
        minionIterateCost = minion;

        //village
        villageMultiCost = 0;
        villageIterateCost = village;
        vPowIterate = 0;

        for (int iterateOHundred = 0; iterateOHundred < 100; iterateOHundred++)
        {
            //bugs >= ogrePow * 10
            ogrePowMultiCost += ogrePowIterateCost * 10;
            ogrePowIterateCost += 1;

            //bugs >= 100 * minion + 100
            minionMultiCost += 100 * minionIterateCost + 100;
            minionIterateCost += 1;

            //villagePower = Mathf.Pow(village, 2);
            //villagePrint = villagePower * 10 + 10;
            vPowIterate = Mathf.Pow(villageIterateCost, 2);
            villageMultiCost += vPowIterate * 10 + 10;
            villageIterateCost += 1;
            Debug.Log (villageIterateCost);
        }
        CostAnalasis();
    }

    public void BuyMax()
    {
        buyAmountMultiplier = 0;

        //ogre
        ogrePowMultiCost = 0;
        ogrePowIterateCost = ogrePow;

        //minion
        minionMultiCost = 0;
        minionIterateCost = minion;

        //village
        villageMultiCost = 0;
        villageIterateCost = village;
        vPowIterate = 0;

        while (bugs >= ogrePowMultiCost)
        {
            ogrePowMultiCost += ogrePowIterateCost * 10;
            ogrePowIterateCost += 1;
            buyAmountMultiplier += 1;
        }
        ogrePowMultiCost -= ogrePowIterateCost * 10;
    }

    public void CostAnalasis()
    {
        ogrePowButtText.text = "cost: " + ogrePowMultiCost + " bugs";

        minionButtonText.text = "cost: " + minionMultiCost + " bugs";

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
        if (bugs >= minionMultiCost)
        {
            minionButton.interactable = true;
        }
        else if (bugs < minionMultiCost)
        {
            minionButton.interactable = false;
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
            ogrePow += 1 * buyAmountMultiplier;

            bugsText.text = "Bugs: " + bugs;
            ogrePowText.text = "Ogre Power: " + ogrePow;
            BuyCharManager();
        }
    }

    public void MinionOnClick()
    {
        if (bugs >= minionMultiCost)
        {
            bugs -= minionMultiCost;
            minion += 1 * buyAmountMultiplier;
            bugsText.text = "Bugs: " + bugs;
            minionText.text = "Minion: " + minion;
            BuyCharManager();
        }
    }

    public void VillageOnClick ()
    {
        if (ogrePow >= villageMultiCost)
        {
            bugs = 0;
            ogrePow = 1;
            minion = 0;
            village += 1 * buyAmountMultiplier;
            bugsText.text = "Bugs: " + bugs;
            ogrePowText.text = "Ogre Power: " + ogrePow;
            minionText.text = "Minion: " + minion;
            villageText.text = "Village: " + village;

            BuyCharManager();

            ogrePowButton.interactable = false;
            minionButton.interactable = false;
            villageButton.interactable = false;
        }
    }
}
