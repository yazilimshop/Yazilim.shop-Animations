using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace Yazilim.shop_Animations
{
    public static class BlurAnimations
    {
        public static void BlurIn(FrameworkElement element, double duration = 0.5, EasingFunctionBase easing = null)
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
                        AnimationType = "BlurIn",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var blurEffect = element.Effect as BlurEffect;
                    if (blurEffect == null)
                    {
                        blurEffect = new BlurEffect { Radius = 20 };
                        element.Effect = blurEffect;
                    }
                    else
                    {
                        blurEffect.Radius = 20;
                    }

                    var blurAnimation = new DoubleAnimation
                    {
                        From = 20,
                        To = 0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    Storyboard.SetTarget(blurAnimation, element);
                    Storyboard.SetTargetProperty(blurAnimation, new PropertyPath("(UIElement.Effect).(BlurEffect.Radius)"));

                    storyboard.Children.Add(blurAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"BlurIn animation error: {ex.Message}");
            }
        }

        public static void BlurOut(FrameworkElement element, double duration = 0.5, EasingFunctionBase easing = null)
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
                        AnimationType = "BlurOut",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var blurEffect = element.Effect as BlurEffect;
                    if (blurEffect == null)
                    {
                        blurEffect = new BlurEffect { Radius = 0 };
                        element.Effect = blurEffect;
                    }

                    var blurAnimation = new DoubleAnimation
                    {
                        To = 20,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseIn }
                    };

                    Storyboard.SetTarget(blurAnimation, element);
                    Storyboard.SetTargetProperty(blurAnimation, new PropertyPath("(UIElement.Effect).(BlurEffect.Radius)"));

                    storyboard.Children.Add(blurAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"BlurOut animation error: {ex.Message}");
            }
        }

        public static void BlurTo(FrameworkElement element, double targetBlur, double duration = 0.5, EasingFunctionBase easing = null)
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
                        AnimationType = "BlurTo",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var blurEffect = element.Effect as BlurEffect;
                    if (blurEffect == null)
                    {
                        blurEffect = new BlurEffect { Radius = 0 };
                        element.Effect = blurEffect;
                    }

                    var blurAnimation = new DoubleAnimation
                    {
                        To = targetBlur,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    Storyboard.SetTarget(blurAnimation, element);
                    Storyboard.SetTargetProperty(blurAnimation, new PropertyPath("(UIElement.Effect).(BlurEffect.Radius)"));

                    storyboard.Children.Add(blurAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"BlurTo animation error: {ex.Message}");
            }
        }

        public static void BlurPulse(FrameworkElement element, double duration = 0.8, int repeatCount = 1)
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
                        AnimationType = "BlurPulse",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);
                    storyboard.RepeatBehavior = new RepeatBehavior(repeatCount);

                    var blurEffect = element.Effect as BlurEffect;
                    if (blurEffect == null)
                    {
                        blurEffect = new BlurEffect { Radius = 0 };
                        element.Effect = blurEffect;
                    }

                    var blurAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 10,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 3 }
                    };

                    Storyboard.SetTarget(blurAnimation, element);
                    Storyboard.SetTargetProperty(blurAnimation, new PropertyPath("(UIElement.Effect).(BlurEffect.Radius)"));

                    storyboard.Children.Add(blurAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"BlurPulse animation error: {ex.Message}");
            }
        }
    }
} 