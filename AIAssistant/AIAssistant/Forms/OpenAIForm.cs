﻿using AIAssistant.Shared;
using AIAssistant.Helpers;
namespace AIAssistant.Forms;

public partial class OpenAIForm : Form
{
    private string targetPath;
    public OpenAIForm()
    {
        InitializeComponent();
    }

    public OpenAIForm(string targetPath = null)
    {
        InitializeComponent();
        this.targetPath = targetPath;
        Shown += OpenAIForm_Shown;
    }
    private async void OpenAIForm_Shown(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(targetPath))
            return;

        if (File.Exists(targetPath)) // targetPath is a file
        {
            try
            {
                button_sendPrompt.Enabled = false;
                string fileContent = File.ReadAllText(targetPath);

                const int maxTokens = 24_000;
                const int maxChars = maxTokens * 4; // ~96,000 characters
                int estimatedTokens = GPTProcessor.EstimateTokens(fileContent);

            
                Logger.LogContextMenu($"[{DateTime.Now}] Analyzing file: {targetPath}\n" +
                                      $"- Char length: {fileContent.Length}\n" +
                                      $"- Estimated tokens: {estimatedTokens} / {maxTokens}\n");
            
                if (estimatedTokens > maxTokens)
                {
                    try
                    {
                        Logger.LogContextMenu($"[{DateTime.Now}] File is too large. Splitting into chunks.");


                        int chunkCharSize = maxChars / 2; // ~48,000 chars per chunk
                        List<string>
                            chunks = GPTProcessor.ChunkString(fileContent,
                                chunkCharSize); // roughly 12,000 tokens per chunk


                        button_sendPrompt.Enabled = false;
                        textBox_response.Text = "Analyzing large file in parts...";
                        string finalResponse = await GPTProcessor.StartMultiChunkCall(chunks, targetPath);
                        textBox_response.Text = finalResponse;

                    }
                    catch (Exception ex)
                    {
                        Logger.LogContextMenu(
                            $"-----ChunkString() failed at {DateTime.Now} -- {ex.Message}\n{ex.StackTrace}-----");
                    }
                    finally
                    {
                        button_sendPrompt.Enabled = true;
                    }
                }
                else
                {
                    textBox_prompt.Text = $"Please analyze and summarize the contents of the following file: \n\"{targetPath}\"";
                    textBox_response.Text = "Thinking...";
                    string prompt = $"Please analyze and summarize the contents of the following file: \n\"{targetPath}\" \n\n{fileContent} \n\n{fileContent.Length}";
                    string response = await GPTProcessor.CallOpenAiAsync(prompt, OpenAiMode.AnalyzeFileOrFolder);
                    textBox_response.Text = response;
                    
                }
            }
            catch (Exception ex)
            {
                Logger.LogContextMenu(ex, "-----OpenAIForm_Shown failed.-----");
            }
            finally
            {
                button_sendPrompt.Enabled = true;
            }
        }
        else if (Directory.Exists(targetPath)) // targetPath is a folder
        {
            try
            {
                // call folder scanner
                button_sendPrompt.Enabled = false;
                var summary = FolderScanner.ScanFolder(targetPath);
                string formatted = await FolderScanner.FormatSummary(summary);
                textBox_prompt.Text = $"Please analyze and summarize the contents of the following folder: \n\"{targetPath}\" \n\n{formatted}";
                textBox_response.Text = "Thinking...";
                string prompt = $"Please analyze and summarize the contents of the following folder: \n\"{targetPath}\" \n\n{formatted}";
                // todo: ENSURE CHUNKS ARENT OVER SIZE LIMIT
                string response = await GPTProcessor.CallOpenAiAsync(prompt, OpenAiMode.AnalyzeFileOrFolder);
                textBox_response.Text = response;
                
            }
            catch(Exception ex)
            {
                Logger.LogContextMenu(ex, "-----OpenAIForm_Shown failed.-----");
            }
            finally
            {
                button_sendPrompt.Enabled = true;
            }
        }
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
            saveFileDialog.Title = "Save OpenAI Response";
            saveFileDialog.FileName = "OpenAIResponse.txt";

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

    private async void button_sendPrompt_Click(object sender, EventArgs e)
    {
        button_sendPrompt.Enabled = false;
        textBox_response.Text = "Thinking...";
        string input = textBox_prompt.Text.Trim();
        if (!string.IsNullOrEmpty(input))
        {
            string response = await GPTProcessor.CallOpenAiAsync(input, OpenAiMode.IdeaToOutline);
            textBox_response.Text = response;
        }

        button_sendPrompt.Enabled = true;
    }
}