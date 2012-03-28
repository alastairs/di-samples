using System;
using System.ComponentModel;
using Blog.BusinessLogic;

namespace Composing_WPF.ViewModels
{
    class EditorViewModel : IEditorViewModel, INotifyPropertyChanged
    {
        private readonly IPostService postService;
        private string title;
        private string summary;
        private string body;
        private DateTime publicationDate;

        public EditorViewModel(IPostService postService, IWindow window)
        {
            if (postService == null)
            {
                throw new ArgumentNullException("postService");
            }

            this.postService = postService;
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (value == title) return;

                title = value;
                InvokePropertyChanged("Title");
            }
        }

        public string Summary
        {
            get { return summary; }
            set
            {
                if (value == summary) return;
                
                summary = value;
                InvokePropertyChanged("Summary");
            }
        }

        public string Body
        {
            get { return body; }
            set
            {
                if (value == body) return;
                
                body = value;
                InvokePropertyChanged("Body");
            }
        }

        public DateTime PublicationDate
        {
            get { return publicationDate; }
            set
            {
                if (value == publicationDate) return;
                
                publicationDate = value;
                InvokePropertyChanged("PublicationDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
