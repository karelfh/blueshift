using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    [SerializeField] private FloatReference speed;

    private Renderer textureRenderer;


    private void Awake() {
        textureRenderer = GetComponent<Renderer>();
    }

    private void Update() {
        Vector2 offset = new Vector2(0, speed * Time.time);

        textureRenderer.material.mainTextureOffset = offset;
    }

}
