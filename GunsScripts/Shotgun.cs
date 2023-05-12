using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Shotgun : MonoBehaviour
{
    //bullet
    public AudioSource ShootS;
    public AudioSource ReloadS;
    public GameObject bullet;
    //bullet force
    public float shootForce, upwardForce;
    //gun stats
    public float timeBtwShooting, spread, reloadTime, timeBtwShoots;
    public int maxBullets, magazineSize, bulletsPerTap, bulletsLeft;
    public bool allowButtonHold;

    int  bulletsShot;


    //bools
    bool shooting, readyToShoot; 
    public bool reloading;

    //refference
    public Camera Cam;
    public Transform attackPoint;

    public PauseMenu pauseMenu;
    //graphics
    public GameObject muzzleFlash;
    public Text ammoDisplay;
    public Animator anim;
    public bool allowInvoke = true;

    private void Awake()
    {   //make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        if (!pauseMenu.gamePaused)
        {
            MyInput();
        }
        //set ammo display
        if (ammoDisplay != null)
        {
            ammoDisplay.text = (bulletsLeft / bulletsPerTap + " / "  + maxBullets / 5);
        }

    }

    private void MyInput()
    {
        //check if allowed to hold key
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading && maxBullets > 0)
        {
            Reload();
        }
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0 && maxBullets > 0)
        {
            Reload();
        }

        //shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        PlayShoot();
        readyToShoot = false;

        Ray ray = Cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //ray to middle of screen

        RaycastHit hit;

        //check if ray hits
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);//Point far from player
        }

        //calculate direction from atack point to target

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        // calculate direvtion with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);
        //instantie bullet
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //rotate bullet
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forcees
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(Cam.transform.up * upwardForce, ForceMode.Impulse);



        //instatnie muzzle flash
        if (muzzleFlash != null)
        {
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        }

        bulletsLeft--;
        bulletsShot++;

        //invoke resetShot
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBtwShooting);
            allowInvoke = false;
        }

        //shoot gun like (if more bullet at once)
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBtwShoots);
        }

    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        anim.SetTrigger("Reloading");
        PlayReload();
        reloading = true;
        StartCoroutine(ReloadFinished());

    }
    IEnumerator ReloadFinished()
    {
        yield return new WaitForSeconds(reloadTime);
        if (maxBullets + bulletsLeft >= magazineSize)
        {
            maxBullets = maxBullets + bulletsLeft - magazineSize;

            bulletsLeft = magazineSize;
        }
        else
        {
            bulletsLeft = maxBullets + bulletsLeft;
            maxBullets = 0;
        }
        anim.ResetTrigger("Reloading");
        reloading = false;
    }
    public void PlayReload()
    {
        ReloadS.Play();
    }
    public void PlayShoot()
    {
        ShootS.Play();
    }
    private void OnEnable()
    {
        reloading = false;
    }
}
