using UnityEngine;

public class TimeManager : MonoBehaviour {

    [Header("Slowdown Settings")]
    [Tooltip("How much will time be slowed.")]
    [SerializeField] private FloatReference slowdownFactor;
    [Tooltip("For how long, in seconds, will time be slowed.")]
    [SerializeField] private FloatReference slowdownLength;

    private bool isGameStarted = false;
    private bool isGameOver = false;


    private void Update() {
        if (!isGameStarted) {
            Time.timeScale = 0f;
        } else {
            if (!isGameOver && isGameStarted) {
                Time.timeScale += (1 / slowdownLength) * Time.unscaledDeltaTime;
                Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 1);
            } else {
                Time.timeScale = 0f;
            }
        }

        
    }

    public void SlowdownTime() {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    public void IsGameOver(bool _isGameOver) {
        isGameOver = _isGameOver;
    }

    public void IsGameStarted(bool _isGameStarted) {
        isGameStarted = _isGameStarted;
    }
}
