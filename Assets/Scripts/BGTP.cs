using UnityEngine;

public class BGTP : MonoBehaviour
{
    public Transform destination;

    private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Background"))
		{
			col.transform.position = destination.transform.position;
		}        
	}

}
