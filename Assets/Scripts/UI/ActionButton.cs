using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour {
    private string action;

    public void setAction(string action) {
        this.action = action;
    }

    private void doAction() {
//        State.uiController.doAction(action);
    }

    public void Start() {
        GetComponent<Button>().onClick.AddListener(doAction);
    }
}