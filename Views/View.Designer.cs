namespace SimPranks
{
    partial class View
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
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.lblDescription1 = new System.Windows.Forms.Label();
            this.lblDescription2 = new System.Windows.Forms.Label();
            this.chkLstPranks = new System.Windows.Forms.CheckedListBox();
            this.lblActivePranks = new System.Windows.Forms.Label();
            this.btnHideAndApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.AutoSize = true;
            this.lblWindowTitle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindowTitle.Location = new System.Drawing.Point(53, 13);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(101, 26);
            this.lblWindowTitle.TabIndex = 1;
            this.lblWindowTitle.Text = "SimPranks";
            // 
            // lblDescription1
            // 
            this.lblDescription1.AutoSize = true;
            this.lblDescription1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription1.Location = new System.Drawing.Point(53, 39);
            this.lblDescription1.Name = "lblDescription1";
            this.lblDescription1.Size = new System.Drawing.Size(531, 26);
            this.lblDescription1.TabIndex = 1;
            this.lblDescription1.Text = "Hi, please use the options below to control the active pranks.";
            // 
            // lblDescription2
            // 
            this.lblDescription2.AutoSize = true;
            this.lblDescription2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription2.Location = new System.Drawing.Point(53, 65);
            this.lblDescription2.Name = "lblDescription2";
            this.lblDescription2.Size = new System.Drawing.Size(717, 26);
            this.lblDescription2.TabIndex = 1;
            this.lblDescription2.Text = "To activate this window again, press the left Windows and Esc keys simultaneously" +
    ".";
            // 
            // chkLstPranks
            // 
            this.chkLstPranks.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.chkLstPranks.CheckOnClick = true;
            this.chkLstPranks.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLstPranks.FormattingEnabled = true;
            this.chkLstPranks.Location = new System.Drawing.Point(58, 150);
            this.chkLstPranks.Name = "chkLstPranks";
            this.chkLstPranks.Size = new System.Drawing.Size(712, 238);
            this.chkLstPranks.TabIndex = 2;
            // 
            // lblActivePranks
            // 
            this.lblActivePranks.AutoSize = true;
            this.lblActivePranks.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivePranks.Location = new System.Drawing.Point(53, 121);
            this.lblActivePranks.Name = "lblActivePranks";
            this.lblActivePranks.Size = new System.Drawing.Size(132, 26);
            this.lblActivePranks.TabIndex = 1;
            this.lblActivePranks.Text = "Active Pranks:";
            // 
            // btnHideAndApply
            // 
            this.btnHideAndApply.Location = new System.Drawing.Point(651, 395);
            this.btnHideAndApply.Name = "btnHideAndApply";
            this.btnHideAndApply.Size = new System.Drawing.Size(118, 23);
            this.btnHideAndApply.TabIndex = 3;
            this.btnHideAndApply.Text = "Hide and apply";
            this.btnHideAndApply.UseVisualStyleBackColor = true;
            this.btnHideAndApply.Click += new System.EventHandler(this.btnHideAndApply_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnHideAndApply);
            this.Controls.Add(this.chkLstPranks);
            this.Controls.Add(this.lblDescription2);
            this.Controls.Add(this.lblActivePranks);
            this.Controls.Add(this.lblDescription1);
            this.Controls.Add(this.lblWindowTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimPranks";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ApplicationWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblWindowTitle;
        private System.Windows.Forms.Label lblDescription1;
        private System.Windows.Forms.Label lblDescription2;
        private System.Windows.Forms.CheckedListBox chkLstPranks;
        private System.Windows.Forms.Label lblActivePranks;
        private System.Windows.Forms.Button btnHideAndApply;
    }
}