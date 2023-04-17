using Microsoft.Extensions.Primitives;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Interface
{
    public partial class СheckForm : Form
    {

        DbBarContext Context = new DbBarContext();
        private MainForm mainForm;
        private Dictionary<string, int> DictionaryDishes = new Dictionary<string, int>();
        public decimal ResultPrice = 0;
        public СheckForm(MainForm Parant)
        {
            InitializeComponent();
            this.mainForm = Parant;
            mainForm= Parant;
          

            Context.Foods.Load();
            Context.Drinks.Load();

            dataGridView1.DataSource = Context.Foods.Local.ToBindingList();
            dataGridView2.DataSource = Context.Drinks.Local.ToBindingList();
            MainForm.FixTable(ref dataGridView1, 1,3);

            MainForm.FixTable(ref dataGridView2, 1,3,4,5,7,8,9);
            MainForm.FixTable(1,ref dataGridView2);
            DataGridViewButtonColumn buttonColumn1 =
            new DataGridViewButtonColumn();
            buttonColumn1.HeaderText = "Add";
            buttonColumn1.Name = "add1";
            buttonColumn1.Text = "+";
            buttonColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            buttonColumn1.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn buttonColumn2 =
    new DataGridViewButtonColumn();
            buttonColumn2.HeaderText = "Add";
            buttonColumn2.Name = "add2";
            buttonColumn2.Text = "+";
            buttonColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            buttonColumn2.UseColumnTextForButtonValue = true;


            DataGridViewButtonColumn buttonColumn3 =
            new DataGridViewButtonColumn();
            buttonColumn3.HeaderText = "Del";
            buttonColumn3.Name = "del1";
            buttonColumn3.Text = "-";
            buttonColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            buttonColumn3.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn buttonColumn4 =
new DataGridViewButtonColumn();
            buttonColumn4.HeaderText = "Del";
            buttonColumn4.Name = "del2";
            buttonColumn4.Text = "-";
            buttonColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            buttonColumn4.UseColumnTextForButtonValue = true;


            dataGridView1.Columns.Add(buttonColumn1);
            dataGridView2.Columns.Add(buttonColumn2);

            dataGridView1.Columns.Add(buttonColumn3);
            dataGridView2.Columns.Add(buttonColumn4);
            dataGridView1.Refresh();
        }

        private void СheckForm_Load(object sender, EventArgs e)
        {
         


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RefreshList(ref ListBox listBox, Dictionary<string, int> DictionaryDishes)
        {
            listBox.Items.Clear();
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var pair in DictionaryDishes)
            {
                int dotNum = (35 - pair.Key.Length - pair.Value.ToString().Length) / 7;
                stringBuilder.Append(pair.Key);
                for (int i = 0; i < dotNum; i++)
                {
                    stringBuilder.Append("\t");
                }
                stringBuilder.Append(pair.Value);
                listBox.Items.Add(stringBuilder.ToString());
                stringBuilder.Clear(); 
                
            }
            Price.Text = ResultPrice.ToString();
        }

        public void CalculatePrice(Dictionary<string, int> DictionaryDishes)
        {

        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //if (e.RowIndex < 0 || e.ColumnIndex !=
            //    dataGridView1.Columns["+"].Index) return;
            if (e.ColumnIndex == dataGridView1.Columns["add1"].Index)
            {
                ResultPrice += Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["TotalPrice"].Value);
                string value = dataGridView1.Rows[e.RowIndex].Cells["FoodName"].Value.ToString() ?? "error";
                if (DictionaryDishes.ContainsKey(value)) { DictionaryDishes[value]++; }
                else { DictionaryDishes.Add(value, 1); }
                RefreshList(ref listBox1, DictionaryDishes);
                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["del1"].Index)
            {
                
                string value = dataGridView1.Rows[e.RowIndex].Cells["FoodName"].Value.ToString() ?? "error";
                if (DictionaryDishes.ContainsKey(value))
                {
                    ResultPrice -= Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["TotalPrice"].Value);
                    DictionaryDishes[value]--;
                    if (DictionaryDishes[value] == 0)
                    {
                        DictionaryDishes.Remove(value);
                    }
                    RefreshList(ref listBox1, DictionaryDishes);
                }
                else return;
            }
        }
        void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["add2"].Index)
            {
                ResultPrice += Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells["TotalPrice"].Value);
                string value = dataGridView2.Rows[e.RowIndex].Cells["DrinkName"].Value.ToString() ?? "error";
                if (DictionaryDishes.ContainsKey(value)) { DictionaryDishes[value]++; }
                else { DictionaryDishes.Add(value, 1); }
                RefreshList(ref listBox1, DictionaryDishes);
            }
            if (e.ColumnIndex == dataGridView2.Columns["del2"].Index)
            {
                string value = dataGridView2.Rows[e.RowIndex].Cells["DrinkName"].Value.ToString() ?? "error";
                if (DictionaryDishes.ContainsKey(value))
                {
                    ResultPrice -= Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells["TotalPrice"].Value);
                    DictionaryDishes[value]--;
                    if (DictionaryDishes[value] == 0)
                    {
                        DictionaryDishes.Remove(value);
                    }
                    RefreshList(ref listBox1, DictionaryDishes);
                }
                else return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime.Now.ToString();
            Directory.CreateDirectory(Directory.GetCurrentDirectory() +@"\PriceLists");
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @$"\PriceLists\{DateTime.UtcNow.ToString("MM-dd-yyyy")}");
            //string path =
            //using (StreamWriter writer = new StreamWriter(path, false))
            //{
            //    await writer.WriteLineAsync(text);
            //}
        }
    } 
    
}
