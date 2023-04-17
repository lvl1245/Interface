namespace Interface
{
    partial class RegisterForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Login = new System.Windows.Forms.TextBox();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.NewAccBox = new System.Windows.Forms.CheckBox();
            this.EnterButton = new System.Windows.Forms.Button();
            this.ShowPasswordBox = new System.Windows.Forms.CheckBox();
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.Enter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.MintCream;
            this.Login.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Login.Enabled = false;
            this.Login.Location = new System.Drawing.Point(12, 16);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(125, 20);
            this.Login.TabIndex = 0;
            this.Login.Text = "Логин";
            // 
            // LoginBox
            // 
            this.LoginBox.Location = new System.Drawing.Point(12, 57);
            this.LoginBox.MaxLength = 20;
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(337, 27);
            this.LoginBox.TabIndex = 1;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(12, 147);
            this.PasswordBox.MaxLength = 20;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(337, 27);
            this.PasswordBox.TabIndex = 3;
            this.PasswordBox.UseSystemPasswordChar = true;
            // 
            // Password
            // 
            this.Password.BackColor = System.Drawing.Color.MintCream;
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password.Enabled = false;
            this.Password.Location = new System.Drawing.Point(12, 107);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(125, 20);
            this.Password.TabIndex = 2;
            this.Password.Text = "Пароль";
            // 
            // NewAccBox
            // 
            this.NewAccBox.AutoSize = true;
            this.NewAccBox.Location = new System.Drawing.Point(7, 284);
            this.NewAccBox.Name = "NewAccBox";
            this.NewAccBox.Size = new System.Drawing.Size(139, 24);
            this.NewAccBox.TabIndex = 4;
            this.NewAccBox.Text = "Новый аккаунт ";
            this.NewAccBox.UseVisualStyleBackColor = true;
            this.NewAccBox.CheckedChanged += new System.EventHandler(this.NewAccBox_CheckedChanged);
            // 
            // EnterButton
            // 
            this.EnterButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.EnterButton.Location = new System.Drawing.Point(7, 314);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(144, 36);
            this.EnterButton.TabIndex = 5;
            this.EnterButton.Text = "Вход";
            this.EnterButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EnterButton.UseVisualStyleBackColor = false;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_click);
            // 
            // ShowPasswordBox
            // 
            this.ShowPasswordBox.AutoSize = true;
            this.ShowPasswordBox.Location = new System.Drawing.Point(81, 107);
            this.ShowPasswordBox.Name = "ShowPasswordBox";
            this.ShowPasswordBox.Size = new System.Drawing.Size(154, 24);
            this.ShowPasswordBox.TabIndex = 6;
            this.ShowPasswordBox.Text = "Показать пароль ";
            this.ShowPasswordBox.UseVisualStyleBackColor = true;
            this.ShowPasswordBox.CheckedChanged += new System.EventHandler(this.ShowPasswordBox_CheckedChanged);
            // 
            // UserNameBox
            // 
            this.UserNameBox.Enabled = false;
            this.UserNameBox.Location = new System.Drawing.Point(12, 227);
            this.UserNameBox.MaxLength = 20;
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(337, 27);
            this.UserNameBox.TabIndex = 7;
            this.UserNameBox.Visible = false;
            // 
            // UserName
            // 
            this.UserName.BackColor = System.Drawing.Color.MintCream;
            this.UserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserName.Enabled = false;
            this.UserName.Location = new System.Drawing.Point(12, 192);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(140, 20);
            this.UserName.TabIndex = 8;
            this.UserName.Text = "Имя пользователя";
            this.UserName.Visible = false;
            // 
            // Enter
            // 
            this.Enter.AutoSize = true;
            this.Enter.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Enter.Location = new System.Drawing.Point(366, 0);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(109, 54);
            this.Enter.TabIndex = 9;
            this.Enter.Text = "Вход";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(478, 376);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.UserNameBox);
            this.Controls.Add(this.ShowPasswordBox);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.NewAccBox);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.Login);
            this.Name = "RegisterForm";
            this.Text = "Мего интерфейс";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox Login;
        private TextBox LoginBox;
        private TextBox PasswordBox;
        private TextBox Password;
        private CheckBox NewAccBox;
        private Button EnterButton;
        private CheckBox ShowPasswordBox;
        private TextBox UserNameBox;
        private TextBox UserName;
        private Label Enter;
    }
}