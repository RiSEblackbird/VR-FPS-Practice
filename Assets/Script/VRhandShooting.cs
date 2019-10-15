using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRhandShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject Mazzleflash;
    public GameObject MF;
    public Vector3 BulletScale;
    public Vector3 MFScale;
    public Quaternion MFRotation;
    public float shotSpeed;
    public int shotCount = 500;
    private float shotInterval;

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            shotInterval += 1;

            if (shotInterval % 2 == 0 && shotCount > 0)
            {
                shotCount -= 1;

                Mazzleflash.SetActive(true);

                MF = Instantiate(Mazzleflash, transform.position, transform.rotation);
                MF.transform.SetParent(gameObject.transform);
                MF.transform.localScale = MFScale;
                MF.transform.localRotation = MFRotation;

                GameObject bullet = (GameObject)Instantiate(bulletPrefab, Mazzleflash.transform.position, Mazzleflash.transform.rotation);
                bullet.transform.localScale = BulletScale;

                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * shotSpeed);

                Destroy(bullet, 5.0f);

            }

        }
        else if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            shotCount = 500;
        }

        Mazzleflash.SetActive(false);

    }
}
