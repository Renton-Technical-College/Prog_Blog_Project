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
        Brush _headerForeground;
        Brush _bodyForground;

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


 

        private string DateTimeFormatted()
        {
            return _posted.ToShortDateString();
        }

        public Paragraph FullPost()
        {
            string header = _header;
            string spacing = "\n\n";
            string body = _body;

            Paragraph fullPost = new Paragraph();
       
            fullPost.Inlines.Add(HeaderFormatted(_header));
            fullPost.Inlines.Add(new Run(spacing));
            fullPost.Inlines.Add(BodyFormatted(_body));

            return fullPost;
        }

        private Run HeaderFormatted(string headerText)
        {
            Run header = new Run(FormattedString());
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

        public string FormattedString()
        {
            return $"{DateTimeFormatted()} - {_header}";
        }

        public override string ToString()
        {
            return FormattedString();
        }


    }
}
