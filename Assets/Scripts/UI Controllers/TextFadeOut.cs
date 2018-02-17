using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextFadeOut : MonoBehaviour {

    [Tooltip("Seconds after text starts to fade out.")]
    [SerializeField] private float secondsToFadeOut;
    [Tooltip("Duration of the tween in seconds.")]
    [SerializeField] private float duration;
    [Tooltip("Should ignore Time.scale?")]
    [SerializeField] private bool ignoreTimeScale;

    private float delay = .1f;
    private Text textToFade;
    

    private void Awake() {
        textToFade = GetComponent<Text>();
    }

    private void Update() {
        if (gameObject.activeSelf == true) {
            StartCoroutine(StartFadeOut());    
        }
    }

    private IEnumerator StartFadeOut() {
        yield return new WaitForSeconds(secondsToFadeOut);
        textToFade.CrossFadeAlpha(0f, duration, ignoreTimeScale);

        yield return new WaitForSeconds(duration + delay);
        gameObject.SetActive(false);
    }

}
