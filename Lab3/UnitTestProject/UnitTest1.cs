using System;
using NUnit.Framework;
using Lab3;
using Microsoft.VisualBasic.Logging;


namespace UnitTestProject
{
    public class Tests
    {
        ///<summary>
        ///���������� �������� ��� addNewForm.
        ///� ������� �������� ��� ����������� ����������.
        ///</summary>

        [Test]
        public void T_001_checkName_BaseFlow()
        {
            string name = "NewDirectory";

            // ��������� ��������
            bool expectedReturnValue = true;

            // ���������� ��� ����������� ��������
            bool actualReturnValue = false;

            Assert.DoesNotThrow(() =>
            {
                actualReturnValue = addNewForm.checkName(name);
            });

            // ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedReturnValue, actualReturnValue);

        }

        ///<summary>
        ///��� ���������� ��������� � ��� ������������.
        ///� ������� �������� ��� ������������ ����������.
        ///</summary>

        [Test]
        public void T_002_checkName_AlreadyExists()
        {
            string name = "ExistingDirectory";

            // ��������� ��������
            String expectedExceptionMessage = addNewForm.ExceptionStrings.Matching_names;

            // ���������� ��� ����������� ��������
            Exception? exception = Assert.Throws<Exception>(() =>
            {
                addNewForm.checkName(name);
            });


            // ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedExceptionMessage, exception.Message);

        }

        /// <summary>
        /// ����������������� ������.
        /// ������������ ������ ���� � �������� �������� ���������� ����������������� ������.
        /// </summary>
        [TestCase("directory*name")]
        [TestCase("directory/name")]
        [TestCase(@"directory\name")]
        [TestCase("directory|name")]
        [TestCase("directory>name")]
        [TestCase("directory:name")]
        [TestCase("directory?name")]
        [TestCase(@"directory""name")]
        [TestCase("directory<name")]
        public void T_003_checkName_ReservSymbol(string value)
        {
            string name = value;

            string expectedExceptionMessage = addNewForm.ExceptionStrings.SymbolReserv;

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                addNewForm.checkName(name);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        ///<summary>
        ///������ ����� ������ 20 ��������.
        ///������������ ������ ���� � ������ ����� ������ 20 ��������.
        ///</summary>

        [Test]
        public void T_004_checkName_ReservSymbol()
        {
            string name = "namedirnamedirnamedir";

            // ��������� ��������
            String expectedExceptionMessage = addNewForm.ExceptionStrings.Lenght;

            // ���������� ��� ����������� ��������
            Exception? exception = Assert.Throws<Exception>(() =>
            {
                addNewForm.checkName(name);
            });


            // ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedExceptionMessage, exception.Message);

        }

        [Test]
        public void T_005_checkName_EmptyName()
        {
            string name = "";

            // ��������� ��������
            String expectedExceptionMessage = addNewForm.ExceptionStrings.Null_name;

            // ���������� ��� ����������� ��������
            Exception? exception = Assert.Throws<Exception>(() =>
            {
                addNewForm.checkName(name);
            });


            // ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedExceptionMessage, exception.Message);

        }

        public class MockSaveDir : SaveDirInterface
        {
            public string Name { get; set; }
        }

        public class MockToConnectController_NoConnection : ToConnectControllerInterface
        {
            public SaveDirInterface getNameDir() { throw new NotImplementedException(); }

            public bool tryConnect() { return false; }

            public bool save(string name) { throw new NotImplementedException(); }

        }
        public class MockToConnectController_Connection : ToConnectControllerInterface
        {
            public SaveDirInterface getNameDir() { return new MockSaveDir() { Name = "NewDirectory" }; }

            public bool tryConnect() { return true; }

            public bool save(string name) { return true; }

        }

        /// <summary>
        /// ���������� ������������.
        /// ������� �������� � ��������� ��������.
        /// </summary>
        [Test]
        public void T_006_clickToArchive_BasicFlow()
        {
            string nameDir = "NewDirectory";

            addNewForm addNewForm = new addNewForm();
            addNewForm.controllerInterface = new MockToConnectController_Connection();
            SaveDirInterface name = null;

            Assert.DoesNotThrow(() =>
            {
                name = addNewForm.clickToArchive(nameDir);
            });

            Assert.IsNotNull(name);

            Assert.AreEqual(name.Name, nameDir);
        }

        /// <summary>
        /// ��� ����������� � �������.
        /// ���������� ������������.
        /// </summary>
        [Test]
        public void T_007_clickToArchive_NoConnection()
        {
            string nameDir = "NewDirectory";

            addNewForm addNewForm = new addNewForm();
            addNewForm.controllerInterface = new MockToConnectController_NoConnection();
            String expectedExceptionMessage = addNewForm.ExceptionStrings.NoConnection;

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                addNewForm.clickToArchive(nameDir);
            });


            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

    }
}