using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform destination;
	public int killCount;

    private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Enemy"))
		{
			col.transform.position = destination.transform.position;
			killCount += 1;
		}        
	}
}
