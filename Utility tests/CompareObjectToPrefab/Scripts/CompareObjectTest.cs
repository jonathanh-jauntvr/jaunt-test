using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class CompareObjectTest : MonoBehaviour {

    public virtual void Start() {
        RunTest(GetExpected());
        IntegrationTest.Pass();
    }

	void RunTest(bool expected)
	{
		GameObject obj = GameObject.Find(GetObjectName());
		if (obj == null)
		{
			IntegrationTest.Assert(false, "Object is null");
		}

		GameObject prefab = PrefabUtility.GetPrefabParent(obj) as GameObject;
		if (prefab == null)
		{
			IntegrationTest.Assert(false, "Prefab is null");
		}
		bool success = TestUtilities.CompareObjectToPrefab(obj, prefab);
		IntegrationTest.Assert(success == expected);
	}

    protected abstract string GetObjectName();
    protected abstract bool GetExpected();
}
