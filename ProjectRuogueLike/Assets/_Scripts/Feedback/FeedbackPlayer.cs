using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackPlayer : MonoBehaviour
{
    [SerializeField]
    private List<Feedback> _feedbackToPlay = null;

    public void PlayFeedback()
    {
        FinishFeedback();
        foreach (var feedback in _feedbackToPlay)
        {
            feedback.CreateFeedBack();
        }

    }

    private void FinishFeedback()
    {
        foreach (var feedback in _feedbackToPlay)
        {
            feedback.CompletePreviousFeedBack();
        }
    }
}
