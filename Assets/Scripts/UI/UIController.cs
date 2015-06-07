using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {
    public BuildButton button;
    public GameObject unitPane;
    public GameObject commandPane;
    public GameObject goButton;
    public GameObject arrow;

    private GameObject actualArrow;

    // Use this for initialization
    void Awake () {
        actualArrow = Instantiate(arrow);
        State.uiController = this;
    }

    public void drawArrow(Tile from, Tile to) {
        Vector3 position = from.transform.position + to.transform.position;
        float scale = Vector3.Distance(from.transform.position, to.transform.position) / .64f;

        actualArrow.transform.position = position / 2;
        actualArrow.transform.LookAt(to.transform);
        arrow.transform.localScale = new Vector3(1, 1, scale);
    }

    public void hideArrow() {
        arrow.transform.position = new Vector3(-10, -10, -10);
    }

    // Move to UI
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

    // Move to UI
    public void createUnitButton(UnitJSON unit, int count) {
        BuildButton newButton = Instantiate(button);
        newButton.transform.SetParent(unitPane.transform);
        newButton.transform.localPosition = new Vector3(count * 50 + 15, -15, 0);
        newButton.transform.localScale = new Vector3(1, 1, 1);
        newButton.transform.localRotation = new Quaternion();
        newButton.setUnit(unit);
    }

}
