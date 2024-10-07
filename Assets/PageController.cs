using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{
    public Image fadeImage; // 暗転用のImageをインスペクターで設定
    public float fadeDuration = 1f; // フェード時間

    void Start()
    {
        fadeImage.color = new Color(0, 0, 0, 0); // 初期は透明
    }
    private void Update()
    {
        // 画面をタッチまたはクリックしたとき
        if (Input.GetMouseButtonDown(0))
        {
            OnScreenTapped();
        }
    }
    public void OnScreenTapped()
    {
        // すでにタップ済みの場合は何もしない
        if (fadeImage.color.a > 0) return;

        StartCoroutine(FadeAndLoad());
    }

    private IEnumerator FadeAndLoad()
    {
        // フェードアウト
        yield return Fade(1f);

        // 次のシーンを読み込む
        SceneManager.LoadScene("GameScene"); // 遷移先のシーン名を設定
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeImage.color.a;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, targetAlpha);
    }
}
