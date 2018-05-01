using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using TestProject.DAL;

namespace TestProject.Controllers.api
{
    public class FormApiController : ApiController
    {
        DataClasses1DataContext DB = new DataClasses1DataContext(Helper.GetConnection());

        [HttpPost]
        public IHttpActionResult CreateMember(member newmember)
        {
            if (ValidValues(newmember.First_Name) && ValidValues(newmember.Last_Name)
                && ValidValues(newmember.Identity_Card) && ValidValues(newmember.Join_Track)
                && ValidValues(newmember.Monthly_Deposit) && ValidValues(newmember.Agent)
                && ValidValues(newmember.Bank_Account_) && ValidValues(newmember.Phone))
            {
                DB.members.InsertOnSubmit(newmember);
                DB.SubmitChanges();

                CreateFolder(newmember);
                PdfHelper.CreatePdf(newmember);

                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public IEnumerable<member> Get()
        {
            IEnumerable<member> list = DB.members;
            return list;
        }
        static public void CreateFolder(member N)
        {
            string folderName = @"C:\Users\USER\Desktop\test";
            string pathString = System.IO.Path.Combine(folderName, N.Request_ID.ToString());
            System.IO.Directory.CreateDirectory(pathString);

            // Create xml file

            XDocument doc = new XDocument(
            new XElement("member",
            new XElement("First_Name", N.First_Name),
            new XElement("Last_Name", N.Last_Name),
            new XElement("Identity_Card", N.Identity_Card),
            new XElement("Join_Track", N.Join_Track),
            new XElement("Monthly_Deposit", N.Monthly_Deposit),
            new XElement("Agent", N.Agent),
            new XElement("Address", N.Address),
            new XElement("Phone", N.Phone),
            new XElement("Email", N.Email),
            new XElement("Bank_Account", N.Bank_Account_)
            ));
            doc.Save("C:\\Users\\USER\\Desktop\\test\\" + N.Request_ID.ToString() + "\\XmlFile.xml");
        }

        static public bool ValidValues(string value)
        {
            return !string.IsNullOrEmpty(value);
        }
        static public bool ValidValues(int value)
        {
            return !string.IsNullOrEmpty(value.ToString());
        }
    }
}
