using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Ebay;
using System.IO;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Ebay.Models
{
    public class Scraper
    {
        private int _id;
        private string _title;
    

        public Scraper(string title, int id = 0)
        {
            _title = title;
            _id = id;
        }

        public static ChromeDriver driver = new ChromeDriver("/Users/Guest/Desktop/Ebay.Solution");

        public static void myScraper()
        {
            driver.Navigate().GoToUrl("https://www.ebay.com/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=xbox&_sacat=0&LH_TitleDesc=0&_osacat=0&_odkw=xbox+");

            IWebElement title = driver.FindElement(By.XPath("//*[@id='srp-river-results-listing1']/div/div[2]/a/h3"));

            string productTitle = title.Text;

            Scraper newScraper = new Scraper(productTitle);

            newScraper.Save();
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO scrapers (title) VALUES (@title);";
            cmd.Parameters.AddWithValue("@title", this._title);
            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }


    }
}
