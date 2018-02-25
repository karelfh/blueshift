using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour {

    [SerializeField] private StringVariable changeText;

    private Text textToChange;


    private void Awake() {
        textToChange = GetComponent<Text>();
    }

    private void Start() {
        textToChange.text = changeText.Value;
    }

}
