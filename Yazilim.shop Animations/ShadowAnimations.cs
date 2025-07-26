using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace Yazilim.shop_Animations
{
    public static class ShadowAnimations
    {
        public static void ShadowIn(FrameworkElement element, double duration = 0.8, EasingFunctionBase easing = null)
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
                        AnimationType = "ShadowIn",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var dropShadowEffect = element.Effect as DropShadowEffect;
                    if (dropShadowEffect == null)
                    {
                        dropShadowEffect = new DropShadowEffect
                        {
                            Color = Colors.Black,
                            Direction = 315,
                            ShadowDepth = 0,
                            BlurRadius = 0,
                            Opacity = 0
                        };
                        element.Effect = dropShadowEffect;
                    }
                    else
                    {
                        dropShadowEffect.ShadowDepth = 0;
                        dropShadowEffect.BlurRadius = 0;
                        dropShadowEffect.Opacity = 0;
                    }

                    var shadowDepthAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 10,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    var blurRadiusAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 15,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    var opacityAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 0.5,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    Storyboard.SetTarget(shadowDepthAnimation, element);
                    Storyboard.SetTargetProperty(shadowDepthAnimation, new PropertyPath("(UIElement.Effect).(DropShadowEffect.ShadowDepth)"));
                    
                    Storyboard.SetTarget(blurRadiusAnimation, element);
                    Storyboard.SetTargetProperty(blurRadiusAnimation, new PropertyPath("(UIElement.Effect).(DropShadowEffect.BlurRadius)"));
                    
                    Storyboard.SetTarget(opacityAnimation, element);
                    Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath("(UIElement.Effect).(DropShadowEffect.Opacity)"));

                    storyboard.Children.Add(shadowDepthAnimation);
                    storyboard.Children.Add(blurRadiusAnimation);
                    storyboard.Children.Add(opacityAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ShadowIn animation error: {ex.Message}");
            }
        }

        public static void ShadowOut(FrameworkElement element, double duration = 0.8, EasingFunctionBase easing = null)
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
                        AnimationType = "ShadowOut",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var dropShadowEffect = element.Effect as DropShadowEffect;
                    if (dropShadowEffect == null)
                    {
                        dropShadowEffect = new DropShadowEffect
                        {
                            Color = Colors.Black,
                            Direction = 315,
                            ShadowDepth = 10,
                            BlurRadius = 15,
                            Opacity = 0.5
                        };
                        element.Effect = dropShadowEffect;
                    }

                    var shadowDepthAnimation = new DoubleAnimation
                    {
                        To = 0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseIn }
                    };

                    var blurRadiusAnimation = new DoubleAnimation
                    {
                        To = 0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseIn }
                    };

                    var opacityAnimation = new DoubleAnimation
                    {
                        To = 0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseIn }
                    };

                    Storyboard.SetTarget(shadowDepthAnimation, element);
                    Storyboard.SetTargetProperty(shadowDepthAnimation, new PropertyPath("(UIElement.Effect).(DropShadowEffect.ShadowDepth)"));
                    
                    Storyboard.SetTarget(blurRadiusAnimation, element);
                    Storyboard.SetTargetProperty(blurRadiusAnimation, new PropertyPath("(UIElement.Effect).(DropShadowEffect.BlurRadius)"));
                    
                    Storyboard.SetTarget(opacityAnimation, element);
                    Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath("(UIElement.Effect).(DropShadowEffect.Opacity)"));

                    storyboard.Children.Add(shadowDepthAnimation);
                    storyboard.Children.Add(blurRadiusAnimation);
                    storyboard.Children.Add(opacityAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ShadowOut animation error: {ex.Message}");
            }
        }

        public static void ShadowMove(FrameworkElement element, double targetDepth = 20, double duration = 1.0, EasingFunctionBase easing = null)
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
                        AnimationType = "ShadowMove",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var dropShadowEffect = element.Effect as DropShadowEffect;
                    if (dropShadowEffect == null)
                    {
                        dropShadowEffect = new DropShadowEffect
                        {
                            Color = Colors.Black,
                            Direction = 315,
                            ShadowDepth = 5,
                            BlurRadius = 10,
                            Opacity = 0.3
                        };
                        element.Effect = dropShadowEffect;
                    }

                    var shadowDepthAnimation = new DoubleAnimation
                    {
                        To = targetDepth,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new ElasticEase { Oscillations = 2, Springiness = 3 }
                    };

                    var directionAnimation = new DoubleAnimation
                    {
                        From = 315,
                        To = 45,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    Storyboard.SetTarget(shadowDepthAnimation, element);
                    Storyboard.SetTargetProperty(shadowDepthAnimation, new PropertyPath("(UIElement.Effect).(DropShadowEffect.ShadowDepth)"));
                    
                    Storyboard.SetTarget(directionAnimation, element);
                    Storyboard.SetTargetProperty(directionAnimation, new PropertyPath("(UIElement.Effect).(DropShadowEffect.Direction)"));

                    storyboard.Children.Add(shadowDepthAnimation);
                    storyboard.Children.Add(directionAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ShadowMove animation error: {ex.Message}");
            }
        }

        public static void ShadowPulse(FrameworkElement element, double duration = 1.2, int repeatCount = 1)
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
                        AnimationType = "ShadowPulse",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);
                    storyboard.RepeatBehavior = new RepeatBehavior(repeatCount);

                    var dropShadowEffect = element.Effect as DropShadowEffect;
                    if (dropShadowEffect == null)
                    {
                        dropShadowEffect = new DropShadowEffect
                        {
                            Color = Colors.Black,
                            Direction = 315,
                            ShadowDepth = 5,
                            BlurRadius = 10,
                            Opacity = 0.3
                        };
                        element.Effect = dropShadowEffect;
                    }

                    var shadowDepthAnimation = new DoubleAnimation
                    {
                        From = 5,
                        To = 15,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new ElasticEase { Oscillations = 2, Springiness = 3 }
                    };

                    var blurRadiusAnimation = new DoubleAnimation
                    {
                        From = 10,
                        To = 20,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new ElasticEase { Oscillations = 2, Springiness = 3 }
                    };

                    Storyboard.SetTarget(shadowDepthAnimation, element);
                    Storyboard.SetTargetProperty(shadowDepthAnimation, new PropertyPath("(UIElement.Effect).(DropShadowEffect.ShadowDepth)"));
                    
                    Storyboard.SetTarget(blurRadiusAnimation, element);
                    Storyboard.SetTargetProperty(blurRadiusAnimation, new PropertyPath("(UIElement.Effect).(DropShadowEffect.BlurRadius)"));

                    storyboard.Children.Add(shadowDepthAnimation);
                    storyboard.Children.Add(blurRadiusAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ShadowPulse animation error: {ex.Message}");
            }
        }

        public static void GlowShadow(FrameworkElement element, Color glowColor, double duration = 1.0, EasingFunctionBase easing = null)
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
                        AnimationType = "GlowShadow",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var dropShadowEffect = element.Effect as DropShadowEffect;
                    if (dropShadowEffect == null)
                    {
                        dropShadowEffect = new DropShadowEffect
                        {
                            Color = glowColor,
                            Direction = 315,
                            ShadowDepth = 0,
                            BlurRadius = 0,
                            Opacity = 0
                        };
                        element.Effect = dropShadowEffect;
                    }
                    else
                    {
                        dropShadowEffect.Color = glowColor;
                        dropShadowEffect.ShadowDepth = 0;
                        dropShadowEffect.BlurRadius = 0;
                        dropShadowEffect.Opacity = 0;
                    }

                    var shadowDepthAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 8,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    var blurRadiusAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 25,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    var opacityAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 0.8,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    Storyboard.SetTarget(shadowDepthAnimation, element);
                    Storyboard.SetTargetProperty(shadowDepthAnimation, new PropertyPath("(UIElement.Effect).(DropShadowEffect.ShadowDepth)"));
                    
                    Storyboard.SetTarget(blurRadiusAnimation, element);
                    Storyboard.SetTargetProperty(blurRadiusAnimation, new PropertyPath("(UIElement.Effect).(DropShadowEffect.BlurRadius)"));
                    
                    Storyboard.SetTarget(opacityAnimation, element);
                    Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath("(UIElement.Effect).(DropShadowEffect.Opacity)"));

                    storyboard.Children.Add(shadowDepthAnimation);
                    storyboard.Children.Add(blurRadiusAnimation);
                    storyboard.Children.Add(opacityAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GlowShadow animation error: {ex.Message}");
            }
        }
    }
} 