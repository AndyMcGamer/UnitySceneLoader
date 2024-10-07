using PrimeTween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionDemo : MonoBehaviour
{
    [SerializeField] private TransitionType transitionType;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private Ease ease = Ease.Linear;
    [SerializeField] private bool reset = true;
    [SerializeField] private Color color = Color.black;
    [SerializeField] private bool ignoreTimeScale;

    public async void ExecuteTransition()
    {
        await TransitionManager.instance.Transition(transitionType, duration, ease, reset, color, ignoreTimeScale);
    }
}
