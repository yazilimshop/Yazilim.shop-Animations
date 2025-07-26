using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Yazilim.shop_Animations
{
    public static class ParticleAnimations
    {
        public static void Sparkle(FrameworkElement element, int particleCount = 8, double duration = 1.5)
        {
            if (element == null) return;

            try
            {
                var parent = element.Parent as Panel;
                if (parent == null) return;

                lock (AnimationManager._lockObject)
                {
                    var animationInfo = new AnimationInfo
                    {
                        Element = element,
                        AnimationType = "Sparkle",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var random = new Random();
                    var particles = new Ellipse[particleCount];

                    for (int i = 0; i < particleCount; i++)
                    {
                        var particle = new Ellipse
                        {
                            Width = 4,
                            Height = 4,
                            Fill = new SolidColorBrush(Color.FromRgb((byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255))),
                            Opacity = 0.8
                        };

                        var translateTransform = new TranslateTransform();
                        particle.RenderTransform = translateTransform;

                        parent.Children.Add(particle);

                        var xAnimation = new DoubleAnimation
                        {
                            From = 0,
                            To = random.Next(-100, 100),
                            Duration = TimeSpan.FromSeconds(duration),
                            EasingFunction = new ElasticEase { Oscillations = 2, Springiness = 3 }
                        };

                        var yAnimation = new DoubleAnimation
                        {
                            From = 0,
                            To = random.Next(-100, 100),
                            Duration = TimeSpan.FromSeconds(duration),
                            EasingFunction = new ElasticEase { Oscillations = 2, Springiness = 3 }
                        };

                        var opacityAnimation = new DoubleAnimation
                        {
                            From = 0.8,
                            To = 0,
                            Duration = TimeSpan.FromSeconds(duration),
                            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
                        };

                        Storyboard.SetTarget(xAnimation, particle);
                        Storyboard.SetTargetProperty(xAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
                        
                        Storyboard.SetTarget(yAnimation, particle);
                        Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));
                        
                        Storyboard.SetTarget(opacityAnimation, particle);
                        Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

                        storyboard.Children.Add(xAnimation);
                        storyboard.Children.Add(yAnimation);
                        storyboard.Children.Add(opacityAnimation);

                        particles[i] = particle;
                    }

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();

                    storyboard.Completed += (s, e) =>
                    {
                        foreach (var particle in particles)
                        {
                            parent.Children.Remove(particle);
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Sparkle animation error: {ex.Message}");
            }
        }

        public static void Confetti(FrameworkElement element, int particleCount = 15, double duration = 2.0)
        {
            if (element == null) return;

            try
            {
                var parent = element.Parent as Panel;
                if (parent == null) return;

                lock (AnimationManager._lockObject)
                {
                    var animationInfo = new AnimationInfo
                    {
                        Element = element,
                        AnimationType = "Confetti",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var random = new Random();
                    var particles = new Rectangle[particleCount];
                    var colors = new Color[] 
                    { 
                        Colors.Red, Colors.Blue, Colors.Green, Colors.Yellow, 
                        Colors.Purple, Colors.Orange, Colors.Pink, Colors.Cyan 
                    };

                    for (int i = 0; i < particleCount; i++)
                    {
                        var particle = new Rectangle
                        {
                            Width = random.Next(8, 16),
                            Height = random.Next(8, 16),
                            Fill = new SolidColorBrush(colors[random.Next(colors.Length)]),
                            Opacity = 0.9
                        };

                        var translateTransform = new TranslateTransform();
                        var rotateTransform = new RotateTransform();
                        var transformGroup = new TransformGroup();
                        transformGroup.Children.Add(translateTransform);
                        transformGroup.Children.Add(rotateTransform);
                        particle.RenderTransform = transformGroup;

                        parent.Children.Add(particle);

                        var xAnimation = new DoubleAnimation
                        {
                            From = 0,
                            To = random.Next(-150, 150),
                            Duration = TimeSpan.FromSeconds(duration),
                            EasingFunction = new BounceEase { Bounces = 3, Bounciness = 2 }
                        };

                        var yAnimation = new DoubleAnimation
                        {
                            From = 0,
                            To = random.Next(50, 200),
                            Duration = TimeSpan.FromSeconds(duration),
                            EasingFunction = new BounceEase { Bounces = 3, Bounciness = 2 }
                        };

                        var rotationAnimation = new DoubleAnimation
                        {
                            From = 0,
                            To = random.Next(180, 720),
                            Duration = TimeSpan.FromSeconds(duration),
                            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                        };

                        var opacityAnimation = new DoubleAnimation
                        {
                            From = 0.9,
                            To = 0,
                            Duration = TimeSpan.FromSeconds(duration),
                            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
                        };

                        Storyboard.SetTarget(xAnimation, particle);
                        Storyboard.SetTargetProperty(xAnimation, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.X)"));
                        
                        Storyboard.SetTarget(yAnimation, particle);
                        Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.Y)"));
                        
                        Storyboard.SetTarget(rotationAnimation, particle);
                        Storyboard.SetTargetProperty(rotationAnimation, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[1].(RotateTransform.Angle)"));
                        
                        Storyboard.SetTarget(opacityAnimation, particle);
                        Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

                        storyboard.Children.Add(xAnimation);
                        storyboard.Children.Add(yAnimation);
                        storyboard.Children.Add(rotationAnimation);
                        storyboard.Children.Add(opacityAnimation);

                        particles[i] = particle;
                    }

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();

                    storyboard.Completed += (s, e) =>
                    {
                        foreach (var particle in particles)
                        {
                            parent.Children.Remove(particle);
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Confetti animation error: {ex.Message}");
            }
        }

        public static void Fireworks(FrameworkElement element, int particleCount = 20, double duration = 2.5)
        {
            if (element == null) return;

            try
            {
                var parent = element.Parent as Panel;
                if (parent == null) return;

                lock (AnimationManager._lockObject)
                {
                    var animationInfo = new AnimationInfo
                    {
                        Element = element,
                        AnimationType = "Fireworks",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var random = new Random();
                    var particles = new Ellipse[particleCount];
                    var colors = new Color[] 
                    { 
                        Colors.Red, Colors.Orange, Colors.Yellow, Colors.Gold,
                        Colors.Pink, Colors.Purple, Colors.Cyan, Colors.Lime 
                    };

                    for (int i = 0; i < particleCount; i++)
                    {
                        var particle = new Ellipse
                        {
                            Width = random.Next(3, 8),
                            Height = random.Next(3, 8),
                            Fill = new SolidColorBrush(colors[random.Next(colors.Length)]),
                            Opacity = 1.0
                        };

                        var translateTransform = new TranslateTransform();
                        particle.RenderTransform = translateTransform;

                        parent.Children.Add(particle);

                        var angle = random.NextDouble() * 2 * Math.PI;
                        var distance = random.Next(80, 150);
                        var targetX = Math.Cos(angle) * distance;
                        var targetY = Math.Sin(angle) * distance;

                        var xAnimation = new DoubleAnimation
                        {
                            From = 0,
                            To = targetX,
                            Duration = TimeSpan.FromSeconds(duration),
                            EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 4 }
                        };

                        var yAnimation = new DoubleAnimation
                        {
                            From = 0,
                            To = targetY,
                            Duration = TimeSpan.FromSeconds(duration),
                            EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 4 }
                        };

                        var opacityAnimation = new DoubleAnimation
                        {
                            From = 1.0,
                            To = 0,
                            Duration = TimeSpan.FromSeconds(duration),
                            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
                        };

                        Storyboard.SetTarget(xAnimation, particle);
                        Storyboard.SetTargetProperty(xAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
                        
                        Storyboard.SetTarget(yAnimation, particle);
                        Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));
                        
                        Storyboard.SetTarget(opacityAnimation, particle);
                        Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

                        storyboard.Children.Add(xAnimation);
                        storyboard.Children.Add(yAnimation);
                        storyboard.Children.Add(opacityAnimation);

                        particles[i] = particle;
                    }

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();

                    storyboard.Completed += (s, e) =>
                    {
                        foreach (var particle in particles)
                        {
                            parent.Children.Remove(particle);
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Fireworks animation error: {ex.Message}");
            }
        }

        public static void Bubble(FrameworkElement element, int bubbleCount = 6, double duration = 2.0)
        {
            if (element == null) return;

            try
            {
                var parent = element.Parent as Panel;
                if (parent == null) return;

                lock (AnimationManager._lockObject)
                {
                    var animationInfo = new AnimationInfo
                    {
                        Element = element,
                        AnimationType = "Bubble",
                        StartTime = DateTime.Now
                    };

                    var storyboard = new Storyboard();
                    storyboard.Completed += (s, e) => AnimationManager.OnAnimationCompleted(element);

                    var random = new Random();
                    var bubbles = new Ellipse[bubbleCount];

                    for (int i = 0; i < bubbleCount; i++)
                    {
                        var bubble = new Ellipse
                        {
                            Width = random.Next(15, 30),
                            Height = random.Next(15, 30),
                            Fill = new SolidColorBrush(Color.FromArgb(100, 100, 150, 255)),
                            Stroke = new SolidColorBrush(Color.FromArgb(150, 150, 200, 255)),
                            StrokeThickness = 1,
                            Opacity = 0.7
                        };

                        var translateTransform = new TranslateTransform();
                        bubble.RenderTransform = translateTransform;

                        parent.Children.Add(bubble);

                        var xAnimation = new DoubleAnimation
                        {
                            From = random.Next(-20, 20),
                            To = random.Next(-20, 20),
                            Duration = TimeSpan.FromSeconds(duration),
                            EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
                        };

                        var yAnimation = new DoubleAnimation
                        {
                            From = 0,
                            To = -random.Next(100, 200),
                            Duration = TimeSpan.FromSeconds(duration),
                            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
                        };

                        var scaleAnimation = new DoubleAnimation
                        {
                            From = 0.3,
                            To = 1.0,
                            Duration = TimeSpan.FromSeconds(duration),
                            EasingFunction = new ElasticEase { Oscillations = 2, Springiness = 3 }
                        };

                        var opacityAnimation = new DoubleAnimation
                        {
                            From = 0.7,
                            To = 0,
                            Duration = TimeSpan.FromSeconds(duration),
                            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
                        };

                        Storyboard.SetTarget(xAnimation, bubble);
                        Storyboard.SetTargetProperty(xAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
                        
                        Storyboard.SetTarget(yAnimation, bubble);
                        Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));
                        
                        Storyboard.SetTarget(scaleAnimation, bubble);
                        Storyboard.SetTargetProperty(scaleAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                        
                        Storyboard.SetTarget(opacityAnimation, bubble);
                        Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

                        storyboard.Children.Add(xAnimation);
                        storyboard.Children.Add(yAnimation);
                        storyboard.Children.Add(scaleAnimation);
                        storyboard.Children.Add(opacityAnimation);

                        bubbles[i] = bubble;
                    }

                    animationInfo.Storyboard = storyboard;
                    AnimationManager._activeAnimations[element] = animationInfo;

                    storyboard.Begin();

                    storyboard.Completed += (s, e) =>
                    {
                        foreach (var bubble in bubbles)
                        {
                            parent.Children.Remove(bubble);
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Bubble animation error: {ex.Message}");
            }
        }
    }
} 