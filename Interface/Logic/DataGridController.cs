
using Interface.Models;
using System.Data.Entity;
using System.Globalization;

namespace Interface.Forms
{
    partial class DataGridController
    {
        
        public static MainForm mainForm { get; set; }

        public static Form RegisterForm { get; set; }
        public enum UserState
        {
            waiter = 0,// Подсистема офицанта
            manager = 1, // подсистема менеджера по закупкам 
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
            BankDetails,
            ProviderProduct
        }

        public static ListBox listBox1 { get; set; }

        public static TextBox TableNameText { get; set; }

        private static LinkedList<TableState> EnabledStates = new LinkedList<TableState>();

        private static TableState tableState { get; set; }

        private static LinkedListNode<TableState> _tableState { get; set; }

        public static DataGridController? _instance;

        private static bool FixTableMode { get; set; }
        public static UserState userState { get; private set; }

        public static DbBarContext context { get; set; }

        public static Models.User currentUser { get; set; }
        public static DataGridView dataGridView1 { get; set; }

        public static DateTimePicker dtp { get; set; }
        public static int RowCount { get; private set; }

        private void ApplyUserPremission()
        {
            EnabledStates.Clear();
            listBox1.Items.Clear();
            FixTableMode = true;

            switch (userState)
            {
                case UserState.waiter:
                    EnabledStates.AddLast(TableState.Drink);
                    EnabledStates.AddLast(TableState.Food);
                    EnabledStates.AddLast(TableState.Ingredients);
                    EnabledStates.AddLast(TableState.Product);
                    break;
                case UserState.manager:
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
                    EnabledStates.AddLast(TableState.ProviderProduct);
                    FixTableMode = false;
                   
                    break;
                default:
                    break;
            }
            listBox1.DataSource = EnabledStates.ToList();
        }
        private static void LoadTable()
        {
          
            switch (tableState)
            {
                case TableState.Emploees:
                    TableNameText.Text = "Table: Emploees";
                    context.Employees.Load();
                    dataGridView1.DataSource = context.Employees.Local.ToBindingList();
                    if (FixTableMode)
                    {
                        DataGridFixer.FixTable(dataGridView1, 1);
                        DataGridFixer.FixTable(2, dataGridView1);
                    }

                    dataGridView1.Columns["DateOfBirth"].DefaultCellStyle.Format = "MM/dd/yyyy";
                    
                    dataGridView1.Columns["Salary"].DefaultCellStyle.Format = "c2";
                    dataGridView1.Columns["Salary"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("be-BY");

                    dataGridView1.Refresh();
                    break;
                case TableState.PrevJobs:
                    TableNameText.Text = "Table: PrevJobs";
                    context.Prevjobs.Load();
                    dataGridView1.DataSource = context.Prevjobs.Local.ToBindingList();
                    if (FixTableMode) DataGridFixer.FixTable(dataGridView1, 1, 2); DataGridFixer.FixTable(1, dataGridView1);
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
                    if (FixTableMode)
                    {
                        DataGridFixer.FixTable(dataGridView1, 1);
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
                    if (FixTableMode)
                    {
                        DataGridFixer.FixTable(2, dataGridView1);

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
                    if (FixTableMode)
                    {
                        DataGridFixer.FixTable(dataGridView1, 1);
                        DataGridFixer.FixTable(1, dataGridView1);
                    }
                    dataGridView1.Refresh();
                    break;
                default:
                    break;
            }
            
            if (!FixTableMode)
            {
                foreach (DataGridViewColumn item in dataGridView1.Columns)
                {
                   // item.ReadOnly = false;
                }
             dataGridView1.Columns[0].ReadOnly = true;   
            }

        }
        private static void Delete<T>(Microsoft.EntityFrameworkCore.DbSet<T> dbset) where T : class
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
        private static void Add<T>(Microsoft.EntityFrameworkCore.DbSet<T> dbset) where T : class
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                throw new Exception("Error Please select only one new row");
            }
            if (dataGridView1.SelectedRows.Count < 1)
            {
                throw new Exception("Error Please select row to add");
              
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            var Item = (T)selectedRow.DataBoundItem;

            dbset.Add(Item);

            context.SaveChanges();
        }

        public static DataGridController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataGridController();
            }
            return _instance;
        }
        
        DataGridController()
        {




            userState = (DataGridController.UserState)currentUser.UserPermission;
            

            ApplyUserPremission();

            _tableState = EnabledStates.First;
            tableState = _tableState.Value;

           

            LoadTable();

            RowCount = dataGridView1.RowCount - 1;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

           

        }

        

        public static void LoadNext()
        {
            _tableState = _tableState.Next ?? EnabledStates.First;
            tableState = _tableState.Value;
            LoadTable();
        }

        public static void LoadPrev() 
        {
            _tableState = _tableState.Previous ?? EnabledStates.Last;
            tableState = _tableState.Value;
            LoadTable();
        }

        public static void AddToTable()
        {
            try
            {
                RowCount++;
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
            }
            catch (Exception e)
            {
                RowCount--;
                MessageBox.Show(e.ToString() , "Adding Error" );
                
            }
            LoadTable();
        }
        public static void DellFromTable()
        {
            try
            {
                RowCount--;
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
            }
            catch (Exception e)
            {
                RowCount++;
                MessageBox.Show( e.ToString() , "Delet Error");
            }
            LoadTable();
        }

        public static void RefreshTable()
        {
            LoadTable();
        }

        public  static void ListDoubleClick()
        {
            tableState = (TableState)listBox1.SelectedItem;
            LoadTable();
        }
    }
}
