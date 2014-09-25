using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace POS.Retail.Common
{
    class RegexClass
    {
        public void checkForNumeric(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void checkForNumericWithSpecialCharacters(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9-/.,!*()]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void checkForNumericWithoutDash(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9-+.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void checkForNumericWithDash(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void checkForNumericWithDot(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public void checkForNumericWithDotDash(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void checkForNumericWithComma(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void checkForAlphabet(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void checkForAlphabetAndSlash(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z/]");
            e.Handled = regex.IsMatch(e.Text);
        }

        public string getMonth(string date)
        {
            string month = null;
            string x = date.Substring(5,2);
            if (x == "01")
            {
                month = "Janurary";
            }
            else if (x == "02")
            {
                month = "Feburary";
            }
            else if (x == "03")
            {
                month = "March";
            }
            else if (x == "04")
            {
                month = "April";
            }
            else if (x == "05")
            {
                month = "May";
            }
            else if (x == "06")
            {
                month = "June";
            }
            else if (x == "07")
            {
                month = "July";
            }
            else if (x == "08")
            {
                month = "August";
            }
            else if (x == "09")
            {
                month = "September";
            }
            else if (x == "10")
            {
                month = "October";
            }
            else if (x == "11")
            {
                month = "November";
            }
            else if (x == "12")
            {
                month = "December";
            }

            return month;
        }

        public string getYear(string date)
        {
            string x = date.Substring(6,4);
            return x;
        }

        public int GetYear()
        {
            int date = DateTime.Today.Year;
            return date;
        }

        public string getFirstDate(string month)
        {
            string first = null;

            if (month == "January")
            {
                first = "01/01";
            }
            else if (month == "February")
            {
                first = "02/01";
            }
            if (month == "March")
            {
                first = "03/01";
            }
            else if (month == "April")
            {
                first = "04/01";
            }
            else if (month == "May")
            {
                first = "05/01";
            }
            else if (month == "June")
            {
                first = "06/01";
            }
            else if (month == "July")
            {
                first = "07/01";
            }
            else if (month == "August")
            {
                first = "08/01";
            }
            else if (month == "September")
            {
                first = "09/01";
            }
            else if (month == "October")
            {
                first = "10/01";
            }
            else if (month == "November")
            {
                first = "11/01";
            }
            else if (month == "December")
            {
                first = "12/01";
            }
            return first;
        }

        public string getlastDate(string month, int year)
        {
            string first = null;

            if (month == "January")
            {
                first = "01/31";
            }
            else if (month == "February")
            {
                if ((year % 4) == 0)
                {
                    first = "02/29";
                }
                else
                {
                    first = "02/28";
                }
            }
            else if (month == "March")
            {
                first = "03/31";
            }
            else if (month == "April")
            {
                first = "04/30";
            }
            else if (month == "May")
            {
                first = "05/31";
            }
            else if (month == "June")
            {
                first = "06/30";
            }
            else if (month == "July")
            {
                first = "07/31";
            }
            else if (month == "August")
            {
                first = "08/31";
            }
            else if (month == "September")
            {
                first = "09/30";
            }
            else if (month == "October")
            {
                first = "10/31";
            }
            else if (month == "November")
            {
                first = "11/30";
            }
            else if (month == "December")
            {
                first = "12/31";
            }
            return first;
        }


    }
    }

