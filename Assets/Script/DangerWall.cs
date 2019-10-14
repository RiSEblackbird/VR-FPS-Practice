using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DangerWall : MonoBehaviour
{
    // オブジェクトと接触した時に呼ばれるコールバック
    private void OnCollisionEnter (Collision hit)
    {
        // 接触したオブジェクトのタグが"Player"の場合
        if (hit.gameObject.CompareTag ("Player")) {

            // 現在のシーン番号を取得
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            // 現在のシーンを再読み込みする
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
