using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{
    public Image fadeImage; // �Ó]�p��Image���C���X�y�N�^�[�Őݒ�
    public float fadeDuration = 1f; // �t�F�[�h����

    void Start()
    {
        fadeImage.color = new Color(0, 0, 0, 0); // �����͓���
    }
    private void Update()
    {
        // ��ʂ��^�b�`�܂��̓N���b�N�����Ƃ�
        if (Input.GetMouseButtonDown(0))
        {
            OnScreenTapped();
        }
    }
    public void OnScreenTapped()
    {
        // ���łɃ^�b�v�ς݂̏ꍇ�͉������Ȃ�
        if (fadeImage.color.a > 0) return;

        StartCoroutine(FadeAndLoad());
    }

    private IEnumerator FadeAndLoad()
    {
        // �t�F�[�h�A�E�g
        yield return Fade(1f);

        // ���̃V�[����ǂݍ���
        SceneManager.LoadScene("GameScene"); // �J�ڐ�̃V�[������ݒ�
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
