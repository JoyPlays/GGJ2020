using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultController : MonoBehaviour
{
    [SerializeField] Animator[] catapults = null;
	private bool shooting = false;

	private void Update()
	{
		if (!shooting)
		{
			StartCoroutine("Load");
		}
		
	}

	IEnumerator Load()
    {
		shooting = true;
        foreach (Animator a in catapults)
        {
            yield return new WaitForSeconds(Random.Range(0f, 0.5f));
            a.SetBool("load", true);
        }
		yield return new WaitForSeconds(3f);
		StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        foreach (Animator a in catapults)
        {
            yield return new WaitForSeconds(Random.Range(0f, 0.5f));
            a.SetBool("shoot", true);
        }
		yield return new WaitForSeconds(3f);
		shooting = false;
    }
}
