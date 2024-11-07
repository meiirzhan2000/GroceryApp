using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace GroceryApp
{
    public class Checker
    {
        public static string name(string val, string whichOne)
        {
            if (val.Length <= 0)
            {
                return "Enter " + whichOne + " Name";
            }
            else if(val.Length > 99)
            {
                return "Error when compiling your name" + whichOne + " Name, Please provide short version of it";
            }
            else if (val.Any(char.IsDigit))
            {
                return "Do not include any digits";
            }
            return null;
        }

        private static bool emailExistOrNot(string email)
        {
            string conStr = ConfigurationManager.ConnectionStrings["GroData"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            string check = "SELECT COUNT(*) FROM [Customer] WHERE email = @Email";
            using (SqlCommand connectionSearch = new SqlCommand(check, con))
            {
                connectionSearch.Parameters.AddWithValue("@Email", email);
                con.Open();
                int temp = Convert.ToInt32(connectionSearch.ExecuteScalar().ToString());
                con.Close();
                connectionSearch.Dispose();
                if (temp == 1)
                    return true;
                return false;
            }
        }

        public static string phone(string phoneNumber)
        {
            if (!phoneNumber.All(char.IsDigit))
            {
                return "Please do not include characters";
            }
            else if(phoneNumber.Length < 8 || phoneNumber.Length > 10)
            {
                return "Please include the right number";
            }
            return null;
        }

        public static string emailChecker(string email)
        {
            if (email.Trim().Length <= 0)
            {
                return "Provide Your Email Address";
            }
            else if(email.Trim().Length >= 99)
            {
                return "There is a number of characters that a website can compile: 99 characters";
            }
            else if (emailExistOrNot(email))
            {
                return "The Email Address is already registered";
            }
            else if (new EmailAddressAttribute().IsValid(email))
                return null;
            else
                return "The Email Address is not valid";
        }

        public static string passwordChecker(string val)
        {
            int validConditions = 0;
            if (val.Length < 8 || val.Length > 24)
            {
                return "Invalid number of characters, Include at least 8 characters length";
            }
            foreach (char c in val)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in val)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            if (val.Any(char.IsDigit))
            {
                validConditions++;
            }
            char[] special = { '@', '#', '$', '%', '^', '&', '+', '=', '!' };
            if (val.IndexOfAny(special) == -1) return "Include Special Character(s)";
            if (validConditions != 3) return "Include At least one lower case letter, upper case letter, and one number";
            return null;

        }

        public static string checkAddress(string val)
        {
            if(val.Length == 0)
            {
                return "Please provide your address";
            }else if(val.Length < 5)
            {
                return "Please provide a valid address";
            }
            return null;
        }

        public static string checkPostcode(string val)
        {
            if (val.Length == 0)
            {
                return "Please include your postcode number";
            }
            else if(val.Length < 5)
            {
                return "Please provide a full postcode number";
            }
            return null;
        }
    }
}