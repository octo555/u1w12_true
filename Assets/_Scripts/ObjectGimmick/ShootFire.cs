using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFire : MonoBehaviour
{
    [SerializeField] GameObject fire;
    [SerializeField] float fireSpeed;
    [SerializeField] float fireInterval;
    public float timer = 0;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (StopTime.instance.isPaused == false)
        {

            timer += Time.deltaTime;
            if (timer > fireInterval)
            {
                Shoot();
                timer = 0;
            }
        }
    }

    private void Shoot()
    {
        SuperGod.instance.PlaySE(3);
        var f = Instantiate(fire,transform.position,Quaternion.identity);
        f.GetComponent<Rigidbody2D>().AddForce(fireSpeed * Vector2.left, ForceMode2D.Impulse);
    }
}
