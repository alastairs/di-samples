using System.Windows;
using Composing_WPF.ViewModels;
using Ninject;
using Ninject.Extensions.Conventions;

namespace Composing_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ComposeApplication();
        }

        private static void ComposeApplication()
        {
            // Ninject
            var kernel = new StandardKernel();

            // Manual binding:
            //kernel.Bind<IEditorViewModel>().To<EditorViewModel>();

            //Auto-wiring: bind IFoo to Foo
            kernel.Bind(x => x.FromAssembliesMatching("*").SelectAllClasses().BindDefaultInterface());
        }
    }
}
