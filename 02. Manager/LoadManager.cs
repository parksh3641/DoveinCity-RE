using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    private int LoadingCode;

    public static string[] LoadingName = { "01.title", "02.tutorial", "03.Select", "04.Shop", "05.Online", "06.Offline" };

    [SerializeField]
    public UISprite progressBar;
    public UILabel progressLabel;

    void Awake()
    {
        progressBar.fillAmount = 0f;
        progressLabel.text = "0%";

        StartCoroutine(LoadScene());
        LoadingCode = SystemManager.LoadingCode -1;
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(LoadingName[LoadingCode]);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if (op.progress >= 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                float progress = op.progress * 100.0f;
                int pRounded = Mathf.RoundToInt(progress);
                progressLabel.text = ((pRounded+10).ToString() + "%");

                if (progressBar.fillAmount == 1.0f)
                    op.allowSceneActivation = true;
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                float progress = op.progress * 100.0f;
                int pRounded = Mathf.RoundToInt(progress);
                progressLabel.text = (pRounded.ToString() + "%");
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
        }
    }
}