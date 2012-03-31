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

            /* 
             * Wire up an Ambient Context.
             * 
             * Could be achieved by decorating DateTimeContext.Current with [Inject].
             * You'd then need to bind the type to the required implementation as follows:
             * 
             * kernel.Bind<DateTimeContext>().To<DefaultDateTimeContext>();
             *
             * Unfortunately, this then means that the BusinessLogic assembly is tied to the
             * IoC container, as DateTimeContext is defined in that layer. Given how easy it
             * is to wire this up manually, it's not worth bringing an IoC container into the
             * picture unless you really need to.
             */

            DateTimeContext.Current = new DefaultDateTimeContext();

            // Manual binding:
            kernel.Bind<IEditorViewModel>().To<EditorViewModel>();
            kernel.Bind<IViewModelFactory>().To<EditorViewModelFactory>();
            kernel.Bind<IWindow>().To<EditorWindowAdaptor>();
            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<IPostRepository>().To<PostRepository>();
            kernel.Bind<IRatingAlgorithm>().To<SimpleAverageRatingAlgorithm>();

            //Auto-wiring: bind Foo to all interfaces it implements
            //kernel.Bind(x => x.FromAssembliesMatching("*").SelectAllClasses().BindAllInterfaces());
        }
    }
}
