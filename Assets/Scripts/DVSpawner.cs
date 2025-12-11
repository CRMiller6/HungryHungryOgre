using System.Buffers.Text;
using UnityEngine;
using System.Collections.Generic;

public class DVSpawner : MonoBehaviour
{
    public List<Transform> backgroundObjects;
    public List<Transform> enemyObjects;
    public string moveBackground = "Background";
    public float baseSpeed = 5f;
    public float playerBoost = 10f;
    private float currentSpeed;
    public DestryVillageScript dashin;
    public float dashTimer = 0.05f;
    public float iNeedDeltaTime;



    void Start()
    {
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        if (dashin.winQT == true)
        {
            currentSpeed += baseSpeed + playerBoost;
            iNeedDeltaTime = 0;

            foreach (Transform enmyTransform in enemyObjects)
            {
                enmyTransform.Translate(Vector3.left * baseSpeed * Time.deltaTime);
            }
        }

        else if (dashin.winQT == false)
        {
            foreach (Transform enmyTransform in enemyObjects)
            {
                enmyTransform.Translate(Vector3.right * 1 * Time.deltaTime);
            }
        }

        else
        {
            currentSpeed = baseSpeed;
        }

        iNeedDeltaTime += Time.deltaTime;
        if (dashTimer >= iNeedDeltaTime)
        {
            currentSpeed = baseSpeed;
        }

        foreach (Transform bgTransform in backgroundObjects)
        {
            bgTransform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        }
        Debug.Log(currentSpeed);
    }    


}
