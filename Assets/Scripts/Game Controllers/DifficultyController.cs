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
            yield return new WaitForSeconds(changeTime);

            spawnDelay.Value -= change;
        }
    }

}
