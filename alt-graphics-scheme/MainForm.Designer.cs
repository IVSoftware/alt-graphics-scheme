
namespace alt_graphics_scheme
{
    partial class MainForm
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
            this.checkBoxMyBool = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxMyBool
            // 
            this.checkBoxMyBool.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxMyBool.AutoSize = true;
            this.checkBoxMyBool.Location = new System.Drawing.Point(12, 12);
            this.checkBoxMyBool.Name = "checkBoxMyBool";
            this.checkBoxMyBool.Size = new System.Drawing.Size(52, 23);
            this.checkBoxMyBool.TabIndex = 0;
            this.checkBoxMyBool.Text = "MyBool";
            this.checkBoxMyBool.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxMyBool);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxMyBool;
    }
}

