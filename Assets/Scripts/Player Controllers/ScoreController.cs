using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour {

    [SerializeField] private FloatVariable playerScore;
    [SerializeField] private FloatReference starScoreValue;
    [SerializeField] private UnityEvent pickupEvent;


    private void Start() {
        playerScore.Value = 0f;
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Star")) {
            pickupEvent.Invoke();

            playerScore.Value += starScoreValue.Value;
            coll.GetComponent<ObjectDestroyController>().Destroy();
        }
    }

}
