// <copyright file="FileManagementTest.cs" company="Puget Sound Energy">Copyright © Puget Sound Energy 2018</copyright>
using System;
using FileArchiver.Filemanagement;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileArchiver.Filemanagement.Tests
{
    /// <summary>This class contains parameterized unit tests for FileManagement</summary>
    [PexClass(typeof(FileManagement))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class FileManagementTest
    {
        /// <summary>Test stub for ProcessFiles()</summary>
        [PexMethod]
        internal void ProcessFilesTest([PexAssumeUnderTest]FileManagement target)
        {
            target.ProcessFiles();
            // TODO: add assertions to method FileManagementTest.ProcessFilesTest(FileManagement)
        }
    }
}
