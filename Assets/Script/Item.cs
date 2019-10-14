using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Player")) {
            // このコンポーネントを持つGameObjectを破棄する
            Destroy(gameObject);
        }
            
        
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0));
    }
}
