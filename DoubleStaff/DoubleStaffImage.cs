using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoubleStaff
{
    [TemplatePart(Name = "PART_Left",Type = typeof(Grid))]
    public class DoubleStaffImage : Control , INotifyPropertyChanged
    {
        private Grid _GridLeft;

        /// <summary>
        /// 底图
        /// </summary>
        public ImageSource BottomImage
        {
            get { return (ImageSource)GetValue(BottomImageProperty); }
            set { SetValue(BottomImageProperty, value); }
        }

        public static readonly DependencyProperty BottomImageProperty = DependencyProperty.Register(
            "BottomImage", 
            typeof(ImageSource), 
            typeof(DoubleStaffImage), 
            new PropertyMetadata(default(ImageSource)));

        /// <summary>
        /// 叠加图
        /// </summary>
        public ImageSource TopImage
        {
            get { return (ImageSource)GetValue(TopImageProperty); }
            set { SetValue(TopImageProperty, value); }
        }

        public static readonly DependencyProperty TopImageProperty =DependencyProperty.Register(
            "TopImage", 
            typeof(ImageSource), 
            typeof(DoubleStaffImage), 
            new PropertyMetadata(default(ImageSource)));

        private Rect _RectLeft;
        public Rect RectLeft { get { return _RectLeft; } set { _RectLeft = value; NotifyChanged(() => RectLeft); } }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if((_GridLeft = GetTemplateChild("PART_Left") as Grid) != null)
                _GridLeft.SizeChanged += _GridLeft_SizeChanged;
        }

        private void _GridLeft_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(sender is Grid grid)
                RectLeft = new Rect(0, 0, grid.ActualWidth + 5, grid.ActualHeight);
        }

        static DoubleStaffImage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DoubleStaffImage), new FrameworkPropertyMetadata(typeof(DoubleStaffImage)));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyChanged<T>(Expression<Func<T>> propertyName)
        {
            if (PropertyChanged != null)
            {
                var memberExpression = propertyName.Body as MemberExpression;
                if (memberExpression != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
            }
        }
    }
}
