using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroceryApp
{
    public class ShoppingCart
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\database.mdf;Integrated Security=True";

        public void UpdateCart(int ID, string email)
        {

            if (ItemExist(ID, email))
            {
                UpdateItem(ID, email);
            }
            else
            {
                InsertItem(ID, email);
            }


        }

        private bool ItemExist(int id, string email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Cart_Item WHERE ProductID = @ID AND CustomerEmail = @Email", con))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Email", email);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private void UpdateItem(int id, string email)
        {
            int currentQuantity = FindCurrentQuantity(id, email);
            int amount = currentQuantity + 1;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Cart_Item SET Quantity = @Amount WHERE ProductID = @ID AND CustomerEmail = @Email", con))
                {
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Email", email);

                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        private int FindCurrentQuantity(int id, string email)
        {
            int currentQuantity = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT Quantity FROM Cart_Item WHERE ProductID = @ID AND CustomerEmail = @Email", con))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Email", email);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        currentQuantity = Convert.ToInt32(result);
                    }
                }
                con.Close();
            }

            return currentQuantity;
        }

        private void InsertItem(int id, string email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Cart_Item (ProductID, CustomerEmail, Quantity) VALUES (@ID, @Email, @Amount)", con))
                {
                    command.Parameters.AddWithValue("@Amount", 1);
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Email", email);

                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }


    }
}