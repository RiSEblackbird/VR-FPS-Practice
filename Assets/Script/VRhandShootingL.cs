using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRhandShootingL : MonoBehaviour
{
    public GameObject bulletPrefabL;
    public GameObject MazzleflashL;
    public GameObject MFL;
    public Vector3 BulletScaleL;
    public Vector3 MFScaleL;
    public Quaternion MFRotationL;
    public float shotSpeedL;
    public int shotCountL = 500;
    private float shotIntervalL;

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            shotIntervalL += 1;

            if (shotIntervalL % 2 == 0 && shotCountL > 0)
            {
                shotCountL -= 1;

                MazzleflashL.SetActive(true);

                MFL = Instantiate(MazzleflashL, transform.position, transform.rotation);
                MFL.transform.SetParent(gameObject.transform);
                MFL.transform.localScale = MFScaleL;
                MFL.transform.localRotation = MFRotationL;

                GameObject bulletL = (GameObject)Instantiate(bulletPrefabL, MazzleflashL.transform.position, MazzleflashL.transform.rotation);
                bulletL.transform.localScale = BulletScaleL;

                Rigidbody bulletRbL = bulletL.GetComponent<Rigidbody>();
                bulletRbL.AddForce(transform.forward * shotSpeedL);

                Destroy(bulletL, 5.0f);

            }

        }
        else if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            shotCountL = 500;
        }

        MazzleflashL.SetActive(false);

    }
}
