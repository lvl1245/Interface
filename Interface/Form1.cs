using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace Interface
{
    public partial class RegisterForm : Form
    {
        DbBarContext context;
        MD5 md5;

        public RegisterForm()
        {
            md5 = MD5.Create();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            context = new DbBarContext();
        }

        private void EnterButton_click(object sender, EventArgs e)
        {
            if (!CheckBoxes())// проверяем заполнены ли поля логина и пароля
            {
                return;
            }
            if (NewAccBox.Checked)
            {
                if (!CreateNewAcc(LoginBox.Text, PasswordBox.Text))
                {
                    return;
                } 
            }
            User user = new User();
            if  (CompareUser(LoginBox.Text, PasswordBox.Text,out user))
            {
                MainForm mainForm = new MainForm(context, user , this);
              
                mainForm.Show();
                this.Hide();

            }

        }

        private bool CheckBoxes()
        {

            if (string.IsNullOrEmpty(LoginBox.Text) || string.IsNullOrEmpty(LoginBox.Text))
            {
                return false;
            }
            return true;
        }

        private bool CompareUser(string login , string password, out User user)
        {
            var loghash = md5.ComputeHash(Encoding.UTF8.GetBytes(login));
            var passwordhash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            try
            {
                User UserToCheck = context.Users.FirstOrDefault(x => x.UserLogin == loghash);

                if (Encoding.UTF8.GetString(passwordhash).Equals(Encoding.UTF8.GetString(UserToCheck.UserPassword)))
                {

                    user = UserToCheck;
                    return true;

                }
                else
                {
                    MessageBox.Show("Вы ne вошли", "Провал");
                    user = null;
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Вы ne вошли", "Провал");
                user = null;
                return false;

            }
        }

        private bool CreateNewAcc(string login, string password)
        {
            User tmpUser = new User();
            tmpUser.UserLogin = md5.ComputeHash(Encoding.UTF8.GetBytes(login));
            tmpUser.UserPassword = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            User UserToCheck = context.Users.FirstOrDefault(x => x.UserLogin == tmpUser.UserLogin);
            User UserToCheck2 = context.Users.FirstOrDefault(x => x.UserPassword == tmpUser.UserPassword);


            if ((UserToCheck != null && UserToCheck2 != null) && UserToCheck == UserToCheck2)
            {
                MessageBox.Show("Такой аккаунт уже существует ", "Ошибка!");
                return false;
            }

            tmpUser.UserPermission = 1;
            context.Users.Add(tmpUser);
            context.SaveChanges();
            return true;
        }

        private void ShowPasswordBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPasswordBox.Checked)
            {
                PasswordBox.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordBox.UseSystemPasswordChar = true;
            }
        }

        private void NewAccBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NewAccBox.Checked)
            {
                UserName.Show();
                UserNameBox.Show();
                UserNameBox.Enabled = true;
            }
            else
            {
                UserName.Hide();
                UserNameBox.Hide();
                UserNameBox.Text = "";
                UserNameBox.Enabled = false;    
            }
        }
    }
}