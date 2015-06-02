using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Camera.main.transform.localEulerAngles = new Vector3(90, 0, 0);
        Camera.main.transform.position = new Vector3(1, 2, 1);
    }

    // Update is called once per frame
    void Update () {
        int tilesWide = 11;
        int tilesHigh = 8;

        Vector3 cameraOffset = new Vector3();

        Vector3 mapUpperLeft = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0));
        if(mapUpperLeft.x > 0) cameraOffset.x += .1f;
        if(mapUpperLeft.y < Camera.main.pixelHeight) cameraOffset.z -= .1f;

        Vector3 mapLowerRight = Camera.main.WorldToScreenPoint(new Vector3(0.44f * tilesWide, 0, -0.64f * tilesHigh));
        if(mapLowerRight.x < Camera.main.pixelWidth) cameraOffset.x -= .1f;
        if(mapLowerRight.y > 0) cameraOffset.z += .1f;

        Camera.main.transform.position += cameraOffset;

//        if(Camera.main.fieldOfView.)
        if(Input.GetKey(KeyCode.W)) {
            //if(Input.GetKey(KeyCode.UpArrow)) {
            Camera.main.transform.position = Camera.main.transform.position + new Vector3(0, 0, .1f);
        }
        if(Input.GetKey(KeyCode.S)) {
            //		if(Input.GetKey(KeyCode.DownArrow)) {
            Camera.main.transform.position = Camera.main.transform.position + new Vector3(0, 0, -.1f);
        }
        if(Input.GetKey(KeyCode.A)) {
            //		if(Input.GetKey(KeyCode.LeftArrow)) {
            Camera.main.transform.position = Camera.main.transform.position + new Vector3(-.1f, 0, 0);
        }
        if(Input.GetKey(KeyCode.D)) {
            //		if(Input.GetKey(KeyCode.RightArrow)) {
            Camera.main.transform.position = Camera.main.transform.position + new Vector3(.1f, 0, 0);
        }
    }
}
