using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Yazilim.shop_Animations
{
    public static class TextAnimations
    {
        public static void Typewriter(TextBlock textBlock, string fullText, double duration = 2.0, double delayBetweenChars = 0.05)
        {
            if (textBlock == null || string.IsNullOrEmpty(fullText)) return;

            try
            {
                lock (AnimationManager._lockObject)
                {
                    if (AnimationManager._activeAnimations.ContainsKey(textBlock))
                    {
                        var existingAnimation = AnimationManager._activeAnimations[textBlock];
                        existingAnimation.Storyboard.Stop();
                        AnimationManager._activeAnimations.Remove(textBlock);
                    }

                    var animationInfo = new AnimationInfo
                    {
                        Element = textBlock,
                        AnimationType = "Typewriter",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(textBlock);

                    textBlock.Text = "";
                    var currentText = "";

                    for (int i = 0; i < fullText.Length; i++)
                    {
                        var charAnimation = new ObjectAnimationUsingKeyFrames();
                        charAnimation.BeginTime = TimeSpan.FromSeconds(i * delayBetweenChars);
                        charAnimation.Duration = TimeSpan.FromSeconds(delayBetweenChars);

                        var keyFrame = new DiscreteObjectKeyFrame();
                        keyFrame.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0));
                        keyFrame.Value = fullText.Substring(0, i + 1);

                        charAnimation.KeyFrames.Add(keyFrame);

                        Storyboard.SetTarget(charAnimation, textBlock);
                        Storyboard.SetTargetProperty(charAnimation, new PropertyPath(TextBlock.TextProperty));

                        storyboard.Children.Add(charAnimation);
                    }

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[textBlock] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Typewriter animation error: {ex.Message}");
            }
        }

        public static void TextFadeIn(TextBlock textBlock, double duration = 0.8, EasingFunctionBase easing = null)
        {
            if (textBlock == null) return;

            try
            {
                lock (AnimationManager._lockObject)
                {
                    if (AnimationManager._activeAnimations.ContainsKey(textBlock))
                    {
                        var existingAnimation = AnimationManager._activeAnimations[textBlock];
                        existingAnimation.Storyboard.Stop();
                        AnimationManager._activeAnimations.Remove(textBlock);
                    }

                    var animationInfo = new AnimationInfo
                    {
                        Element = textBlock,
                        AnimationType = "TextFadeIn",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(textBlock);

                    var opacityAnimation = new DoubleAnimation
                    {
                        From = 0.0,
                        To = 1.0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    Storyboard.SetTarget(opacityAnimation, textBlock);
                    Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

                    storyboard.Children.Add(opacityAnimation);

                    textBlock.Opacity = 0.0;
                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[textBlock] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"TextFadeIn animation error: {ex.Message}");
            }
        }

        public static void TextSlideIn(TextBlock textBlock, double duration = 0.8, EasingFunctionBase easing = null)
        {
            if (textBlock == null) return;

            try
            {
                lock (AnimationManager._lockObject)
                {
                    if (AnimationManager._activeAnimations.ContainsKey(textBlock))
                    {
                        var existingAnimation = AnimationManager._activeAnimations[textBlock];
                        existingAnimation.Storyboard.Stop();
                        AnimationManager._activeAnimations.Remove(textBlock);
                    }

                    var animationInfo = new AnimationInfo
                    {
                        Element = textBlock,
                        AnimationType = "TextSlideIn",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(textBlock);

                    var translateTransform = textBlock.RenderTransform as TranslateTransform;
                    if (translateTransform == null)
                    {
                        translateTransform = new TranslateTransform(-textBlock.ActualWidth, 0);
                        textBlock.RenderTransform = translateTransform;
                    }
                    else
                    {
                        translateTransform.X = -textBlock.ActualWidth;
                        translateTransform.Y = 0;
                    }

                    var xAnimation = new DoubleAnimation
                    {
                        To = 0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = easing ?? new CubicEase { EasingMode = EasingMode.EaseOut }
                    };

                    Storyboard.SetTarget(xAnimation, textBlock);
                    Storyboard.SetTargetProperty(xAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

                    storyboard.Children.Add(xAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[textBlock] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"TextSlideIn animation error: {ex.Message}");
            }
        }

        public static void TextBounce(TextBlock textBlock, double duration = 0.6)
        {
            if (textBlock == null) return;

            try
            {
                lock (AnimationManager._lockObject)
                {
                    if (AnimationManager._activeAnimations.ContainsKey(textBlock))
                    {
                        var existingAnimation = AnimationManager._activeAnimations[textBlock];
                        existingAnimation.Storyboard.Stop();
                        AnimationManager._activeAnimations.Remove(textBlock);
                    }

                    var animationInfo = new AnimationInfo
                    {
                        Element = textBlock,
                        AnimationType = "TextBounce",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(textBlock);

                    var scaleTransform = textBlock.RenderTransform as ScaleTransform;
                    if (scaleTransform == null)
                    {
                        scaleTransform = new ScaleTransform(0.3, 0.3);
                        textBlock.RenderTransform = scaleTransform;
                    }
                    else
                    {
                        scaleTransform.ScaleX = 0.3;
                        scaleTransform.ScaleY = 0.3;
                    }

                    var scaleXAnimation = new DoubleAnimation
                    {
                        To = 1.0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new BounceEase { Bounces = 4, Bounciness = 2 }
                    };

                    var scaleYAnimation = new DoubleAnimation
                    {
                        To = 1.0,
                        Duration = TimeSpan.FromSeconds(duration),
                        EasingFunction = new BounceEase { Bounces = 4, Bounciness = 2 }
                    };

                    Storyboard.SetTarget(scaleXAnimation, textBlock);
                    Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                    
                    Storyboard.SetTarget(scaleYAnimation, textBlock);
                    Storyboard.SetTargetProperty(scaleYAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

                    storyboard.Children.Add(scaleXAnimation);
                    storyboard.Children.Add(scaleYAnimation);

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[textBlock] = animationInfo;

                    storyboard.Begin();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"TextBounce animation error: {ex.Message}");
            }
        }
    }
} 