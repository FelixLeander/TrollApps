using OperationBlueThunderBird.FakeBlueScreen;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace OperationBlueThunderBird.FakeBlueScreen;

public partial class PremadeBsod : Form
{
    private readonly Screen _screen;

    public PremadeBsod(Screen? screen = null)
    {
        InitializeComponent();
        _screen = screen ?? Screen.AllScreens.First(s => s.Primary);
    }

    private async void FakeBsodForm_Load(object sender, EventArgs e)
    {
        BsodHelper.SetFormSettings(this, _screen);

        this.pictureBoxFull.ImageLocation = Path.Combine(Environment.CurrentDirectory, "FakeBlueScreen", "win10Bsod.png");

        if (_screen.Primary)
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Primary)
                    continue;

                var form = new PremadeBsod(screen);
                form.Show();
            }

            await Task.Delay(3000);
            this.pictureBoxFull.ImageLocation = Path.Combine(Environment.CurrentDirectory, "FakeBlueScreen", "theRoll.gif");
        }
    }
}