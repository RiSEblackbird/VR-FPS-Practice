using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRhandShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject Mazzleflash;
    public GameObject MF;
    public Text ShotCount;
    public Vector3 BulletScale;
    public Vector3 MFScale;
    public Quaternion MFRotation;
    public float shotSpeed;
    public int shotCount = 500;
    private float shotInterval;

    void Update()
    {
        ShotCount.text = shotCount.ToString();

        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || Input.GetKey(KeyCode.Mouse0))
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
        else if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || Input.GetKey(KeyCode.R))
        {
            shotCount = 500;
        }

        Mazzleflash.SetActive(false);

    }
}
