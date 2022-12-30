using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    int isFnished;
    public GameObject panel;
    public Text red_ball_text, white_ball_text, blue_ball_text;
    public int white_ball, red_ball, blue_Ball;
    public void restartScene()
    {
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt(nameof(isFnished)) == 1)
        {
            panel.SetActive(true);
        }
        red_ball_text.text =" "+ PlayerPrefs.GetInt(nameof(red_ball));
        white_ball_text.text =" "+ PlayerPrefs.GetInt(nameof(white_ball));
        blue_ball_text.text =" "+ PlayerPrefs.GetInt(nameof(blue_Ball));

    }
}
