using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonkeScript : MonoBehaviour
{
    private Animator anim;
    IEnumerator Start()
    {
        anim = GetComponent<Animator>();
        while(true)
        {
            yield return new WaitForSeconds(7);
            anim.SetInteger("FlyIndex", Random.Range(0, 6));
            anim.SetTrigger("Fly");
        }

    }
}
