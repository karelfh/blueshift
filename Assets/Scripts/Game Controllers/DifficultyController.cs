using UnityEngine;
using System.Collections;

public class DifficultyController : MonoBehaviour {

    [SerializeField] private FloatVariable spawnDelay;
    [SerializeField] private FloatReference change;
    [SerializeField] private FloatReference changeTime;


    private void Start() {
        spawnDelay.Value = 1f;

        StartCoroutine(SpeedIncrease());
    }

    private IEnumerator SpeedIncrease() {
        while (true) {
            yield return WaitFor(changeTime);

            spawnDelay.Value -= change;   
        }
    }

    private IEnumerator WaitFor(float seconds) {
        float end = Time.realtimeSinceStartup + seconds;

        while (Time.realtimeSinceStartup < end) {
            yield return null;
        }
    }

}
