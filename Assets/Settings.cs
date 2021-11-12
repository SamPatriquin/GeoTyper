using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    Canvas UI = null;

    private void Awake() {
        UI = this.gameObject.GetComponentInChildren<Canvas>(includeInactive: true);
        if (UI == null) { Debug.Log("No canvas found in child"); }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (UI != null) {
                UI.gameObject.SetActive(true);
            }
            Time.timeScale = 0;
        }
    }

    public void exitMenu() {
        if (UI != null) {
            UI.gameObject.SetActive(false);
        }
        Time.timeScale = 1;
    }
}
