using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using Interface.Models;

using Interface.Forms;
using static Interface.Forms.DataGridController;

namespace Interface
{
    public partial class MainForm : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        public MainForm(DbBarContext context, User CurrentUser, Form RegisterForm)
        {
            try
            {
                InitializeComponent();

                DataGridController.context = context;
                DataGridController.currentUser = (Models.User)CurrentUser;
                DataGridController.listBox1= listBox1;
                DataGridController.dataGridView1= dataGridView1;
                DataGridController.mainForm = this;
                DataGridController.TableNameText = TableNameText;
                DataGridController.RegisterForm = RegisterForm;

                DataGridController DGC = DataGridController.GetInstance();
                DataGridController.dtp= dtp;


                DataGridController.context = context ?? new DbBarContext();
              


               
               

                UserNameText.Text = "User name: " + (currentUser.UserName ?? "Guest");
                PremissionText.Text = "User premission: " + DataGridController.userState;


                if (userState == UserState.waiter || userState == UserState.manager)
                {
                    buttonDelete.Enabled = false;
                    ButtonAdd.Enabled = false;

                    buttonDelete.Hide();
                    ButtonAdd.Hide();

                    dataGridView1.ReadOnly = true;
                }


                Rectangle rectangle;
                dataGridView1.Controls.Add(dtp);
                dtp.Visible = false;
                dtp.Format = DateTimePickerFormat.Custom;
                dtp.TextChanged += new EventHandler(dtpTextChange);
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "Возникла ошибка при инициализации и загрузке интерфейса!!!");
            }
  
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataGridController.RegisterForm.Close();
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
          DataGridController.LoadNext();
           
       
        }
        private void dtpTextChange(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtp.Text.ToString();
        }

        private void ButtonPrev_Click(object sender, EventArgs e)
        {
            DataGridController.LoadPrev();
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DataGridController.AddToTable();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridController.DellFromTable();
        }

        private void REFRESH_Click(object sender, EventArgs e)
        {
          Refresh();
        }

        private void Check_Click(object sender, EventArgs e)
        {
            СheckForm сheckForm = new СheckForm(this);
            сheckForm.Show();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListDoubleClick();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtp.Visible = false;
            if (DataGridController.RowCount > e.RowIndex || e.ColumnIndex < 0)
            {
                return;
            }

            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
               
                case "DateOfBirth":
                  
                    Rectangle _rec = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_rec.Width, _rec.Height);
                    dtp.Location = new Point(_rec.X, _rec.Y);
                    dtp.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Id")
                {
                    throw new Exception("You can`t change id");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Id change error");
             
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportForm report = new ReportForm();
            report.Show();
        }
    }
}
