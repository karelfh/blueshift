using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneItem : Editor {

    [MenuItem("Open Scene/Menu/Preload")]
    public static void OpenPreload() {
        OpenScene("00a Preload");
    }

    [MenuItem("Open Scene/Menu/Menu Preload")]
    public static void OpenMenuPreload() {
        OpenScene("00b Menu Preload");
    }

    [MenuItem("Open Scene/Menu/Main Menu")]
    public static void OpenMainMenu() {
        OpenScene("01a Main Menu");
    }

    [MenuItem("Open Scene/Menu/Options")]
    public static void OpenOptions() {
        OpenScene("01b Options");
    }

    [MenuItem("Open Scene/Levels/Game")]
    public static void OpenGame() {
        OpenScene("02 Game");
    }


    private static void OpenScene(string name) {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) {
            EditorSceneManager.OpenScene("Assets/Scenes/" + name + ".unity");
        }
    }
}
