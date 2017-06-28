using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class LoadSceneTest : JauntIntegrationTest {

    private string sceneName;

    void Awake() {
        sceneName = GetSceneName();
    }

    public virtual void Start() {
        Debug.Log("Parent start called");
        StartCoroutine(RunTests());
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns>The name of the production scene that's being tested..</returns>
    public abstract string GetSceneName();

    /// <summary>
    /// Set up the testing environment, run the tests, then tear the environment down.
    /// </summary>
    /// <returns>The tests.</returns>
    private IEnumerator RunTests() {
        CountObjs();
        yield return StartCoroutine(TearDown());
		yield return StartCoroutine(SetUp());
		yield return StartCoroutine(Run());

        IntegrationTest.Pass();  //Required to actually give the green checkmarks, removing this makes the tests fail automatically
    }

    /// <summary>
    /// Loads the production scene and waits a frame for everything to finish loading.
    /// </summary>
    /// <returns>The up.</returns>
    protected IEnumerator SetUp() {
		SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        yield return null;
    }

    /// <summary>
    /// Unloads the production scene and waits a frame.
    /// </summary>
    /// <returns>The down.</returns>
    protected IEnumerator TearDown() {
		try {
			SceneManager.UnloadSceneAsync(sceneName);
		}
		catch (ArgumentException e) {
            
		}
        yield return null;
    }

    protected IEnumerator ReloadScene() {
        yield return StartCoroutine(TearDown());
        yield return StartCoroutine(SetUp());
    }

    /// <summary>
    /// Virtual method for running tests.
    /// </summary>
    /// <returns>The run.</returns>
    protected abstract IEnumerator Run();

    public void CountObjs() {
		GameObject[] allObjs = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        Debug.Log("Number of objects in scene " + SceneManager.GetActiveScene().name + ": " + allObjs.Length);
    }
}
