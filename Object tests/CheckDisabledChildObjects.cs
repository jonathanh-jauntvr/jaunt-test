using System.Collections;
using System.Collections.Generic;
using Jaunt.Media.UI;
using UnityEditor;
using UnityEngine;

[IntegrationTest.DynamicTest("GameObjectTests")]
[IntegrationTest.Timeout(5)]
public class CheckDisabledChildObjects : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Run () {
        GameObject controlsObj = GameObject.Find("Jaunt2DControls");
        IntegrationTest.Assert(controlsObj != null, "Jaunt2DControls object does not exist!");
        GameObject controlsPrefab = PrefabUtility.GetPrefabParent(controlsObj) as GameObject;
        IntegrationTest.Assert(controlsPrefab != null, "Jaunt2CControls prefab cannot be found!");
	}
}
