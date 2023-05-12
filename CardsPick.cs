using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardsPick : MonoBehaviour
{
    int RandNum1, RandNum2, RandNum3;
    public int card1, card2, card3;
    public GameObject canvas;
    public GameObject Karta1, Karta2, Karta3, Karta4, Karta5, Karta6, Karta7, Karta8, Karta9, Karta10;
    bool c1 = false, c2 = false, c3 = false, c4 = false, c5 = false, c6 = false, c7 = false, c9 = false, c10 = false;
    public CooldownShow cooldownShow;
    public SpellCooldown spellCooldown;
    public CardsBuffs cardsBuffs;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        canvas.SetActive(true);
        DoRandom1();
        DoRandom2();
        DoRandom3();
        SetCards();
    }

    void DoRandom1()
    {
        RandNum1 = Random.Range(1, 23);
        Card1F();
    } 
    void DoRandom2()
    {
        RandNum2 = Random.Range(1, 23);
        Card2F();
    }
    void DoRandom3()
    {
        RandNum3 = Random.Range(1, 23);
        Card3F();

    }


    void Card1F()
    {
        if ((RandNum1 == 1) || (RandNum1 == 2) || (RandNum1 == 3))
        {
            card1 = 1;
            if (!c1) {
            spellCooldown.cooldownTime1 = cardsBuffs.card1CD;
            Karta1.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250, 0, 0);
            c1 = true;
            cooldownShow.temp1.sprite = cooldownShow.card1;
            }
        }
        if ((RandNum1 == 4) || (RandNum1 == 5) || (RandNum1 == 6))
        {
            card1 = 2;
            if(!c2) {
                spellCooldown.cooldownTime1 = cardsBuffs.card2CD;
                Karta2.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250, 0, 0);
            c2 = true;
                cooldownShow.temp1.sprite = cooldownShow.card2;
            }
        }
        if ((RandNum1 == 7) || (RandNum1 == 8))
        {
            card1 = 3;
            if (!c3) {
                spellCooldown.cooldownTime1 = cardsBuffs.card3CD;
                Karta3.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250, 0, 0);
            c3 = true;
                cooldownShow.temp1.sprite = cooldownShow.card3;
            }
        }
        if ((RandNum1 == 9) || (RandNum1 == 10) || (RandNum1 == 11))
        {
            card1 = 4;
            if (!c4){
            Karta4.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250, 0, 0);
            c4 = true;
                cooldownShow.temp1.sprite = cooldownShow.card4;
            }
        }
        if ((RandNum1 == 12) || (RandNum1 == 13))
        {
            card1 = 5;
            if (!c5)
            {
            Karta5.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250, 0, 0);
            c5 = true;
                cooldownShow.temp1.sprite = cooldownShow.card5;
            }
        }
        if ((RandNum1 == 14) || (RandNum1 == 15))
        {
            card1 = 6;
            if (!c6)
            {
                spellCooldown.cooldownTime1 = cardsBuffs.card6CD;
                Karta6.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250, 0, 0);
            c6 = true;
                cooldownShow.temp1.sprite = cooldownShow.card6;
            }
        }
        if ((RandNum1 == 16) || (RandNum1 == 17))
        {
            card1 = 7;
            if (!c7)
            {
            Karta7.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250, 0, 0);
            c7 = true;
                cooldownShow.temp1.sprite = cooldownShow.card7;
            }

        }
        if ((RandNum1 == 18) || (RandNum1 == 19))
        {
            card1 = 8;
        }
        if ((RandNum1 == 20) || (RandNum1 == 21))
        {
            card1 = 9;
            if(!c9)
            {
                spellCooldown.cooldownTime1 = cardsBuffs.card9CD;
                Karta9.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250, 0, 0);
            c9 = true;
                cooldownShow.temp1.sprite = cooldownShow.card9;
            }
        }
        if ((RandNum1 == 22) || (RandNum1 == 23))
        {
            card1 = 10;
            if (!c10)
            {

            Karta10.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250, 0, 0);
            c10 = true;
                cooldownShow.temp1.sprite = cooldownShow.card10;
            }
        }
        if(card1==8)
        {
            DoRandom1();
        }
    }
    void Card2F()
    {
        if ((RandNum2 == 1) || (RandNum2 == 2) || (RandNum2 == 3))
        {
            card2 = 1;
            if (!c1)
            {
                spellCooldown.cooldownTime2 = cardsBuffs.card1CD;
                Karta1.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                c1 = true;
                cooldownShow.temp2.sprite = cooldownShow.card1;
            }    
        }
        if ((RandNum2 == 4) || (RandNum2 == 5) || (RandNum2 == 6))
        {
            card2 = 2;
            if (!c2)
            {
                spellCooldown.cooldownTime2 = cardsBuffs.card2CD;
                Karta2.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
            c2 = true;
                cooldownShow.temp2.sprite = cooldownShow.card2;
            }
        }
        if ((RandNum2 == 7) || (RandNum2 == 8))
        {
            card2 = 3;
            if (!c3)
            {
                spellCooldown.cooldownTime2 = cardsBuffs.card3CD;
                Karta3.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
            c3 = true;
                cooldownShow.temp2.sprite = cooldownShow.card3;
            }
        }
        if ((RandNum2 == 9) || (RandNum2 == 10) || (RandNum2 == 11))
        {
            card2 = 4;
            if (!c4)
            {

            Karta4.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
            c4 = true;
                cooldownShow.temp2.sprite = cooldownShow.card4;
            }
        }
        if ((RandNum2 == 12) || (RandNum2 == 13))
        {
            card2 = 5;
            if (!c5)
            {

            Karta5.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
            c5 = true;
                cooldownShow.temp2.sprite = cooldownShow.card5;
            }
        }
        if ((RandNum2 == 14) || (RandNum2 == 15))
        {
            card2 = 6;
            if (!c6)
            {
                spellCooldown.cooldownTime2 = cardsBuffs.card6CD;
                Karta6.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                c6 = true;
                cooldownShow.temp2.sprite = cooldownShow.card6;
            }
        }
        if ((RandNum2 == 16) || (RandNum2 == 17))
        {
            card2 = 7;
            if (!c7)
            {

            Karta7.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                c7 = true;
                cooldownShow.temp2.sprite = cooldownShow.card7;
            }
        }
        if ((RandNum2 == 18) || (RandNum2 == 19))
        {
            card2 = 8;
        }
        if ((RandNum2 == 20) || (RandNum2 == 21))
        {
            card2 = 9;
            if (!c9)
            {
                spellCooldown.cooldownTime2 = cardsBuffs.card9CD;
                Karta9.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                c9 = true;
                cooldownShow.temp2.sprite = cooldownShow.card9;
            }
           
        }
        if ((RandNum2 == 22) || (RandNum2 == 23))
        {
            card2 = 10;
            if (!c10)
            {

            Karta10.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                c10 = true;
                cooldownShow.temp2.sprite = cooldownShow.card10;
            }
            
        }
        if (card2 == card1)
        {
            DoRandom2();
        }
        if (card2 == 8)
        {
            DoRandom2();
        }
    }
    void Card3F()
    {
        if ((RandNum3 == 1) || (RandNum3 == 2) || (RandNum3 == 3))
        {
            card3 = 1;
            if (!c1)
            {
                spellCooldown.cooldownTime3 = cardsBuffs.card1CD;
                Karta1.GetComponent<RectTransform>().anchoredPosition = new Vector3(250, 0, 0);
                c1 = true;
                cooldownShow.temp3.sprite = cooldownShow.card1;
            }
        }
        if ((RandNum3 == 4) || (RandNum3 == 5) || (RandNum3 == 6))
        {
            card3 = 2;
            if (!c2)
            {
                spellCooldown.cooldownTime3 = cardsBuffs.card2CD;
                cooldownShow.temp3.sprite = cooldownShow.card2;
            Karta2.GetComponent<RectTransform>().anchoredPosition = new Vector3(250, 0, 0);
                c2 = true;
            }
        }
        if ((RandNum3 == 7) || (RandNum3 == 8))
        {
            card3 = 3;
            if (!c3)
            {
                spellCooldown.cooldownTime3 = cardsBuffs.card3CD;
                Karta3.GetComponent<RectTransform>().anchoredPosition = new Vector3(250, 0, 0);
                c3 = true;
                cooldownShow.temp3.sprite = cooldownShow.card3;
            }
        }
        if ((RandNum3 == 9) || (RandNum3 == 10) || (RandNum3 == 11))
        {
            card3 = 4;
            if (!c4)
            {
            Karta4.GetComponent<RectTransform>().anchoredPosition = new Vector3(250, 0, 0);
                c4 = true;
                cooldownShow.temp3.sprite = cooldownShow.card4;
            }
        }
        if ((RandNum3 == 12) || (RandNum3 == 13))
        {
            card3 = 5;
            if (!c5)
            {
            Karta5.GetComponent<RectTransform>().anchoredPosition = new Vector3(250, 0, 0);
                c5 = true;
                cooldownShow.temp3.sprite = cooldownShow.card5;
            }
        }
        if ((RandNum3 == 14) || (RandNum3 == 15))
        {
            card3 = 6;
            if (!c6)
            {
                spellCooldown.cooldownTime3 = cardsBuffs.card6CD;
                Karta6.GetComponent<RectTransform>().anchoredPosition = new Vector3(250, 0, 0);
                c6= true;
                cooldownShow.temp3.sprite = cooldownShow.card6;
            }
        }
        if ((RandNum3 == 16) || (RandNum3 == 17))
        {
            card3 = 7;
            if (!c7)
            {
            Karta7.GetComponent<RectTransform>().anchoredPosition = new Vector3(250, 0, 0);
                c7 = true;
                cooldownShow.temp3.sprite = cooldownShow.card7;
            }
        }
        if ((RandNum3 == 18) || (RandNum3 == 19))
        {
            card3 = 8;
           
        }
        if ((RandNum3 == 20) ||(RandNum3 == 21))
        {
            card3 = 9;
            if (!c9)
            {
                spellCooldown.cooldownTime3 = cardsBuffs.card9CD;
                cooldownShow.temp3.sprite = cooldownShow.card9;
            Karta9.GetComponent<RectTransform>().anchoredPosition = new Vector3(250, 0, 0);
                c9 = true;
            }
        }
        if ((RandNum3 == 22) || (RandNum3 == 23))
        {
            card3 = 10;
            if (!c10)
            {
            Karta10.GetComponent<RectTransform>().anchoredPosition = new Vector3(250, 0, 0);
                c10 = true;
                cooldownShow.temp3.sprite = cooldownShow.card10;
            }  
        }
        if ((card3 == card1) || (card3==card2))
        {
            DoRandom3();
        }
        if (card3 == 8)
        {
            DoRandom3();
        }
    }

    void SetCards()
    {
        if((card1==1)||(card2==1)||(card3==1))
        {
            Karta1.SetActive(true);
        }
        if ((card1 == 2) || (card2 == 2) || (card3 == 2))
        {
            Karta2.SetActive(true);
        }
        if ((card1 == 3) || (card2 == 3) || (card3 == 3))
        {
            Karta3.SetActive(true);
        }
        if ((card1 == 4) || (card2 == 4) || (card3 == 4))
        {
            Karta4.SetActive(true);
        }
        if ((card1 == 5) || (card2 == 5) || (card3 == 5))
        {
            Karta5.SetActive(true);
        }
        if ((card1 == 6) || (card2 == 6) || (card3 == 6))
        {
            Karta6.SetActive(true);
        }
        if ((card1 == 7) || (card2 == 7) || (card3 == 7))
        {
            Karta7.SetActive(true);
        }
        if ((card1 == 8) || (card2 == 8) || (card3 == 8))
        {
            Karta8.SetActive(true);
        }
        if ((card1 == 9) || (card2 == 9) || (card3 == 9))
        {
            Karta9.SetActive(true);
        }
        if ((card1 == 10) || (card2 == 10) || (card3 == 10))
        {
            Karta10.SetActive(true);
        }

    }
}
