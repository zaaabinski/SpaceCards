using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsScripts : MonoBehaviour
{
    public GameObject Pistol;
    public GameObject Pistol2;
    public GameObject Shotgun;
    public GameObject Shotgun2;
    public GameObject Rifle;
    public GameObject Rifle2;
    public CardsBuffs cardsBuffs;

    bool isSwitching = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Alpha1))&& !isSwitching)
        {
            if (cardsBuffs.multiS2)
            {
                isSwitching = true;
                Shotgun.SetActive(false);
                Shotgun2.SetActive(false);
                Rifle.SetActive(false);
                Rifle2.SetActive(false);
                Invoke("SwapP", 0.5f);
            }
            else
            {
                isSwitching = true;
                Shotgun.SetActive(false);
                Rifle.SetActive(false);
                Invoke("SwapP", 0.5f);
            }
        }
        if ((Input.GetKeyDown(KeyCode.Alpha2))&& !isSwitching)
        {
            if (cardsBuffs.multiS2)
            {
                isSwitching = true;
                Pistol.SetActive(false);
                Pistol2.SetActive(false);
                Rifle.SetActive(false);
                Rifle2.SetActive(false);
                Invoke("SwapS", 0.5f);
            }
            else
            {
                isSwitching = true;
                Pistol.SetActive(false);
                Rifle.SetActive(false);
                Invoke("SwapS", 0.5f);
            }
        }
        if ((Input.GetKeyDown(KeyCode.Alpha3))&& !isSwitching)
        {
            if (cardsBuffs.multiS2)
            {
                isSwitching = true;
                Pistol.SetActive(false);
                Pistol2.SetActive(false);
                Shotgun.SetActive(false);
                Shotgun2.SetActive(false);
                Invoke("SwapR", 0.5f);
            }
            else
            {
                isSwitching = true;
                Pistol.SetActive(false);
                Shotgun.SetActive(false);
                Invoke("SwapR", 0.5f);
            }
        }
    }
    void SwapP()
    {
        if (cardsBuffs.multiS2)
        {
            Pistol.SetActive(true);
            Pistol2.SetActive(true);
            isSwitching = false;
        }
        else
        {
            Pistol.SetActive(true);
            isSwitching = false;
        }

    }
    void SwapS()
    {
        if (cardsBuffs.multiS2)
        {
            Shotgun.SetActive(true);
            Shotgun2.SetActive(true);
            isSwitching = false;
        }
        else
        {
            Shotgun.SetActive(true);
            isSwitching = false;
        }
    }
    void SwapR()
    {

        if (cardsBuffs.multiS2)
        {
            Rifle.SetActive(true);
            Rifle2.SetActive(true);
            isSwitching = false;
        }
        else
        {
            Rifle.SetActive(true);
            isSwitching = false;
        }
    }

}
