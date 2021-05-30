using System;

namespace Bank
{
    public class DatePrinter : IDate
    {
        public DateTime Now()
        {
            return DateTime.Today;
        }
    }
}