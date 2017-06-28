using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jaunt.Media;

[IntegrationTest.DynamicTest("AutoPlayTest")]
[IntegrationTest.Timeout(5)]
public class CheckComponents : LoadSceneTest {

	public override void Start() {
		base.Start();
	}

	public override string GetSceneName() {
		return "AutoPlay";
	}

	protected override IEnumerator Run() {
        //Check that the JauntPlayer object only has the JauntPlayer script and the Transform component
        GameObject jauntPlayerObj = GameObject.Find("JauntPlayer");
        IntegrationTest.Assert(jauntPlayerObj != null);
        JauntPlayer jauntPlayer = jauntPlayerObj.GetComponent(typeof(JauntPlayer)) as JauntPlayer;
		IntegrationTest.Assert(jauntPlayer != null, "Jaunt Player is null!");

		Destroy(jauntPlayerObj.GetComponent(typeof(JauntPlayer)));
        yield return null;
        int numComponents = jauntPlayerObj.GetComponents(typeof(Component)).Length;
		IntegrationTest.Assert(numComponents == 1, "Number of JauntPlayer components is " + numComponents + ", should be 1"); //Only the transform component should be left

		//Check that the AutoPlayer object only has the AutoPlayer script and the Transform component
		GameObject jauntAutoplayObj = GameObject.Find("JauntAutoplay");
        IntegrationTest.Assert(jauntAutoplayObj != null);
        JauntAutoplay jauntAutoplay = jauntAutoplayObj.GetComponent(typeof(JauntAutoplay)) as JauntAutoplay;
		IntegrationTest.Assert(jauntAutoplay != null, "JauntAutoplay is null!");

        Destroy(jauntAutoplayObj.GetComponent(typeof(JauntAutoplay)));
        yield return null;
		numComponents = jauntPlayerObj.GetComponents(typeof(Component)).Length;
		IntegrationTest.Assert(numComponents == 1, "Number of JauntAutoplay components is " + numComponents + ", should be 1");

		yield return null;
	}
}
