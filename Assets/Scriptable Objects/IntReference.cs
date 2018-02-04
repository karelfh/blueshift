[System.Serializable]
public class IntReference {
    public bool UseConstant = true;
    public int ConstantValue;
    public IntReference Variable;

    public IntReference() { }

    public IntReference(int value) {
        UseConstant = true;
        ConstantValue = value;
    }

    public int Value {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public static implicit operator int(IntReference reference) {
        return reference.Value;
    }
}
