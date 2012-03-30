using System;

namespace Blog.BusinessLogic
{
    public class DefaultDateTimeContext : DateTimeContext
    {
        public override DateTime Now
        {
            get { return DateTime.Now; }
        }

        public override DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }
    }
}