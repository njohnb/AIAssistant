﻿using System.ComponentModel;

namespace AIAssistant.Forms;

partial class StartupForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        components = new System.ComponentModel.Container();
        notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
        SuspendLayout();
        // 
        // notifyIcon1
        // 
        notifyIcon1.Text = "notifyIcon1";
        notifyIcon1.Visible = true;
        // 
        // StartupForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Text = "StartupForm";
        ResumeLayout(false);
    }

    private System.Windows.Forms.NotifyIcon notifyIcon1;

    #endregion
}