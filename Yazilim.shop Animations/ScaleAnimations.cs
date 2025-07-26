using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Yazilim.shop_Animations
{
    public static class ScaleAnimations
    {
        public static void ScaleIn(FrameworkElement element, double duration = 0.5, EasingFunctionBase easing = null)
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
                        AnimationType = "ScaleIn",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var scaleTransform = element.RenderTransform as ScaleTransform;
                    if (scaleTransform == null)
                    {
                        scaleTransform = new ScaleTransform(0.0, 0.0);
                        element.RenderTransform = scaleTransform;
                    }
                    else
                    {
                        scaleTransform.ScaleX = 0.0;
                        scaleTransform.ScaleY = 0.0;
                    }

                    var scaleXAnimation = new DoubleAnimation
                    {
                        To = 1.0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    var scaleYAnimation = new DoubleAnimation
                    {
                        To = 1.0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    Storyboard.SetTarget(scaleXAnimation, element);
                    Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                    
                    Storyboard.SetTarget(scaleYAnimation, element);
                    Storyboard.SetTargetProperty(scaleYAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

                    storyboard.Children.Add(scaleXAnimation);
                    storyboard.Children.Add(scaleYAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ScaleIn animation error: {ex.Message}");
            }
        }

        public static void ScaleOut(FrameworkElement element, double duration = 0.5, EasingFunctionBase easing = null)
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
                        AnimationType = "ScaleOut",
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

                    var scaleYAnimation = new DoubleAnimation
                    {
                        To = 0.0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseIn }
                    };

                    Storyboard.SetTarget(scaleXAnimation, element);
                    Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                    
                    Storyboard.SetTarget(scaleYAnimation, element);
                    Storyboard.SetTargetProperty(scaleYAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

                    storyboard.Children.Add(scaleXAnimation);
                    storyboard.Children.Add(scaleYAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ScaleOut animation error: {ex.Message}");
            }
        }

        public static void ScaleTo(FrameworkElement element, double scaleX, double scaleY, double duration = 0.5, EasingFunctionBase easing = null)
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
                        AnimationType = "ScaleTo",
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
                        To = scaleX,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    var scaleYAnimation = new DoubleAnimation
                    {
                        To = scaleY,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    Storyboard.SetTarget(scaleXAnimation, element);
                    Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                    
                    Storyboard.SetTarget(scaleYAnimation, element);
                    Storyboard.SetTargetProperty(scaleYAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

                    storyboard.Children.Add(scaleXAnimation);
                    storyboard.Children.Add(scaleYAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ScaleTo animation error: {ex.Message}");
            }
        }

        public static void Pulse(FrameworkElement element, double duration = 0.3, int repeatCount = 1)
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
                        AnimationType = "Pulse",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);
                    storyboard.RepeatBehavior = new RepeatBehavior(repeatCount);

                    var scaleTransform = element.RenderTransform as ScaleTransform;
                    if (scaleTransform == null)
                    {
                        scaleTransform = new ScaleTransform(1.0, 1.0);
                        element.RenderTransform = scaleTransform;
                    }

                    var scaleXAnimation = new DoubleAnimation
                    {
                        From = 1.0,
                        To = 1.2,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 3 }
                    };

                    var scaleYAnimation = new DoubleAnimation
                    {
                        From = 1.0,
                        To = 1.2,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 3 }
                    };

                    Storyboard.SetTarget(scaleXAnimation, element);
                    Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                    
                    Storyboard.SetTarget(scaleYAnimation, element);
                    Storyboard.SetTargetProperty(scaleYAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

                    storyboard.Children.Add(scaleXAnimation);
                    storyboard.Children.Add(scaleYAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Pulse animation error: {ex.Message}");
            }
        }
    }
} 