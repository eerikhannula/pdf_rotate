using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pdf_rotate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string filePath;
        string fileContent;
        string destinationPath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = "c:\\";
                dialog.Filter = "pdf files (*.pdf)|*.txt|All files (*.*)|*.*";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = dialog.FileName;

                    fileNameLabel.Content = filePath;
                    destinationPath = System.IO.Path.GetDirectoryName(filePath);
                    destinationPath += "\\rotated.pdf";
                }
            }
        }

        private void rotateCW_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(filePath))
            {
                PdfReader reader = new PdfReader(filePath);
                int pagesCount = reader.NumberOfPages;
                PdfDictionary page = reader.GetPageN(1);
                PdfNumber rotate = page.GetAsNumber(PdfName.ROTATE);
                page.Put(PdfName.ROTATE, new PdfNumber(90));
                FileStream fs = new FileStream(destinationPath, FileMode.Create,
                FileAccess.Write, FileShare.None);
                PdfStamper stamper = new PdfStamper(reader, fs);
                stamper.Close();
                reader.Close();
            }
        }

        private void rotateCCW_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(filePath))
            {
                PdfReader reader = new PdfReader(filePath);
                int pagesCount = reader.NumberOfPages;
                PdfDictionary page = reader.GetPageN(1);
                PdfNumber rotate = page.GetAsNumber(PdfName.ROTATE);
                page.Put(PdfName.ROTATE, new PdfNumber(-90));
                FileStream fs = new FileStream(destinationPath, FileMode.Create,
                FileAccess.Write, FileShare.None);
                PdfStamper stamper = new PdfStamper(reader, fs);
                stamper.Close();
                reader.Close();
            }
        }

        private void flip_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(filePath))
            {
                PdfReader reader = new PdfReader(filePath);
                int pagesCount = reader.NumberOfPages;
                PdfDictionary page = reader.GetPageN(1);
                PdfNumber rotate = page.GetAsNumber(PdfName.ROTATE);
                page.Put(PdfName.ROTATE, new PdfNumber(180));
                FileStream fs = new FileStream(destinationPath, FileMode.Create,
                FileAccess.Write, FileShare.None);
                PdfStamper stamper = new PdfStamper(reader, fs);
                stamper.Close();
                reader.Close();
            }
        }
    }
}
