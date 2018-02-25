using UnityEngine;
using UnityEngine.UI;

public class PopupTextChanger : MonoBehaviour {

    [SerializeField] private StringVariable settingsSaved;
    [SerializeField] private StringVariable scoreReset;

    private Text textToChange;


    private void Awake() {
        textToChange = GetComponent<Text>();
    }

    public void SaveSettingsText() {
        textToChange.text = settingsSaved.Value;
    }

    public void ResetScoreText() {
        textToChange.text = scoreReset.Value;
    }

}
