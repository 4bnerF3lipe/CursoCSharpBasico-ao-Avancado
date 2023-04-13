namespace Parte006
{
    partial class Form1
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
            this.checkList = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkList
            // 
            this.checkList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkList.CheckOnClick = true;
            this.checkList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkList.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkList.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkList.ForeColor = System.Drawing.Color.Maroon;
            this.checkList.FormattingEnabled = true;
            this.checkList.Location = new System.Drawing.Point(0, 0);
            this.checkList.Name = "checkList";
            this.checkList.Size = new System.Drawing.Size(400, 479);
            this.checkList.TabIndex = 0;
            this.checkList.SelectedIndexChanged += new System.EventHandler(this.checkList_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(407, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(396, 63);
            this.button1.TabIndex = 1;
            this.button1.Text = "Executar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(407, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 52);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 479);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

