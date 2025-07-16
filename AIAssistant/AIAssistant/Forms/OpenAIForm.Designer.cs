using System.ComponentModel;

namespace AIAssistant.Forms;

partial class OpenAIForm
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
        button_download = new System.Windows.Forms.Button();
        textBox_response = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        button_sendPrompt = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(12, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(100, 23);
        label1.TabIndex = 0;
        label1.Text = "Prompt:";
        // 
        // textBox_prompt
        // 
        textBox_prompt.Location = new System.Drawing.Point(12, 35);
        textBox_prompt.Multiline = true;
        textBox_prompt.Name = "textBox_prompt";
        textBox_prompt.Size = new System.Drawing.Size(776, 139);
        textBox_prompt.TabIndex = 1;
        // 
        // button_download
        // 
        button_download.Location = new System.Drawing.Point(380, 180);
        button_download.Name = "button_download";
        button_download.Size = new System.Drawing.Size(106, 35);
        button_download.TabIndex = 3;
        button_download.Text = "Download";
        button_download.UseVisualStyleBackColor = true;
        button_download.Click += button_download_Click;
        // 
        // textBox_response
        // 
        textBox_response.Location = new System.Drawing.Point(12, 246);
        textBox_response.Multiline = true;
        textBox_response.Name = "textBox_response";
        textBox_response.Size = new System.Drawing.Size(776, 192);
        textBox_response.TabIndex = 4;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(12, 220);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(100, 23);
        label2.TabIndex = 5;
        label2.Text = "Response:";
        // 
        // button_sendPrompt
        // 
        button_sendPrompt.Location = new System.Drawing.Point(268, 180);
        button_sendPrompt.Name = "button_sendPrompt";
        button_sendPrompt.Size = new System.Drawing.Size(106, 35);
        button_sendPrompt.TabIndex = 6;
        button_sendPrompt.Text = "Send Prompt";
        button_sendPrompt.UseVisualStyleBackColor = true;
        button_sendPrompt.Click += button_sendPrompt_Click;
        // 
        // OpenAIForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(button_sendPrompt);
        Controls.Add(label2);
        Controls.Add(textBox_response);
        Controls.Add(button_download);
        Controls.Add(textBox_prompt);
        Controls.Add(label1);
        Text = "OpenAIForm";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button button_sendPrompt;

    private System.Windows.Forms.Button button_download;
    private System.Windows.Forms.TextBox textBox_response;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox_prompt;

    #endregion
}