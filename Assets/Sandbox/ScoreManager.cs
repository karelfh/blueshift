using System.Linq;
using System.Collections.Generic;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> {

    private Dictionary<string, int> playerScores;

    public int ChangeCounter { get { return changeCounter; } }
    private int changeCounter;


    private void Start() {
        SetScore("Eldrik", 1750);
        SetScore("Caedwyn", 9001);
        SetScore("Aztaban", 2500);
        SetScore("Anwaren", 3105);
        SetScore("Romel", 45);
    }


    private void Init() {
        if (playerScores != null) {
            return;
        }

        playerScores = new Dictionary<string, int>();
    }

    public string[] GetPlayerNames() {
        Init();

        //return playerScores.Keys.ToArray();
        return playerScores.Keys.OrderByDescending(n => GetScore(n)).ToArray();
    }

    public string[] GetPlayerNames(string sort) {
        Init();

        return playerScores.Keys.OrderByDescending(n => GetScore(n)).ToArray();
    }

    public int GetScore(string playerName) {
        Init();

        if (playerScores.ContainsKey(playerName) == false) {
            // We have no score record at all fot this player name.
            return 0;
        }

        return playerScores[playerName];
    }

    public void SetScore(string playerName, int scoreValue) {
        Init();

        changeCounter++;

        if (playerScores.ContainsKey(playerName) == false) {
            // do we need this?
        }

        playerScores[playerName] = scoreValue;
    }

    public void ChangeScore(string playerName, int scoreValue) {
        Init();

        int currentScore = GetScore(playerName);
        SetScore(playerName, currentScore + scoreValue);

    }

}
