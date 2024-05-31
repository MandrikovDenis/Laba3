using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using Lab3;

namespace UnitTestProject
{
    internal class UiTest
    {
        string PathTestingApp = @"E:\Учеба\ТП\Лабораторная 3\Laba3\Lab3\Lab3\bin\Debug\net6.0-windows\lab3.exe";

        int M = 5000;

        const string addDirectoryTitleString = "Создать директорию";
        const string addButtonString = "Создать";
        const string nameLabelString = "Имя директории";
        const string errorLabelString = "Неверное имя директории.";

        //automatisation-id 
        const string idAddButton = "AddButton";
        const string idNameLabel = "NameLabel";
        const string idErrorLabel = "ErrorLabel";
        const string idNameTextBox = "NameTextBox";

        public T WaitForElement<T>(Func<T> getter)
        {
            var retry = Retry.WhileNull<T>(
            getter,
            TimeSpan.FromMilliseconds(M));
            if (!retry.Success)
            {
                Assert.Fail($"Невозможно найти элемент {M} ms");
            }
            return retry.Result;
        }

        [Test]
        public void T_001_addNewForm()
        {
            //Step1
            FlaUI.Core.Application app = FlaUI.Core.Application.Launch(PathTestingApp, "2");
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);

                string title = window.Title;
                Assert.AreEqual(addDirectoryTitleString, title);

                var addButton = WaitForElement(() => window.FindFirstDescendant(cf => cf.ByAutomationId(idAddButton)).AsButton());

                var nameTextBox = WaitForElement(() => window.FindFirstDescendant(cf => cf.ByAutomationId(idNameTextBox)).AsTextBox());

                var nameLabel = WaitForElement(() => window.FindFirstDescendant(cf => cf.ByAutomationId(idNameLabel)).AsLabel());
                var errorLabel = WaitForElement(() => window.FindFirstDescendant(cf => cf.ByAutomationId(idErrorLabel)).AsLabel());

                Assert.AreEqual(addButtonString, addButton.AsLabel().Text);

                Assert.AreEqual(nameLabelString, nameLabel.Text);
                Assert.AreEqual(errorLabelString, errorLabel.Text);

                Assert.AreEqual("", nameTextBox.Text);

                //Step2
                addButton.Click();
                System.Threading.Thread.Sleep(1000);
                window.CaptureToFile("EmptyEnter.png");

                var retry = Retry.WhileException(() =>
                {
                    Assert.AreEqual(addNewForm.ExceptionStrings.Null_name, errorLabel.Text);
                }, TimeSpan.FromMilliseconds(M));

                if (!retry.Success)
                {
                    Assert.AreEqual(addNewForm.ExceptionStrings.Null_name, errorLabel.Text);
                }

                //Step3
                nameTextBox.Enter(@"directory*name");

                addButton.Click();
                System.Threading.Thread.Sleep(1000);
                window.CaptureToFile("SymbolReserv.png");

                retry = Retry.WhileException(() =>
                {
                    Assert.AreEqual(addNewForm.ExceptionStrings.SymbolReserv, errorLabel.Text);
                }, TimeSpan.FromMilliseconds(M));

                if (!retry.Success)
                {
                    Assert.AreEqual(addNewForm.ExceptionStrings.SymbolReserv, errorLabel.Text);
                }

                //Step4
                nameTextBox.Enter(@"namedirnamedirnamedir");

                addButton.Click();
                System.Threading.Thread.Sleep(1000);
                window.CaptureToFile("Lenght.png");

                retry = Retry.WhileException(() =>
                {
                    Assert.AreEqual(addNewForm.ExceptionStrings.Lenght, errorLabel.Text);
                }, TimeSpan.FromMilliseconds(1000));

                if (!retry.Success)
                {
                    Assert.AreEqual(addNewForm.ExceptionStrings.Lenght, errorLabel.Text);
                }

                //Step5
                nameTextBox.Enter(@"ExistingDirectory");

                addButton.Click();
                System.Threading.Thread.Sleep(1000);
                window.CaptureToFile("Matching.png");

                retry = Retry.WhileException(() =>
                {
                    Assert.AreEqual(addNewForm.ExceptionStrings.Matching_names, errorLabel.Text);
                }, TimeSpan.FromMilliseconds(1000));

                if (!retry.Success)
                {
                    Assert.AreEqual(addNewForm.ExceptionStrings.Matching_names, errorLabel.Text);
                }

                //Step6
                nameTextBox.Enter("NewDirectory");

                addButton.Click();
                System.Threading.Thread.Sleep(1000);
                window.CaptureToFile("cool.png");

                retry = Retry.WhileException(() =>
                {
                    var msg = window.ModalWindows.FirstOrDefault().AsWindow();

                    Assert.NotNull(msg);

                    var message = msg.FindFirstChild(cf => cf.ByText("Создана директория " + "NewDirectory")).AsLabel();

                    Assert.NotNull(message);

                    var yesButton = msg.FindFirstChild(cf => cf.ByName("ОК")).AsButton();

                    Assert.NotNull(yesButton);

                    msg.CaptureToFile("okdialog.png");

                    yesButton.Click();
                }, TimeSpan.FromMilliseconds(5000));

                if (!retry.Success)
                {
                    Assert.Fail("Нет диалогового окна!");
                }

                app.Close();

            }


        }
        [Test]
        public void T_002_addNewForm()
        {
            //Step #1
            FlaUI.Core.Application app = FlaUI.Core.Application.Launch(PathTestingApp, "1");
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                string title = window.Title;

                Assert.AreEqual(addDirectoryTitleString, title);

                var addButton = WaitForElement(() => window.FindFirstDescendant(cf => cf.ByAutomationId(idAddButton)).AsButton());

                var nameTextBox = WaitForElement(() => window.FindFirstDescendant(cf => cf.ByAutomationId(idNameTextBox)).AsTextBox());

                var nameLabel = WaitForElement(() => window.FindFirstDescendant(cf => cf.ByAutomationId(idNameLabel)).AsLabel());
                var errorLabel = WaitForElement(() => window.FindFirstDescendant(cf => cf.ByAutomationId(idErrorLabel)).AsLabel());

                Assert.AreEqual(addButtonString, addButton.AsLabel().Text);

                Assert.AreEqual(nameLabelString, nameLabel.Text);
                Assert.AreEqual(errorLabelString, errorLabel.Text);

                Assert.AreEqual("", nameTextBox.Text);

                //Step #2
                nameTextBox.Enter("NewDirectory");

                addButton.Click();
                System.Threading.Thread.Sleep(1000);
                window.CaptureToFile("NoConnection.png");

                var retry = Retry.WhileException(() =>
                {
                    Assert.AreEqual(addNewForm.ExceptionStrings.NoConnection, errorLabel.Text);
                }, TimeSpan.FromMilliseconds(M));

                if (!retry.Success)
                {
                    Assert.AreEqual(addNewForm.ExceptionStrings.NoConnection, errorLabel.Text);
                }

                app.Close();
            }
        }
    }
}
