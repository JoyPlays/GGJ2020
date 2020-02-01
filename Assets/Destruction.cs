using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
	[SerializeField] private GameObject originalPrefab;
	[SerializeField] private GameObject gibsPrefab;

	private void Start()
	{
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "projectile")
		{
			originalPrefab.SetActive(false);
			gibsPrefab.SetActive(true);

			gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}
}
