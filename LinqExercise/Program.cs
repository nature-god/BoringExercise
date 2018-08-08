using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace LinqExercise
{
    public class BookModel
    {
        public BookModel()
        {

        }
        private string bookType;
        public string BookType
        {
            get {return bookType;}
            set {bookType = value;}
        }

        private string bookISBN;
        public string BookISBN
        {
            get {return bookISBN;}
            set {bookISBN = value;}
        }

        private string bookName;
        public string BookName
        {
            get {return bookName;}
            set {bookName = value;}
        }

        private string bookAuthor;
        public string BookAuthor
        {
            get {return bookAuthor;}
            set {bookAuthor = value;}
        }

        private double price;
        public double Price
        {
            get {return price;}
            set {price = value;}
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            XmlReaderSettings setting = new XmlReaderSettings();
            setting.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(@"a.xml",setting);
            doc.Load(reader);

            XmlNode xn = doc.SelectSingleNode("bookstore");

            XmlNodeList xnl = xn.ChildNodes;

            foreach(XmlNode tmp in xnl)
            {
                BookModel bookModel = new BookModel();

                XmlElement xe = (XmlElement)tmp;

                bookModel.BookISBN = xe.GetAttribute("ISBN").ToString();
                bookModel.BookType = xe.GetAttribute("Type").ToString();
                XmlNodeList xn10 = xe.ChildNodes;
                bookModel.BookName = xn10.Item(0).InnerText;
                bookModel.BookAuthor = xn10.Item(1).InnerText;
                bookModel.Price = Convert.ToDouble(xn10.Item(2).InnerText);
            }
            reader.Close();
        }
    }
}
