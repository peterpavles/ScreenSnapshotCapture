﻿
#region LICENSE

//The MIT License (MIT)
//Copyright (c) 2014 Leonardo Mack
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScreenSnapshotCapture.Software
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.NotifyIcon notifyIcon;        
        
        public MainWindow()
        {
            InitializeComponent();
            
            InitializeApplication();
        }
        
        private void InitializeApplication()
        {
            notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.BalloonTipText = "";
            notifyIcon.BalloonTipTitle = "";
            notifyIcon.Text = "ScreenSnapshotCapture";
            notifyIcon.Icon = new System.Drawing.Icon(@"D:\Software\LosseGitHub\ScreenSnapshotCapture\ScreenSnapshotCapture.Software\Resources\Images\Ico.ico");
            notifyIcon.DoubleClick += new EventHandler(NotifyIcon_DoubleClick);
        }
        
        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = WindowState.Normal;
        }
        
        private void Window_StateChanged(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Maximized:
                    {
                        break;
                    }
                case WindowState.Minimized:
                    {
                        Hide();
                        if (notifyIcon != null)
                        {
                            notifyIcon.Visible = true;
                        }
                        break;
                    }
                case WindowState.Normal:
                    {
                        notifyIcon.Visible = false;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }            
        }
    }
}