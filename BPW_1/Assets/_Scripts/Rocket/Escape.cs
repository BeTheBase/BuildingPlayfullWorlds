using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    public Camera NewCam;
    public Animation RocketAnimation;
    public float TimeToEnd = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.SetActive(false);
            NewCam.gameObject.SetActive(true);
            NewCam = Camera.main;
            RocketAnimation.Play();
            StartCoroutine(EndGame(TimeToEnd));
        }
    }

    private IEnumerator EndGame(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
    }
}
