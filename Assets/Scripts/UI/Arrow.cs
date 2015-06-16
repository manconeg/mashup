using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow {
    private GameObject arrow;
    private Tile source;
    private Tile destination;

    public Arrow(GameObject arrow) {
        this.arrow = arrow;
    }

    public void clear() {
        source = null;
        destination = null;
        hideArrow();
    }

    public bool isTargeting() {
        return source;
    }

    public void setSource(Tile tile) {
        destination = null;
        source = tile;
        hideArrow();
    }

    public Tile getSource() {
        return source;
    }

    public Tile getDestination() {
        return destination;
    }

    public void setDestination(Tile tile) {
        destination = tile;
        drawArrow();
    }

    private void drawArrow() {
        Vector3 position = source.transform.position + destination.transform.position;
        float scale = Vector3.Distance(source.transform.position, destination.transform.position) / .64f;

        arrow.transform.position = position / 2;
        arrow.transform.LookAt(destination.transform);
        arrow.transform.localScale = new Vector3(1, 1, scale);
    }

    public void hideArrow() {
        arrow.transform.position = new Vector3(-10, -10, -10);
    }
}
