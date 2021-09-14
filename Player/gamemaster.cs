using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gamemaster : MonoBehaviour
{
    public int point = 0;
    public int highScore = 0;
    public Text textpoint;
    public Text highscoreText;
    public Text PassLevelText;
    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = ("High Score : " + PlayerPrefs.GetInt("highScore") + ",000");
        highScore = PlayerPrefs.GetInt("highScore", 0);
        if (PlayerPrefs.HasKey("point")){
            Scene ActiveScreen = SceneManager.GetActiveScene();
            if (ActiveScreen.buildIndex == 1)
            {
                PlayerPrefs.DeleteKey("point");
                point = 0;
            }
            else
            {
                point = PlayerPrefs.GetInt("point");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        textpoint.text = "Points : " + point.ToString()+",000";
    }
}
