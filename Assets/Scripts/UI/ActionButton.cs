using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour {
    public string action;
    public Player player;

    private void doAction() {
        switch(action) {
            case "move":
                State.gameState.getPlayer().isTargeting(true);
            break;
        }
    }

    public void Start() {
        GetComponent<Button>().onClick.AddListener(doAction);
    }
}
