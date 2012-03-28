using System;

namespace Composing_WPF.ViewModels
{
    internal interface IEditorViewModel : IViewModel
    {
        string Title { get; set; }
        string Summary { get; set; }
        string Body { get; set; }
        DateTime PublicationDate { get; set; }
    }
}