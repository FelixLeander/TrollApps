using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperationBlueThunderBird.FakeBlueScreen
{
    public partial class CustomBsod : Form
    {
        private readonly Screen _screen;

        /// <summary>
        /// The array can be any length or null.<br/>
        /// The first 5 inputs elements are the text on the screen.<br/>
        /// Element 6 is the time in seconds, -1 to not change the image.<br/>
        /// Element 7 is the path to the image.<br/>
        /// </summary>
        private string[]? _config = null;
        public CustomBsod(Screen? screen = null, string[]? config = null)
        {
            InitializeComponent();
            this._config = config;
            _screen = screen ?? Screen.AllScreens.First(s => s.Primary);

            _config = new string[] { ":)", "Sowwy Marcel, we did run in an upsi, UwU", "Better luck next time", "Looking kinda cute ngl <3" };
        }

        private async void CustomBsod_Load(object sender, EventArgs e)
        {
            BsodHelper.SetFormSettings(this, _screen);

            this.pictureBoxQrCode.ImageLocation = Path.Combine(Environment.CurrentDirectory, "FakeBlueScreen", "rollQrCode.png");

            if (_screen.Primary)
            {
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (screen.Primary)
                        continue;

                    var form = new CustomBsod(screen, _config);
                    form.Show();
                }
            }

            BsodHelper.SetTextByArrayOrDefaultText(
                new TextBox[] { textBoxH1, textBoxH2, textBoxH3, textBoxH4, textBoxH5 },
                new string[]
                {
                    ":(", $"Your PC ran into a problem and needs to restart. We're{Environment.NewLine}just collecting some error, info and then we'll restart for{Environment.NewLine}you.",
                    "20% complete",
                    "For more information about this issue and possible fixes, visit https://www.windows.com/stopcode",
                    $"If you call a support give them this info:{Environment.NewLine}Stop code: FLANDER_WAS_HERE"
                },
                _config);

            if (!_screen.Primary)
                return;

            int arrIndexCounter = 4;
            string numText = BsodHelper.SetTextByArrayOrDefaultText(arrIndexCounter++, "3", _config);
            int waitTime = int.TryParse(numText, out waitTime) ? waitTime : 3;

            if (waitTime == -1)
                return;

            await Task.Delay(1000 * waitTime);

            string imagePath = BsodHelper.SetTextByArrayOrDefaultText(arrIndexCounter++, Path.Combine(Environment.CurrentDirectory, "FakeBlueScreen", "theRoll.gif"), _config);
            this.pictureBoxFull.ImageLocation = imagePath;
            this.pictureBoxFull.Visible = true;

            //await Task.Delay(1000 * 5);
            //this.Close();
        }
    }
}