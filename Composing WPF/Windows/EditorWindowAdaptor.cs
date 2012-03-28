using System;
using System.Windows;
using Composing_WPF.ViewModels;
using Composing_WPF.Views;

namespace Composing_WPF.Windows
{
    public class EditorWindowAdaptor : IWindow
    {
        private readonly IViewModelFactory viewModelFactory;
        private readonly Window wpfWindow;
        public EditorWindowAdaptor(IViewModelFactory viewModelFactory, EditorWindow wpfWindow)
        {
            if (viewModelFactory == null)
            {
                throw new ArgumentNullException("viewModelFactory");
            }

            if (wpfWindow == null)
            {
                throw new ArgumentNullException("wpfWindow");
            }

            this.viewModelFactory = viewModelFactory;
            this.wpfWindow = wpfWindow;

            AssignDataContext();
        }

        private void AssignDataContext()
        {
            var viewModel = viewModelFactory.Create(this);
            wpfWindow.DataContext = viewModel;
        }

        public void Show()
        {
            wpfWindow.Show();
        }
    }
}
