using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CreateSeminarApp.Models
{
    public class Menu : MenuStrip
    {
        private Form1 mainForm;

        public Menu(Form1 form)
        {
            mainForm = form;

            BackColor = ColorTranslator.FromHtml("#F8BBD0");
            ForeColor = Color.Black;
            Font = new Font("Segoe UI", 12, FontStyle.Regular);

            InitializeMenu();
        }

        private void InitializeMenu()
        {
            var addHeaderMenuItem = new ToolStripMenuItem("Add Header");
            addHeaderMenuItem.Click += (sender, e) => mainForm.ShowInputControls("Header");

            var addTitleMenuItem = new ToolStripMenuItem("Add Title");
            addTitleMenuItem.Click += (sender, e) => mainForm.ShowInputControls("Title");//&& mainForm.ShowInputControls;

            var addFooterMenuItem = new ToolStripMenuItem("Add Footer");
            addFooterMenuItem.Click += (sender, e) => mainForm.ShowInputControls("Footer");

            var addParagraphMenuItem = new ToolStripMenuItem("Add Paragraph");
            addParagraphMenuItem.Click += (sender, e) => mainForm.ShowInputControls("Paragraph");

            Items.Add(addHeaderMenuItem);
            Items.Add(addTitleMenuItem);
            Items.Add(addFooterMenuItem);
            Items.Add(addParagraphMenuItem);
        }

    }
}

