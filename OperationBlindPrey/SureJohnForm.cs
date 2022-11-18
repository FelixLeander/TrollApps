namespace OperationBlindPrey;

public partial class SureJohnForm : Form
{
    public SureJohnForm()
    {
        InitializeComponent();
    }

    private void SureJohnForm_Load(object sender, EventArgs e)
    {
        var primaryScreen = Screen.PrimaryScreen;
        this.ShowInTaskbar = false;
        this.Location = primaryScreen.Bounds.Location;
        this.Size = primaryScreen.Bounds.Size;
        this.TopMost = true;
        this.FormBorderStyle = FormBorderStyle.None;
        this.WindowState = FormWindowState.Maximized;
    }
}