using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

public class JSONParser {
    MetadataJSON metadata;

    Dictionary<int, TileJSON> tiles = new Dictionary<int, TileJSON>();
    Dictionary<int, UnitJSON> unitsJSON = new Dictionary<int, UnitJSON>();

    public void loadMetadata(string file) {
        TextAsset txt = (TextAsset) Resources.Load(file, typeof(TextAsset));

        metadata = JsonMapper.ToObject<MetadataJSON>(txt.ToString());

        foreach(TileJSON tile in metadata.tiles) {
            tiles.Add(tile.id, tile);
        }
        foreach(UnitJSON unit in metadata.units) {
            unitsJSON.Add(unit.id, unit);
        }
    }

    public Dictionary<int, UnitJSON> getUnits() {
        return unitsJSON;
    }

    public int[][] loadLevel(string file) {
        TextAsset txt = (TextAsset) Resources.Load(file, typeof(TextAsset));

        return JsonMapper.ToObject<int[][]>(txt.ToString());
    }

    public string getUnitSpriteName(int unitId) {
        UnitJSON unitJSON;

        unitsJSON.TryGetValue(unitId, out unitJSON);

        return unitJSON.sprite;
    }

    public string getTileSpriteName(int tileId) {
        TileJSON tileJSON;

        tiles.TryGetValue(tileId, out tileJSON);

        return tileJSON.sprite;
    }

//
//    public IUnitData getUnitData(UnitJSON json) {
//        IUnitData unitData = new UnitData();
//        unitData.setName(json.name);
//        unitData.setHp(json.hp);
//        unitData.setAnimations(json.animationMap);
//        unitData.setScale((float) json.scale);
//        unitData.setSize(1);
//        unitData.setSpeed((float) json.speed);
//        unitData.setActions(json.actions);
//
//        unitData.setXWidth(json.xwidth);
//        unitData.setYWidth(json.ywidth);
//        unitData.setZWidth(json.zwidth);
//
//        Projectile projectile = new Projectile();
//        //        ModelFactory.populateModel(projectile, "cube");
//        IWeapon weapon = new Weapon(projectile, json.damage, (float) json.cooldown);
//
//        unitData.setWeapon(weapon);
//        unitData.setModel(json.model);
//
//        return unitData;
//    }
//
//    public IUnitPrimer create(string unitName) {
//        IUnitPrimer unitPrimer = new UnitPrimer();
//        IUnitData unitData = (UnitData) unitDatum[unitName];
//
//        unitPrimer.setUnitData(unitData);
//
//        return unitPrimer;
//    }
}
