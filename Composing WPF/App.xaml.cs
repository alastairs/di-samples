using System.Windows;
using Blog.BusinessLogic;
using Blog.BusinessLogic.Implementation;
using Blog.DataAccess;
using Composing_WPF.ViewModels;
using Composing_WPF.Windows;
using Ninject;
using Ninject.Extensions.Conventions;

namespace Composing_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private IKernel kernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ComposeApplication();

            kernel.Get<IWindow>().Show();
        }

        private void ComposeApplication()
        {
            // Ninject
            kernel = new StandardKernel();

            // Manual binding:
            kernel.Bind<IEditorViewModel>().To<EditorViewModel>();
            kernel.Bind<IViewModelFactory>().To<EditorViewModelFactory>();
            kernel.Bind<IWindow>().To<EditorWindowAdaptor>();
            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<IPostRepository>().To<PostRepository>();

            //Auto-wiring: bind Foo to all interfaces it implements
            //kernel.Bind(x => x.FromAssembliesMatching("*").SelectAllClasses().BindAllInterfaces());
        }
    }
}
