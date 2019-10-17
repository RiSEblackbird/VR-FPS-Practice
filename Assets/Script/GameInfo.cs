using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            // 入力されたキー名
            string keyStr = Input.inputString;
            Debug.Log(keyStr);
        }

        foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(code))
            {
                // 入力されたキー名を表示
                Debug.Log(code.ToString());
            }
        }



    }
}
