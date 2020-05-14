using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Shotgun : RayCastWeapons
{
    public override void Fire(Vector3 fireFromePosition)
    {
        base.Fire(fireFromePosition);
        ShootRay(fireFromePosition, transform.forward);
        Vector3 right = transform.forward;
        right.x += 0.1f;
        ShootRay(fireFromePosition, right );
        Vector3 left = transform.forward;
        left.x -= 0.1f;
        ShootRay(fireFromePosition, left );
    }

    private  void ShootRay(Vector3 position, Vector3 direction)
    {
        if(Physics.Raycast(position,direction,out RaycastHit, Range))
        {
            HealthComponent hitHealth = RaycastHit.transform.GetComponent<HealthComponent>();
            if (hitHealth != null)
                ApplyDamage(hitHealth);
        }
    }
}

