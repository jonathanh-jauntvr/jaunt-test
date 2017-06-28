using System;
using System.Collections;
using System.Collections.Generic;
using Jaunt.Media;
using UnityEngine;

[IntegrationTest.DynamicTest("AutoPlayTest")]
[IntegrationTest.Timeout(5)]
public class CheckUnexpectedObjects : LoadSceneTest
{

    private string[] expectedObjects = {"JauntPlayer", "JauntAutoplay"};

	public override void Start()
	{
		base.Start();
	}

	public override string GetSceneName()
	{
		return "AutoPlay";
	}

	protected override IEnumerator Run()
	{
        foreach (string objName in expectedObjects) {
            GameObject obj = GameObject.Find(objName);
            IntegrationTest.Assert(obj != null, objName + " does not exist!");
            Destroy(obj);
            yield return null;
        }

        //Only main camera should be left
        GameObject[] objs = FindObjectsOfType<GameObject>();
        IntegrationTest.Assert(objs.Length == 2, "Only the TestRunner and Main Camera should be active in the scene!");

		yield return null;
	}
}
