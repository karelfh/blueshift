using UnityEngine;

public class TimeManager : MonoBehaviour {

    private bool isGameStarted = false;
    private bool isGameOver = false;


    private void Update() {
        if (!isGameStarted) {
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;

            if (isGameOver) {
                Time.timeScale = 0f;
            }
        }
    }

    public void IsGameOver(bool _isGameOver) {
        isGameOver = _isGameOver;
    }

    public void IsGameStarted(bool _isGameStarted) {
        isGameStarted = _isGameStarted;
    }
}
