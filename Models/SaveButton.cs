using CreateSeminarApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Xceed.Words.NET;

namespace CreateSeminarApp.Models
{

    public class SaveButton : Button
    {
        private TextBox hederInput;
        private TextBox footerInput;
        private TextBox titleInput;
        private TextBox paragraphInput;
        //private ListBox savedItemsList; this will be in future
        Titles title;
        public string contentType { get; set; } = "Text";
        List<Titles> titles = new List<Titles>();

        public SaveButton(string contentType, TextBox hederInput, TextBox footerInput, TextBox titleInput, TextBox paragraphInput)
        {
            this.contentType = contentType;
            this.hederInput = hederInput;
            this.footerInput = footerInput;
            this.titleInput = titleInput;
            this.paragraphInput = paragraphInput;

            Text = "Save " + contentType;
            Width = 100;
            BackColor = Color.Green;

            Click += SaveButton_Click;

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string content = GetContent();
            string filePath = @"C:\Users\Mirko\Desktop\seminarski.docx";

            if (!File.Exists(filePath))
            {
                using (var document = DocX.Create(filePath))
                {
                    InsertContentToDocument(document, content);
                    document.Save();
                    MessageBox.Show($"Created a new document, and u added {contentType}");
                }
            }
            else
            {
                using (var document = DocX.Load(filePath))
                {
                    InsertContentToDocument(document, content);
                    document.Save();
                    MessageBox.Show($"You added {contentType} to the document");
                }
            }
        }


        private string GetContent()
        {
            return contentType switch
            {
                "Header" => hederInput.Text,
                "Footer" => footerInput.Text,
                "Title" => titleInput.Text,
                "Paragraph" => paragraphInput.Text,
                _ => string.Empty
            };
        }

        private void InsertContentToDocument(DocX document, string content)
        {
            document.DifferentFirstPage = true;
            switch (contentType)
            {
                case "Header":
                    document.AddHeaders();
                    var firstPageHeader = document.Headers.First;
                    firstPageHeader.InsertParagraph(content).Font("Times New Roman").FontSize(12);
                    break;

                case "Footer":
                    document.AddFooters();
                    var firstPageFooter = document.Footers.First;
                    firstPageFooter.InsertParagraph(content).Font("Times New Roman").FontSize(12);
                    break;

                case "Title":
                    document.InsertParagraph(content).Font("Times New Roman").FontSize(18).Bold().Alignment = Xceed.Document.NET.Alignment.center;
                    title=new Titles(content);
                    titles.Add(title);
                    title.SaveData(titles);
                    break;

                case "Paragraph":
                    document.InsertParagraph(content).Font("Times New Roman").FontSize(12);
                    break;
            }
        }
    }
}
