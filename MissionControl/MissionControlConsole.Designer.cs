namespace MissionControl
{
    partial class MissionControlConsole
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
            this.btnForward = new System.Windows.Forms.Button();
            this.txtCommandList = new System.Windows.Forms.TextBox();
            this.cmdLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.cmdExecute = new System.Windows.Forms.Button();
            this.startposX = new System.Windows.Forms.NumericUpDown();
            this.startposY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.startposX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startposY)).BeginInit();
            this.SuspendLayout();
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(101, 100);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(75, 23);
            this.btnForward.TabIndex = 0;
            this.btnForward.Text = "Forward";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // txtCommandList
            // 
            this.txtCommandList.Location = new System.Drawing.Point(44, 50);
            this.txtCommandList.Name = "txtCommandList";
            this.txtCommandList.Size = new System.Drawing.Size(189, 23);
            this.txtCommandList.TabIndex = 1;
            // 
            // cmdLeft
            // 
            this.cmdLeft.Location = new System.Drawing.Point(44, 140);
            this.cmdLeft.Name = "cmdLeft";
            this.cmdLeft.Size = new System.Drawing.Size(75, 23);
            this.cmdLeft.TabIndex = 2;
            this.cmdLeft.Text = "Left";
            this.cmdLeft.UseVisualStyleBackColor = true;
            this.cmdLeft.Click += new System.EventHandler(this.cmdLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(158, 140);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 3;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // cmdExecute
            // 
            this.cmdExecute.Location = new System.Drawing.Point(101, 17);
            this.cmdExecute.Name = "cmdExecute";
            this.cmdExecute.Size = new System.Drawing.Size(75, 23);
            this.cmdExecute.TabIndex = 4;
            this.cmdExecute.Text = "Execute";
            this.cmdExecute.UseVisualStyleBackColor = true;
            this.cmdExecute.Click += new System.EventHandler(this.cmdExecute_Click);
            // 
            // startposX
            // 
            this.startposX.Location = new System.Drawing.Point(75, 218);
            this.startposX.Name = "startposX";
            this.startposX.Size = new System.Drawing.Size(44, 23);
            this.startposX.TabIndex = 5;
            this.startposX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startposY
            // 
            this.startposY.Location = new System.Drawing.Point(158, 218);
            this.startposY.Name = "startposY";
            this.startposY.Size = new System.Drawing.Size(44, 23);
            this.startposY.TabIndex = 6;
            this.startposY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Start Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Y";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(116, 244);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(42, 26);
            this.btnSet.TabIndex = 10;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // MissionControlConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 312);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startposY);
            this.Controls.Add(this.startposX);
            this.Controls.Add(this.cmdExecute);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.cmdLeft);
            this.Controls.Add(this.txtCommandList);
            this.Controls.Add(this.btnForward);
            this.Name = "MissionControlConsole";
            this.Text = "Mission Control Console";
            this.Load += new System.EventHandler(this.MissionControlConsole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.startposX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startposY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnForward;
        private TextBox txtCommandList;
        private Button cmdLeft;
        private Button btnRight;
        private Button cmdExecute;
        private NumericUpDown startposX;
        private NumericUpDown startposY;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSet;
    }
}