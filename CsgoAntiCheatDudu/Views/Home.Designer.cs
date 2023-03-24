namespace CsAntiCheat.Views
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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

        async void InitializeAsync()
        {

        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));

            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(75, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Anti Cheat Iniciando";
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5.5F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(522, 95);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AntiCheatCsgo";
            this.Text = "AntiCheatCsgo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion
        private Label label1;


    }
}