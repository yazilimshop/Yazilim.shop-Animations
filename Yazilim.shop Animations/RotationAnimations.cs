using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Yazilim.shop_Animations
{
    public static class RotationAnimations
    {
        public static void RotateIn(FrameworkElement element, double duration = 0.5, EasingFunctionBase easing = null)
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
                        AnimationType = "RotateIn",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var rotateTransform = element.RenderTransform as RotateTransform;
                    if (rotateTransform == null)
                    {
                        rotateTransform = new RotateTransform(360, element.ActualWidth / 2, element.ActualHeight / 2);
                        element.RenderTransform = rotateTransform;
                    }
                    else
                    {
                        rotateTransform.Angle = 360;
                        rotateTransform.CenterX = element.ActualWidth / 2;
                        rotateTransform.CenterY = element.ActualHeight / 2;
                    }

                    var rotationAnimation = new DoubleAnimation
                    {
                        From = 360,
                        To = 0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    Storyboard.SetTarget(rotationAnimation, element);
                    Storyboard.SetTargetProperty(rotationAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));

                    storyboard.Children.Add(rotationAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"RotateIn animation error: {ex.Message}");
            }
        }

        public static void RotateOut(FrameworkElement element, double duration = 0.5, EasingFunctionBase easing = null)
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
                        AnimationType = "RotateOut",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var rotateTransform = element.RenderTransform as RotateTransform;
                    if (rotateTransform == null)
                    {
                        rotateTransform = new RotateTransform(0, element.ActualWidth / 2, element.ActualHeight / 2);
                        element.RenderTransform = rotateTransform;
                    }
                    else
                    {
                        rotateTransform.CenterX = element.ActualWidth / 2;
                        rotateTransform.CenterY = element.ActualHeight / 2;
                    }

                    var rotationAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 360,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseIn }
                    };

                    Storyboard.SetTarget(rotationAnimation, element);
                    Storyboard.SetTargetProperty(rotationAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));

                    storyboard.Children.Add(rotationAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"RotateOut animation error: {ex.Message}");
            }
        }

        public static void RotateTo(FrameworkElement element, double targetAngle, double duration = 0.5, EasingFunctionBase easing = null)
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
                        AnimationType = "RotateTo",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var rotateTransform = element.RenderTransform as RotateTransform;
                    if (rotateTransform == null)
                    {
                        rotateTransform = new RotateTransform(0, element.ActualWidth / 2, element.ActualHeight / 2);
                        element.RenderTransform = rotateTransform;
                    }
                    else
                    {
                        rotateTransform.CenterX = element.ActualWidth / 2;
                        rotateTransform.CenterY = element.ActualHeight / 2;
                    }

                    var rotationAnimation = new DoubleAnimation
                    {
                        To = targetAngle,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    Storyboard.SetTarget(rotationAnimation, element);
                    Storyboard.SetTargetProperty(rotationAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));

                    storyboard.Children.Add(rotationAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"RotateTo animation error: {ex.Message}");
            }
        }

        public static void Rotate45(FrameworkElement element, double duration = 0.5, EasingFunctionBase easing = null)
        {
            RotateTo(element, 45, duration, easing);
        }

        public static void Rotate90(FrameworkElement element, double duration = 0.5, EasingFunctionBase easing = null)
        {
            RotateTo(element, 90, duration, easing);
        }

        public static void Rotate180(FrameworkElement element, double duration = 0.5, EasingFunctionBase easing = null)
        {
            RotateTo(element, 180, duration, easing);
        }

        public static void Rotate360(FrameworkElement element, double duration = 0.5, EasingFunctionBase easing = null)
        {
            RotateTo(element, 360, duration, easing);
        }

        public static void Spin(FrameworkElement element, double duration = 1.0, int repeatCount = 1)
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
                        AnimationType = "Spin",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);
                    storyboard.RepeatBehavior = new RepeatBehavior(repeatCount);

                    var rotateTransform = element.RenderTransform as RotateTransform;
                    if (rotateTransform == null)
                    {
                        rotateTransform = new RotateTransform(0, element.ActualWidth / 2, element.ActualHeight / 2);
                        element.RenderTransform = rotateTransform;
                    }
                    else
                    {
                        rotateTransform.CenterX = element.ActualWidth / 2;
                        rotateTransform.CenterY = element.ActualHeight / 2;
                    }

                    var rotationAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 360,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = null
                    };

                    Storyboard.SetTarget(rotationAnimation, element);
                    Storyboard.SetTargetProperty(rotationAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));

                    storyboard.Children.Add(rotationAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Spin animation error: {ex.Message}");
            }
        }

        public static void Wobble(FrameworkElement element, double duration = 0.6)
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
                        AnimationType = "Wobble",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var rotateTransform = element.RenderTransform as RotateTransform;
                    if (rotateTransform == null)
                    {
                        rotateTransform = new RotateTransform(0, element.ActualWidth / 2, element.ActualHeight / 2);
                        element.RenderTransform = rotateTransform;
                    }
                    else
                    {
                        rotateTransform.CenterX = element.ActualWidth / 2;
                        rotateTransform.CenterY = element.ActualHeight / 2;
                    }

                    var rotationAnimation = new DoubleAnimation
                    {
                        From = -3,
                        To = 3,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new ElasticEase { Oscillations = 3, Springiness = 3 }
                    };

                    Storyboard.SetTarget(rotationAnimation, element);
                    Storyboard.SetTargetProperty(rotationAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));

                    storyboard.Children.Add(rotationAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Wobble animation error: {ex.Message}");
            }
        }
    }
} 