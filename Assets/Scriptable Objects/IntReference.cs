using UnityEngine;

[System.Serializable]
public class IntReference {

    public bool useConstant;
    public int constantValue;
    public IntVariable variable;

    public int Value {
        get {
            return useConstant ? constantValue :
                                 variable.value;
        }
    }

}
