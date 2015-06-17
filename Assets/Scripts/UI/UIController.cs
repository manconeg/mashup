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

    private SelectionManager selectionManager;

    void Awake () {
        selectionManager = new SelectionManager(Instantiate(arrow));
        State.uiController = this;
    }

    public Tile getSelected() {
        return selectionManager.getSource();
    }

    public void setSelected(Tile tile) {
        selectionManager.setSource(tile);
    }

    public void clearSelected() {
        selectionManager.clear();
    }

    public void unit(UnitJSON unit) {
        if(State.gameState.state == PlayState.Placement) {
            // TODO: This should be a gamestate thing, not a dependency on unit factory
            // gamestate needs to check for counter attacks, eventually
            UnitFactory.create(unit);
        }
        if(State.gameState.state == PlayState.Move) {
            // if( there is a destination tile )
            // move unit to destination tile
            // decrement unit from current tile
        }
        if(State.gameState.state == PlayState.Attack) {
            // if( there is a destination tile )
            // attack destination square
        }
    }

    public void clicked(Tile tile, PointerEventData eventData) {
        if(eventData.button == PointerEventData.InputButton.Left) {
            setSelected(tile);
            // clear units
            if(State.gameState.state == PlayState.Placement) {
                // show units player can build
            }
            if(State.gameState.state == PlayState.Move) {
                // set unts to the units in the tile if the state is move
            }
            if(State.gameState.state == PlayState.Attack) {
                // show units capable of attacking
            }
        } else {
            if(selectionManager.isTargeting()) {
                selectionManager.setDestination(tile);
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

//    public void createActionButton(string action, int count) {
//        ActionButton newButton = Instantiate(actionButton);
//        newButton.transform.SetParent(commandPane.transform);
//        newButton.transform.localPosition = new Vector3(count * 50, -15, 0);
//        newButton.transform.localScale = new Vector3(1, 1, 1);
//        newButton.transform.localRotation = new Quaternion();
//        newButton.setAction(action);
//    }

}
