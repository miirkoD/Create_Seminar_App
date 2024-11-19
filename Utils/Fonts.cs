using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSeminarApp.Utils
{
    internal class Fonts
    {
        private string fontName {  get; set; }
        private int fontSize { get; set; }
        private string fontStyle { get; set; }

        public Fonts(string fontName,int fontSize,string fontStyle) 
        {
            this.fontName = fontName;
            this.fontSize = fontSize;
            this.fontStyle = fontStyle;
        }
    }
}
