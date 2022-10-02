using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Clock.WPF
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            //DataContext = new MainWindowViewModel();
            //Storyboard seconds = (Storyboard)second.FindResource("sbseconds");
            //seconds.Begin();
            //seconds.Seek(new TimeSpan(0, 0, 0, DateTime.Now.Second, 0));

            //Storyboard minutes = (Storyboard)minute.FindResource("sbminutes");
            //minutes.Begin();
            //minutes.Seek(new TimeSpan(0, 0, DateTime.Now.Minute, DateTime.Now.Second, 0));

            //Storyboard hours = (Storyboard)hour.FindResource("sbhours");
            //hours.Begin();
            //hours.Seek(new TimeSpan(0, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, 0));
            timer.Start();
            AnimateClock();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        public void AnimateClock()
        {
            //var backEase = new CircleEase() { EasingMode = EasingMode.EaseOut };

            var backEase = new BackEase() { Amplitude = 0.1, EasingMode = EasingMode.EaseInOut };
            Storyboard storyAnimation = new Storyboard();
            storyAnimation.Name = "secondStory";
            storyAnimation.RepeatBehavior = RepeatBehavior.Forever;
            DoubleAnimationUsingKeyFrames secondFrames = new DoubleAnimationUsingKeyFrames();
            double angleValue = DateTime.Now.Second * 6 - 90;

            for (int i = 0; i < 600; i++)
            {
                EasingDoubleKeyFrame keyFrame = new EasingDoubleKeyFrame();
                keyFrame.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, i * 100));
                keyFrame.Value = angleValue;
                keyFrame.EasingFunction = backEase;
                secondFrames.KeyFrames.Add(keyFrame);
                //angleValue -= 0.024;
                angleValue += 0.6;
                //0.012 angleValue -= 0.012;
            }
            
            #region KeyFrames


            /*     secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(-90, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1)),backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 2)),backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 3)),backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 4)),backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 5)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 6)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 7)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 8)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 9)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 10)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 11)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 12)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 13)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 14)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 15)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 16)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 17)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 18)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 19)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 20)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 21)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 22)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 23)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 24)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 25)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 26)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 27)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 28)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 29)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 30)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 31)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 32)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 33)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 34)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 35)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 36)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 37)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 38)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 39)), backEase));
                 secondFrames.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 40)), backEase)); */
            #endregion

            //  Storyboard.SetTarget(secondFrames,second);
            Storyboard.SetTargetName(secondFrames, "secondAngle");
            Storyboard.SetTargetProperty(secondFrames, new PropertyPath(RotateTransform.AngleProperty));

            storyAnimation.Children.Add(secondFrames);
            storyAnimation.Begin(this);
            //storyAnimation.Seek(new TimeSpan(0, 0, 0, 0, DateTime.Now.Millisecond));
            //BeginStoryboard(storyAnimation);
            storyAnimation.Seek(new TimeSpan(0, 0, 0, DateTime.Now.Second, DateTime.Now.Millisecond));
            //  storyAnimation.SkipToFill();
        }
    }
}
