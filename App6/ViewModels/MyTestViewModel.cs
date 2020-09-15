using App6.Contracts.ViewModels;
using App6.Core.Contracts.Services;
using App6.Core.Services;
using App6.Helpers;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace App6.ViewModels
{
    public class MyTestViewModel : Observable, INavigationAware
    {
        
        private string _TxtCbx;
        public string TxtCbx
        {
            get { return _TxtCbx; }
            set
            {
                Set(ref _TxtCbx, value);
            }
        }

        private Process _selectedHandler;
        public Process SelectedHandler
        {
            get { return _selectedHandler; }
            set 
            {
                
                //MessageBox.Show("ssss:" + value);
                RECT rec = new RECT();
                //RECT rec2 = new RECT();
                WINDOWPLACEMENT winpla = new WINDOWPLACEMENT();
                var hh = GetClientRect(value.MainWindowHandle, ref rec);
                var ClientRecW = rec.Right - rec.Left;
                var ClientRecH = rec.Bottom - rec.Top;
                //var jj = GetWindowRect(value.MainWindowHandle, ref rec2);
                //var MaximizedRecW = rec2.Right - rec2.Left;
                //var MaximizedRecH = rec2.Bottom - rec2.Top;
                var gg = GetWindowPlacement(value.MainWindowHandle, out winpla);
                //var WinPlaceRecW = winpla.Right - rec3.Left;
                //var WinPlaceRecH = rec3.Bottom - rec3.Top;
                TxtCbx = $"left:{rec.Left} top:{rec.Top} right:{rec.Right} bottom:{rec.Bottom} W:{ClientRecW} H:{ClientRecH}";
                Set(ref _selectedHandler, value); 
            }
        }


        enum windowState
        {
            SW_HIDE,
            SW_SHOWNORMAL,
            SW_SHOWMINIMIZED,
            SW_SHOWMAXIMIZED
        }

        //const int SW_HIDE = 0;
        //const int SW_SHOWNORMAL = 1;
        //const int SW_SHOWMINIMIZED = 2;
        //const int SW_SHOWMAXIMIZED = 3;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);


        [StructLayout(LayoutKind.Sequential)]
        struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public windowState showCmd;
            public Point ptMinPosition;
            public Point ptMaxPosition;
            public RECT rcNormalPosition;
        }


        /// <summary>
        /// client rect does not include title bar, borders, scroll bars, status bar...client rect does not include title bar, borders, scroll bars, status bar...
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpRect"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetClientRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

       
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public ObservableCollection<Process> SampleItems { get; private set; } = new ObservableCollection<Process>();
        private readonly IGetProcessService _sampleGetProcesService;

        public MyTestViewModel(IGetProcessService sampleGetProcesService)
        {
            _sampleGetProcesService = sampleGetProcesService;
            
        }
        public MyTestViewModel() 
        {
            _SelectedAction = SelectedAction;

        }


        public void OnNavigatedTo(object parameter)
        {
            SampleItems.Clear();

            var data = _sampleGetProcesService.GetProcessForComboBoxAsync();

            foreach (var item in data)
            {
                SampleItems.Add(item);
            }

            if (SampleItems != null)
            {
                SelectedHandler = SampleItems.First();
            }
        }

        public void OnNavigatedFrom()
        {
        }


        public void ClickedActionBtn()
        {
            Button btn1 = new Button();
            btn1.Content = "SET";
        }


        private string _SelectedAction;

        public string SelectedAction
        {
            get { return _SelectedAction; }
            set 
            {
                if (value == "Left Click")
                {
                    MessageBox.Show(value);
                }
                _SelectedAction = value; 
            }
        }

    }

}
