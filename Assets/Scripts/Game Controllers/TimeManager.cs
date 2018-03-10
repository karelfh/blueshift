using UnityEngine;

public class TimeManager : MonoBehaviour {

    private bool isGameStarted = false;
    private bool isGamePaused = false;
    private bool isGameOver = false;


    private void Update() {
        if (!isGameStarted) {
            Time.timeScale = 0f;
        } else if (!isGamePaused) {
            Time.timeScale = 1f;

            if (isGameOver) {
                Time.timeScale = 0f;
            }
        } else if (isGamePaused) {
            Time.timeScale = 0f;
        }
    }

    public void IsGameOver(bool _isGameOver) {
        isGameOver = _isGameOver;
    }

    public void IsGamePaused(bool _isGamePaused) {
        isGamePaused = _isGamePaused;
    }

    public void IsGameStarted(bool _isGameStarted) {
        isGameStarted = _isGameStarted;
    }
}
