using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAmmo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text = null;

    public void UpdateBulletText(int bulletCount)
    {
        if (bulletCount == 0)
        {
            _text.color = Color.red;
        }
        else
        {
            _text.color = Color.white;
        }
        _text.SetText(bulletCount.ToString());
    }
}
