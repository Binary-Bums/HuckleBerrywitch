using UnityEngine;

public class CraftingToggle : MonoBehaviour {
    public KeyCode key = KeyCode.C;
    public static event System.Action ToggleCrafting;
    private bool range = false;

    private void Update() {
        if (Input.GetKeyDown(key) && range)
        {
            ToggleCrafting?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("playerBody")) range = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("playerBody")) range = false;
    }
}