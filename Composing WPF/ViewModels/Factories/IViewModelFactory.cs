namespace Composing_WPF.ViewModels
{
    public interface IViewModelFactory
    {
        IViewModel Create(IWindow window);
    }
}