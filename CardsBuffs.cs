using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsBuffs : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerHealth playerHealth;
    public Pistol pistol;
    public Pistol pistol2;
    public Shotgun shotgun;
    public Shotgun shotgun2;
    public Rifle rifle;
    public Rifle rifle2;
    public CardsPick cardsPick;
    public EnemyAI enemy;
    public SpellCooldown spellCooldown;
    public PauseMenu pauseMenu;
    public GameObject dmgCanv, noRldCanv, inviCanv, slowMoCanv;
    //enable skills
    bool SlowMo = false, NoRld = false, DMG = false, SPD = false, Inv = false, DJump = false, multiS = false, canDash = false, canHeal=false;
    public bool Inv2 = false, DJump2 = false, multiS2, canDash2 = false, canHeal2 = false, DMG2 = false;
    public float card1CD = 10f, card2CD = 20f, card3CD = 20f, card6CD = 5f, card9CD = 15f ;
    //cooldowns
    bool SlowMoCD = false, NoRldCD = false, DmgUpCd = false, InvCD=false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetBuffs", 0.05f);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.T) )&& (SlowMo) && (!SlowMoCD)&&(!pauseMenu.gamePaused))
        {
            StartCoroutine(SlowMotion()); 
        }
        if ((Input.GetKeyDown(KeyCode.V)) && (NoRld) && (!NoRldCD) && (!pauseMenu.gamePaused))
        {
            StartCoroutine(NoReload());
        }
        if ((Input.GetKeyDown(KeyCode.X)) && (DMG) && (!DmgUpCd) && (!pauseMenu.gamePaused))
        {
            StartCoroutine(DMG4Times()); 
        }
        if(SPD)
        {
            MSpeed();
        }
        if(DJump)
        {
            DoubleJump();
        }
        if(canDash)
        {
            DashF();
        }
        if(canHeal)
        {
            KillsHeal();
        }
        if ((Input.GetKeyDown(KeyCode.C)) && (Inv) && (!InvCD) && (!pauseMenu.gamePaused))
        {
            StartCoroutine(Invi());
        }
        if (multiS)
        {
            MultiShot();
        }

        


    }

    void SetBuffs()
    {
        if ((cardsPick.card1 == 1) || (cardsPick.card2 == 1) || (cardsPick.card3 == 1))
        {
            SlowMo = true;
        }
        if ((cardsPick.card1 == 2) || (cardsPick.card2 == 2) || (cardsPick.card3 == 2))
        {
            NoRld = true;
        }
        if ((cardsPick.card1 == 3) || (cardsPick.card2 == 3) || (cardsPick.card3 == 3))
        {
            DMG = true;
        }
        if ((cardsPick.card1 == 4) || (cardsPick.card2 == 4) || (cardsPick.card3 == 4))
        {
            SPD = true;
        }
        if ((cardsPick.card1 == 5) || (cardsPick.card2 == 5) || (cardsPick.card3 == 5))
        {
            DJump = true;
        }
        if ((cardsPick.card1 == 6) || (cardsPick.card2 == 6) || (cardsPick.card3 == 6))
        {
            canDash = true; 
        }
        if (cardsPick.card1 == 7 || cardsPick.card2 == 7 || cardsPick.card3 == 7)
        {
            canHeal = true;
        }
        if ((cardsPick.card1 == 9) || (cardsPick.card2 == 9) || (cardsPick.card3 == 9))
        {
            Inv = true; 
        }
        if ((cardsPick.card1 == 10) || (cardsPick.card2 == 10) || (cardsPick.card3 == 10))
        {
            multiS = true;
        }
    }

    IEnumerator SlowMotion()
    {
        SlowMoCD = true;
        Time.timeScale = 0.5f;
        slowMoCanv.SetActive(true);
        yield return new WaitForSeconds(2);
        spellCooldown.SpellOne();
        Time.timeScale = 1f;
        slowMoCanv.SetActive(false);
        yield return new WaitForSeconds(card1CD);
        SlowMoCD = false;
    }
    int pAmmo, sAmmo, rAmmo;
    int pAmmo2, sAmmo2, rAmmo2;
    IEnumerator NoReload()
    {
        NoRldCD = true;
        noRldCanv.SetActive(true);
        if (!multiS2)
        {
            if(!pistol.gameObject.activeInHierarchy)
            {
                pistol.gameObject.SetActive(true);
                pAmmo = pistol.bulletsLeft;
                pistol.bulletsLeft = 1000;
                pistol.gameObject.SetActive(false);
            }
            if(pistol.gameObject.activeInHierarchy)
            {
                pAmmo = pistol.bulletsLeft;
                pistol.bulletsLeft = 1000;
            }
            if (!shotgun.gameObject.activeInHierarchy)
            {
                shotgun.gameObject.SetActive(true);
                sAmmo = shotgun.bulletsLeft;
                shotgun.bulletsLeft = 1000;
                shotgun.gameObject.SetActive(false);
            }
            if (shotgun.gameObject.activeInHierarchy)
            {
                sAmmo = shotgun.bulletsLeft;
                shotgun.bulletsLeft = 1000;
            }
            if (!rifle.gameObject.activeInHierarchy)
            {
                rifle.gameObject.SetActive(true);
                rAmmo = rifle.bulletsLeft;
                rifle.bulletsLeft = 1000;
                rifle.gameObject.SetActive(false);
            }
            if (rifle.gameObject.activeInHierarchy)
            {
                rAmmo = rifle.bulletsLeft;
                rifle.bulletsLeft = 1000;
            }
        }
        if(multiS2)
        {
            if (!pistol.gameObject.activeInHierarchy)
            {
                pistol.gameObject.SetActive(true);
                pAmmo = pistol.bulletsLeft;
                pistol.bulletsLeft = 1000;
                pistol.gameObject.SetActive(false);
            }
            if (pistol.gameObject.activeInHierarchy)
            {
                pAmmo = pistol.bulletsLeft;
                pistol.bulletsLeft = 1000;
            }
            if (!shotgun.gameObject.activeInHierarchy)
            {
                shotgun.gameObject.SetActive(true);
                sAmmo = shotgun.bulletsLeft;
                shotgun.bulletsLeft = 1000;
                shotgun.gameObject.SetActive(false);
            }
            if (shotgun.gameObject.activeInHierarchy)
            {
                sAmmo = shotgun.bulletsLeft;
                shotgun.bulletsLeft = 1000;
            }
            if (!rifle.gameObject.activeInHierarchy)
            {
                rifle.gameObject.SetActive(true);
                rAmmo = rifle.bulletsLeft;
                rifle.bulletsLeft = 1000;
                rifle.gameObject.SetActive(false);
            }
            if (rifle.gameObject.activeInHierarchy)
            {
                rAmmo = rifle.bulletsLeft;
                rifle.bulletsLeft = 1000;
            }

            if (!pistol2.gameObject.activeInHierarchy)
            {
                pistol2.gameObject.SetActive(true);
                pAmmo2 = pistol2.bulletsLeft;
                pistol2.bulletsLeft = 1000;
                pistol2.gameObject.SetActive(false);
            }
            if (pistol2.gameObject.activeInHierarchy)
            {
                pAmmo2 = pistol2.bulletsLeft;
                pistol2.bulletsLeft = 1000;
            }
            if (!shotgun2.gameObject.activeInHierarchy)
            {
                shotgun2.gameObject.SetActive(true);
                sAmmo2 = shotgun2.bulletsLeft;
                shotgun2.bulletsLeft = 1000;
                shotgun2.gameObject.SetActive(false);
            }
            if (shotgun2.gameObject.activeInHierarchy)
            {
                sAmmo2 = shotgun2.bulletsLeft;
                shotgun2.bulletsLeft = 1000;
            }
            if (!rifle2.gameObject.activeInHierarchy)
            {
                rifle2.gameObject.SetActive(true);
                rAmmo2 = rifle2.bulletsLeft;
                rifle2.bulletsLeft = 1000;
                rifle2.gameObject.SetActive(false);
            }
            if (rifle2.gameObject.activeInHierarchy)
            {
                rAmmo2 = rifle2.bulletsLeft;
                rifle2.bulletsLeft = 1000;
            }
        }
        yield return new WaitForSeconds(7);
        spellCooldown.SpellTwo();
        noRldCanv.SetActive(false);
        if (!multiS2)
        {
        pistol.bulletsLeft = pAmmo;
        shotgun.bulletsLeft = sAmmo;
        rifle.bulletsLeft = rAmmo;
        }
        if (multiS2)
        {
            pistol.bulletsLeft = pAmmo;
            shotgun.bulletsLeft = sAmmo;
            rifle.bulletsLeft = rAmmo;
            pistol2.bulletsLeft = pAmmo2;
            shotgun2.bulletsLeft = sAmmo2;
            rifle2.bulletsLeft = rAmmo2;
        }
        yield return new WaitForSeconds(card2CD);
        NoRldCD = false;
    }

    IEnumerator DMG4Times()
    {
        DmgUpCd = true;
        DMG2 = true;
        dmgCanv.SetActive(true);
        yield return new WaitForSeconds(4);
        DMG2 = false;
        spellCooldown.SpellThree();
        dmgCanv.SetActive(false);
        yield return new WaitForSeconds(card3CD);
        DmgUpCd = false;
    }
    void MSpeed()
    {
        playerMovement.moveSpeed += 3 ;
        SPD = false;
    }
    void DoubleJump()
    {
        DJump2 = true;
        playerMovement.nrOfJumps = 2;
        DJump = false;
    }
    void DashF()
    {
        canDash2 = true;
        canDash = false;
        card6CD = 5f;
    }
    void KillsHeal()
    {
        canHeal = false;
        canHeal2 = true;
    }
    void MultiShot()
    {
        multiS2 = true;
        multiS = false;
    }
    IEnumerator Invi()
    {
        InvCD = true;
        Inv2 = true;
        int HP;
        HP = playerHealth.currentHealth;
        playerHealth.currentHealth = 10000;
        inviCanv.SetActive(true);
        yield return new WaitForSeconds(3);
        spellCooldown.SpellNine();
        playerHealth.currentHealth = HP;
        Inv2 = false;
        inviCanv.SetActive(false);
        yield return new WaitForSeconds(card9CD);
        InvCD = false;

    }
}
