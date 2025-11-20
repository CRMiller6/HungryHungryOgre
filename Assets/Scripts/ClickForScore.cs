using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickForScore : MonoBehaviour
{
    public float bugs = 0f;
    public TMP_Text bugsText;
    public GameObject bugsBox;
    public int ogrePow = 1;
    public TMP_Text ogrePowText;
    public GameObject ogrePowBox;
    public Button ogrePowButton;
    public int minion = 0;
    public TMP_Text minionText;
    public GameObject minionBox;
    public Button minionButton;
    public float second = 0.0f;
    public int secondInt = 1;

    //add villages at 10 oger pow

    void Start()
    {
        ogrePowButton.interactable = false;
        minionButton.interactable = false;
    }

    public void BugsOnClick()
    {
        bugs += ogrePow;
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

            if (bugs > 100 * minion + 100)
            {
                minionButton.interactable = true;
            }            
        }
        
    }
}
