using Droid_financial;
using NUnit.Framework;
using System.Drawing;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void TestUTRuns()
        {
            Assert.IsTrue(true);
        }
        [Test]
        public void Test_interface_financial()
        {
            try
            {
                Interface_fnc intfnc = new Interface_fnc(new System.Collections.Generic.List<string>());
                Assert.IsTrue(true);
            }
            catch (System.Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        [Test]
        public void Test_change()
        {
            try
            {
                Change c = new Change();
                c.ConvertToCur1(123);
                c.ConvertToCur2(456);
                var v = c.ToXml();
                Assert.IsTrue(true);
            }
            catch (System.Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        [Test]
        public void Test_icalendar()
        {
            try
            {
                ICalendar ic = new ICalendar();
                ic.BeginDate = System.DateTime.Now;
                ic.EndDate = System.DateTime.Now.AddDays(1);
                ic.Text = "je suis une mouette";
                Assert.IsTrue(true);
            }
            catch (System.Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        [Test]
        public void Test_movement()
        {
            try
            {
                Movement m = new Movement();
                m.Convert(new Change("EUR", "USD", 2), "USD");
                m.StartDate = System.DateTime.Now;
                m.EndDate = System.DateTime.Now.AddDays(1);
                m.SubMovement = true;
                m.Name = "je suis une mouette";
                m.Gop = Movement.GOP.COMODITIES;
                m.IsPartial = false;
                var v = m.Clone();
                Assert.IsTrue(true);
            }
            catch (System.Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        [Test]
        public void Test_refund()
        {
            try
            {
                Refund r = new Refund();
                r.Amount = 123;
                r.Currency = "EUR";
                r.CurrentStatus = Refund.Status.REFUNDED;
                var v1 = r.ToXml();
                Assert.IsTrue(true);
            }
            catch (System.Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        [Test]
        public void Test_user1()
        {
            try
            {
                User u = new User();
                u.AvatarIndex = 1;
                u.Calendars = new System.Collections.Generic.List<ICalendar>();
                u.Color = Color.Orange;
                u.Currency = "EUR";
                u.Firstname = "Tobi";
                u.Name = "ASSISTANT";
                u.Solde = 100;
                var v1 = u.SoldeSimulation;
                var v2 = u.SumExpances;
                var v3 = u.ToXml();
                Assert.IsTrue(true);
            }
            catch (System.Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        [Test]
        public void Test_user2()
        {
            try
            {
                User u = new User("Tobi", "ASSISTANT", Color.Orange, 3, new System.Collections.Generic.List<ICalendar>());
                Assert.IsTrue(true);
            }
            catch (System.Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        [Test]
        public void Test_project()
        {
            try
            {
                ProjectFinancial pf = new ProjectFinancial();
                pf.Balance();
                pf.ExportCSV();
                pf.ExportPDF(""); // TODO : see why this one have parameter
                pf.ExportTXT();
                pf.ExportWEB();
                pf.ExportXML();
                Assert.IsTrue(true);
            }
            catch (System.Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
    }
}
