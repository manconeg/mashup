﻿using UnityEngine;
using System.Collections;

public class UnitFactory {
    public static void create(UnitJSON unit) {
        Tile tile = State.uiController.getSelected();
        tile.addUnit(unit);
    }
}
