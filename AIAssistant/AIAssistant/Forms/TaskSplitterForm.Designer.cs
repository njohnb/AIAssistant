using System.ComponentModel;

namespace AIAssistant.Forms;

partial class TaskSplitterForm
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
        label1 = new System.Windows.Forms.Label();
        textBox_prompt = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        textBox_response = new System.Windows.Forms.TextBox();
        button_sendPrompt = new System.Windows.Forms.Button();
        button_download = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(12, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(100, 23);
        label1.TabIndex = 0;
        label1.Text = "Task:";
        // 
        // textBox_prompt
        // 
        textBox_prompt.Location = new System.Drawing.Point(12, 35);
        textBox_prompt.Multiline = true;
        textBox_prompt.Name = "textBox_prompt";
        textBox_prompt.Size = new System.Drawing.Size(776, 156);
        textBox_prompt.TabIndex = 1;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(12, 245);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(100, 23);
        label2.TabIndex = 2;
        label2.Text = "Response:";
        // 
        // textBox_response
        // 
        textBox_response.Location = new System.Drawing.Point(12, 271);
        textBox_response.Multiline = true;
        textBox_response.Name = "textBox_response";
        textBox_response.Size = new System.Drawing.Size(776, 167);
        textBox_response.TabIndex = 3;
        // 
        // button_sendPrompt
        // 
        button_sendPrompt.Location = new System.Drawing.Point(209, 210);
        button_sendPrompt.Name = "button_sendPrompt";
        button_sendPrompt.Size = new System.Drawing.Size(137, 41);
        button_sendPrompt.TabIndex = 4;
        button_sendPrompt.Text = "Split Task";
        button_sendPrompt.UseVisualStyleBackColor = true;
        button_sendPrompt.Click += button_sendPrompt_Click;
        // 
        // button_download
        // 
        button_download.Location = new System.Drawing.Point(416, 210);
        button_download.Name = "button_download";
        button_download.Size = new System.Drawing.Size(135, 41);
        button_download.TabIndex = 5;
        button_download.Text = "Download Response";
        button_download.UseVisualStyleBackColor = true;
        button_download.Click += button_download_Click;
        // 
        // TaskSplitterForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(button_download);
        Controls.Add(button_sendPrompt);
        Controls.Add(textBox_response);
        Controls.Add(label2);
        Controls.Add(textBox_prompt);
        Controls.Add(label1);
        Text = "TaskSplitterForm";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button button_download;

    private System.Windows.Forms.TextBox textBox_response;
    private System.Windows.Forms.Button button_sendPrompt;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox_prompt;

    #endregion
}