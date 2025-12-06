using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DestryVillageScript : MonoBehaviour
{

    public string[] Alphabet = new string[26] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
    public float timer = 0;
    public float sceneTimer;
    private int three = 3;
    private float halfSec = 0.5f;
    public string quickLetter;
    public TMP_Text quickText;
    public string playerInput;
    public float dVScore;


    
    void Start()
    {
        //quickLetter = Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)];
    
    }

    void Update()
    {
        
        if (timer <= 0)
        {
            Debug.Log (timer);
            quickLetter = Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)];
            Debug.Log (quickLetter);
        }

        timer += Time.deltaTime;
        sceneTimer += Time.deltaTime;

        if (timer < three && playerInput == quickLetter)
        {
            //win QT
            timer = 0;
            dVScore += 0.05f;
        }

        if (timer >= three && playerInput != quickLetter)
        {
            Debug.Log (timer);
            //lose QT
            timer = -0.5f;
            Debug.Log (timer);
            Debug.Log("lose quickTime");
        }

        if (sceneTimer > 60)
        {
            //change back to clicker scene
        }

    }

    public void QuickTime()
    {
        

        
    }
}
