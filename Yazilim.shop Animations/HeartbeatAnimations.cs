using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Yazilim.shop_Animations
{
    public static class HeartbeatAnimations
    {
        public static void Heartbeat(FrameworkElement element, double duration = 1.0, int repeatCount = 1)
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
                        AnimationType = "Heartbeat",
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
                        To = 1.3,
                        Duration = TimeSpan.FromSeconds(duration * 0.3),
                        EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 3 }
                    };

                    var scaleYAnimation = new DoubleAnimation
                    {
                        From = 1.0,
                        To = 1.3,
                        Duration = TimeSpan.FromSeconds(duration * 0.3),
                        EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 3 }
                    };

                    var scaleXAnimation2 = new DoubleAnimation
                    {
                        From = 1.3,
                        To = 1.0,
                        BeginTime = TimeSpan.FromSeconds(duration * 0.3),
                        Duration = TimeSpan.FromSeconds(duration * 0.2),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    var scaleYAnimation2 = new DoubleAnimation
                    {
                        From = 1.3,
                        To = 1.0,
                        BeginTime = TimeSpan.FromSeconds(duration * 0.3),
                        Duration = TimeSpan.FromSeconds(duration * 0.2),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    var scaleXAnimation3 = new DoubleAnimation
                    {
                        From = 1.0,
                        To = 1.2,
                        BeginTime = TimeSpan.FromSeconds(duration * 0.5),
                        Duration = TimeSpan.FromSeconds(duration * 0.2),
                        EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 3 }
                    };

                    var scaleYAnimation3 = new DoubleAnimation
                    {
                        From = 1.0,
                        To = 1.2,
                        BeginTime = TimeSpan.FromSeconds(duration * 0.5),
                        Duration = TimeSpan.FromSeconds(duration * 0.2),
                        EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 3 }
                    };

                    var scaleXAnimation4 = new DoubleAnimation
                    {
                        From = 1.2,
                        To = 1.0,
                        BeginTime = TimeSpan.FromSeconds(duration * 0.7),
                        Duration = TimeSpan.FromSeconds(duration * 0.3),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    var scaleYAnimation4 = new DoubleAnimation
                    {
                        From = 1.2,
                        To = 1.0,
                        BeginTime = TimeSpan.FromSeconds(duration * 0.7),
                        Duration = TimeSpan.FromSeconds(duration * 0.3),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    Storyboard.SetTarget(scaleXAnimation, element);
                    Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                    
                    Storyboard.SetTarget(scaleYAnimation, element);
                    Storyboard.SetTargetProperty(scaleYAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

                    Storyboard.SetTarget(scaleXAnimation2, element);
                    Storyboard.SetTargetProperty(scaleXAnimation2, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                    
                    Storyboard.SetTarget(scaleYAnimation2, element);
                    Storyboard.SetTargetProperty(scaleYAnimation2, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

                    Storyboard.SetTarget(scaleXAnimation3, element);
                    Storyboard.SetTargetProperty(scaleXAnimation3, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                    
                    Storyboard.SetTarget(scaleYAnimation3, element);
                    Storyboard.SetTargetProperty(scaleYAnimation3, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

                    Storyboard.SetTarget(scaleXAnimation4, element);
                    Storyboard.SetTargetProperty(scaleXAnimation4, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                    
                    Storyboard.SetTarget(scaleYAnimation4, element);
                    Storyboard.SetTargetProperty(scaleYAnimation4, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

                    storyboard.Children.Add(scaleXAnimation);
                    storyboard.Children.Add(scaleYAnimation);
                    storyboard.Children.Add(scaleXAnimation2);
                    storyboard.Children.Add(scaleYAnimation2);
                    storyboard.Children.Add(scaleXAnimation3);
                    storyboard.Children.Add(scaleYAnimation3);
                    storyboard.Children.Add(scaleXAnimation4);
                    storyboard.Children.Add(scaleYAnimation4);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Heartbeat animation error: {ex.Message}");
            }
        }

        public static void Pulse(FrameworkElement element, double duration = 0.8, int repeatCount = 1)
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
                        To = 1.1,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 3 }
                    };

                    var scaleYAnimation = new DoubleAnimation
                    {
                        From = 1.0,
                        To = 1.1,
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