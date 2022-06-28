using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisolveFeedback : Feedback
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer = null;
    [SerializeField]
    private float _duration = 0.5f;
    [field: SerializeField]
    public UnityEvent DeathCallback { get; set; }

    public override void CompletePreviousFeedBack()
    {
        _spriteRenderer.DOComplete();
        _spriteRenderer.material.DOComplete();
    }

    public override void CreateFeedBack()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(_spriteRenderer.material.DOFloat(0, "_Disolve", _duration));

        if (DeathCallback != null)
        {
            sequence.AppendCallback(() => DeathCallback.Invoke());
        }
    }
}
