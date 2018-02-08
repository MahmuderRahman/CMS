using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CMS
{
    public partial class Form1 : Form
    {
        Transaction transaction=new Transaction();
        Card card=new Card();
        User user=new User();
        private int transactionId = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void ResetForm()
        {
            amountTextBox.Clear();
            descriptionTextBox.Clear();
            cardComboBox.SelectedIndex = 0;
            userComboBox.SelectedIndex = 0;
            dateTimePicker.Value = DateTime.Now;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            transaction.CardId = (int) cardComboBox.SelectedValue;
            transaction.UserId = (int) userComboBox.SelectedValue;
            transaction.Amount = Convert.ToDecimal(amountTextBox.Text);
            transaction.Description = descriptionTextBox.Text;
            transaction.Date = Convert.ToDateTime(dateTimePicker.Text);
            ResetForm();
            string msg=transaction.SaveTransaction(transaction);
            MessageBox.Show(msg);
            DisplayTransaction();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //card dropdow
           

            //user dropdown
            userComboBox.DataSource = user.GetUserList();
            userComboBox.DisplayMember = "Name";
            userComboBox.ValueMember = "Id";
            
            DisplayTransaction();
        }


        private void DisplayTransaction()
        {
            List<Transaction> transactions = transaction.GetTransactionList();
            dataGridView1.DataSource = transactions;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["CardId"].Visible = false;
            dataGridView1.Columns["UserId"].Visible = false;
        }

         private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            transactionId = (int) dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            userComboBox.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value;
            cardComboBox.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            amountTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            descriptionTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            dateTimePicker.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

         private void deleteButton_Click(object sender, EventArgs e)
         {
             string msg = transaction.DeleteTransaction(transactionId);
             ResetForm();
             DisplayTransaction();
             MessageBox.Show(msg);
         }

         private void updateButton_Click(object sender, EventArgs e)
         {
             transaction.Id = transactionId;
             transaction.CardId = (int)cardComboBox.SelectedValue;
             transaction.UserId = (int)userComboBox.SelectedValue;
             transaction.Amount = Convert.ToDecimal(amountTextBox.Text);
             transaction.Description = descriptionTextBox.Text;
             transaction.Date = Convert.ToDateTime(dateTimePicker.Text);
             ResetForm();
             string msg = transaction.UpdateTransaction(transaction);
             MessageBox.Show(msg);
             DisplayTransaction();
         }

       
    }
}
