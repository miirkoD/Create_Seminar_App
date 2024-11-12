using CreateSeminarApp.Utils;
using System;
using System.Windows.Forms;


namespace CreateSeminarApp
{
    public partial class Form1 : Form
    {
        private Menu menu;
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

            menu = new Menu(this);
            this.MainMenuStrip = menu;
            this.Controls.Add(menu);
        }
    }
}
