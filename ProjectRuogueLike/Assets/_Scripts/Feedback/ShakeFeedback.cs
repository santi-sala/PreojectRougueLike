using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeFeedback : Feedback
{
    [SerializeField]
    private GameObject _objectToShake = null;
    [SerializeField]
    private float _duration = 0.2f, _strenght = 1, _randomness = 90;
    [SerializeField]
    private int _vibrato = 10;
    [SerializeField]
    private bool _snapping = false, _fadeOut = true;

    public override void CompletePreviousFeedBack()
    {
        _objectToShake.transform.DOComplete();
    }

    public override void CreateFeedBack()
    {
        CompletePreviousFeedBack();
        _objectToShake.transform.DOShakePosition(_duration, _strenght, _vibrato, _randomness, _snapping, _fadeOut);
    }
}
