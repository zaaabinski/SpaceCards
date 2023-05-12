using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 100f;
    public Transform playerBody;
    private float xRotation = 0f;
    public Slider sensSlider;
    string sensName;
    // Start is called before the first frame update
    void Start()
    {
        GetFloat("sensitivity");
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSens*40 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens*40 * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

    }
    public void SensChange()
    {
        mouseSens = sensSlider.value;
        SetFloat("sensitivity", sensSlider.value);
    }
    void SetFloat(string sensName, float value)
    {
        PlayerPrefs.SetFloat(sensName, value);
    }
    void GetFloat(string sensName)
    {
        mouseSens = PlayerPrefs.GetFloat(sensName);
        sensSlider.value = PlayerPrefs.GetFloat(sensName);
    }
}
