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
    }

    public void OnRetry ()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name);
    }
}
