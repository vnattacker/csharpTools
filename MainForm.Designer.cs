
namespace RunMultiApps
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            lstFiles = new ListBox();
            btnBrowse = new Button();
            btnRun = new Button();
            btnClear = new Button();
            panel1 = new Panel();
            label1 = new Label();
            btnMinimize = new Button();
            btnClose = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lstFiles
            // 
            lstFiles.FormattingEnabled = true;
            lstFiles.ItemHeight = 15;
            lstFiles.Location = new Point(10, 79);
            lstFiles.Name = "lstFiles";
            lstFiles.Size = new Size(437, 274);
            lstFiles.TabIndex = 0;
            // 
            // btnBrowse
            // 
            btnBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBrowse.BackColor = Color.Transparent;
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Segoe MDL2 Assets", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBrowse.ForeColor = Color.DeepSkyBlue;
            btnBrowse.Location = new Point(12, 375);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(76, 63);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnRun
            // 
            btnRun.Anchor = AnchorStyles.None;
            btnRun.BackColor = Color.Transparent;
            btnRun.FlatStyle = FlatStyle.Flat;
            btnRun.Font = new Font("Segoe MDL2 Assets", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRun.ForeColor = Color.Lime;
            btnRun.Location = new Point(124, 366);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(171, 72);
            btnRun.TabIndex = 2;
            btnRun.Text = "";
            btnRun.UseVisualStyleBackColor = false;
            btnRun.Click += btnRun_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClear.BackColor = Color.Transparent;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe MDL2 Assets", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.Red;
            btnClear.Location = new Point(340, 366);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(92, 72);
            btnClear.TabIndex = 3;
            btnClear.Text = "";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SeaShell;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnMinimize);
            panel1.Controls.Add(btnClose);
            panel1.Location = new Point(1, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(455, 60);
            panel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Roboto", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Olive;
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(58, 8);
            label1.Name = "label1";
            label1.Size = new Size(274, 44);
            label1.TabIndex = 2;
            label1.Text = "Run Multi Apps";
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe MDL2 Assets", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinimize.ForeColor = Color.ForestGreen;
            btnMinimize.Location = new Point(375, 16);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(32, 32);
            btnMinimize.TabIndex = 1;
            btnMinimize.Text = "";
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe MDL2 Assets", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.Red;
            btnClose.Location = new Point(419, 16);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(32, 32);
            btnClose.TabIndex = 0;
            btnClose.Text = "";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(455, 450);
            Controls.Add(panel1);
            Controls.Add(btnClear);
            Controls.Add(btnRun);
            Controls.Add(btnBrowse);
            Controls.Add(lstFiles);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "Multi Apps Run";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }



        #endregion

        private ListBox lstFiles;
        private Button btnBrowse;
        private Button btnRun;
        private Button btnClear;
        private Panel panel1;
        private Button btnMinimize;
        private Button btnClose;
        private Label label1;
    }
}
