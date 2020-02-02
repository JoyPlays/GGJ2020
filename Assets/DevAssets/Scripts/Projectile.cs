using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public GameObject explosionParticle;

	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log(collision.collider.name);
		GameObject explosionEffect = Instantiate(explosionParticle, transform.position, Quaternion.identity);
		Destroy(explosionEffect, 3f);
		Destroy(gameObject, 1f);
	}
}
