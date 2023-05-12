using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolActivate : MonoBehaviour
{
    public GameObject pistol1, pistol2;
    public CardsBuffs cardsBuffs;

    public void Waited()
    {
        Invoke("ActivePistol", 0.07f);
    }

   public void ActivePistol()
    {
        if(cardsBuffs.multiS2)
        {
            pistol1.SetActive(true);
            pistol2.SetActive(true);
        }
        else
        {
            pistol1.SetActive(true);
        }
    }
}
