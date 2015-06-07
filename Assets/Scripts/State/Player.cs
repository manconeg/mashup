using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IPlayer {

    private bool targeting;
    public bool isTargeting() { return targeting; }
    public void isTargeting(bool targeting) { this.targeting = targeting; }

    public void doneState() {
        State.gameState.doneState();
    }

    public void doStage(GameState.PlayState state) {
        State.uiController.clearUI();
        switch(state) {
            case GameState.PlayState.Placement:
                startPlacement();
                break;
            case GameState.PlayState.Attack:
                startAttack();
                break;
            case GameState.PlayState.Move:
                startMove();
                break;
        }
    }

    private void startAttack() {
        // Show Attack Button Greyed Out
    }

    private void startMove() {
        // Show Move Button Greyed Out
    }

    private void startPlacement() {
        State.uiController.hideArrow();
        createUnitsUI();
    }

    public void clicked(Tile tile) {
        if(this.isTargeting()) {
            State.uiController.drawArrow(Tile.selected, tile);
        } else {
            if(Tile.selected != null) Tile.selected.reset();
            tile.select();
        }
    }

    void createAttackUI() {

    }

    void createUnitsUI() {
        Dictionary<int, UnitJSON> units = State.gameState.parser.getUnits();

        int count = 0;
        foreach (UnitJSON unit in units.Values) {
            State.uiController.createUnitButton(unit, count);

            count++;
        }
    }
}
