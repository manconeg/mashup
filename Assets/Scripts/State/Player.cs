using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IPlayer {
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

    private void startPlacement() {
        State.uiController.clearSelected();
        State.uiController.text("place");
        createUnitsUI();
    }

    private void startAttack() {
        State.uiController.clearSelected();
        State.uiController.text("attack");
        createAttackUI();
    }

    private void startMove() {
        State.uiController.clearSelected();
        State.uiController.text("move");
    }

    void createAttackUI() {
        State.uiController.createActionButton("test", 0);
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
