using UnityEngine;

public class VDSingle : MonoBehaviour
{
    public static VDSingle instance;
    public long destroyVillageTrack;

    public static VDSingle GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        if(VDSingle.instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
}
