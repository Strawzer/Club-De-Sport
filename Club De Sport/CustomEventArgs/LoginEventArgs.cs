using Club_De_Sport.Models;
using System;

namespace Club_De_Sport.CustomEventArgs
{
    public class LoginEventArgs : EventArgs
    {
        public User User { get; set; }
    }
}
