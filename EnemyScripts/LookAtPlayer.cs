using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform targetPlayer;

    private void Awake()
    {
        targetPlayer = GameObject.Find("PlayerObject").transform;
    }

    void Update()
    {
        var lookDir = targetPlayer.position - transform.position;
        lookDir.y = 0; // keep only the horizontal direction
        transform.rotation = Quaternion.LookRotation(-lookDir);
    }
}
