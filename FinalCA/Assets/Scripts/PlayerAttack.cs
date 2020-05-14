using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAttack : MonoBehaviour
{
    

    public Weapon[] weapons;
    int activeWeaponIndex = -1;
    Weapon activeWeapon;//removed public keyword as this shouldn't be assigned a starting a value in the inspector

    public int index = 2;

    //Added by Neil
    //bools needed for animator transitions
    //see the animator in Assets/Animations/handgun
    public Animator animator;
    bool isAiming;
    bool isFiring;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SetActiveWeapon(0);
    }



    private void Update()
    {
        //don't update if the game is paused
        //only FixedUpdate is stopped when TimeScale is 0.0
        if (PauseMenu.GameIsPaused)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetActiveWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SetActiveWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SetActiveWeapon(2);
        if (activeWeapon == null) return;


        if(Input.GetButton("Fire2"))
        {
            isAiming = true;
        }
        else
        {
            isAiming = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            activeWeapon.Fire(transform.position);
            isFiring = true;
        }
        else
        {
            isFiring = false;
        }

        animator.SetBool("IsAiming", isAiming);
        animator.SetBool("IsFiring", isFiring);
    }
   
    private void SetActiveWeapon(int index)
    {
       if(index != activeWeaponIndex)
        {
            if(index >= 0 && index <= weapons.Length)
            {
                if (activeWeapon)
                    Destroy(activeWeapon.gameObject);

                activeWeapon = Instantiate(weapons[index], transform);
                activeWeaponIndex = index;
            }
        }
    }

   

}

