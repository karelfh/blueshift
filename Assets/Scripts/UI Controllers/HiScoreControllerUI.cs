using UnityEngine;
using UnityEngine.UI;

public class HiScoreControllerUI : MonoBehaviour {

    private Text scoreText;


    public void Awake() {
        scoreText = GetComponent<Text>();
    }

    private void Start() {
        scoreText.text = "High Score: " + PlayerSettings.GetPlayerHiScore();
    }

}