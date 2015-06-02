using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions.Syntax;
using UnityEngine;

public class UnitGroup {
    UnitJSON unit;
    Transform transform;
    public int count;

    List<GameObject> objects = new List<GameObject>();

    public UnitGroup(Transform transform, UnitJSON unit) {
        this.unit = unit;
        this.transform = transform;
    }

    public UnitJSON getUnit() {
        return unit;
    }

    public void draw(float y) {
        Sprite sprite = Resources.Load<Sprite>(unit.icon);

        if(count <= 3) {
            int iconX = (count - 1) % 3;
            int iconY = Mathf.FloorToInt((count - 1) / 3);

            objects.Add(putUnitIcon(iconX, iconY + y));
        } else {
            foreach(GameObject obj in objects) {
                Object.Destroy(obj);
            }

            objects.Add(drawCount(y));
            objects.Add(putUnitIcon(1, y));
        }
    }

    private GameObject drawCount(float y) {
        GameObject gameObject = new GameObject();
        gameObject.transform.SetParent(transform);
        gameObject.transform.localPosition = new Vector3(-.16f, .15f - .15f * y, -.1f);
        gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);

        float pixelRatio = (Camera.main.orthographicSize * 2.0f) / Camera.main.pixelHeight;
        gameObject.transform.localScale = new Vector3(pixelRatio * 2.0f, pixelRatio * 2.0f, pixelRatio * 0.1f);

        TextMesh mesh = gameObject.AddComponent<TextMesh>();
        mesh.text = count + "x";
        mesh.fontSize = 20;
        mesh.anchor = TextAnchor.MiddleCenter;

        return gameObject;
    }

    private GameObject putUnitIcon(float x, float y) {
        GameObject gameObject = new GameObject();
        gameObject.transform.SetParent(transform);
        gameObject.transform.localPosition = new Vector3(-.16f + .15f * x, .15f - .15f * y, 0);
        gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        gameObject.transform.localScale = new Vector3(.007f * unit.buttonScale, .007f * unit.buttonScale, 0);

        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>(unit.icon);
        sr.sortingOrder = 1;

        return gameObject;
    }
}
