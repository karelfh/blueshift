using UnityEngine;

public class ScoreController : MonoBehaviour {

    [SerializeField] private FloatVariable playerScore;
    [SerializeField] private FloatReference starScoreValue;


    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Star")) {
            playerScore.Value += starScoreValue.Value;
            coll.GetComponent<ObjectDestroyController>().Destroy();
        }
    }

}
