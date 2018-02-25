using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> {

    [SerializeField] private FloatReference playerScore;
    [SerializeField] private FloatVariable playerHiScore;


    public void CheckHiScore() {
        if (playerScore.Value > playerHiScore.Value) {
            playerHiScore.Value = playerScore.Value;
            PlayerSettings.SetPlayerHiScore(playerHiScore.Value);
        }
    }

    public void ResetHiScore() {
        playerHiScore.Value = 0;
        PlayerSettings.SetPlayerHiScore(playerHiScore.Value);
    }

}
