using DocControl.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocControl.Domain.Entities
{
    public sealed class Document : Entity
    {
        public int Code { get; private set; }
        public string Title { get; private set; }
        public string Process { get; private set; }
        public string Category { get; private set; }
        public string File { get; private set; }


        //This constructor is used just for populating Database with code, without WebApp, tests purpose
        public Document(int id, int code, string title, string process, string category, string file)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id, it has to be bigger than 0");
            Id = id;
            ValidateDomain(code, title, process, category, file);
        }

        public Document(int code, string title, string process, string category, string file)
        {
            ValidateDomain(code, title, process, category, file);
        }

        public void Update(int code, string title, string process, string category, string file)
        {
            ValidateDomain(code, title, process, category, file);
        }


        private void ValidateDomain(int code, string title, string process, string category, string file)
        {
            DomainExceptionValidation.When(code == 0, "Invalid code. Code is required");

            DomainExceptionValidation.When(string.IsNullOrEmpty(title), "Invalid title. Title is required");

            DomainExceptionValidation.When(string.IsNullOrEmpty(process), "Invalid process. Process is required");

            DomainExceptionValidation.When(string.IsNullOrEmpty(category), "Invalid category. Category is required");

            DomainExceptionValidation.When(!file.EndsWith(".pdf")&&
                !file.EndsWith(".doc")&&!file.EndsWith(".xls")&&
                !file.EndsWith(".docx")&&!file.EndsWith(".xlsx")
                , "Invalid file. Extension has to be .pdf, .doc, .xls, .docx or .xlsx"); // used ? because, doing this if file is null, Exception will not thrown

            Code = code;
            Title = title;
            Process = process;
            Category = category;
            File = file;
        }

    }


}
