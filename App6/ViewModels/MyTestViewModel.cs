using App6.Contracts.ViewModels;
using App6.Core.Contracts.Services;
using App6.Core.Services;
using App6.Helpers;
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
        private Process _selected;
        //private string _TxtCbx = "";
        private string _TxtCbx;
        //public string TxtCbx
        //{
        //    get { return _TxtCbx; }
        //    set
        //    {
        //        Set(ref _TxtCbx, value);
        //    }
        //}

        public string TxtCbx
        {
            get { return _TxtCbx; }
            set
            {
                Set(ref _TxtCbx, value);
            }
        }

        public Process Selected
        {
            get { return _selected; }
            set 
            {
                //MessageBox.Show("ssss:" + value);
                RECT rec = new RECT();
                var hh = GetClientRect(value.MainWindowHandle, ref rec);
                TxtCbx = $"left:{rec.Left} top:{rec.Top} right:{rec.Right} bottom:{rec.Bottom}";
                Set(ref _selected, value); 
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetClientRect(IntPtr hWnd, ref RECT lpRect);
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
                Selected = SampleItems.First();
            }
        }

        public void OnNavigatedFrom()
        {
        }




    }

}
