using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour {


    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
