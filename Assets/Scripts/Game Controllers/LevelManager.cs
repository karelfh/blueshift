﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private void Start() {
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            LoadNextLevel();
        }
    }

    private void OnLevelWasLoaded(int level) {
        if (level == 1) {
            MusicManager.Instance.PlayMusic("Menu");
        }
        if (level == 4) {
            MusicManager.Instance.PlayMusic("Theme");
            MusicManager.Instance.StopAudio("Menu");
        }
    }

    public void LoadLevel(string levelName) {
        SceneManager.LoadScene(levelName);
    }

    public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        Application.Quit();
    }

}
