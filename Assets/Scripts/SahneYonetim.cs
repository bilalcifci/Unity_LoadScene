using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SahneYonetim : MonoBehaviour
{
    public GameObject LoadingEkrani;
    public Slider yuklemeSlider;
    public Text yuklemeText;
    public void SahneYukle(int LevelID)
    {
        StartCoroutine(SahneYuklemeAsama(LevelID));
    }

    IEnumerator SahneYuklemeAsama(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
        LoadingEkrani.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            yuklemeSlider.value = progress;
            yuklemeText.text = $"Loading %: {Mathf.Round(progress * 100f) / 100f}";
            yield return null;
        }
    }
}
