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
            addHeaderMenuItem.Click += (sender, e) => mainForm.showInputControls("Header");
            
            var addTitleMenuItem = new ToolStripMenuItem("Add Title");
            addTitleMenuItem.Click += (sender, e) => mainForm.showInputControls("Title"); 

            var addFooterMenuItem = new ToolStripMenuItem("Add Footer");
            addFooterMenuItem.Click += (sender, e) => mainForm.showInputControls("Footer");

            var addParagraphMenuItem = new ToolStripMenuItem("Add Paragraph");
            addParagraphMenuItem.Click += (sender, e) => mainForm.showInputControls("Paragraph");

            this.Items.Add(addHeaderMenuItem);
            this.Items.Add(addTitleMenuItem);
            this.Items.Add(addFooterMenuItem);
            this.Items.Add(addParagraphMenuItem);
        }

    }
}

