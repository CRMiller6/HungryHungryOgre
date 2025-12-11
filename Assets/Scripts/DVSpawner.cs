using System.Buffers.Text;
using UnityEngine;

public class DVSpawner : MonoBehaviour
{

    // public GameObject spawnBgPrefab;
    // public Transform spawnBgPoint;
    // public float bgSpawnDistance = 5f;
    // private GameObject currBg;
    // private Vector3 ogBgSpawn;
    public Transform bG;
    public float baseSpeed = 5f;
    public float playerBoost = 10f;
    private float currentSpeed;
    public DestryVillageScript dashin;
    public int dashTimer = 1;
    public float iNeedDeltaTime;

    void Start()
    {
        currentSpeed = baseSpeed;
        iNeedDeltaTime += Time.deltaTime;
    //     ogBgSpawn = spawnBgPoint.position;
    //     SpawnPrefab();
    }

    void Update()
    {
        

        if (dashin.winQT == true)
        {
            currentSpeed = baseSpeed + playerBoost;
            iNeedDeltaTime = 0;
        }
        else
        {
            currentSpeed = baseSpeed;
        }


        bG.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        Debug.Log(currentSpeed);

        iNeedDeltaTime += Time.deltaTime;
        if (dashTimer >= iNeedDeltaTime)
        {
            currentSpeed = baseSpeed;
        }

        
    //     float distance = Vector3.Distance(currBg.transform.position, ogBgSpawn);

    //     if (distance >= bgSpawnDistance)
    //     {
    //         SpawnPrefab();
    //     }
    }

    // void SpawnPrefab()
    // {
    //     currBg = Instantiate(currBg, ogBgSpawn, spawnBgPoint.rotation);
    // }
}
