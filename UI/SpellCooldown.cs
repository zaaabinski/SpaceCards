using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SpellCooldown : MonoBehaviour
{

    public Image imageCooldown1;
    public Image imageCooldown2;
    public Image imageCooldown3;
    public TMP_Text textCooldown1;
    public TMP_Text textCooldown2;
    public TMP_Text textCooldown3;

    public GameObject img1, img2, img3;

    public CardsPick cardsPick;

    bool isCooldown1 = false;
    bool isCooldown2 = false;
    bool isCooldown3 = false;
    public float cooldownTime1 = 0f;
    public float cooldownTime2 = 0f;
    public float cooldownTime3 = 0f;
    float cooldownTimer1 = 0f;
    float cooldownTimer2 = 0f;
    float cooldownTimer3 = 0f;
    public bool cd1=false, cd2 = false, cd3 = false, cd6 = false, cd9 = false;
    // Start is called before the first frame update
    void Start()
    {
        textCooldown1.gameObject.SetActive(false);
        imageCooldown1.fillAmount = 0f;
        textCooldown2.gameObject.SetActive(false);
        imageCooldown2.fillAmount = 0f;
        textCooldown3.gameObject.SetActive(false);
        imageCooldown3.fillAmount = 0f;
        if(cardsPick.card1==4 || cardsPick.card1 == 5 || cardsPick.card1 == 7 || cardsPick.card1 == 10)
        {
            img1.SetActive(true);
        }
        if (cardsPick.card2 == 4 || cardsPick.card2 == 5 || cardsPick.card2 == 7 || cardsPick.card2 == 10)
        {
            img2.SetActive(true);
        }
        if (cardsPick.card3 == 4 || cardsPick.card3 == 5 || cardsPick.card3 == 7 || cardsPick.card3 == 10)
        {
            img3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isCooldown1)
        {
            ApplyCooldown1();
        }
        if (isCooldown2)
        {
            ApplyCooldown2();
        }
        if (isCooldown3)
        {
            ApplyCooldown3();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
          
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
               
            
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            
        }
       

    }

    void ApplyCooldown1()
    {
        cooldownTimer1 -= Time.deltaTime;

        if (cooldownTimer1 < 0f)
        {
            isCooldown1 = false;
            textCooldown1.gameObject.SetActive(false);
            imageCooldown1.fillAmount = 0f;
        }
        else
        {
            textCooldown1.text = Mathf.RoundToInt(cooldownTimer1).ToString();
            imageCooldown1.fillAmount = cooldownTimer1 / cooldownTime1;
        }
    }
    public void UseSpell1()
    {
        if(isCooldown1)
        {
           
        }
        else
        {
            isCooldown1 = true;
            textCooldown1.gameObject.SetActive(true);
            cooldownTimer1 = cooldownTime1;
        }
    }
    void ApplyCooldown2()
    {
        cooldownTimer2 -= Time.deltaTime;

        if (cooldownTimer2 < 0f)
        {
            isCooldown2 = false;
            textCooldown2.gameObject.SetActive(false);
            imageCooldown2.fillAmount = 0f;
        }
        else
        {
            textCooldown2.text = Mathf.RoundToInt(cooldownTimer2).ToString();
            imageCooldown2.fillAmount = cooldownTimer2 / cooldownTime2;
        }
    }
    public void UseSpell2()
    {
        if (isCooldown2)
        {

        }
        else
        {
            isCooldown2 = true;
            textCooldown2.gameObject.SetActive(true);
            cooldownTimer2 = cooldownTime2;
        }
    }
    void ApplyCooldown3()
    {
        cooldownTimer3 -= Time.deltaTime;

        if (cooldownTimer3 < 0f)
        {
            isCooldown3 = false;
            textCooldown3.gameObject.SetActive(false);
            imageCooldown3.fillAmount = 0f;
        }
        else
        {
            textCooldown3.text = Mathf.RoundToInt(cooldownTimer3).ToString();
            imageCooldown3.fillAmount = cooldownTimer3 / cooldownTime3;
        }
    }
    public void UseSpell3()
    {
        if (isCooldown3)
        {

        }
        else
        {
            isCooldown3 = true;
            textCooldown3.gameObject.SetActive(true);
            cooldownTimer3 = cooldownTime3;
        }
    }

    public void SpellOne()
    {
        if (cardsPick.card1 == 1)
        {
            UseSpell1();
        }
        if (cardsPick.card2 == 1)
        {
            UseSpell2();
        }
        if (cardsPick.card3 == 1)
        {
            UseSpell3();
        }
    }
    public void SpellTwo()
    {
        if (cardsPick.card1 == 2)
        {
            UseSpell1();
        }
        if (cardsPick.card2 == 2)
        {
            UseSpell2();
        }
        if (cardsPick.card3 == 2)
        {
            UseSpell3();
        }
    }
    public void SpellThree()
    {
        if (cardsPick.card1 == 3)
        {
            UseSpell1();
        }
        if (cardsPick.card2 == 3)
        {
            UseSpell2();
        }
        if (cardsPick.card3 == 3)
        {
            UseSpell3();
        }
    }
    public void SpellSix()
    {
        if (cardsPick.card1 == 6)
        {
            UseSpell1();
        }
        if (cardsPick.card2 == 6)
        {
            UseSpell2();
        }
        if (cardsPick.card3 == 6)
        {
            UseSpell3();
        }
    }
    public void SpellNine()
    {
        if (cardsPick.card1 == 9)
        {
            UseSpell1();
        }
        if (cardsPick.card2 == 9)
        {
            UseSpell2();
        }
        if (cardsPick.card3 == 9)
        {
            UseSpell3();
        }
    }
}
