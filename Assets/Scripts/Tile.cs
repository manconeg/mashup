using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler {
    Dictionary<int, UnitGroup> units = new Dictionary<int, UnitGroup>();

    public List<Tile> neighbors = new List<Tile>();

    public void addNeighbor(Tile tile) {
        neighbors.Add(tile);
    }

    public void addUnit(UnitJSON unit) {
        if(!units.ContainsKey(unit.id)) units.Add(unit.id, new UnitGroup(transform, unit));

        UnitGroup group = units[unit.id];

        group.count++;

        IDictionaryEnumerator enumerator = units.GetEnumerator();
        int location = 0;
        while (enumerator.MoveNext()) {
            UnitGroup currentGroup = (UnitGroup) enumerator.Value;
            currentGroup.draw(location);
            location++;
        }
    }

    public void move(Tile tile) {

    }

    public void attack(Tile tile) {
    }

    #region IPointerClickHandler implementation
    public void OnPointerClick(PointerEventData eventData) {
        State.uiController.clicked(this, eventData);
    }
    #endregion

    public void changeNeighborsTo(Color color) {
        for(int i = 0; i < neighbors.Count; i++) {
            neighbors[i].gameObject.GetComponent<Renderer>().material.color = color;
        }
    }

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
