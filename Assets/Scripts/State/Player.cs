using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IPlayer {

    public GameObject arrow;

    private bool targeting;
    public bool isTargeting() { return targeting; }
    public void isTargeting(bool targeting) { this.targeting = targeting; }

    public void setArrow(GameObject arrow) { this.arrow = arrow; }
    public void yourTurn() {
        hideArrow();
    }

    private void hideArrow() {
        arrow.transform.position = new Vector3(-10, -10, -10);
    }

    public void drawArrow(Tile from, Tile to) {
        Vector3 position = from.transform.position + to.transform.position;
        arrow.transform.position = position / 2;
        arrow.transform.LookAt(to.transform);

        float scale = Vector3.Distance(from.transform.position, to.transform.position) / .64f;

        arrow.transform.localScale = new Vector3(1, 1, scale);
    }
}
