using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocControl.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace DocControl.Domain.Tests
{
    public class DocumentUnitTest1
    {
        [Fact(DisplayName = "Create Document With Valid State")]
        public void CreateDocument_WithValidParameters_ResultObjectValidState()
        {
            //princípio AAA
            Action action = () => new Document(1, "title", "process", "category", "file.pdf");
            action.Should()
                .NotThrow<DocControl.Domain.Validation.DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Create Document With Negative Id")]
        public void CreateDocument_WithNegativeId_DomainExceptionNegativeId()
        {
            //princípio AAA
            Action action = () => new Document(-1, 1, "title", "process", "category", "file");
            action.Should()
                .Throw<DocControl.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id, it has to be bigger than 0");

        }

        [Fact(DisplayName = "Create Document With Title Empty")]
        public void CreateDocument_WithTitleEmpty_DomainExceptionTitleEmpty()
        {
            //princípio AAA
            Action action = () => new Document(1, 1, "", "process", "category", "file");
            action.Should()
                .Throw<DocControl.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid title. Title is required");

        }

        [Fact(DisplayName = "Create Document With Title Null")]
        public void CreateDocument_WithTitleNull_DomainExceptionTitleIsNull()
        {
            //princípio AAA
            Action action = () => new Document(1, 1, null, "process", "category", "file");
            action.Should()
                .Throw<DocControl.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid title. Title is required");

        }
       

        [Fact(DisplayName = "Create Document With Process Empty")]
        public void CreateDocument_WithProcessEmpty_DomainExceptionProcessEmpty()
        {
            //princípio AAA
            Action action = () => new Document(1, 1, "title", "", "category", "file");
            action.Should()
                .Throw<DocControl.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid process. Process is required");

        }

        [Fact(DisplayName = "Create Document With Process Null")]
        public void CreateDocument_WithProcessNull_DomainExceptionProcessIsNull()
        {
            //princípio AAA
            Action action = () => new Document(1, 1, "title", null, "category", "file");
            action.Should()
                .Throw<DocControl.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid process. Process is required");

        }

        //until here ok

        [Fact(DisplayName = "Create Document With Category Empty")]
        public void CreateDocument_WithCategoryEmpty_DomainExceptionCategoryEmpty()
        {
            //princípio AAA
            Action action = () => new Document(1, 1, "title", "process", "", "file");
            action.Should()
                .Throw<DocControl.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid category. category is required");

        }

        [Fact(DisplayName = "Create Document With Category Null")]
        public void CreateDocument_WithCategoryNull_DomainExceptionCategoryIsNull()
        {
            //princípio AAA
            Action action = () => new Document(1, 1, "title", "process", null, "file");
            action.Should()
                .Throw<DocControl.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid category. Category is required");

        }

        [Fact(DisplayName = "Create Document With Wrong File Extension")]
        public void CreateDocument_WithWrongFileExtension_DomainExceptionFileExtensionWrong()
        {
            //princípio AAA
            Action action = () => new Document(1, 1, "title", "process", "category", "planilha.ExtensaoInvalida");
            action.Should()
                .Throw<DocControl.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid file. Extension has to be .pdf, .doc, .xls, .docx or .xlsx");

        }

    }
}
