using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultController : MonoBehaviour
{
    [SerializeField] Animator[] catapults = null;

    IEnumerator Load()
    {
        foreach (Animator a in catapults)
        {
            yield return new WaitForSeconds(Random.Range(0f, 0.5f));
            a.SetBool("load", true);
        }
    }

    IEnumerator Shoot()
    {
        foreach (Animator a in catapults)
        {
            yield return new WaitForSeconds(Random.Range(0f, 0.5f));
            a.SetBool("shoot", true);
        }
    }
}
