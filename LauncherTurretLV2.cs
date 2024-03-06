using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LauncherTurretLV2 : BaseTerret
{
    public float fireRate = 2f;
    private float fireTimer = 0f;
    public float damage = 20;
    public float bomeRange = 3f;

    public GameObject rocketPrefeb;
    public Transform muzzle;

    public Animator shootAni;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        fireTimer -= Time.deltaTime;
        base.Update();

        if (fireTimer <= 0f && target != null)
        {
            Shoot();
            fireTimer = 1f / fireRate;
        }

    }


    private void Shoot()
    {
        GameObject go = Instantiate(rocketPrefeb, muzzle.position, Quaternion.identity);

        RocketBullet missile = go.GetComponent<RocketBullet>();

        if (missile != null)
        {
            shootAni.SetBool("Shoot", true);
            missile.SetUpRocket(target, damage, bomeRange);
        }
        else
        {
            Destroy(go);
        }
    }
}
