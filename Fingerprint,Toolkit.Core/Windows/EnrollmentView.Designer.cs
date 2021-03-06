﻿namespace Fingerprint.Toolkit
{
    partial class EnrollmentView
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
            System.Windows.Forms.Button btnCancel;
            System.Windows.Forms.Button btnComplete;
            this.EnrollmentControl = new DPFP.Gui.Enrollment.EnrollmentControl();
            this.GroupEvents = new System.Windows.Forms.GroupBox();
            this.ListEvents = new System.Windows.Forms.ListBox();
            btnCancel = new System.Windows.Forms.Button();
            btnComplete = new System.Windows.Forms.Button();
            this.GroupEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnrollmentControl
            // 
            this.EnrollmentControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EnrollmentControl.EnrolledFingerMask = 0;
            this.EnrollmentControl.Location = new System.Drawing.Point(1, -3);
            this.EnrollmentControl.MaxEnrollFingerCount = 10;
            this.EnrollmentControl.Name = "EnrollmentControl";
            this.EnrollmentControl.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000";
            this.EnrollmentControl.Size = new System.Drawing.Size(492, 314);
            this.EnrollmentControl.TabIndex = 2;
            this.EnrollmentControl.OnDelete += new DPFP.Gui.Enrollment.EnrollmentControl._OnDelete(this.EnrollmentControl_OnDelete);
            this.EnrollmentControl.OnEnroll += new DPFP.Gui.Enrollment.EnrollmentControl._OnEnroll(this.EnrollmentControl_OnEnroll);
            this.EnrollmentControl.OnFingerTouch += new DPFP.Gui.Enrollment.EnrollmentControl._OnFingerTouch(this.EnrollmentControl_OnFingerTouch);
            this.EnrollmentControl.OnFingerRemove += new DPFP.Gui.Enrollment.EnrollmentControl._OnFingerRemove(this.EnrollmentControl_OnFingerRemove);
            this.EnrollmentControl.OnComplete += new DPFP.Gui.Enrollment.EnrollmentControl._OnComplete(this.EnrollmentControl_OnComplete);
            this.EnrollmentControl.OnReaderConnect += new DPFP.Gui.Enrollment.EnrollmentControl._OnReaderConnect(this.EnrollmentControl_OnReaderConnect);
            this.EnrollmentControl.OnReaderDisconnect += new DPFP.Gui.Enrollment.EnrollmentControl._OnReaderDisconnect(this.EnrollmentControl_OnReaderDisconnect);
            this.EnrollmentControl.OnSampleQuality += new DPFP.Gui.Enrollment.EnrollmentControl._OnSampleQuality(this.EnrollmentControl_OnSampleQuality);
            this.EnrollmentControl.OnStartEnroll += new DPFP.Gui.Enrollment.EnrollmentControl._OnStartEnroll(this.EnrollmentControl_OnStartEnroll);
            this.EnrollmentControl.OnCancelEnroll += new DPFP.Gui.Enrollment.EnrollmentControl._OnCancelEnroll(this.EnrollmentControl_OnCancelEnroll);
            // 
            // GroupEvents
            // 
            this.GroupEvents.Controls.Add(this.ListEvents);
            this.GroupEvents.Location = new System.Drawing.Point(12, 311);
            this.GroupEvents.Name = "GroupEvents";
            this.GroupEvents.Size = new System.Drawing.Size(473, 146);
            this.GroupEvents.TabIndex = 3;
            this.GroupEvents.TabStop = false;
            this.GroupEvents.Text = "Events";
            // 
            // ListEvents
            // 
            this.ListEvents.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ListEvents.FormattingEnabled = true;
            this.ListEvents.Location = new System.Drawing.Point(16, 19);
            this.ListEvents.Name = "ListEvents";
            this.ListEvents.Size = new System.Drawing.Size(440, 108);
            this.ListEvents.TabIndex = 0;
            // 
            // CancelButton
            // 
            btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnCancel.Location = new System.Drawing.Point(410, 474);
            btnCancel.Name = "CancelButton";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += CancelButton_Click;
            // 
            // btnComplete
            // 
            btnComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnComplete.Location = new System.Drawing.Point(318, 474);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new System.Drawing.Size(75, 23);
            btnComplete.TabIndex = 4;
            btnComplete.Text = "Complete";
            btnComplete.UseVisualStyleBackColor = true;
            btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            this.btnComplete = btnComplete;
            // 
            // EnrollmentView
            // 
            this.AcceptButton = btnCancel;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(497, 509);
            this.Controls.Add(btnComplete);
            this.Controls.Add(this.GroupEvents);
            this.Controls.Add(btnCancel);
            this.Controls.Add(this.EnrollmentControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnrollmentView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fingerprint Enrollment";
            this.Load += new System.EventHandler(this.EnrollmentForm_Load);
            this.GroupEvents.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        System.Windows.Forms.Button btnComplete;
        private DPFP.Gui.Enrollment.EnrollmentControl EnrollmentControl;
        private System.Windows.Forms.GroupBox GroupEvents;
        private System.Windows.Forms.ListBox ListEvents;
    }
}