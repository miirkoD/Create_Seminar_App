using CreateSeminarApp.Models;
using System;
using System.Windows.Forms;


namespace CreateSeminarApp
{
    public partial class Form1 : Form
    {
        private TextBox headerInput = new TextBox { Visible = false };
        private TextBox footerInput = new TextBox { Visible = false };
        private TextBox titleInput = new TextBox { Visible = false };
        private TextBox paragraphInput = new TextBox { Visible = false };
        private SaveButton saveButton;
        private ListBox titlesList=new ListBox { Visible=false};
        public Form1()
        {
            InitializeComponent();
            CreateUI();
        }

        private void CreateUI()
        {
            this.Text = "Seminar App";
            this.Size = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF0F5");

            var menu = new Menu(this);
            this.MainMenuStrip = menu;
            this.Controls.Add(menu);

            titlesList.Width = 150;

            headerInput.Location = new System.Drawing.Point(50, 100);
            footerInput.Location = new System.Drawing.Point(50, 100);
            titleInput.Location = new System.Drawing.Point(210, 100);
            titlesList.Location=new System.Drawing.Point(50, 100);
            paragraphInput.Location = new System.Drawing.Point(50, 100);

            this.Controls.Add(headerInput);
            this.Controls.Add(footerInput);
            this.Controls.Add(titleInput);
            this.Controls.Add(paragraphInput);
            this.Controls.Add(titlesList);

            saveButton = new SaveButton("Header", headerInput, footerInput, titleInput, paragraphInput)
            {
                Location = new System.Drawing.Point(50, 150),
                Visible = false
            };
            this.Controls.Add(saveButton);
        }

        public void ShowInputControls(string contentType)
        {
            headerInput.Visible = footerInput.Visible = titleInput.Visible = paragraphInput.Visible = false;

            switch (contentType)
            {
                case "Header":
                    headerInput.Visible = true; break;
                case "Footer":
                    footerInput.Visible = true; break;
                case "Title":
                    titleInput.Visible = true;
                    titlesList.Visible = true; break;
                case "Paragraph":
                    paragraphInput.Visible = true; break;
            }
            saveButton.contentType = contentType;
            saveButton.Visible = true;
        }
    }
}
