using UnityEngine;

public class DestryVillageScript : MonoBehaviour
{

    public string[] Alphabet = new string[26] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
    



    
    void Start()
    {
        Debug.Log(Alphabet[Random.Range(0, Alphabet.Length)]);
    
    }

    void Update()
    {
        
    }

    public void QuickTime()
    {
        
    }
}
