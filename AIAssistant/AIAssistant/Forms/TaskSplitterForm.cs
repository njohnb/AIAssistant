using AIAssistant.Helpers;
using AIAssistant.Shared;
namespace AIAssistant.Forms;

public partial class TaskSplitterForm : Form
{
    public TaskSplitterForm()
    {
        InitializeComponent();
    }


    private async void button_sendPrompt_Click(object sender, EventArgs e)
    {
        button_sendPrompt.Enabled = false;
        textBox_response.Text = "Thinking...";
        string input = textBox_prompt.Text.Trim();
        if (!string.IsNullOrEmpty(input))
        {
            string response = await GPTProcessor.CallOpenAiAsync(input, OpenAiMode.SplitTask);
            textBox_response.Text = response;
        }

        button_sendPrompt.Enabled = true;
    }

    private void button_download_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBox_response.Text) || string.Equals(textBox_response.Text, "Thinking..."))
        {
            MessageBox.Show("No response to download.","Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog.Title = "Save TaskSplitter Response";
            saveFileDialog.FileName = "SplitTask.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, textBox_response.Text);
                    MessageBox.Show("Response saved successfully.", "Saved", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Failed to save response: {exception.Message}", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}