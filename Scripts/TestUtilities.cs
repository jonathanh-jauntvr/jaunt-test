using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TestUtilities {

    /// <summary>
    /// Compares a GameObject to its prefab counterpart. This method checks if the GameObject's child objects and components are the same as
    /// the prefab'see cref=""/>.
    /// </summary>
    /// <returns><c>true</c>, if object matches the prefab, <c>false</c> otherwise.</returns>
    /// <param name="obj">Object.</param>
    /// <param name="prefab">Prefab.</param>
	public static bool CompareObjectToPrefab(GameObject obj, GameObject prefab)
	{
		//Check if prefab and object have the same number of components
        Component[] objComponents = obj.GetComponents<Component>();
        Component[] prefabComponents = prefab.GetComponents<Component>();
		
        if (objComponents.Length != prefabComponents.Length)
		{
            Debug.Log("Object has " + objComponents.Length + " components, prefab has " + prefabComponents.Length);
			return false;
		}

        //Compare object components to prefab components first
        foreach (Component prefabComp in prefabComponents)
		{
			if (obj.GetComponent(prefabComp.GetType()) == null)
			{
                Debug.Log(obj.name + " is missing component " + prefabComp.GetType());
				return false;
			}
		}

        //Check if prefab and object have the same number of children
        if (obj.transform.childCount != prefab.transform.childCount) {
            Debug.Log("Object has " + obj.transform.childCount + " children, prefab has " + prefab.transform.childCount);
            return false;
        }

		//Now compare child gameobjects recursively
		foreach (Transform prefabChild in prefab.transform)
		{
			//First check if the child object exists
			Transform objChild = obj.transform.Find(prefabChild.name);
			if (objChild == null)
			{
				Debug.Log(obj.name + " is missing child object " + prefabChild.name);
				return false;
			}

			//Then compare the child object to the prefab version
			//Returns an error if any of the recursive checks fail
			if (!CompareObjectToPrefab(objChild.gameObject, prefabChild.gameObject))
			{
				return false;
			}
		}

		return true;
	}

    /*
    public static bool CountActiveComponents(GameObject obj) {
        int numActive = 0;
        foreach(Component comp in obj.GetComponents<Component>()) {
            if(comp.)
        }
    }
    */
}
