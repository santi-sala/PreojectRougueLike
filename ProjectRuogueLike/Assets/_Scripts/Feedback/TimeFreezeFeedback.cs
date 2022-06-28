using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezeFeedback : Feedback
{
    [SerializeField]
    private float _freezeTimeDelay = 0.01f, _unfreezeTimeDelay = 0.02f;
    [SerializeField]
    [Range(0, 1)]
    private float _timeFreezeValue = 0.2f;

    public override void CompletePreviousFeedBack()
    {
        TimeController.instance.ResetTimeScale();
    }

    public override void CreateFeedBack()
    {
        TimeController.instance.ModifyTimeScale(_timeFreezeValue, _freezeTimeDelay, () => TimeController.instance.ModifyTimeScale(1, _unfreezeTimeDelay));
    }
}
