
namespace YouBankruptProviderView
{
    partial class ProviderSignUpForm
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
            this.textBox_full_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_full_name
            // 
            this.textBox_full_name.Location = new System.Drawing.Point(77, 91);
            this.textBox_full_name.Name = "textBox_full_name";
            this.textBox_full_name.Size = new System.Drawing.Size(186, 26);
            this.textBox_full_name.TabIndex = 0;
            // 
            // ProviderSignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 450);
            this.Controls.Add(this.textBox_full_name);
            this.Name = "ProviderSignUpForm";
            this.Text = "Поставщик регистрация ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_full_name;
    }
}