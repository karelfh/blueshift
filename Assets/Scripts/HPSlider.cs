using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour {

    [SerializeField] private FloatReferece playerHealth;

    private Slider hpSlider;


    private void Awake() {
        hpSlider = GetComponent<Slider>();
    }

    private void Update() {
        hpSlider.value = playerHealth.Value;
    }

}
