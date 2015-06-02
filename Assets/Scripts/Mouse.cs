using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {
    Dictionary<int, string> mouseButtons = new Dictionary<int, string>();

    public void Awake() {
        mouseButtons.Add(0, "select");
        mouseButtons.Add(1, "target");
    }

    public void Update () {
        RaycastHit[] hits = scanForContact();
        if(hits.Length == 0) return;


        foreach(KeyValuePair<int, string> action in mouseButtons) {
            if(Input.GetMouseButtonDown(action.Key)) {
            }
        }
    }

    RaycastHit[] scanForContact() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits = Physics.RaycastAll(ray, 100);

        RaycastHit hitt;
        Physics.Raycast(ray, out hitt, 100);

        return hits;
    }
}
