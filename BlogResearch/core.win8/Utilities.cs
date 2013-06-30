using System;
using Windows.UI.Popups;

namespace core
{
    public static class Utilities
    {
        public static async void ShowMessage(string content)
        {
            var messageDialog = new MessageDialog(content);
            await messageDialog.ShowAsync();
        }
    }
}
