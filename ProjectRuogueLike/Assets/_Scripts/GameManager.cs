using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Texture2D _cursorTexture = null;

    private void Start()
    {
        SetCursorIcon();
    }

    private void SetCursorIcon()
    {
        Cursor.SetCursor(_cursorTexture, new Vector2(_cursorTexture.width / 2f, _cursorTexture.height / 2f), CursorMode.Auto);
    }

    public void RestartLevel()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
