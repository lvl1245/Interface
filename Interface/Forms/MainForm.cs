using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using Interface.Models;


namespace Interface
{
    public partial class MainForm : Form
    {
        private enum UserState
        {
            waiter = 0,// Подсистема офицанта
            maneger = 1, // подсистема менеджера по закупкам 
            administrator = 2, // подсистема администратора
        }
        private enum TableState
        {
            Emploees,
            PrevJobs, 
            Posts,
            Providers,
            Ingredients,
            Food,
            Drink,
            Product,
            Users,
            BankDetails
        }

        private LinkedList<TableState> EnabledStates = new LinkedList<TableState>();

        private TableState tableState { get; set; }

        private LinkedListNode<TableState> _tableState { get; set; }

        private bool FixTableMod { get; set; }
        private UserState userState { get; set; }

        private DbBarContext context { get; set; } 

        private User currentUser { get; set; }

        private Form RegisterForm { get; set; }

        private void ApplyUserPremission()
        {
            EnabledStates.Clear();
            listBox1.Items.Clear(); 
            switch (userState)
            {
                case UserState.waiter:
                    EnabledStates.AddLast(TableState.Drink);
                    EnabledStates.AddLast(TableState.Food);
                    EnabledStates.AddLast(TableState.Ingredients);
                    EnabledStates.AddLast(TableState.Product);
                    break;
                case UserState.maneger:
                    EnabledStates.AddLast(TableState.Product);
                    EnabledStates.AddLast(TableState.Providers);
                    EnabledStates.AddLast(TableState.BankDetails);
                    break;
                case UserState.administrator:
                    EnabledStates.AddLast(TableState.Emploees);
                    EnabledStates.AddLast(TableState.PrevJobs);
                    EnabledStates.AddLast(TableState.Posts);
                    EnabledStates.AddLast(TableState.Drink);
                    EnabledStates.AddLast(TableState.Food);
                    EnabledStates.AddLast(TableState.Ingredients);
                    EnabledStates.AddLast(TableState.Product);
                    EnabledStates.AddLast(TableState.Providers);
                    EnabledStates.AddLast(TableState.BankDetails);                           
                    break;
                default:
                    break;
            }
            listBox1.DataSource = EnabledStates.ToList();
        }
        //убирает колонки с конца
        public static void FixTable(int lastColumNumber,ref DataGridView viewTofix)
        {
            for (int i = 1; i < lastColumNumber + 1; i++)
            {
                viewTofix.Columns[viewTofix.Columns.Count - i].Visible = false;
            }
        } 
        // убирает выбранные колонки
        public static void FixTable( ref DataGridView viewTofix, params int[] columnNumbers)
        {
            for (int i = 0; i < viewTofix.ColumnCount; i++)
            {
                if (columnNumbers.Contains(i))
                {
                    viewTofix.Columns[i - 1].Visible = false;
                }
            }
        }

        private void LoadTable()
        {
            switch (tableState)
            {
                case TableState.Emploees:
                    TableNameText.Text = "Table: Emploees";
                    context.Employees.Load();
                    dataGridView1.DataSource = context.Employees.Local.ToBindingList();
                    if (FixTableMod)
                    {
                        FixTable(ref dataGridView1, 1);
                        FixTable(2, ref dataGridView1);     
                    }
                    dataGridView1.Refresh();
                    break;
                case TableState.PrevJobs:
                    TableNameText.Text = "Table: PrevJobs";
                    context.Prevjobs.Load();
                    dataGridView1.DataSource = context.Prevjobs.Local.ToBindingList();
                    if (FixTableMod) FixTable(ref dataGridView1, 1, 2);  FixTable(1, ref dataGridView1); 
                    dataGridView1.Refresh();
                    break;
                case TableState.Posts:
                    TableNameText.Text = "Table: Posts";
                    context.Posts.Load();
                    dataGridView1.DataSource = context.Posts.Local.ToBindingList();
                    dataGridView1.Refresh();
                    break;
                case TableState.Providers:
                    TableNameText.Text = "Table: Providers";
                    context.Providers.Load();
                    dataGridView1.DataSource = context.Providers.Local.ToBindingList();
                    if (FixTableMod)
                    {
                        FixTable( ref dataGridView1, 1);
                    }
                    dataGridView1.Refresh();
                    break;
                case TableState.Ingredients:
                    TableNameText.Text = "Table: Ingridients";
                    context.Ingredients.Load();
                    dataGridView1.DataSource = context.Ingredients.Local.ToBindingList();
                    dataGridView1.Refresh();
                    break;
                case TableState.Food:
                    TableNameText.Text = "Table: Food";
                    context.Foods.Load();
                    dataGridView1.DataSource = context.Foods.Local.ToBindingList();
                    dataGridView1.Refresh();
                    break;
                case TableState.Drink:
                    TableNameText.Text = "Table: Drinks";
                    context.Drinks.Load();
                    dataGridView1.DataSource = context.Drinks.Local.ToBindingList();
                    dataGridView1.Refresh();
                    break;
                case TableState.Product:
                    TableNameText.Text = "Table: Products";
                    context.Products.Load();
                    dataGridView1.DataSource = context.Products.Local.ToBindingList();
                    if (FixTableMod)
                    {
                        FixTable(2, ref dataGridView1);
                    }
                    dataGridView1.Refresh();
                    break;
                case TableState.Users:
                    TableNameText.Text = "Table: Users";
                    context.Users.Load();
                    dataGridView1.DataSource = context.Users.Local.ToBindingList();
                    dataGridView1.Refresh();
                    break;
                case TableState.BankDetails:
                    TableNameText.Text = "Table: BankDetaiks";
                    context.BankDetails.Load();
                    dataGridView1.DataSource = context.BankDetails.Local.ToBindingList();
                    if (FixTableMod)
                    {
                        FixTable(ref dataGridView1, 1);
                        FixTable(1, ref dataGridView1);
                    }
                    dataGridView1.Refresh();
                    break;
                default:
                    break;
            }
            
        }
        public MainForm(DbBarContext context, User CurrentUser, Form RegisterForm)
        {
            try
            {
                InitializeComponent();

                this.context = context ?? new DbBarContext();
                this.RegisterForm = RegisterForm;
                currentUser = CurrentUser;
                userState = (UserState)CurrentUser.UserPermission;

                UserNameText.Text = "User name: " + (currentUser.UserName ?? "Guest");
                PremissionText.Text = "User premission: " + userState;

                ApplyUserPremission();
                FixTableMod = true;
                
                _tableState = EnabledStates.First;
                tableState = _tableState.Value;

                LoadTable();

                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                }
                if (userState == UserState.waiter)
                {
                    buttonDelete.Enabled = false;
                    ButtonAdd.Enabled = false;

                    buttonDelete.Hide();
                    ButtonAdd.Hide();

                    dataGridView1.ReadOnly = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла ошибка при инициализации и загрузке интерфейса!!!");
            }
  
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RegisterForm.Close();
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
           _tableState =  _tableState.Next ?? EnabledStates.First;
            tableState = _tableState.Value;
            LoadTable() ;
       
        }
        private void ButtonPrev_Click(object sender, EventArgs e)
        {
            _tableState = _tableState.Previous ?? EnabledStates.Last;
            tableState = _tableState.Value;
            LoadTable() ;
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            switch (tableState)
            {
                case TableState.Emploees:
                    Add<Employee>(context.Employees);
                    break;
                case TableState.PrevJobs:
                    Add<Prevjob>(context.Prevjobs);
                    break;
                case TableState.Posts:
                    Add<Post>(context.Posts);
                    break;
                case TableState.Providers:
                    Add<Provider>(context.Providers);
                    break;
                case TableState.Ingredients:
                    Add<Ingredient>(context.Ingredients);
                    break;
                case TableState.Food:
                    Add<Food>(context.Foods);
                    break;
                case TableState.Drink:
                    Add<Drink>(context.Drinks);
                    break;
                case TableState.Product:
                    Add<Product>(context.Products);
                    break;
                case TableState.Users:
                    Add<User>(context.Users);
                    break;
                case TableState.BankDetails:
                    Add<BankDetail>(context.BankDetails);
                    break;
                default:
                    break;
            }
            LoadTable();
        }
        private void Delete<T>(Microsoft.EntityFrameworkCore.DbSet<T> dbset) where T : class
        {

            List<T> list = new List<T>();

            for (int index = 0; index < dataGridView1.SelectedRows.Count; index++)
            {
                var selectedRow = dataGridView1.SelectedRows[index];
                var Item = (T)selectedRow.DataBoundItem;

                list.Add(Item);
            }
            foreach (var item in list)
            {
                dbset.Remove(item);
            }
            context.SaveChanges();
        }
        private void Add<T>(Microsoft.EntityFrameworkCore.DbSet<T> dbset) where T : class
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Error", "Please select onli one new row");
                return;
            }
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Error", "Select row to add");
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            var Item = (T)selectedRow.DataBoundItem;
            
            dbset.Add(Item);

            context.SaveChanges();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            switch (tableState)
            {
                case TableState.Emploees:
                    Delete<Employee>(context.Employees);
                    break;
                case TableState.PrevJobs:
                    Delete<Prevjob>(context.Prevjobs);
                    break;
                case TableState.Posts:
                    Delete<Post>(context.Posts);
                    break;
                case TableState.Providers:
                    Delete<Provider>(context.Providers);
                    break;
                case TableState.Ingredients:
                    Delete<Ingredient>(context.Ingredients);
                    break;
                case TableState.Food:
                    Delete<Food>(context.Foods);
                    break;
                case TableState.Drink:
                    Delete<Drink>(context.Drinks);
                    break;
                case TableState.Product:
                    Delete<Product>(context.Products);
                    break;
                case TableState.Users:
                    Delete<User>(context.Users);
                    break;
                case TableState.BankDetails:
                    Delete<BankDetail>(context.BankDetails);
                    break;
                default:
                    break;
            }
            LoadTable();
        }

        private void REFRESH_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void Check_Click(object sender, EventArgs e)
        {
            СheckForm сheckForm = new СheckForm(this);
            сheckForm.Show();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tableState = (TableState)listBox1.SelectedItem;
            LoadTable();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F2)
            {
                FixTableMod = !FixTableMod;
                LoadTable();
              
            }
        }
    }
}
