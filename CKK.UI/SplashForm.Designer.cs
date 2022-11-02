namespace CKK.UI
{
    partial class SplashForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splashFormTimer = new System.Windows.Forms.Timer(this.components);
            this.manageProductsLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.productManagerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OTechLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splashFormCircleProgressBar = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.manageProductsLogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splashFormTimer
            // 
            this.splashFormTimer.Interval = 50;
            this.splashFormTimer.Tick += new System.EventHandler(this.splashFormTimer_Tick);
            // 
            // manageProductsLogoPictureBox
            // 
            this.manageProductsLogoPictureBox.Image = global::CKK.UI.Properties.Resources.coreys_knick_knacks_logo;
            this.manageProductsLogoPictureBox.Location = new System.Drawing.Point(248, 8);
            this.manageProductsLogoPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.manageProductsLogoPictureBox.Name = "manageProductsLogoPictureBox";
            this.manageProductsLogoPictureBox.Size = new System.Drawing.Size(288, 104);
            this.manageProductsLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.manageProductsLogoPictureBox.TabIndex = 2;
            this.manageProductsLogoPictureBox.TabStop = false;
            // 
            // productManagerLabel
            // 
            this.productManagerLabel.AutoSize = true;
            this.productManagerLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.productManagerLabel.ForeColor = System.Drawing.Color.White;
            this.productManagerLabel.Location = new System.Drawing.Point(704, 416);
            this.productManagerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.productManagerLabel.Name = "productManagerLabel";
            this.productManagerLabel.Size = new System.Drawing.Size(87, 21);
            this.productManagerLabel.TabIndex = 63;
            this.productManagerLabel.Text = "Version 1.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(280, 416);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 21);
            this.label1.TabIndex = 64;
            this.label1.Text = "Developed by Ryan L Buchanan";
            // 
            // OTechLabel
            // 
            this.OTechLabel.AutoSize = true;
            this.OTechLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OTechLabel.ForeColor = System.Drawing.Color.White;
            this.OTechLabel.Location = new System.Drawing.Point(8, 416);
            this.OTechLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OTechLabel.Name = "OTechLabel";
            this.OTechLabel.Size = new System.Drawing.Size(199, 21);
            this.OTechLabel.TabIndex = 65;
            this.OTechLabel.Text = "OTech Software Technology";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(168, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(465, 47);
            this.label2.TabIndex = 66;
            this.label2.Text = "Store Management System";
            // 
            // splashFormCircleProgressBar
            // 
            this.splashFormCircleProgressBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.splashFormCircleProgressBar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.splashFormCircleProgressBar.ForeColor = System.Drawing.Color.White;
            this.splashFormCircleProgressBar.Location = new System.Drawing.Point(280, 176);
            this.splashFormCircleProgressBar.Minimum = 0;
            this.splashFormCircleProgressBar.Name = "splashFormCircleProgressBar";
            this.splashFormCircleProgressBar.ProgressColor = System.Drawing.Color.LightGray;
            this.splashFormCircleProgressBar.ProgressColor2 = System.Drawing.Color.White;
            this.splashFormCircleProgressBar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.splashFormCircleProgressBar.Size = new System.Drawing.Size(224, 224);
            this.splashFormCircleProgressBar.TabIndex = 0;
            this.splashFormCircleProgressBar.Text = "0%";
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.manageProductsLogoPictureBox);
            this.Controls.Add(this.splashFormCircleProgressBar);
            this.Controls.Add(this.productManagerLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OTechLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashForm";
            this.Load += new System.EventHandler(this.SplashForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.manageProductsLogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer splashFormTimer;
        private PictureBox manageProductsLogoPictureBox;
        private Label productManagerLabel;
        private Label label1;
        private Label OTechLabel;
        private Label label2;
        private Guna.UI2.WinForms.Guna2CircleProgressBar splashFormCircleProgressBar;
    }
}