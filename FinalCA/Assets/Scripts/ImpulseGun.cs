using UnityEngine;

class ImpulseGun : RayCastWeapons
{
    public float ImpulseAmount = 10;

    public override void Fire(Vector3 fireFromePosition)
    {
        base.Fire(fireFromePosition);

        if (Physics.Raycast(fireFromePosition, transform.forward, out RaycastHit, Range))
        {
            Rigidbody body = RaycastHit.transform.GetComponent<Rigidbody>();
            if (body != null)
                body.AddForce((RaycastHit.transform.position  - fireFromePosition  ).normalized * ImpulseAmount, ForceMode.Impulse);
        }
    }
}

