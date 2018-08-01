using System;
using WebAPI.Interfaces;

namespace WebAPI.Classes
{
    public class Clock : IClock
    {
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}
