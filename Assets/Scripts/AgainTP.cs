using UnityEngine;

public class AgainTP : MonoBehaviour
{
    public Transform destination;

        private void OnTriggerEnter2D(Collider2D colli)
    {
        if (colli.gameObject.CompareTag("BottomHouse"))
		{
			colli.transform.position = destination.transform.position;
		}
    }
}
