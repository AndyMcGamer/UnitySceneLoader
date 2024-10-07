using PrimeTween;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public enum TransitionType
{
    FadeIn,
    FadeOut,
    FadeInOut,
    WipeLeftIn,
    WipeLeftOut,
    WipeLeftInOut,
    WipeRightIn,
    WipeRightOut,
    WipeRightInOut,
    WipeUpIn,
    WipeUpOut,
    WipeUpInOut,
    WipeDownIn,
    WipeDownOut,
    WipeDownInOut
}

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;

    private delegate Task TransitionDelegate(float time, Ease ease, bool reset, bool ignoreTimeScale);

    public static event Action OnTransitionStart;
    public static event Action OnTransitionEnd;

    [SerializeField] private Image image;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Executes the specified transition.
    /// </summary>
    /// <param name="type">The transition type.</param>
    /// <param name="time">The duration of the transition.</param>
    /// <param name="ease">The ease function to use.</param>
    /// <param name="reset">Whether or not to force the transition to start from the very beginning.</param>
    /// <returns></returns>
    public async Task Transition(TransitionType type, float time, Ease ease, bool reset, bool ignoreTimeScale = false)
    {
        OnTransitionStart?.Invoke();
        await GetTransition(type)(time, ease, reset, ignoreTimeScale);
        OnTransitionEnd?.Invoke();
    }

    /// <summary>
    /// Executes the specified transition.
    /// </summary>
    /// <param name="type">The transition type.</param>
    /// <param name="time">The duration of the transition.</param>
    /// <param name="ease">The ease function to use.</param>
    /// <param name="reset">Whether or not to force the transition to start from the very beginning.</param>
    /// <param name="color">What color the transition image will be.</param>
    /// <returns></returns>
    public async Task Transition(TransitionType type, float time, Ease ease, bool reset, Color color, bool ignoreTimeScale = false)
    {
        image.color = color;
        OnTransitionStart?.Invoke();
        await GetTransition(type)(time, ease, reset, ignoreTimeScale);
        OnTransitionEnd?.Invoke();
    }

    private TransitionDelegate GetTransition(TransitionType type)
    {
        return type switch
        {
            TransitionType.FadeIn => FadeIn,
            TransitionType.FadeOut => FadeOut,
            TransitionType.FadeInOut => FadeInOut,
            TransitionType.WipeLeftIn => WipeLeftIn,
            TransitionType.WipeLeftOut => WipeLeftOut,
            TransitionType.WipeLeftInOut => WipeLeftInOut,
            TransitionType.WipeRightIn => WipeRightIn,
            TransitionType.WipeRightOut => WipeRightOut,
            TransitionType.WipeRightInOut => WipeRightInOut,
            TransitionType.WipeUpIn => WipeUpIn,
            TransitionType.WipeUpOut => WipeUpOut,
            TransitionType.WipeUpInOut => WipeUpInOut,
            TransitionType.WipeDownIn => WipeDownIn,
            TransitionType.WipeDownOut => WipeDownOut,
            TransitionType.WipeDownInOut => WipeDownInOut,
            _ => throw new NotImplementedException($"Transition Type {type} not implemented")
        };
    }

    #region Fade

    private async Task FadeIn(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true, bool ignoreTimeScale = false)
    {
        image.rectTransform.anchoredPosition3D = new(0f, 0f, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = true;
        if(reset)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        }
        await Tween.Alpha(image, endValue: 1f, duration: time, ease: ease, useUnscaledTime: ignoreTimeScale);
    }

    private async Task FadeOut(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true, bool ignoreTimeScale = false)
    {
        image.rectTransform.anchoredPosition3D = new(0f, 0f, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = false;
        if (reset)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        }
        await Tween.Alpha(image, endValue: 0f, duration: time, ease: ease, useUnscaledTime: ignoreTimeScale);
    }

    private async Task FadeInOut(float time = 1f, Ease ease = Ease.Linear, bool reset = true, bool ignoreTimeScale = false)
    {
        image.raycastTarget = true;
        if (reset)
        {
            await FadeIn(time / 2f, ease, ignoreTimeScale: ignoreTimeScale);
        }
        await FadeOut(time / 2f, ease, ignoreTimeScale: ignoreTimeScale);
        image.raycastTarget = false;
    }

    #endregion

    #region HorizontalWipe

    private async Task WipeLeftIn(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true, bool ignoreTimeScale = false)
    {
        image.rectTransform.anchoredPosition3D = new(image.rectTransform.anchoredPosition3D.x, 0, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = true;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(-image.rectTransform.rect.width, 0f, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionX(image.rectTransform, endValue: 0f, duration: time, ease: ease, useUnscaledTime: ignoreTimeScale);
    }

    private async Task WipeLeftOut(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true, bool ignoreTimeScale = false)
    {
        image.rectTransform.anchoredPosition3D = new(image.rectTransform.anchoredPosition3D.x, 0, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = false;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(0f, 0f, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionX(image.rectTransform, endValue: image.rectTransform.rect.width, duration: time, ease: ease, useUnscaledTime: ignoreTimeScale);
    }

    private async Task WipeLeftInOut(float time = 1f, Ease ease = Ease.Linear, bool reset = true, bool ignoreTimeScale = false)
    {
        image.raycastTarget = true;
        if (reset)
        {
            await WipeLeftIn(time / 2f, ease, ignoreTimeScale: ignoreTimeScale);
        }
        await WipeLeftOut(time / 2f, ease, ignoreTimeScale: ignoreTimeScale);
        image.raycastTarget = false;
    }

    private async Task WipeRightIn(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true, bool ignoreTimeScale = false)
    {
        image.rectTransform.anchoredPosition3D = new(image.rectTransform.anchoredPosition3D.x, 0, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = true;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(image.rectTransform.rect.width, 0f, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionX(image.rectTransform, endValue: 0f, duration: time, ease: ease, useUnscaledTime: ignoreTimeScale);
    }

    private async Task WipeRightOut(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true, bool ignoreTimeScale = false)
    {
        image.rectTransform.anchoredPosition3D = new(image.rectTransform.anchoredPosition3D.x, 0, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = false;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(0f, 0f, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionX(image.rectTransform, endValue: -image.rectTransform.rect.width, duration: time, ease: ease, useUnscaledTime: ignoreTimeScale);
    }

    private async Task WipeRightInOut(float time = 1f, Ease ease = Ease.Linear, bool reset = true, bool ignoreTimeScale = false)
    {
        image.raycastTarget = true;
        if (reset)
        {
            await WipeRightIn(time / 2f, ease, ignoreTimeScale: ignoreTimeScale);
        }
        await WipeRightOut(time / 2f, ease, ignoreTimeScale: ignoreTimeScale);
        image.raycastTarget = false;
    }

    #endregion

    #region VerticalWipe

    private async Task WipeUpIn(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true, bool ignoreTimeScale = false)
    {
        image.rectTransform.anchoredPosition3D = new(0, image.rectTransform.anchoredPosition3D.y, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = true;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(0f, -image.rectTransform.rect.height, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionY(image.rectTransform, endValue: 0f, duration: time, ease: ease, useUnscaledTime: ignoreTimeScale);
    }

    private async Task WipeUpOut(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true, bool ignoreTimeScale = false)
    {
        image.rectTransform.anchoredPosition3D = new(0, image.rectTransform.anchoredPosition3D.y, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = true;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(0f, 0f, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionY(image.rectTransform, endValue: image.rectTransform.rect.height, duration: time, ease: ease, useUnscaledTime: ignoreTimeScale);
    }

    private async Task WipeUpInOut(float time = 1f, Ease ease = Ease.Linear, bool reset = true, bool ignoreTimeScale = false)
    {
        image.raycastTarget = true;
        if (reset)
        {
            await WipeUpIn(time / 2f, ease, ignoreTimeScale: ignoreTimeScale);
        }
        await WipeUpOut(time / 2f, ease, ignoreTimeScale: ignoreTimeScale);
        image.raycastTarget = false;
    }

    private async Task WipeDownIn(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true, bool ignoreTimeScale = false)
    {
        image.rectTransform.anchoredPosition3D = new(0, image.rectTransform.anchoredPosition3D.y, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = true;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(0f, image.rectTransform.rect.height, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionY(image.rectTransform, endValue: 0f, duration: time, ease: ease, useUnscaledTime: ignoreTimeScale);
    }

    private async Task WipeDownOut(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true, bool ignoreTimeScale = false)
    {
        image.rectTransform.anchoredPosition3D = new(0, image.rectTransform.anchoredPosition3D.y, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = true;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(0f, 0f, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionY(image.rectTransform, endValue: -image.rectTransform.rect.height, duration: time, ease: ease, useUnscaledTime: ignoreTimeScale);
    }

    private async Task WipeDownInOut(float time = 1f, Ease ease = Ease.Linear, bool reset = true, bool ignoreTimeScale = false)
    {
        image.raycastTarget = true;
        if (reset)
        {
            await WipeDownIn(time / 2f, ease, ignoreTimeScale: ignoreTimeScale);
        }
        await WipeDownOut(time / 2f, ease, ignoreTimeScale: ignoreTimeScale);
        image.raycastTarget = false;
    }

    #endregion
}
