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

        public static DateTimeContext Current
        {
            get { return current; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                current = value;
            }
        }

        public abstract DateTime Now { get; }

        public abstract DateTime UtcNow { get; }
    }
}
