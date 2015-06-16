using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public BuildButton button;
    public ActionButton actionButton;
    public GameObject unitPane;
    public GameObject commandPane;
    public GameObject goButton;
    public GameObject arrow;
    public Text stage;

    private Arrow arrowScript;

    void Awake () {
        arrowScript = new Arrow(Instantiate(arrow));
        State.uiController = this;
    }

    public Tile getSelected() {
        return arrowScript.getSource();
    }

    public void setSelected(Tile tile) {
        if(arrowScript.getSource() != null) clearSelected();
        arrowScript.setSource(tile);

        tile.GetComponent<Renderer>().material.color = Color.green;
        tile.changeNeighborsTo(Color.red);
    }

    public void clearSelected() {
        if(arrowScript.getSource()) {
            arrowScript.getSource().GetComponent<Renderer>().material.color = Color.white;
            arrowScript.getSource().changeNeighborsTo(Color.white);
        }
        arrowScript.clear();
    }

    public void doAction(string action) {
        if(action == "move") {

        }
    }

    public void clicked(Tile tile, PointerEventData eventData) {
        if(eventData.button == PointerEventData.InputButton.Left) {
            setSelected(tile);
//            clearCommands();
        } else {
            if(arrowScript.isTargeting()) {
                arrowScript.setDestination(tile);
            }
        }
    }

    public void text(string text) {
        stage.text = text;
    }

    public void clearUI() {
        foreach (Transform child in unitPane.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in commandPane.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void createUnitButton(UnitJSON unit, int count) {
        BuildButton newButton = Instantiate(button);
        newButton.transform.SetParent(unitPane.transform);
        newButton.transform.localPosition = new Vector3(count * 50, -15, 0);
        newButton.transform.localScale = new Vector3(1, 1, 1);
        newButton.transform.localRotation = new Quaternion();
        newButton.setUnit(unit);
    }

    public void createActionButton(string action, int count) {
        ActionButton newButton = Instantiate(actionButton);
        newButton.transform.SetParent(commandPane.transform);
        newButton.transform.localPosition = new Vector3(count * 50, -15, 0);
        newButton.transform.localScale = new Vector3(1, 1, 1);
        newButton.transform.localRotation = new Quaternion();
        newButton.setAction(action);
    }

}
