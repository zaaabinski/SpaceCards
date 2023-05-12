using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask platformMask;
    public float moveSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public int nrOfJumps = 1;
    public float dashTime=2;
    public float dashSpeed=3;
    bool dashCD = false;
    Vector3 velocity;
    bool isGrounded;
    public CardsBuffs cardsBuffs;
    public SpellCooldown spellCooldown;
    public PauseMenu pauseMenu;
    // Update is called once per frame
    void Update()
    {
        // movement
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
       // if ((Physics.CheckSphere(groundCheck.position, groundDistance, groundMask)) || Physics.CheckSphere(groundCheck.position, groundDistance, platformMask)) 
       // {
       //     isGrounded = true;
      //  }
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            if (cardsBuffs.DJump2)
            {
                nrOfJumps = 2;
            }
            else
            {
                nrOfJumps = 1;
            }
        }
        if((Input.GetKeyDown(KeyCode.LeftShift))&&(cardsBuffs.canDash2)&&(!dashCD)&&(!pauseMenu.gamePaused))
        {
            StartCoroutine(Dash());
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);



        if (Input.GetButtonDown("Jump") && nrOfJumps > 0 && (!pauseMenu.gamePaused))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.5f * gravity);
            nrOfJumps--;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
    }
    IEnumerator Dash()
    {
        dashCD = true;
        float startTime = Time.time;
        while (Time.time < startTime + dashTime)
        {
            controller.Move(Camera.main.transform.forward * dashSpeed * Time.deltaTime);

            yield return null;
        }
        spellCooldown.SpellSix();
        yield return new WaitForSeconds(cardsBuffs.card6CD);
        dashCD = false;
    }
}
