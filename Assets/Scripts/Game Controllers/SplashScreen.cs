using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    [Tooltip("Text game object that going to be faded.")]
    [SerializeField] private Text splashTextOne;
    [SerializeField] private Text splashTextTwo;
    [Tooltip("Image game object that going to be faded.")]
    [SerializeField] private Image splashImage;


    private IEnumerator Start() {
        // Set alpha to 0 - invisible
        splashTextOne.canvasRenderer.SetAlpha(0f);
        splashTextTwo.canvasRenderer.SetAlpha(0f);
        splashImage.canvasRenderer.SetAlpha(0f);

        FadeIn();
        yield return new WaitForSeconds(2.5f); // Wait 2.5 second and than run next code
        FadeOut();
        yield return new WaitForSeconds(2.5f); // Wait 2.5 second and than run next code
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update() {
        if (Input.GetButton("Fire1")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Fade alpha from 0 to 1 in 1.5 seconds
    private void FadeIn() {
        splashTextOne.CrossFadeAlpha(1f, 1.5f, false);
        splashTextTwo.CrossFadeAlpha(1f, 1.5f, false);
        splashImage.CrossFadeAlpha(1f, 1.5f, false);
    }

    // Fade alpha from 1 to 0 in 1.5 seconds
    private void FadeOut() {
        splashTextOne.CrossFadeAlpha(0f, 1.5f, false);
        splashTextTwo.CrossFadeAlpha(0f, 1.5f, false);
        splashImage.CrossFadeAlpha(0f, 1.5f, false);
    }
}
