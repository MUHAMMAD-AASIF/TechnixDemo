namespace TechnixDemo.Forms.Component
{
    partial class CMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMessageBox));
            panel1 = new Panel();
            Close = new Button();
            GenProcBtn = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Khaki;
            panel1.Controls.Add(Close);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(369, 26);
            panel1.TabIndex = 1;
            // 
            // Close
            // 
            Close.BackgroundImage = (Image)resources.GetObject("Close.BackgroundImage");
            Close.BackgroundImageLayout = ImageLayout.Stretch;
            Close.Dock = DockStyle.Right;
            Close.FlatAppearance.BorderSize = 0;
            Close.FlatStyle = FlatStyle.Flat;
            Close.Location = new Point(346, 0);
            Close.Name = "Close";
            Close.Size = new Size(23, 26);
            Close.TabIndex = 4;
            Close.UseVisualStyleBackColor = true;
            // 
            // GenProcBtn
            // 
            GenProcBtn.BackColor = SystemColors.ActiveCaptionText;
            GenProcBtn.FlatAppearance.BorderSize = 0;
            GenProcBtn.FlatStyle = FlatStyle.Flat;
            GenProcBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            GenProcBtn.ForeColor = Color.White;
            GenProcBtn.Location = new Point(275, 101);
            GenProcBtn.Name = "GenProcBtn";
            GenProcBtn.Size = new Size(65, 23);
            GenProcBtn.TabIndex = 13;
            GenProcBtn.Text = "OK";
            GenProcBtn.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 54);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 14;
            // 
            // CMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(369, 145);
            Controls.Add(label1);
            Controls.Add(GenProcBtn);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CMessageBox";
            Text = "Message Box";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button Close;
        private Button GenProcBtn;
        private Label label1;
    }
}