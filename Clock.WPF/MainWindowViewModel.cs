using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Clock.WPF
{
    public class MainWindowViewModel : BaseViewModel
    {
        private int _yAxis;

        public int YAxis
        {
            get { return _yAxis; }
            set { _yAxis = value; OnPropertyChanged(); }
        }
        public void AnimateClock()
        {
            //var backEase = new CircleEase() { EasingMode = EasingMode.EaseOut };
            var backEase = new BackEase() { Amplitude = 0.1, EasingMode = EasingMode.EaseOut };
            Storyboard storyAnimation = new Storyboard();
            storyAnimation.Name = "secondStory";
            storyAnimation.RepeatBehavior = RepeatBehavior.Forever;
            DoubleAnimationUsingKeyFrames secondFrames = new DoubleAnimationUsingKeyFrames();
            double angleValue = -90;

            for (int i = 15000; i >= 1; i--)
            {
                EasingDoubleKeyFrame keyFrame = new EasingDoubleKeyFrame();
                keyFrame.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, i));
                keyFrame.Value = angleValue;
                keyFrame.EasingFunction = backEase;
                secondFrames.KeyFrames.Add(keyFrame);
                angleValue -= 0.024;
                //0.012 angleValue -= 0.012;
            }
            
            Storyboard.SetTargetName(secondFrames, "secondAngle");
            Storyboard.SetTargetProperty(secondFrames, new PropertyPath(RotateTransform.AngleProperty));

            storyAnimation.Children.Add(secondFrames);
            storyAnimation.Seek(new TimeSpan(0, 0, 0, DateTime.Now.Second));
            storyAnimation.Begin(App.Current.MainWindow);
        }

        public ICommand ButtonClick { get; set; }
        public MainWindowViewModel()
        {
            ButtonClick = new RelayCommand(OnClick);
        }

        private void OnClick()
        {
            YAxis += 5;
            
        }
    }
}
