using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Pistol : RayCastWeapons
{
    private AudioSource mAudioSrc;

    void Start()
    {
        mAudioSrc = GetComponent<AudioSource>();
    }

    public override void Fire(Vector3 fireFromePosition)
    {
        mAudioSrc.Play();

        base.Fire(fireFromePosition);

        //ideally I'd use this to cast a ray from the center of the screen
        //your camera rotation is off by a few degrees so iut doesn't work
        //ray = Camera.main.ScreenPointToRay(new Vector3(0.5f, 0.5f, 0f));

        //can comment out
        lines.Add(new TestLine() { start = fireFromePosition, direction = Camera.main.transform.forward });

        if (Physics.Raycast(fireFromePosition, Camera.main.transform.forward, out RaycastHit, Range, Layer))
        {
            //can comment out
            Debug.Log(RaycastHit.collider.gameObject.name);

            HealthComponent hitHealth = RaycastHit.transform.GetComponent<HealthComponent>();

            if (hitHealth != null)
                ApplyDamage(hitHealth);
        }
    }

    //can comment out
    List<TestLine> lines = new List<TestLine>();

    //can comment out
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach(var line in lines)
        {
            Gizmos.DrawLine(line.start, line.start + (line.direction * Range));
        }
    }
}

public class TestLine
{
    public Vector3 start;
    public Vector3 direction;
}

