using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform destination;
	public long killCount;
	public long KS_trig;
	public AudioSource sfxSource;
    public AudioClip sound;
	void Start()
    {
        killCount = 0;
		KS_trig = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Enemy"))
		{
			col.transform.position = destination.transform.position;
			killCount += 1;
				if (KS_trig != killCount)
					{sfxSource.PlayOneShot(sound);}
		}        
	}
}
