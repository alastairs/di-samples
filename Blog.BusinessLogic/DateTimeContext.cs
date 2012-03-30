using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.BusinessLogic
{
    public abstract class DateTimeContext
    {
        private static DateTimeContext current;

        static DateTimeContext()
        {
            current = new DefaultDateTimeContext();
        }
    }
}
