using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlotDisplayButtons : MonoBehaviour
{
    public GameObject continueButton;
    public int currentSceneIndex;

   
    // Start is called before the first frame update
    void Start()
    {
        Invoke("cnt", 25f);
    }

    void cnt()
    {
        continueButton.SetActive(true);
    }

    public void GoToLevel1 ()
        {
        
            Time.timeScale = 1f;
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
            SceneManager.LoadScene("Level1");        
    }
}
