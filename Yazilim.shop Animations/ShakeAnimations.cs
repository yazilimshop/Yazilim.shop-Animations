using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Yazilim.shop_Animations
{
    public static class ShakeAnimations
    {
        public static void Shake(FrameworkElement element, double duration = 0.6, int intensity = 10)
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
                        AnimationType = "Shake",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var translateTransform = element.RenderTransform as TranslateTransform;
                    if (translateTransform == null)
                    {
                        translateTransform = new TranslateTransform(0, 0);
                        element.RenderTransform = translateTransform;
                    }

                    var xAnimation = new DoubleAnimation
                    {
                        From = -intensity,
                        To = intensity,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new ElasticEase { Oscillations = 5, Springiness = 3 }
                    };

                    Storyboard.SetTarget(xAnimation, element);
                    Storyboard.SetTargetProperty(xAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

                    storyboard.Children.Add(xAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Shake animation error: {ex.Message}");
            }
        }

        public static void ShakeVertical(FrameworkElement element, double duration = 0.6, int intensity = 10)
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
                        AnimationType = "ShakeVertical",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var translateTransform = element.RenderTransform as TranslateTransform;
                    if (translateTransform == null)
                    {
                        translateTransform = new TranslateTransform(0, 0);
                        element.RenderTransform = translateTransform;
                    }

                    var yAnimation = new DoubleAnimation
                    {
                        From = -intensity,
                        To = intensity,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new ElasticEase { Oscillations = 5, Springiness = 3 }
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
                System.Diagnostics.Debug.WriteLine($"ShakeVertical animation error: {ex.Message}");
            }
        }

        public static void ShakeRotate(FrameworkElement element, double duration = 0.6, double intensity = 5)
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
                        AnimationType = "ShakeRotate",
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
                        From = -intensity,
                        To = intensity,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new ElasticEase { Oscillations = 5, Springiness = 3 }
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
                System.Diagnostics.Debug.WriteLine($"ShakeRotate animation error: {ex.Message}");
            }
        }

        public static void Wobble(FrameworkElement element, double duration = 0.8)
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

        public static void Jelly(FrameworkElement element, double duration = 0.8)
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
                        AnimationType = "Jelly",
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
                        To = 1.25,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new ElasticEase { Oscillations = 3, Springiness = 3 }
                    };

                    var scaleYAnimation = new DoubleAnimation
                    {
                        From = 1.0,
                        To = 0.75,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new ElasticEase { Oscillations = 3, Springiness = 3 }
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
                System.Diagnostics.Debug.WriteLine($"Jelly animation error: {ex.Message}");
            }
        }
    }
} 