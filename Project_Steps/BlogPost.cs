using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Project_Playground.Project_Steps
{
    public class BlogPost
    {
        // Fields

        string _header; // Holds Header value
        string _body; // Holds Body value
        DateTime _posted; // Holds time post was created
        Brush _headerForeground; // Hold header color
        Brush _bodyForground; // hold body color

        // Constructor
        public BlogPost(string header, string body)
        {
            SolidColorBrush defaultColor = new SolidColorBrush(Colors.Black);

            _header = header;
            _body = body;
            _headerForeground = defaultColor;
            _bodyForground = defaultColor;
            _posted = DateTime.Now;
        }

        public BlogPost(string header, string body, Brush headerColor, Brush bodyColor)
        {

            _header = header;
            _body = body;
            _headerForeground = headerColor;
            _bodyForground = bodyColor;
            _posted = DateTime.Now;
        }

        // Properties
        public string Header { get => _header; set => _header = value; }  

        public string Body { get => _body; set => _body = value; }

        public DateTime Posted { get => _posted; }

        // Methods
        public string Post()
        {

            // Date - Header
            // Body

            string date = _posted.ToShortDateString();
            string header = $"{date} - {_header}"; 
            string space = $"\n\n";
            string body = _body;

            string full = header + space + body;

            return full;

        }

        public Paragraph PostFormatted()
        {
            // Date - Header
            // Body

            string date = _posted.ToShortDateString();
            string header = $"{date} - {_header}";
            string space = $"\n\n";
            string body = _body;

            string full = header + space + body;

            // Contains the Date - Header - And new lines
            Run runHeader = new Run(header + space);
            runHeader.FontSize = 22; 
            runHeader.Foreground = _headerForeground; // Header Color

            // Contains our body text
            Run runBody = new Run(body);
            runBody.Foreground = _bodyForground; // Body Color

            // Create a paragraph object that holds our Run's
            Paragraph paragraphFull = new Paragraph();
            paragraphFull.Inlines.Add(runHeader);
            paragraphFull.Inlines.Add(runBody); 

            // Return that paragraph
            return paragraphFull;

        } // PostFormatted



        private string DateTimeFormatted()
        {
            return _posted.ToShortDateString();
        }

        public Paragraph FullPost()
        {
            string header = _header;
            string spacing = "\n\n";
            string body = _body;

            string dateAndHeader = DateAndHeader();

            Paragraph fullPost = new Paragraph();
       
            fullPost.Inlines.Add(HeaderFormatted(dateAndHeader));
            fullPost.Inlines.Add(new Run(spacing));
            fullPost.Inlines.Add(BodyFormatted(_body));

            return fullPost;
        }

        private Run HeaderFormatted(string headerText)
        {
            Run header = new Run(headerText);
            header.FontSize = 22;
            header.FontWeight = FontWeights.Bold;
            header.Foreground = _headerForeground;

            return header;
        } 

        private Run BodyFormatted(string bodyText)
        {
            Run body = new Run(bodyText);
            body.Foreground = _bodyForground;

            return body;
        }

        public string DateAndHeader()
        {
            return $"{DateTimeFormatted()} - {_header}";
        }

        public override string ToString()
        {
            return DateAndHeader();
        }


    }
}
