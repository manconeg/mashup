using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {
    public JSONParser parser = new JSONParser();

    Tile[,] tiles;

    private int turn;
    private List<IPlayer> players = new List<IPlayer>();

    // Move to it's own file
    public enum PlayState{Placement, Attack, Move};
    PlayState state;

	// Use this for initialization
	void Awake () {
        turn = 0;

        Player player = new Player();
        players.Add((IPlayer) player);

        State.gameState = this;
        state = PlayState.Placement;

        parser.loadMetadata("metadata");
        createLevel(parser.loadLevel("level"));
	}

    void Start() {
        getPlayer().doStage(state);
    }

    public void doneState() {
        switch(state) {
            case PlayState.Placement:
                state = PlayState.Attack;
                break;
            case PlayState.Attack:
                state = PlayState.Move;
                break;
            case PlayState.Move:
                state = PlayState.Placement;
                turn ++;
                if(turn >= players.Count) {
                    turn = 0;
                }
                break;
        }
        getPlayer().doStage(state);

    }

    void createUnit(int unitId, Vector2 position) {
        string unitName = parser.getUnitSpriteName(unitId);
        Sprite sprite = Resources.Load<Sprite>(unitName);

        GameObject tile = new GameObject();
        tile.AddComponent<SpriteRenderer>().sprite = sprite;

        tile.transform.localEulerAngles = new Vector3(90, 0, 0);
        tile.transform.parent = this.transform;
    }

    void createLevel(int[][] level) {
        float x = 0;
        float z = 0;

        tiles = new Tile[level.Length, level[0].Length];

        for(int row = 0; row < level.Length; row++) {
            for(int column = 0; column < level[row].Length; column++) {
                int tileId = level[row][column];

                string tileName = parser.getTileSpriteName(tileId);
                Sprite sprite = Resources.Load<Sprite>(tileName);

                GameObject gameObject = new GameObject();
                gameObject.transform.position = new Vector3(x, 0, z + column % 2 * -.32f);
                gameObject.transform.localEulerAngles = new Vector3(90, 0, 0);
                gameObject.transform.parent = this.transform;

                gameObject.AddComponent<BoxCollider>().size = new Vector3(.3f, .64f, .2f);
                gameObject.AddComponent<SpriteRenderer>().sprite = sprite;
                Tile tile = gameObject.AddComponent<Tile>();
                tiles[row, column] = tile;

                x += .47f;
            }
            x = 0;
            z -= .64f;
        }

         for(int i = 0; i < level.Length; i++) {
             for(int j = 0; j < level[i].Length; j++) {
                 findNeighbors(i, j);
             }
         }
    }

    public Player getPlayer() {
        return (Player) players[turn];
    }

    void findNeighbors(int targetRow, int targetColumn) {
        bool offset = targetColumn % 2 == 0 ? true : false;

        int startRow = Mathf.Max(0, targetRow - 1);
        int startColumn = Mathf.Max(0, targetColumn - 1);

        int endRow = Mathf.Min(tiles.GetLength(0), targetRow + 2);
        int endColumn = Mathf.Min(tiles.GetLength(1), targetColumn + 2);

        for(int x = startRow; x < endRow; x++) {
            for (int y = startColumn; y < endColumn; y++) {
                if (y != targetColumn) {
                    if (!offset && (x == startRow)) continue;
                    if (offset && (x == endRow - 1)) continue;
                }

                if (x == targetRow && y == targetColumn) continue;

                tiles[targetRow, targetColumn].addNeighbor(tiles[x, y]);
            }
        }
    }
}
