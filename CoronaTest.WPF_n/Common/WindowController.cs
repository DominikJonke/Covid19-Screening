using CoronaTest.WPF_n.Common.Contracts;
using CoronaTest.WPF_n.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CoronaTest.WPF_n.Common
{
    public class WindowController : IWindowController
    {
        private readonly Dictionary<BaseViewModel, Window> _windows
          = new Dictionary<BaseViewModel, Window>();

        public void ShowWindow(BaseViewModel viewModel, bool showAsDialog = false)
        {
            Window window = viewModel switch
            {
                null => throw new ArgumentNullException(nameof(viewModel)),

                MainViewModel _ => new MainWindow(),

                _ => throw new InvalidOperationException($"Unbekanntes ViewModel '{viewModel}'"),
            };

            _windows[viewModel] = window;

            window.DataContext = viewModel;

            if (showAsDialog)
            {
                window.ShowDialog();
            }
            else
            {
                window.Show();
            }
        }

        public void CloseWindow(BaseViewModel viewModel)
        {
            if (_windows.ContainsKey(viewModel))
            {
                Window window = _windows[viewModel];
                _windows.Remove(viewModel);
                window.Close();
            }
        }
    }
}
