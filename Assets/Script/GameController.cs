using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Text scoreLabel;
    public GameObject Reticle;
    public GameObject winnerLabelObject;
    public GameObject RetryButton;

    public void Update ()
    {
        int count = GameObject.FindGameObjectsWithTag ("Enemy").Length;
        scoreLabel.text = count.ToString ();

        if (count == 0) {
            // オブジェクトをアクティブにする
            winnerLabelObject.SetActive(true);
            Reticle.SetActive(false);
        }


        if (OVRInput.Get(OVRInput.Button.Four))
        {
            // 現在のシーン番号を取得
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            // 現在のシーンを再読み込みする
            SceneManager.LoadScene(sceneIndex);
        }
    }

    public void OnRetry ()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name);
    }
}
