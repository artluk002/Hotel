using NUnit.Framework;
using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ProjectTest
{
    public class Tests
    {
        private Hotel.DB db;
        private string mail;
        private DateTime date;

        [SetUp]
        public void Setup()
        {
            db = Hotel.DB.getInstance();// Создание экземпляра класса базы данных
            mail = "example@example.com";
            date = new DateTime(2023, 6, 1);
        }

        [Test]
        public void CheckConnection_ReturnsTrueWhenConnectionIsValid()
        {
            // Act
            bool result = CheckConnection();

            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void IsValid_ReturnsTrueForValidEmail()
        {

            // Act
            bool isValid = IsValid();

            // Assert
            Assert.IsTrue(isValid);
        }
        [Test]
        public void IsEvict_ReturnsTrueWhenDateIsInThePast()
        {
            // Arrange
            bool expectedResult = true;

            // Act
            bool result = IsEvict();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        private bool CheckConnection()
        {
            try
            {
                db.openConnection();
                return true;
            }
            catch (Exception)
            {
                // Замените на соответствующий код для отображения сообщения об ошибке
                return false;
            }
            finally
            {
                db.closeConnection();
            }
        }
        private bool IsValid() // метод проверки корректности ввода почтового адреса
        {
            try
            {
                MailAddress m = new MailAddress(mail);
                Regex r = new Regex("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])");
                if (!(r.IsMatch(mail)))
                    return false;
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private bool IsEvict() // метод проверки даты выезда с текщей датой
        {
            DateTime DOD = new DateTime(date.Ticks);
            DateTime CurrDay = DateTime.Now;
            TimeSpan Difference = DOD.Subtract(CurrDay);
            if (Difference.Days < 0)
            {
                return true;
            }
            return false;
        }
    }
}