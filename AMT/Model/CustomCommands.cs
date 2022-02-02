using System.Windows.Input;

namespace AMT.Model
{
    /// <summary>
    /// Klasse für eigene Commands
    /// </summary>
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Edit = new("Edit", "Edit", typeof(CustomCommands),
            new InputGestureCollection
            {
                new KeyGesture(Key.F2)
            });

        public static readonly RoutedUICommand SendMail = new("Send Mail", "SendMail", typeof(CustomCommands));
    }
}