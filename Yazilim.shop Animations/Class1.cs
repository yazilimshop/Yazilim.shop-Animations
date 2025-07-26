using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Yazilim.shop_Animations
{
    public class AnimationManager
    {
        public static Dictionary<FrameworkElement, AnimationInfo> _activeAnimations = new Dictionary<FrameworkElement, AnimationInfo>();
        public static readonly object _lockObject = new object();

        public static void StopAnimation(FrameworkElement element)
        {
            lock (_lockObject)
            {
                if (_activeAnimations.ContainsKey(element))
                {
                    var animationInfo = _activeAnimations[element];
                    animationInfo.Storyboard.Stop();
                    _activeAnimations.Remove(element);
                }
            }
        }

        public static void StopAllAnimations()
        {
            lock (_lockObject)
            {
                foreach (var kvp in _activeAnimations)
                {
                    kvp.Value.Storyboard.Stop();
                }
                _activeAnimations.Clear();
            }
        }

        public static bool IsAnimating(FrameworkElement element)
        {
            lock (_lockObject)
            {
                return _activeAnimations.ContainsKey(element);
            }
        }

        public static void OnAnimationCompleted(FrameworkElement element)
        {
            lock (_lockObject)
            {
                if (_activeAnimations.ContainsKey(element))
                {
                    _activeAnimations.Remove(element);
                }
            }
        }
    }

    public class AnimationInfo
    {
        public FrameworkElement Element { get; set; }
        public Storyboard Storyboard { get; set; }
        public string AnimationType { get; set; }
        public DateTime StartTime { get; set; }
    }
}
