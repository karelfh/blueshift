using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour {

    [SerializeField] private FloatReference playerHealth;

    private Image hpSlider;


    private void Awake() {
        hpSlider = GetComponent<Image>();
    }

    private void Update() {
        hpSlider.fillAmount = playerHealth.Value;
    }

}
