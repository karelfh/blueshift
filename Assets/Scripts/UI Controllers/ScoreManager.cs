using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [SerializeField] private FloatReference playerScore;

    private Text scoreText;


    private void Awake() {
        scoreText = GetComponent<Text>();
    }

    private void Update() {
        scoreText.text = playerScore.Value.ToString();
    }

}
