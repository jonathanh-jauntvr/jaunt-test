using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[IntegrationTest.DynamicTest("CompareObjectToPrefab")]
[IntegrationTest.Timeout(5)]
public class TooManyComponentsInChild : CompareObjectTest
{

	// Use this for initialization
	public override void Start()
	{
		base.Start();
	}

	protected override string GetObjectName()
	{
		return "TooManyComponentsInChild";
	}

	protected override bool GetExpected()
	{
		return false;
	}
}
