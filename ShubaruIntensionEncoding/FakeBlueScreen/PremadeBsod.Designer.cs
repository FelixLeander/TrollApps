namespace OperationBlueThunderBird.FakeBlueScreen;

partial class PremadeBsod
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.pictureBoxFull = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFull)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFull
            // 
            this.pictureBoxFull.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictureBoxFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxFull.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxFull.Name = "pictureBoxFull";
            this.pictureBoxFull.Size = new System.Drawing.Size(800, 450);
            this.pictureBoxFull.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFull.TabIndex = 0;
            this.pictureBoxFull.TabStop = false;
            // 
            // FakeBsodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxFull);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FakeBsodForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FakeBsodForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFull)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private PictureBox pictureBoxFull;
}