using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour {

    [SerializeField] private GameObject playerScoreEntry;

    private int lastChangeCounter;


    private void Start() {
        lastChangeCounter = ScoreManager.Instance.ChangeCounter;
    }

    private void Update() {
        if (ScoreManager.Instance.ChangeCounter == lastChangeCounter) {
            // No Change since last update
            return;
        }

        lastChangeCounter = ScoreManager.Instance.ChangeCounter;

        while (transform.childCount > 0) {
            Transform child = transform.GetChild(0);

            child.SetParent(null);
            Destroy(child.gameObject);
        }

        string[] names = ScoreManager.Instance.GetPlayerNames();

        foreach (string name in names) {
            GameObject go = Instantiate(playerScoreEntry);
            go.transform.SetParent(transform);
            go.transform.Find("Player Name").GetComponent<Text>().text = name;
            go.transform.Find("Player Score").GetComponent<Text>().text = ScoreManager.Instance.GetScore(name).ToString();
        }
    }

}
