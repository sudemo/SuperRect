
namespace RectTestClass
{
    partial class Form2
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
            this.logrtx2 = new Sunny.UI.UIRichTextBox();
            this.uiAnalogMeter1 = new Sunny.UI.UIAnalogMeter();
            this.SuspendLayout();
            // 
            // logrtx2
            // 
            this.logrtx2.AutoWordSelection = true;
            this.logrtx2.FillColor = System.Drawing.Color.White;
            this.logrtx2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.logrtx2.Location = new System.Drawing.Point(1204, 105);
            this.logrtx2.MinimumSize = new System.Drawing.Size(1, 1);
            this.logrtx2.Name = "logrtx2";
            this.logrtx2.Padding = new System.Windows.Forms.Padding(1);
            this.logrtx2.Size = new System.Drawing.Size(211, 439);
            this.logrtx2.Style = Sunny.UI.UIStyle.Custom;
            this.logrtx2.TabIndex = 0;
            this.logrtx2.Text = "uiRichTextBox1";
            this.logrtx2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.logrtx2.WordWrap = true;
            this.logrtx2.TextChanged += new System.EventHandler(this.logrtx2_TextChanged);
            // 
            // uiAnalogMeter1
            // 
            this.uiAnalogMeter1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiAnalogMeter1.Location = new System.Drawing.Point(692, 352);
            this.uiAnalogMeter1.MaxValue = 100D;
            this.uiAnalogMeter1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiAnalogMeter1.MinValue = 0D;
            this.uiAnalogMeter1.Name = "uiAnalogMeter1";
            this.uiAnalogMeter1.Renderer = null;
            this.uiAnalogMeter1.Size = new System.Drawing.Size(8, 8);
            this.uiAnalogMeter1.TabIndex = 1;
            this.uiAnalogMeter1.Text = "uiAnalogMeter1";
            this.uiAnalogMeter1.Value = 0D;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1500, 759);
            this.Controls.Add(this.uiAnalogMeter1);
            this.Controls.Add(this.logrtx2);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Activated += new System.EventHandler(this.Form2_Activated);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.ResumeLayout(false);

        }
        #endregion
        private Sunny.UI.UIRichTextBox logrtx2;
        private Sunny.UI.UIAnalogMeter uiAnalogMeter1;
    }
}