using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Yazilim.shop_Animations
{
    public static class PathAnimations
    {
        public static void CircularMotion(FrameworkElement element, double radius = 100, double duration = 2.0, int repeatCount = 1)
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
                        AnimationType = "CircularMotion",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);
                    storyboard.RepeatBehavior = new RepeatBehavior(repeatCount);

                    var translateTransform = element.RenderTransform as TranslateTransform;
                    if (translateTransform == null)
                    {
                        translateTransform = new TranslateTransform(0, 0);
                        element.RenderTransform = translateTransform;
                    }

                    var xAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = radius,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = null
                    };

                    var yAnimation = new DoubleAnimation
                    {
                        From = -radius,
                        To = radius,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = null
                    };

                    Storyboard.SetTarget(xAnimation, element);
                    Storyboard.SetTargetProperty(xAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
                    
                    Storyboard.SetTarget(yAnimation, element);
                    Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));

                    storyboard.Children.Add(xAnimation);
                    storyboard.Children.Add(yAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CircularMotion animation error: {ex.Message}");
            }
        }

        public static void WaveMotion(FrameworkElement element, double amplitude = 50, double frequency = 2.0, double duration = 2.0, int repeatCount = 1)
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
                        AnimationType = "WaveMotion",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);
                    storyboard.RepeatBehavior = new RepeatBehavior(repeatCount);

                    var translateTransform = element.RenderTransform as TranslateTransform;
                    if (translateTransform == null)
                    {
                        translateTransform = new TranslateTransform(0, 0);
                        element.RenderTransform = translateTransform;
                    }

                    var yAnimation = new DoubleAnimation
                    {
                        From = -amplitude,
                        To = amplitude,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
                    };

                    Storyboard.SetTarget(yAnimation, element);
                    Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));

                    storyboard.Children.Add(yAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"WaveMotion animation error: {ex.Message}");
            }
        }

        public static void SpiralMotion(FrameworkElement element, double maxRadius = 150, double duration = 3.0, int repeatCount = 1)
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
                        AnimationType = "SpiralMotion",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);
                    storyboard.RepeatBehavior = new RepeatBehavior(repeatCount);

                    var translateTransform = element.RenderTransform as TranslateTransform;
                    if (translateTransform == null)
                    {
                        translateTransform = new TranslateTransform(0, 0);
                        element.RenderTransform = translateTransform;
                    }

                    var xAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = maxRadius,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    var yAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = maxRadius,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    Storyboard.SetTarget(xAnimation, element);
                    Storyboard.SetTargetProperty(xAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
                    
                    Storyboard.SetTarget(yAnimation, element);
                    Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));

                    storyboard.Children.Add(xAnimation);
                    storyboard.Children.Add(yAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SpiralMotion animation error: {ex.Message}");
            }
        }

        public static void ZigzagMotion(FrameworkElement element, double distance = 100, double duration = 2.0, int repeatCount = 1)
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
                        AnimationType = "ZigzagMotion",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);
                    storyboard.RepeatBehavior = new RepeatBehavior(repeatCount);

                    var translateTransform = element.RenderTransform as TranslateTransform;
                    if (translateTransform == null)
                    {
                        translateTransform = new TranslateTransform(0, 0);
                        element.RenderTransform = translateTransform;
                    }

                    var xAnimation = new DoubleAnimation
                    {
                        From = -distance,
                        To = distance,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new ElasticEase { Oscillations = 3, Springiness = 3 }
                    };

                    var yAnimation = new DoubleAnimation
                    {
                        From = -distance / 2,
                        To = distance / 2,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new ElasticEase { Oscillations = 3, Springiness = 3 }
                    };

                    Storyboard.SetTarget(xAnimation, element);
                    Storyboard.SetTargetProperty(xAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
                    
                    Storyboard.SetTarget(yAnimation, element);
                    Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));

                    storyboard.Children.Add(xAnimation);
                    storyboard.Children.Add(yAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ZigzagMotion animation error: {ex.Message}");
            }
        }
    }
} 