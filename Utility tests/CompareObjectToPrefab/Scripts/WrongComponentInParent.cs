using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[IntegrationTest.DynamicTest("CompareObjectToPrefab")]
[IntegrationTest.Timeout(5)]
public class WrongComponentInParent : CompareObjectTest
{

	// Use this for initialization
	public override void Start()
	{
		base.Start();
	}

	protected override string GetObjectName()
	{
		return "WrongComponentInParent";
	}

	protected override bool GetExpected()
	{
		return false;
	}
}
