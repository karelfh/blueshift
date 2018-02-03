using UnityEngine;

[System.Serializable]
public class FloatReferece {

    public bool useConstant;
    public float constantValue;
    public FloatVariable variable;

    public float Value {
        get { return useConstant ? constantValue :
                                   variable.value; }
    }

}
