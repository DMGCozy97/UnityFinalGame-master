using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{


    public string Name { get { return this.GetType().Name; } }
    public int MaxReserves;
    public int Reserves;

    public int MaxMagazine;
    public int Magazine;

    public int AmmoUserPerShot;

    private void Start()
    {
        Magazine = MaxMagazine;
        Reserves = MaxReserves;
    }


    public virtual void Fire(Vector3 fireFromePosition)
    {
        if(!HasAmmo())
        {
            Reload();
            return;
        }
        Magazine -= AmmoUserPerShot;

    }

    public bool HasAmmo() { return Magazine > 0; }

    public void Reload()
    {
        if(Reserves > 0)
        {
            if (Reserves >= MaxMagazine)
            {
                Magazine = MaxMagazine;
                Reserves -= MaxMagazine;
            }else
            {
                Magazine = Reserves;
                Reserves = 0;
            }
        }
    }
}
