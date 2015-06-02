using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour {
    UnitJSON unit;
    public void setUnit(UnitJSON unit) {
        this.unit = unit;

        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.gameObject.transform.localScale = new Vector3(unit.buttonScale, unit.buttonScale, 1);
        spriteRenderer.sprite = Resources.Load<Sprite>(unit.icon);
    }

    public void create() {
        UnitFactory.create(unit);
    }

    public void Start() {
        GetComponent<Button>().onClick.AddListener(create);
    }
}
