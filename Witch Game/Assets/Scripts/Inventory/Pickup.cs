using UnityEngine;

public class Pickup : MonoBehaviour {
    public InventoryItem inventoryItem;

    private void Start() {
        GetComponent<SpriteRenderer>().sprite = inventoryItem.sprite;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("playerBody"))
            other.gameObject.GetComponentInParent<PlayerInventory>().PickUp(this);
    }

    public void PickedUp()
    {
        Destroy(gameObject);
    }
}