using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HP_UI : MonoBehaviour
{
    private Slider hpslider;
    private DestroyObject enemy;

    void Start()
    {
        enemy = transform.root.GetComponent<DestroyObject>();

        hpslider = transform.Find("Slider").GetComponent<Slider>();
    }


    void Update()
    {
        //hpslider.value = enemy.damage;
        transform.rotation = Camera.main.transform.rotation; // MainCameraに対面する。
    }
}
