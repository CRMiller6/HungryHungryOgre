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
    public long henchmanMultiplier;

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

    public GameObject advice;
    public GameObject greaterAdvice;

    void Start()
    {
        if(VDSingle.instance != null)
        {
            village = VDSingle.instance.destroyVillageTrack;
            henchmanMultiplier = VDSingle.instance.ogreKillScore;
            
        }
        villageText.text = "Village: " + VDSingle.instance.destroyVillageTrack;
        CostAnalasis();
        ogrePowButton.interactable = false;
        henchmanButton.interactable = false;
        villageButton.interactable = false;
        BuyCharManager();

        if (village >= 3)
        {
            advice.SetActive(true);
        }
        if (village >= 6)
        {
            greaterAdvice.SetActive(true);
        }
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

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            multiCharValueIdentifyer = '5';
            BuyCharManager();
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            multiCharValueIdentifyer = '6';
            BuyCharManager();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            multiCharValueIdentifyer = '1';
            BuyCharManager();
        }

        second += Time.deltaTime;
        if (second >= secondIntval)
        {
            bugs += henchman + (henchman * (henchmanMultiplier * village) / 2);
            second -= 1;
            bugsText.text = "Bugs: " + bugs;          
        }
        CostAnalasis();
    }

    public void BuyCharManager()
    {
        if (multiCharValueIdentifyer == '1')
        {
            iterateNumber = 1;
            oPBuyAmountMultiplier = 1;
            henBuyAmountMultiplier = 1;
            BuyOne();
        }

        if (multiCharValueIdentifyer == '2')
        {
            iterateNumber = 5;
            oPBuyAmountMultiplier = 5;
            henBuyAmountMultiplier = 5;
            BuyMulti();
        }

        if (multiCharValueIdentifyer == '3')
        {
            iterateNumber = 10;
            oPBuyAmountMultiplier = 10;
            henBuyAmountMultiplier = 10;
            BuyMulti();
        }

        if (multiCharValueIdentifyer == '4')
        {
            iterateNumber = 100;
            oPBuyAmountMultiplier = 100;
            henBuyAmountMultiplier = 100;
            BuyMulti();
        }

        if (multiCharValueIdentifyer == '5')
        {
            iterateNumber = 500;
            oPBuyAmountMultiplier = 500;
            henBuyAmountMultiplier = 500;
            BuyMulti();
        }

        if (multiCharValueIdentifyer == '5')
        {
            iterateNumber = 1000;
            oPBuyAmountMultiplier = 1000;
            henBuyAmountMultiplier = 1000;
            BuyMulti();
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

        for (int iterate = 0; iterate < iterateNumber; iterate++)
        {
            //bugs >= ogrePow * 10
            ogrePowMultiCost += ogrePowIterateCost * 10;
            ogrePowIterateCost += 1;
            oPBuyAmountMultiplier += 1;

            //bugs >= 100 * henchman + 100
            henchmanMultiCost += 100 * henchmanIterateCost + 100;
            henchmanIterateCost += 1;
        }

        vPowIterate = village * village;
        villageMultiCost = vPowIterate * 10 + 10;

        CostAnalasis();
    }


    public void CostAnalasis()
    {
        ogrePowButtText.text = "cost: " + ogrePowMultiCost + " bugs";

        henchmanButtonText.text = "cost: " + henchmanMultiCost + " bugs";

        villageButtonText.text = "takes: EVERYTHING    Req: " + villageMultiCost + " Ogre Power";

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
            ogrePow += 1 * iterateNumber;

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
            henchman += 1 * iterateNumber;
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

            BuyCharManager();

            ogrePowButton.interactable = false;
            henchmanButton.interactable = false;
            villageButton.interactable = false;

            VDSingle.instance.destroyVillageTrack = village;
            SceneManager.LoadScene("DestroyVillage");
        }
    }
}
