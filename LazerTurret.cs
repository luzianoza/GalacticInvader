using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerTurret : BaseTerret
{

    public float damage = 50f;

    [Range(0.01f,0.99f)]
    public float slowPct;

    public LineRenderer lineBullet;

    public Transform muzzle;

    public Animator shootAni;

    // Start is called before the first frame update
    public override void Start()
    {
        lineBullet = GetComponent<LineRenderer>();
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base .Update();

        if (target == null)
        {
            if (lineBullet.enabled)
            {
                lineBullet.enabled = false;
            }
            return;
        }

        Lazer();
    }

    private void Lazer()
    {
        if (!lineBullet.enabled)
        {
            lineBullet.enabled = true;
            shootAni.SetBool("Shoot", true);
        }

        lineBullet.SetPosition(0, muzzle.position);
        lineBullet.SetPosition(1, target.position);
        enemyTarget.TakeDamage(damage * Time.deltaTime);
        enemyTarget.Slow(slowPct);
    }
}

