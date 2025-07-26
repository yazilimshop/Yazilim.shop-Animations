using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Yazilim.shop_Animations
{
    public static class ColorAnimations
    {
        public static void AnimateBackgroundColor(Control element, Color targetColor, double duration = 0.5, EasingFunctionBase easing = null)
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
                        AnimationType = "AnimateBackgroundColor",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var currentBrush = element.Background as SolidColorBrush;
                    var startColor = currentBrush?.Color ?? Colors.Transparent;

                    var colorAnimation = new ColorAnimation
                    {
                        From = startColor,
                        To = targetColor,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    Storyboard.SetTarget(colorAnimation, element);
                    Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Control.Background).(SolidColorBrush.Color)"));

                    storyboard.Children.Add(colorAnimation);

                    if (element.Background == null)
                    {
                        element.Background = new SolidColorBrush(startColor);
                    }

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"AnimateBackgroundColor animation error: {ex.Message}");
            }
        }

        public static void AnimateForegroundColor(Control element, Color targetColor, double duration = 0.5, EasingFunctionBase easing = null)
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
                        AnimationType = "AnimateForegroundColor",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var currentBrush = element.Foreground as SolidColorBrush;
                    var startColor = currentBrush?.Color ?? Colors.Black;

                    var colorAnimation = new ColorAnimation
                    {
                        From = startColor,
                        To = targetColor,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    Storyboard.SetTarget(colorAnimation, element);
                    Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Control.Foreground).(SolidColorBrush.Color)"));

                    storyboard.Children.Add(colorAnimation);

                    if (element.Foreground == null)
                    {
                        element.Foreground = new SolidColorBrush(startColor);
                    }

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"AnimateForegroundColor animation error: {ex.Message}");
            }
        }

        public static void AnimateBorderColor(Control element, Color targetColor, double duration = 0.5, EasingFunctionBase easing = null)
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
                        AnimationType = "AnimateBorderColor",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var currentBrush = element.BorderBrush as SolidColorBrush;
                    var startColor = currentBrush?.Color ?? Colors.Transparent;

                    var colorAnimation = new ColorAnimation
                    {
                        From = startColor,
                        To = targetColor,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    Storyboard.SetTarget(colorAnimation, element);
                    Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Control.BorderBrush).(SolidColorBrush.Color)"));

                    storyboard.Children.Add(colorAnimation);

                    if (element.BorderBrush == null)
                    {
                        element.BorderBrush = new SolidColorBrush(startColor);
                    }

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"AnimateBorderColor animation error: {ex.Message}");
            }
        }

        public static void AnimateBackgroundColorFromHex(Control element, string hexColor, double duration = 0.5, EasingFunctionBase easing = null)
        {
            try
            {
                var color = (Color)ColorConverter.ConvertFromString(hexColor);
                AnimateBackgroundColor(element, color, duration, easing);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"AnimateBackgroundColorFromHex error: {ex.Message}");
            }
        }

        public static void AnimateForegroundColorFromHex(Control element, string hexColor, double duration = 0.5, EasingFunctionBase easing = null)
        {
            try
            {
                var color = (Color)ColorConverter.ConvertFromString(hexColor);
                AnimateForegroundColor(element, color, duration, easing);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"AnimateForegroundColorFromHex error: {ex.Message}");
            }
        }

        public static void AnimateBorderColorFromHex(Control element, string hexColor, double duration = 0.5, EasingFunctionBase easing = null)
        {
            try
            {
                var color = (Color)ColorConverter.ConvertFromString(hexColor);
                AnimateBorderColor(element, color, duration, easing);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"AnimateBorderColorFromHex error: {ex.Message}");
            }
        }

        public static void AnimateBackgroundColorFromRgb(Control element, byte r, byte g, byte b, double duration = 0.5, EasingFunctionBase easing = null)
        {
            var color = Color.FromRgb(r, g, b);
            AnimateBackgroundColor(element, color, duration, easing);
        }

        public static void AnimateForegroundColorFromRgb(Control element, byte r, byte g, byte b, double duration = 0.5, EasingFunctionBase easing = null)
        {
            var color = Color.FromRgb(r, g, b);
            AnimateForegroundColor(element, color, duration, easing);
        }

        public static void AnimateBorderColorFromRgb(Control element, byte r, byte g, byte b, double duration = 0.5, EasingFunctionBase easing = null)
        {
            var color = Color.FromRgb(r, g, b);
            AnimateBorderColor(element, color, duration, easing);
        }

        public static void AnimateBackgroundColorFromArgb(Control element, byte a, byte r, byte g, byte b, double duration = 0.5, EasingFunctionBase easing = null)
        {
            var color = Color.FromArgb(a, r, g, b);
            AnimateBackgroundColor(element, color, duration, easing);
        }

        public static void AnimateForegroundColorFromArgb(Control element, byte a, byte r, byte g, byte b, double duration = 0.5, EasingFunctionBase easing = null)
        {
            var color = Color.FromArgb(a, r, g, b);
            AnimateForegroundColor(element, color, duration, easing);
        }

        public static void AnimateBorderColorFromArgb(Control element, byte a, byte r, byte g, byte b, double duration = 0.5, EasingFunctionBase easing = null)
        {
            var color = Color.FromArgb(a, r, g, b);
            AnimateBorderColor(element, color, duration, easing);
        }

        public static void RainbowBackground(Control element, double duration = 2.0, int repeatCount = 1)
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
                        AnimationType = "RainbowBackground",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);
                    storyboard.RepeatBehavior = new RepeatBehavior(repeatCount);

                    var currentBrush = element.Background as SolidColorBrush;
                    var startColor = currentBrush?.Color ?? Colors.Red;

                    // R (Kırmızı) animasyonu - 0'dan 255'e, sonra 255'ten 0'a
                    var redAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 255,
                        Duration = TimeSpan.FromSeconds(duration / 3),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    var redAnimation2 = new DoubleAnimation
                    {
                        From = 255,
                        To = 0,
                        BeginTime = TimeSpan.FromSeconds(duration / 3),
                        Duration = TimeSpan.FromSeconds(duration / 3),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    var redAnimation3 = new DoubleAnimation
                    {
                        From = 0,
                        To = 255,
                        BeginTime = TimeSpan.FromSeconds(2 * duration / 3),
                        Duration = TimeSpan.FromSeconds(duration / 3),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    // G (Yeşil) animasyonu - 255'ten 0'a, sonra 0'dan 255'e
                    var greenAnimation = new DoubleAnimation
                    {
                        From = 255,
                        To = 0,
                        Duration = TimeSpan.FromSeconds(duration / 3),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    var greenAnimation2 = new DoubleAnimation
                    {
                        From = 0,
                        To = 255,
                        BeginTime = TimeSpan.FromSeconds(duration / 3),
                        Duration = TimeSpan.FromSeconds(duration / 3),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    var greenAnimation3 = new DoubleAnimation
                    {
                        From = 255,
                        To = 0,
                        BeginTime = TimeSpan.FromSeconds(2 * duration / 3),
                        Duration = TimeSpan.FromSeconds(duration / 3),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    // B (Mavi) animasyonu - 0'dan 255'e, sonra 255'ten 0'a
                    var blueAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 255,
                        Duration = TimeSpan.FromSeconds(duration / 3),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    var blueAnimation2 = new DoubleAnimation
                    {
                        From = 255,
                        To = 0,
                        BeginTime = TimeSpan.FromSeconds(duration / 3),
                        Duration = TimeSpan.FromSeconds(duration / 3),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    var blueAnimation3 = new DoubleAnimation
                    {
                        From = 0,
                        To = 255,
                        BeginTime = TimeSpan.FromSeconds(2 * duration / 3),
                        Duration = TimeSpan.FromSeconds(duration / 3),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    if (element.Background == null)
                    {
                        element.Background = new SolidColorBrush(startColor);
                    }

                    // R animasyonları
                    Storyboard.SetTarget(redAnimation, element);
                    Storyboard.SetTargetProperty(redAnimation, new PropertyPath("(Control.Background).(SolidColorBrush.Color).R"));
                    storyboard.Children.Add(redAnimation);

                    Storyboard.SetTarget(redAnimation2, element);
                    Storyboard.SetTargetProperty(redAnimation2, new PropertyPath("(Control.Background).(SolidColorBrush.Color).R"));
                    storyboard.Children.Add(redAnimation2);

                    Storyboard.SetTarget(redAnimation3, element);
                    Storyboard.SetTargetProperty(redAnimation3, new PropertyPath("(Control.Background).(SolidColorBrush.Color).R"));
                    storyboard.Children.Add(redAnimation3);

                    // G animasyonları
                    Storyboard.SetTarget(greenAnimation, element);
                    Storyboard.SetTargetProperty(greenAnimation, new PropertyPath("(Control.Background).(SolidColorBrush.Color).G"));
                    storyboard.Children.Add(greenAnimation);

                    Storyboard.SetTarget(greenAnimation2, element);
                    Storyboard.SetTargetProperty(greenAnimation2, new PropertyPath("(Control.Background).(SolidColorBrush.Color).G"));
                    storyboard.Children.Add(greenAnimation2);

                    Storyboard.SetTarget(greenAnimation3, element);
                    Storyboard.SetTargetProperty(greenAnimation3, new PropertyPath("(Control.Background).(SolidColorBrush.Color).G"));
                    storyboard.Children.Add(greenAnimation3);

                    // B animasyonları
                    Storyboard.SetTarget(blueAnimation, element);
                    Storyboard.SetTargetProperty(blueAnimation, new PropertyPath("(Control.Background).(SolidColorBrush.Color).B"));
                    storyboard.Children.Add(blueAnimation);

                    Storyboard.SetTarget(blueAnimation2, element);
                    Storyboard.SetTargetProperty(blueAnimation2, new PropertyPath("(Control.Background).(SolidColorBrush.Color).B"));
                    storyboard.Children.Add(blueAnimation2);

                    Storyboard.SetTarget(blueAnimation3, element);
                    Storyboard.SetTargetProperty(blueAnimation3, new PropertyPath("(Control.Background).(SolidColorBrush.Color).B"));
                    storyboard.Children.Add(blueAnimation3);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"RainbowBackground animation error: {ex.Message}");
            }
        }

        public static void PulseColor(Control element, Color pulseColor, double duration = 0.8, int repeatCount = 1)
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
                        AnimationType = "PulseColor",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);
                    storyboard.RepeatBehavior = new RepeatBehavior(repeatCount);

                    var currentBrush = element.Background as SolidColorBrush;
                    var startColor = currentBrush?.Color ?? Colors.Transparent;

                    var colorAnimation = new ColorAnimation
                    {
                        From = startColor,
                        To = pulseColor,
                        AutoReverse = true,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 3 }
                    };

                    Storyboard.SetTarget(colorAnimation, element);
                    Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Control.Background).(SolidColorBrush.Color)"));

                    storyboard.Children.Add(colorAnimation);

                    if (element.Background == null)
                    {
                        element.Background = new SolidColorBrush(startColor);
                    }

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"PulseColor animation error: {ex.Message}");
            }
        }
    }
} 