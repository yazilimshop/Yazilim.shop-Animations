using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Yazilim.shop_Animations
{
    public static class FadeAnimations
    {
        public static void FadeIn(FrameworkElement element, double duration = 0.5, EasingFunctionBase easing = null)
        {
            if (element == null) return;

            try
            {
                lock (AnimationManager._lockObject)
                {
                    if (AnimationManager._activeAnimations.ContainsKey(element))
                    {
                        var existingAnimation = AnimationManager._activeAnimations[element];
                        existingAnimation.Storyboard.Stop();
                        AnimationManager._activeAnimations.Remove(element);
                    }

                    var animationInfo = new AnimationInfo
                    {
                        Element = element,
                        AnimationType = "FadeIn",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var opacityAnimation = new DoubleAnimation
                    {
                        From = 0.0,
                        To = 1.0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    Storyboard.SetTarget(opacityAnimation, element);
                    Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

                    storyboard.Children.Add(opacityAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    element.Opacity = 0.0;
                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"FadeIn animation error: {ex.Message}");
            }
        }

        public static void FadeOut(FrameworkElement element, double duration = 0.5, EasingFunctionBase easing = null)
        {
            if (element == null) return;

            try
            {
                lock (AnimationManager._lockObject)
                {
                    if (AnimationManager._activeAnimations.ContainsKey(element))
                    {
                        var existingAnimation = AnimationManager._activeAnimations[element];
                        existingAnimation.Storyboard.Stop();
                        AnimationManager._activeAnimations.Remove(element);
                    }

                    var animationInfo = new AnimationInfo
                    {
                        Element = element,
                        AnimationType = "FadeOut",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var opacityAnimation = new DoubleAnimation
                    {
                        From = element.Opacity,
                        To = 0.0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    Storyboard.SetTarget(opacityAnimation, element);
                    Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

                    storyboard.Children.Add(opacityAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"FadeOut animation error: {ex.Message}");
            }
        }

        public static void FadeTo(FrameworkElement element, double targetOpacity, double duration = 0.5, EasingFunctionBase easing = null)
        {
            if (element == null) return;

            try
            {
                lock (AnimationManager._lockObject)
                {
                    if (AnimationManager._activeAnimations.ContainsKey(element))
                    {
                        var existingAnimation = AnimationManager._activeAnimations[element];
                        existingAnimation.Storyboard.Stop();
                        AnimationManager._activeAnimations.Remove(element);
                    }

                    var animationInfo = new AnimationInfo
                    {
                        Element = element,
                        AnimationType = "FadeTo",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var opacityAnimation = new DoubleAnimation
                    {
                        To = targetOpacity,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    Storyboard.SetTarget(opacityAnimation, element);
                    Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

                    storyboard.Children.Add(opacityAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"FadeTo animation error: {ex.Message}");
            }
        }
    }
} 