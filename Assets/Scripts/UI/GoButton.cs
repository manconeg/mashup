using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GoButton : MonoBehaviour {
    private void doAction() {
        State.gameState.getPlayer().doneState();
    }

    public void Start() {
        GetComponent<Button>().onClick.AddListener(doAction);
    }
}
