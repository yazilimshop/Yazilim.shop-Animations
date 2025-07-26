using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Yazilim.shop_Animations
{
    public static class FlipAnimations
    {
        public static void FlipHorizontal(FrameworkElement element, double duration = 0.8, EasingFunctionBase easing = null)
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
                        AnimationType = "FlipHorizontal",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var scaleTransform = element.RenderTransform as ScaleTransform;
                    if (scaleTransform == null)
                    {
                        scaleTransform = new ScaleTransform(1.0, 1.0);
                        element.RenderTransform = scaleTransform;
                    }

                    var scaleXAnimation = new DoubleAnimation
                    {
                        From = 1.0,
                        To = -1.0,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    Storyboard.SetTarget(scaleXAnimation, element);
                    Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));

                    storyboard.Children.Add(scaleXAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"FlipHorizontal animation error: {ex.Message}");
            }
        }

        public static void FlipVertical(FrameworkElement element, double duration = 0.8, EasingFunctionBase easing = null)
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
                        AnimationType = "FlipVertical",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var scaleTransform = element.RenderTransform as ScaleTransform;
                    if (scaleTransform == null)
                    {
                        scaleTransform = new ScaleTransform(1.0, 1.0);
                        element.RenderTransform = scaleTransform;
                    }

                    var scaleYAnimation = new DoubleAnimation
                    {
                        From = 1.0,
                        To = -1.0,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    Storyboard.SetTarget(scaleYAnimation, element);
                    Storyboard.SetTargetProperty(scaleYAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

                    storyboard.Children.Add(scaleYAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"FlipVertical animation error: {ex.Message}");
            }
        }

        public static void FlipIn(FrameworkElement element, double duration = 0.8, EasingFunctionBase easing = null)
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
                        AnimationType = "FlipIn",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var scaleTransform = element.RenderTransform as ScaleTransform;
                    if (scaleTransform == null)
                    {
                        scaleTransform = new ScaleTransform(0.0, 1.0);
                        element.RenderTransform = scaleTransform;
                    }
                    else
                    {
                        scaleTransform.ScaleX = 0.0;
                        scaleTransform.ScaleY = 1.0;
                    }

                    var scaleXAnimation = new DoubleAnimation
                    {
                        To = 1.0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    Storyboard.SetTarget(scaleXAnimation, element);
                    Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));

                    storyboard.Children.Add(scaleXAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"FlipIn animation error: {ex.Message}");
            }
        }

        public static void FlipOut(FrameworkElement element, double duration = 0.8, EasingFunctionBase easing = null)
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
                        AnimationType = "FlipOut",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var scaleTransform = element.RenderTransform as ScaleTransform;
                    if (scaleTransform == null)
                    {
                        scaleTransform = new ScaleTransform(1.0, 1.0);
                        element.RenderTransform = scaleTransform;
                    }

                    var scaleXAnimation = new DoubleAnimation
                    {
                        To = 0.0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseIn }
                    };

                    Storyboard.SetTarget(scaleXAnimation, element);
                    Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));

                    storyboard.Children.Add(scaleXAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"FlipOut animation error: {ex.Message}");
            }
        }

        public static void Flip3D(FrameworkElement element, double duration = 1.0, EasingFunctionBase easing = null)
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
                        AnimationType = "Flip3D",
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
                System.Diagnostics.Debug.WriteLine($"Flip3D animation error: {ex.Message}");
            }
        }
    }
} 