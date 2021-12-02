using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField] string dialogue;

    private bool isColliding = false;
    private Collision2D collidedWith = null;
    private Canvas UI = null;

    private void Awake() {
        UI = this.gameObject.transform.GetComponentInChildren<Canvas>(includeInactive: true);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isColliding = true;
        collidedWith = collision;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        isColliding = false;
        collidedWith = null;
    }

    private void Update() {
        if (isColliding) {
            if (collidedWith != null) {
                if (collidedWith.gameObject.GetComponent<PlayerMovement>() != null && Input.GetKeyDown(KeyCode.E)) {
                    Interact();
                }
            }
        }
    }
    private void Interact() {
        if (UI != null) {
            UI.gameObject.SetActive(true);
            TextMeshProUGUI text = UI.GetComponentInChildren<TextMeshProUGUI>();
            if (text != null) {
                text.text = dialogue;
            } else { Debug.Log("No text component found"); }
            
        } else { Debug.Log("No Canvas Component in child"); }

    }

    public void exitMenu() {
        if (UI != null) {
            UI.gameObject.SetActive(false);
        }
    }
}
