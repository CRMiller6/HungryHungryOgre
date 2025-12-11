using UnityEngine;

public class AnotherTP : MonoBehaviour
{

    public Transform destination;
    
     private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("TopHouse"))
		{
			coll.transform.position = destination.transform.position;
		}
    }
}
