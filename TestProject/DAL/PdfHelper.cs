using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace TestProject.DAL
{
    public class PdfHelper
    {
        static public void CreatePdf(member NewMember) {

            string fileNameExisting = @"C:\Users\USER\Desktop\test\טופס_הצטרפות.pdf";
            string fileNameNew = @"C:\Users\USER\Desktop\test\" + NewMember.Request_ID.ToString() + "\\form.pdf";

            //PdfReader reader = new iTextSharp.text.pdf.PdfReader(fileNameExisting);
            //for (int i = 1; i <= reader.NumberOfPages; i++)
            //{
            //    Rectangle dim = reader.GetPageSize(i);
            //    int[] xy = new int[] { (int)dim.Width, (int)dim.Height };

            //}

            // open the reader
            PdfReader reader = new PdfReader(fileNameExisting);
            Rectangle size = reader.GetPageSizeWithRotation(1);
            Document document = new Document(size);

            // open the writer
            FileStream fs = new FileStream(fileNameNew, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            // the pdf content
            PdfContentByte cb = writer.DirectContent;

            // select the font properties
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.BLACK);
            cb.SetFontAndSize(bf, 10);

            // write the text in the pdf content
            cb.BeginText();
            string name = NewMember.First_Name;
            // put the alignment and coordinates here
            cb.ShowTextAligned(1, name, 500, 535, 0);
            cb.EndText();

            cb.BeginText();
            string lastname = NewMember.Last_Name;
            cb.ShowTextAligned(2, lastname, 430, 535, 0);
            cb.EndText();

            cb.BeginText();
            string Identity_Card = NewMember.Identity_Card;
            cb.ShowTextAligned(3, Identity_Card, 213, 535, 0);
            cb.EndText();

            if (!string.IsNullOrEmpty(NewMember.Address))
            {
                cb.BeginText();
                string Address = NewMember.Address;
                cb.ShowTextAligned(4, Address, 480, 500, 0);
                cb.EndText();
            }

            cb.BeginText();
            string Phone = NewMember.Phone;
            cb.ShowTextAligned(5, Phone, 495, 450, 0);
            cb.EndText();

            if (!string.IsNullOrEmpty(NewMember.Email))
            {
                cb.BeginText();
                string Email = NewMember.Email;
                cb.ShowTextAligned(6, Email, 220, 455, 0);
                cb.EndText();
            }
              

            cb.BeginText();
            string Bank_Account_ = NewMember.Bank_Account_;
            // put the alignment and coordinates here
            cb.ShowTextAligned(7, Bank_Account_, 289, 251,0);
            cb.EndText();

            // create the new page and add it to the pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            cb.AddTemplate(page, 0, 0);

            // close the streams and voilá the file should be changed :)
            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();


            //using (var existingFileStream = new FileStream(fileNameExisting, FileMode.Open))
            //using (var newFileStream = new FileStream(fileNameNew, FileMode.Create))
            //{
            //    // Open existing PDF
            //    var pdfReader = new PdfReader(existingFileStream);

            //    // PdfStamper, which will create
            //    var stamper = new PdfStamper(pdfReader, newFileStream);

            //    var form = stamper.AcroFields;
            //    var fieldKeys = form.Fields.Keys;

            //    foreach (string fieldKey in fieldKeys)
            //    {
            //        form.SetField(fieldKey, "REPLACED!");
            //    }

            //    // "Flatten" the form so it wont be editable/usable anymore
            //    stamper.FormFlattening = true;

            //    // You can also specify fields to be flattened, which
            //    // leaves the rest of the form still be editable/usable
            //    stamper.PartialFormFlattening("field1");

            //    stamper.Close();
            //    pdfReader.Close();
            //}
        }

    }
}