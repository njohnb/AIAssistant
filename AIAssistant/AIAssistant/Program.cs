using AIAssistant.Forms;
using AIAssistant.Shared;

namespace AIAssistant;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args = null)
    {
        
        
        if (args.Length >= 2 && args[0] == "--analyze")
        {
            Logger.LogContextMenu("===Starting analyze window===");
            ApplicationConfiguration.Initialize();
            Application.Run(new OpenAIForm(args[1]));
            return;
        }
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        string baseDir = AppContext.BaseDirectory;
        string iconPath = Path.Combine(baseDir, "AIAssistant.ico");
        if (!File.Exists(iconPath))
        {
            
            MessageBox.Show("Icon file not found: " + iconPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var notifyIcon = new NotifyIcon
        {
            Icon = new Icon(iconPath),
            Visible = true,
            Text = "AI Assistant"
        };
        
        var contextMenu = new ContextMenuStrip();
        var openIdeaToOutline = new ToolStripMenuItem("Open Idea to Outline Generator");
        
        openIdeaToOutline.Click += (s, e) =>
        {
            var form = new OpenAIForm();
            form.Show();
        };
        
        contextMenu.Items.Add(openIdeaToOutline);
        contextMenu.Items.Add(new ToolStripSeparator());
       
        
        
       var openTaskSplitter = new ToolStripMenuItem("Open Task Splitter");
       openTaskSplitter.Click += (s, e) =>
       {
           var form = new TaskSplitterForm();
           form.Show();
       };
        
       contextMenu.Items.Add(openTaskSplitter);
       contextMenu.Items.Add(new ToolStripSeparator());
       
        var exitItem = new ToolStripMenuItem("Close AI Assistant");
        exitItem.Click += (s, e) =>
        {
            notifyIcon.Visible = false;
            Application.Exit();
        };
        contextMenu.Items.Add(exitItem);
        notifyIcon.ContextMenuStrip = contextMenu;
        
        Application.Run();
    }
}