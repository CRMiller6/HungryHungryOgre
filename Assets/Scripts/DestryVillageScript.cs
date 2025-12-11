using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class DestryVillageScript : MonoBehaviour
{

    public string[] Alphabet = new string[26] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
    public float quickTimer = 0;
    public float sceneTimer;
    private int three = 3;
    public string quickLetter;
    public TMP_Text quickText;
    public GameObject qText;
    public string playerInput;
    public float dVScore;
    public GameObject timerGO;
    public TMP_Text timerTxt;
    public float timerVounter;
    public float countDown = 60.0f;
    private int one = 1;
    public int letterRepeater = 0;
    public bool winQT = false;


    
    void Start()
    {
        //quickLetter = Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)];
    
    }

    void Update()
    {
        
        timerVounter += Time.deltaTime;
        if (timerVounter >= one)
        {
            countDown -= 1;
            timerVounter -= 1;
        }
        
        TextUpdate();

        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (keyCode >= KeyCode.A && keyCode <= KeyCode.Z)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    playerInput = keyCode.ToString();
                    Debug.Log("Player pressed: " + playerInput);
                    //break; 
                }
            }
        }



        if (quickTimer >= -0.0007 && quickTimer <= 0.0007 && letterRepeater == 0)
        {
            //Debug.Log (quickTimer);
            quickLetter = Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)];
            Debug.Log (quickLetter);
            letterRepeater += 1;
        }

        quickTimer += Time.deltaTime;
        sceneTimer += Time.deltaTime;

        if (quickTimer < three && playerInput == quickLetter)
        {
            //win QT
            quickTimer = 0;
            dVScore += 0.05f;
            Debug.Log ("did QT");
            letterRepeater = 0;
            winQT = true;
        }

        if (winQT == true && quickTimer >= 1)
        {
            winQT = false;
        }

        if (quickTimer >= three && playerInput != quickLetter)
        {
            //Debug.Log (quickTimer);
            //lose QT
            quickTimer = -1f;
            quickLetter = null;
            quickText.text = "WAIT penalty";
            //Debug.Log (quickTimer);
            Debug.Log("lose quickTime");
            letterRepeater = 0;
            winQT = false;
        }

        if (countDown <= 0)
        {
            SceneManager.LoadScene("ClickerMain");
        }
    }

    public void TextUpdate()
    {
        timerTxt.text = "Time remaining: " + countDown;

        quickText.text = "Click " + quickLetter + " to move";
    }
    
}
