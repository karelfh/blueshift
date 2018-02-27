using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> {

    [SerializeField] private FloatReference playerScore;
  

    public void CheckHiScore() {
        float playerHiScore = PlayerSettings.GetPlayerHiScore();

        if (playerScore.Value > playerHiScore) {
            playerHiScore = playerScore.Value;
            PlayerSettings.SetPlayerHiScore(playerHiScore);
        }
    }

    public void ResetHiScore() {
        float playerHiScore = PlayerSettings.GetPlayerHiScore();

        playerHiScore = 0;
        PlayerSettings.SetPlayerHiScore(playerHiScore);
    }

}
