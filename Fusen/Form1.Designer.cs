namespace Fusen
{
    partial class FormFusen
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
            this.colorDialogFusen = new System.Windows.Forms.ColorDialog();
            this.textFusenMemo = new System.Windows.Forms.TextBox();
            this.textBox_X = new System.Windows.Forms.TextBox();
            this.textBox_Y = new System.Windows.Forms.TextBox();
            this.textBox_mouse_location = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textFusenMemo
            // 
            this.textFusenMemo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textFusenMemo.Dock = System.Windows.Forms.DockStyle.Top;
            this.textFusenMemo.Location = new System.Drawing.Point(0, 0);
            this.textFusenMemo.Multiline = true;
            this.textFusenMemo.Name = "textFusenMemo";
            this.textFusenMemo.Size = new System.Drawing.Size(322, 240);
            this.textFusenMemo.TabIndex = 0;
            this.textFusenMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textFusenMemo_KeyDown);
            this.textFusenMemo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textFusenMemo_MouseDoubleClick);
            this.textFusenMemo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textFusenMemo_MouseDown);
            this.textFusenMemo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textFusenMemo_MouseMove);
            // 
            // textBox_X
            // 
            this.textBox_X.Location = new System.Drawing.Point(0, 237);
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.Size = new System.Drawing.Size(103, 22);
            this.textBox_X.TabIndex = 1;
            // 
            // textBox_Y
            // 
            this.textBox_Y.Location = new System.Drawing.Point(101, 237);
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.Size = new System.Drawing.Size(100, 22);
            this.textBox_Y.TabIndex = 2;
            // 
            // textBox_mouse_location
            // 
            this.textBox_mouse_location.Location = new System.Drawing.Point(0, 255);
            this.textBox_mouse_location.Name = "textBox_mouse_location";
            this.textBox_mouse_location.Size = new System.Drawing.Size(103, 22);
            this.textBox_mouse_location.TabIndex = 3;
            // 
            // FormFusen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 280);
            this.Controls.Add(this.textBox_mouse_location);
            this.Controls.Add(this.textBox_Y);
            this.Controls.Add(this.textBox_X);
            this.Controls.Add(this.textFusenMemo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFusen";
            this.Opacity = 0.6D;
            this.Text = "Form1";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialogFusen;
        private System.Windows.Forms.TextBox textFusenMemo;
        private System.Windows.Forms.TextBox textBox_X;
        private System.Windows.Forms.TextBox textBox_Y;
        private System.Windows.Forms.TextBox textBox_mouse_location;
    }
}

