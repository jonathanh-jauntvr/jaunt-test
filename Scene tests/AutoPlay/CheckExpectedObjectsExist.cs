using System;
using System.Collections;
using System.Collections.Generic;
using Jaunt.Media;
using UnityEngine;

[IntegrationTest.DynamicTest("AutoPlayTest")]
[IntegrationTest.Timeout(5)]
public class CheckExpectedObjectsExist : LoadSceneTest {

    public override void Start() {
        base.Start();
    }

    public override string GetSceneName()
    {
        return "AutoPlay";
    }

    protected override IEnumerator Run()
    {
        //Check that the JauntAutoplay and JauntPlayer objects exists
        JauntPlayer jauntPlayer = FindObjectOfType(typeof(JauntPlayer)) as JauntPlayer;
        IntegrationTest.Assert(jauntPlayer != null && jauntPlayer.gameObject != null, "Cannot find JauntPlayer object!");

        JauntAutoplay jauntAutoplay = FindObjectOfType(typeof(JauntAutoplay)) as JauntAutoplay;
        IntegrationTest.Assert(jauntAutoplay != null && jauntAutoplay.gameObject != null, "Cannot find JauntAutoplay object!");

        Camera cam = FindObjectOfType(typeof(Camera)) as Camera;
        IntegrationTest.Assert(cam != null && cam.gameObject != null, "Cannot find camera object!");

        yield return null;
    }
}
