using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[IntegrationTest.DynamicTest("CompareObjectToPrefab")]
[IntegrationTest.Timeout(5)]
public class WrongComponentInChild : CompareObjectTest
{

	// Use this for initialization
	public override void Start()
	{
		base.Start();
	}

	protected override string GetObjectName()
	{
		return "WrongComponentInChild";
	}

	protected override bool GetExpected()
	{
		return false;
	}
}
