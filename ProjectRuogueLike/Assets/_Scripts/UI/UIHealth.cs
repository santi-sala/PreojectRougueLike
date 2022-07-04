using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject _heartPrefab = null, _healthPanel = null;
    [SerializeField]
    private Sprite _heartFull = null, _heartEmpty = null;

    private int _heartCount = 0;

    private List<Image> _hearts = new List<Image>();

    public void Initialize(int livesCount)
    {
        _heartCount = livesCount;
        foreach (Transform child in _healthPanel.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < livesCount; i++)
        {
            _hearts.Add(Instantiate(_heartPrefab, _healthPanel.transform).GetComponent<Image>());
        }
    }

    public void UpdateUI(int health)
    {
        int currentIndex = 0;
        for (int i = 0; i < _heartCount; i++)
        {
            if (currentIndex >= health)
            {
                _hearts[i].sprite = _heartEmpty;
            }
            else
            {
                _hearts[i].sprite = _heartFull;
            }
            currentIndex++;
        }
    }
}
