using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jaunt.Media;
using UnityEditor;

[IntegrationTest.DynamicTest("AutoPlayTest")]
[IntegrationTest.Timeout(5)]
public class CheckObjectInstances : LoadSceneTest
{

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
        GameObject jauntPlayer = GameObject.Find("JauntPlayer");
        GameObject jauntPlayerPrefab = PrefabUtility.GetPrefabParent(jauntPlayer) as GameObject;
        jauntPlayerPrefab = Instantiate(jauntPlayerPrefab);
        yield return null;
        bool success = TestUtilities.CompareObjectToPrefab(jauntPlayer, jauntPlayerPrefab);
        IntegrationTest.Assert(success, "JauntPlayer instance does not match prefab");

		GameObject jauntAutoplay = GameObject.Find("JauntAutoplay");
        GameObject jauntAutoplayPrefab = PrefabUtility.GetPrefabParent(jauntAutoplay) as GameObject;
        jauntAutoplayPrefab = Instantiate(jauntAutoplayPrefab);
        yield return null;
        success = TestUtilities.CompareObjectToPrefab(jauntAutoplay, jauntAutoplayPrefab);
		IntegrationTest.Assert(success, "JauntAutoplay instance does not match prefab");

        Destroy(jauntPlayerPrefab);
        Destroy(jauntAutoplayPrefab); //These newly instantiated objects roll over to the next test if not cleaned up

		yield return null;
	}
}
