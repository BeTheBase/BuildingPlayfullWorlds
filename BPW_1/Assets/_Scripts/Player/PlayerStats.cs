using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int Lives = 1;
    public Image BeenHitImage;

    private void Start()
    {
        BeenHitImage.gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        if (Lives < 1)
            StartCoroutine(OnLivesChanged());
    }

    public IEnumerator OnLivesChanged()
    {
        var audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("Dead");
        BeenHitImage.gameObject.SetActive(true);
        BeenHitImage.CrossFadeAlpha(1, 2f, true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
