using UnityEngine;

[CreateAssetMenu(fileName = "New String", menuName = "Variables/String", order = 3)]
public class StringVariable : ScriptableObject {

    [SerializeField] private string value = string.Empty;

    public string Value {
        get { return value; }
        set { this.value = value; }
    }

}
