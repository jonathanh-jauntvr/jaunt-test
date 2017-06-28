using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jaunt.Media;

[IntegrationTest.DynamicTest("AutoPlayTest")]
[IntegrationTest.Timeout(5)]
public class CheckNumberOfObjects : LoadSceneTest {

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
		//Check that the JauntAutoplay and JauntPlayer objects exists
		JauntPlayer[] jauntPlayers = FindObjectsOfType((typeof(JauntPlayer))) as JauntPlayer[];
		IntegrationTest.Assert(jauntPlayers != null && jauntPlayers.Length == 1, "Number of JauntPlayers is not equal to 1!");

		JauntAutoplay[] jauntAutoplays = FindObjectsOfType((typeof(JauntAutoplay))) as JauntAutoplay[];
		IntegrationTest.Assert(jauntAutoplays != null && jauntAutoplays.Length == 1, "Number of JauntAutoplays is not equal to 1!");

		Camera[] cameras = FindObjectsOfType((typeof(Camera))) as Camera[];
		IntegrationTest.Assert(cameras != null && cameras.Length == 1, "Number of cameras is not equal to 1!");

		yield return null;
	}
}
