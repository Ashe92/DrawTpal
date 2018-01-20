using Microsoft.Win32;
using PaintKD.Drawing;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PaintKD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        private Draw dr = new Draw();
        private BackgroundWorker _worker;
        private delegate void DELEGATE();
        private Files.FilesWork FileOp = new Files.FilesWork();
        private Shape s;
        private PenKd pen = new PenKd();
        #endregion 

        public MainWindow()
        {           
            InitializeComponent();
            // set default language checked true
            foreach (MenuItem item in menuItems.Items)
            {
                if (item.Tag.ToString().Equals(CultureInfo.CurrentUICulture.Name))
                    item.IsChecked = true;
            }
        }

        private void btnShape_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            pen.TypePen = button.Name;
        }
       
        private void MouseDown_Action(object sender, MouseButtonEventArgs e)
        {
            dr.IsDraw = true;
            dr.SPoint = dr.GetActualPosition(e, cPaint);
        }
        private void MouseUp_Action(object sender, MouseButtonEventArgs e)
        {
            if (dr.IsDraw )
            {
                dr.LPoint = dr.GetActualPosition(e,cPaint);
                s = dr.DrawOnCanvas(pen);
                if (s != null)
                {
                    cPaint.Children.Add(s);
                }
            }
            dr.IsDraw = false;
        }

        private void MouseMove_Action(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _worker = new BackgroundWorker();
                _worker.DoWork += Worker_DoWork;
                _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
                dr.APoint = e.GetPosition(this.cPaint);
                _worker.RunWorkerAsync();
            }            
         }
        #region Worker
        private void AddToCanvas()
        {
            System.Threading.Thread.Sleep(10);
            s = dr.DrawOn(pen);
        }
        public void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            DELEGATE del = new DELEGATE(AddToCanvas);
            this.Dispatcher.Invoke(del);
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (s != null)
            {
                cPaint.Children.Add(s);
                dr.SPoint = dr.APoint;
            }
        }

        #endregion
        private void colorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            pen.Color = new SolidColorBrush((Color)colorPicker.SelectedColor);
        }

        private void colorFilled_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            pen.FillColor = new SolidColorBrush((Color)colorFilled.SelectedColor);
        }

        #region Files
        private void Load_File(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = FileOp.LoadFile();
            if(brush != null)
            {
                cPaint.Background = brush;
            }
        }

        private void Save_File(object sender, RoutedEventArgs e)
        {
            FileOp.SaveFile(cPaint);
        }
        #endregion

        private void Select_Language(object sender, RoutedEventArgs e)
        {
            foreach (MenuItem item in menuItems.Items)
            {
                item.IsChecked = false;
            }
            MenuItem mi = sender as MenuItem;
            mi.IsChecked = true;
            App.Instance.SwitchLanguage(mi.Tag.ToString());
        }

        private void Clear_All(object sender, RoutedEventArgs e)
        {
            cPaint.Children.Clear();
        }

        private void Undo(object sender, RoutedEventArgs e)
        {
            if (dr.LastElement != -1)
            {
                cPaint.Children.Remove(dr.Undo());
            }

        }
        private void Reverse(object sender, RoutedEventArgs e)
        {
            if (dr.LastUndo != -1)
            {
                cPaint.Children.Add(dr.Reverse());
            }
        }

        private void Size_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            pen.SizeThick =(int)Size.Value;
        }

        private void Filled(object sender, RoutedEventArgs e)
        {
            imgFill.Source = new BitmapImage(new Uri(pen.SetFilled(), UriKind.Relative));

        }
    }
}
