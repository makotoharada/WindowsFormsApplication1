namespace streamWriter_Reader
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_read = new System.Windows.Forms.Button();
            this.button_write = new System.Windows.Forms.Button();
            this.textBox_read = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_open = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_read
            // 
            this.button_read.Location = new System.Drawing.Point(164, 30);
            this.button_read.Name = "button_read";
            this.button_read.Size = new System.Drawing.Size(87, 23);
            this.button_read.TabIndex = 0;
            this.button_read.Text = "read_text";
            this.button_read.UseVisualStyleBackColor = true;
            this.button_read.Click += new System.EventHandler(this.button_read_Click);
            // 
            // button_write
            // 
            this.button_write.Location = new System.Drawing.Point(67, 189);
            this.button_write.Name = "button_write";
            this.button_write.Size = new System.Drawing.Size(87, 23);
            this.button_write.TabIndex = 1;
            this.button_write.Text = "write_text";
            this.button_write.UseVisualStyleBackColor = true;
            this.button_write.Click += new System.EventHandler(this.button_write_Click);
            // 
            // textBox_read
            // 
            this.textBox_read.Location = new System.Drawing.Point(67, 71);
            this.textBox_read.Multiline = true;
            this.textBox_read.Name = "textBox_read";
            this.textBox_read.Size = new System.Drawing.Size(184, 97);
            this.textBox_read.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(67, 30);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(87, 23);
            this.button_open.TabIndex = 3;
            this.button_open.Text = "Open File";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.textBox_read);
            this.Controls.Add(this.button_write);
            this.Controls.Add(this.button_read);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_read;
        private System.Windows.Forms.Button button_write;
        private System.Windows.Forms.TextBox textBox_read;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_open;
    }
}

