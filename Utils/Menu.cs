using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CreateSeminarApp.Utils
{
    public class Menu:MenuStrip
    {
        private Form1 mainForm;

        public Menu(Form1 form) { 
            mainForm = form;

            this.BackColor = ColorTranslator.FromHtml("F8BBD0");
            this.ForeColor = Color.Black;
            this.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            InitializeMenu();
        }

        private void InitializeMenu()
        {
            var addHeaderMenuItem = new ToolStripMenuItem("Add Header");
            addHeaderMenuItem.Click += AddHeaderMenuItem_Click;
            
            var addTitleMenuItem = new ToolStripMenuItem("Add Title");
            addTitleMenuItem.Click += AddTitleMenuItem_Click;

            var addFooterMenuItem = new ToolStripMenuItem("Add Footer");
            addFooterMenuItem.Click += AddFooterMenuItem_Click;

            var addTextMenuItem = new ToolStripMenuItem("Add Text");
            addTextMenuItem.Click += AddTextMenuItem_Click;

            this.Items.Add(addHeaderMenuItem);
            this.Items.Add(addTitleMenuItem);
            this.Items.Add(addFooterMenuItem);
            this.Items.Add(addTextMenuItem);
        }

        private void AddTextMenuItem_Click(object? sender, EventArgs e)
        {
            ShowInputControls("Text");
        }

        private void AddFooterMenuItem_Click(object? sender, EventArgs e)
        {
            ShowInputControls("Footer");
        }

        private void AddTitleMenuItem_Click(object? sender, EventArgs e)
        {
            ShowInputControls("Title");
        }

        private void AddHeaderMenuItem_Click(object? sender, EventArgs e)
        {
            ShowInputControls("Header");
        }

        private void ShowInputControls(string contentType)
        {
            mainForm.Controls.Clear();

            TextBox inputText = new TextBox{PlaceholderText = $"Enter {contentType}",Width=200};
            ListBox previousItemsList=new ListBox { Width = 200 };
            SaveButton saveButton = new SaveButton(contentType) { Text=$"Save {contentType}"};

            mainForm.Controls.Add(saveButton);
            mainForm.Controls.Add(previousItemsList);
            mainForm.Controls.Add(inputText);

            inputText.Location = new System.Drawing.Point(10, 50);
            previousItemsList.Location = new System.Drawing.Point(10, 90);
            saveButton.Location = new System.Drawing.Point(10, 150);

        }
    }
}

