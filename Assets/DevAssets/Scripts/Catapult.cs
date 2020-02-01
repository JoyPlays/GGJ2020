using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
	[Header("Projectile Setup")]
	[SerializeField]
	private Projectile projectile;
	private Rigidbody projectilerb;
	[SerializeField]
	private Transform projectilePosition;
	[SerializeField]
	private bool catapultLoaded;
	[SerializeField]
	private float projectileSpeed = 10f;

	public void ReloadCatapult()
	{
		if (!catapultLoaded)
		{
			GameObject pr = Instantiate(projectile, projectilePosition).gameObject;
			projectilerb = pr.GetComponent<Rigidbody>();
			pr.transform.localPosition = Vector3.zero;
			pr.transform.rotation = Quaternion.identity;
			catapultLoaded = true;
		}
	}

	public void ReleaseProjectile()
	{
		catapultLoaded = false;
		projectilerb.isKinematic = false;
		projectilerb.angularVelocity = projectilePosition.transform.forward * projectileSpeed;
	}
}
