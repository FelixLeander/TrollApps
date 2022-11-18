namespace OperationBlueThunderBird.FakeBlueScreen;

internal static class BsodHelper
{
    internal static void SetFormSettings(Form form, Screen screen)
    {
        form.ShowInTaskbar = false;
        form.Location = screen.Bounds.Location;
        form.Size = screen.Bounds.Size;
        form.TopMost = true;
        form.FormBorderStyle = FormBorderStyle.None;
        form.WindowState = FormWindowState.Maximized;
    }

    internal static void SetTextByArrayOrDefaultText(TextBox[] textBoxes, string[] defaultTexts, string[]? array = null)
    {
        for (int i = 0; i < textBoxes.Length; i++)
            SetTextByArrayOrDefaultText(textBoxes[i], i, defaultTexts[i], array);
    }

    internal static string SetTextByArrayOrDefaultText(int indexCounter, string defaultText, string[]? array = null)
    {
        return array != null && array.Length > indexCounter++ ? array[indexCounter - 1] : defaultText;
    }

    internal static void SetTextByArrayOrDefaultText(this TextBox textBox, int indexCounter, string defaultText, string[]? array = null)
    {
        textBox.Text = array != null && array.Length > indexCounter ? array[indexCounter] : defaultText;
    }
}
