using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace CreateSeminarApp.Utils
{

    public class SaveButton : Button
    {
        private string contentType;
        private TextBox inputText;
        private ListBox savedItemsList;

        public SaveButton()
        {
            this.Text = "Save";
            this.Width = 100;
            this.BackColor = Color.Green;
        }

        public SaveButton(string contentType, TextBox inputText, ListBox savedItemsList)
        {
            this.contentType = contentType;
            this.inputText = inputText;
            this.savedItemsList = savedItemsList;

            this.Text = "Save "+ contentType;
            this.Width = 100;
            this.BackColor = Color.Green;

            this.Click += SaveButton_Click;

        }

        //public SaveButton(string filePath, TextBox inputText, ContentType type)
        //{
        //    this.filePath = filePath;
        //    this.inputText = inputText;
        //    this.contentType = type;

        //    this.Text = $"Save {type}";
        //    this.Width = 100;
        //    this.BackColor = Color.Green;

        //    this.Click += SaveButton_Click;
        //}

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string content = inputText.Text;

            if (string.IsNullOrEmpty(content))
            {
                MessageBox.Show($"Please enter {contentType} text.");
                return;
            }

            string filePath = @"C:\Users\Mirko\Desktop\seminarski.docx";

            if (!File.Exists(filePath)) {
                using (var document = DocX.Create(filePath)) 
                {
                    SaveDocument(document, content);
                }
            }
        }
        private string GetContent()
        {
            if (savedItemsList != null && savedItemsList.SelectedItem != null)
            {
                return savedItemsList.SelectedItem.ToString();
            }

            return inputText?.Text;
        }

        private void SaveDocument(string content)
        {
            if (!File.Exists(filePath))
            {
                using (var document = DocX.Create(filePath))
                {
                    AddContentToDocument(document, content);
                    document.Save();
                    MessageBox.Show($"{contentType} updated in existing document.");
                }
            }
        }

        private void AddContentToDocument(DocX document,string content)
        {
            switch (contentType)
            {
                case ContentType.Header:
                    document.AddHeaders();
                    document.Headers.First.InsertParagraph(content);
                    break;

                case ContentType.Footer:
                    document.AddFooters();
                    document.Footers.First.InsertParagraph(content);
                    break;

                case ContentType.Title:
                    document.InsertParagraph(content).FontSize(20).Bold().Alignment=Xceed.Document.NET.Alignment.center;
                    break;

                case ContentType.Text:
                    document.InsertParagraph(content);
                    break;
            }
        }
    }
}
