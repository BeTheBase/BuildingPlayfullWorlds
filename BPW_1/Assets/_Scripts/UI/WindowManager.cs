using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowManager : MonoBehaviour
{
    public List<GameObject> Windows;

    public GameObject Rocket;

    public Camera MainCamera;

    public float TimeBeforePlay = 7f;

    private SceneManager sceneManager;

    public void PlayGameRocket(float time)
    {
        Animation animation = Rocket.GetComponent<Animation>();
        animation.Play();
        StartCoroutine(LoadSceneAfterTime(time));
    }

    public void PlayGameNormal(float time)
    {
        Animation animation = MainCamera.GetComponent<Animation>();
        animation.Play();
        StartCoroutine(LoadSceneAfterTime(time));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadSceneAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(1);
    }

    public void SwitchWindows(string windowName)
    {
        if (windowName == null) return;

        foreach (var win in Windows)
        {
            if (win.name == windowName)
                win.SetActive(true);
            else
                win.SetActive(false);
        }
    }

    /// <summary>
    /// Public method to set an game object active or inactive ( this function is called with a button )  
    /// </summary>
    public void SetActive(GameObject _activeGameObject)
    {
        //When _activeGameObject is active set to inactive
        if (_activeGameObject.activeSelf)
            _activeGameObject.SetActive(false);
        //When not set to active
        else
            _activeGameObject.SetActive(true);
    }
}
