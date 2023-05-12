using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject croshair;
    public GameObject cards;
    // Start is called before the first frame update

    public void ShowCanv()
    {
        Canvas.SetActive(true);
        croshair.SetActive(true);
        cards.SetActive(false);
        Time.timeScale = 1f;
      Cursor.lockState = CursorLockMode.Locked;
    }    

}
