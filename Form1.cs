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
        private Label Header=new Label ();
        //initialising items that will be used on form
        public Form1()
        {
            InitializeComponent();
            CreateUI();
        }

        private void CreateUI() //method that makes how form would look like
        {
            this.Text = "Seminar App";
            this.Size = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#bf859a");

            var menu = new Menu(this); //defining menu and adding it to the form
            this.MainMenuStrip = menu;
            this.Controls.Add(menu);

            titlesList.Width = 150;

            headerInput.Location = new System.Drawing.Point(50, 100);
            footerInput.Location = new System.Drawing.Point(50, 100);
            titleInput.Location = new System.Drawing.Point(210, 100);
            titlesList.Location=new System.Drawing.Point(50, 100);
            paragraphInput.Location = new System.Drawing.Point(50, 100);
            //setting a positions for items on form

            this.Controls.Add(headerInput);
            this.Controls.Add(footerInput);
            this.Controls.Add(titleInput);
            this.Controls.Add(paragraphInput);
            this.Controls.Add(titlesList);

            saveButton = new SaveButton("Header", headerInput, footerInput, titleInput, paragraphInput)
            {
                //Location = new System.Drawing.Point(155, 100),
                Visible = false
            };//defining saveButton
            this.Controls.Add(saveButton); //adding button on form
        }

        public void ShowInputControls(string contentType)
        {
            headerInput.Visible = footerInput.Visible = titleInput.Visible = paragraphInput.Visible = titlesList.Visible = false;

            switch (contentType)
            {
                case "Header":
                    headerInput.Visible = true;
                    saveButton.Location = new Point(155, 100); break;

                case "Footer":
                    footerInput.Visible = true; 
                    saveButton.Location = new Point(155, 100); break;

                case "Title":
                    titleInput.Visible = true;
                    titlesList.Visible = true;
                    saveButton.Location = new Point(315, 100); break;

                case "Paragraph":
                    paragraphInput.Visible = true;
                    saveButton.Location = new Point(155, 100); break;
            }
            saveButton.contentType = contentType;
            saveButton.Visible = true;
        }
    }
}
