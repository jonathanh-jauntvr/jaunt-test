using System;
using System.Collections;
using System.Collections.Generic;
using Jaunt.Media;
using UnityEngine;

[IntegrationTest.DynamicTest("AutoPlayTest")]
[IntegrationTest.Timeout(5)]
public class ConfigureTest : LoadSceneTest
{

    private string defaultUrl = "https://www.jauntvr.com/title/4d46606f76";

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
        
        GameObject jauntAutoplayObj = GameObject.Find("JauntAutoplay");
        JauntAutoplay jauntAutoplay = jauntAutoplayObj.GetComponent<JauntAutoplay>();
        IntegrationTest.Assert(jauntAutoplay != null);
        IntegrationTest.Assert(jauntAutoplay.autoplayUrl == defaultUrl, "JauntAutoplay default url is not configured correctly");



		yield return null;
	}
}
