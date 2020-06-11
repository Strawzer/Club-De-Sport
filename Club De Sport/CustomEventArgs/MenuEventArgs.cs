using FontAwesome.Sharp;
using System;

namespace Club_De_Sport.CustomEventArgs
{
    public class MenuEventArgs : EventArgs
    {
        public IconButton ClickedButtonIcon { get; set; }
        public string Namespace { get; set; }
    }
}
