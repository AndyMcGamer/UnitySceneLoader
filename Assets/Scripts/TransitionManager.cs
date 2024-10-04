using PrimeTween;
using System;
using System.Collections;
using System.Collections.Generic;
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

    private delegate Task TransitionDelegate(float time, Ease ease, bool reset);

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
    /// <param name="type"></param>
    /// <param name="time"></param>
    /// <param name="ease"></param>
    /// <param name="reset"></param>
    /// <returns></returns>
    public async Task Transition(TransitionType type, float time, Ease ease, bool reset)
    {
        await GetTransition(type)(time, ease, reset);
    }

    /// <summary>
    /// Executes the specified transition.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="time"></param>
    /// <param name="ease"></param>
    /// <param name="reset"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    public async Task Transition(TransitionType type, float time, Ease ease, bool reset, Color color)
    {
        image.color = color;
        await GetTransition(type)(time, ease, reset);
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

    private async Task FadeIn(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true)
    {
        image.rectTransform.anchoredPosition3D = new(0f, 0f, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = true;
        if(reset)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        }
        await Tween.Alpha(image, endValue: 1f, duration: time, ease: ease);
    }

    private async Task FadeOut(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true)
    {
        image.rectTransform.anchoredPosition3D = new(0f, 0f, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = false;
        if (reset)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        }
        await Tween.Alpha(image, endValue: 0f, duration: time, ease: ease);
    }

    private async Task FadeInOut(float time = 1f, Ease ease = Ease.Linear, bool reset = true)
    {
        image.raycastTarget = true;
        if (reset)
        {
            await FadeIn(time / 2f, ease);
        }
        await FadeOut(time / 2f, ease);
        image.raycastTarget = false;
    }

    #endregion

    #region HorizontalWipe

    private async Task WipeLeftIn(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true)
    {
        image.rectTransform.anchoredPosition3D = new(image.rectTransform.anchoredPosition3D.x, 0, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = true;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(-image.rectTransform.rect.width, 0f, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionX(image.rectTransform, endValue: 0f, duration: time, ease: ease);
    }

    private async Task WipeLeftOut(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true)
    {
        image.rectTransform.anchoredPosition3D = new(image.rectTransform.anchoredPosition3D.x, 0, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = false;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(0f, 0f, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionX(image.rectTransform, endValue: image.rectTransform.rect.width, duration: time, ease: ease);
    }

    private async Task WipeLeftInOut(float time = 1f, Ease ease = Ease.Linear, bool reset = true)
    {
        image.raycastTarget = true;
        if (reset)
        {
            await WipeLeftIn(time / 2f, ease);
        }
        await WipeLeftOut(time / 2f, ease);
        image.raycastTarget = false;
    }

    private async Task WipeRightIn(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true)
    {
        image.rectTransform.anchoredPosition3D = new(image.rectTransform.anchoredPosition3D.x, 0, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = true;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(image.rectTransform.rect.width, 0f, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionX(image.rectTransform, endValue: 0f, duration: time, ease: ease);
    }

    private async Task WipeRightOut(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true)
    {
        image.rectTransform.anchoredPosition3D = new(image.rectTransform.anchoredPosition3D.x, 0, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = false;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(0f, 0f, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionX(image.rectTransform, endValue: -image.rectTransform.rect.width, duration: time, ease: ease);
    }

    private async Task WipeRightInOut(float time = 1f, Ease ease = Ease.Linear, bool reset = true)
    {
        image.raycastTarget = true;
        if (reset)
        {
            await WipeRightIn(time / 2f, ease);
        }
        await WipeRightOut(time / 2f, ease);
        image.raycastTarget = false;
    }

    #endregion

    #region VerticalWipe

    private async Task WipeUpIn(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true)
    {
        image.rectTransform.anchoredPosition3D = new(0, image.rectTransform.anchoredPosition3D.y, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = true;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(0f, -image.rectTransform.rect.height, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionY(image.rectTransform, endValue: 0f, duration: time, ease: ease);
    }

    private async Task WipeUpOut(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true)
    {
        image.rectTransform.anchoredPosition3D = new(0, image.rectTransform.anchoredPosition3D.y, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = true;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(0f, 0f, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionY(image.rectTransform, endValue: image.rectTransform.rect.height, duration: time, ease: ease);
    }

    private async Task WipeUpInOut(float time = 1f, Ease ease = Ease.Linear, bool reset = true)
    {
        image.raycastTarget = true;
        if (reset)
        {
            await WipeUpIn(time / 2f, ease);
        }
        await WipeUpOut(time / 2f, ease);
        image.raycastTarget = false;
    }

    private async Task WipeDownIn(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true)
    {
        image.rectTransform.anchoredPosition3D = new(0, image.rectTransform.anchoredPosition3D.y, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = true;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(0f, image.rectTransform.rect.height, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionY(image.rectTransform, endValue: 0f, duration: time, ease: ease);
    }

    private async Task WipeDownOut(float time = 0.5f, Ease ease = Ease.Linear, bool reset = true)
    {
        image.rectTransform.anchoredPosition3D = new(0, image.rectTransform.anchoredPosition3D.y, image.rectTransform.anchoredPosition3D.z);
        image.raycastTarget = true;
        if (reset)
        {
            image.rectTransform.anchoredPosition3D = new(0f, 0f, image.rectTransform.anchoredPosition3D.z);
        }
        await Tween.UIAnchoredPositionY(image.rectTransform, endValue: -image.rectTransform.rect.height, duration: time, ease: ease);
    }

    private async Task WipeDownInOut(float time = 1f, Ease ease = Ease.Linear, bool reset = true)
    {
        image.raycastTarget = true;
        if (reset)
        {
            await WipeDownIn(time / 2f, ease);
        }
        await WipeDownOut(time / 2f, ease);
        image.raycastTarget = false;
    }

    #endregion
}
