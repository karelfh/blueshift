using UnityEngine;

public class TimeManager : MonoBehaviour {

    [Header("Slowdown Settings")]
    [Tooltip("How much will time be slowed.")]
    [SerializeField] private FloatReference slowdownFactor;
    [Tooltip("For how long, in seconds, will time be slowed.")]
    [SerializeField] private FloatReference slowdownLength;

    private bool isGameOver = false;


    private void Update() {
        if (!isGameOver) {
            Time.timeScale += (1 / slowdownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 1);
        }
    }

    public void SlowdownTime() {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    public void IsGameOver(bool _isGameOver) {
        isGameOver = _isGameOver;
    }
}
