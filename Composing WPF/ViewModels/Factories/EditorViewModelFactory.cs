using System;
using Blog.BusinessLogic;

namespace Composing_WPF.ViewModels
{
    public class EditorViewModelFactory : IViewModelFactory
    {
        private readonly IPostService postService;

        public EditorViewModelFactory(IPostService postService)
        {
            if (postService == null) throw new ArgumentNullException("postService");

            this.postService = postService;
        }

        public IViewModel Create(IWindow window)
        {
            return new EditorViewModel(postService, window);
        }
    }
}