using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailVerification
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EmailTectBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) VerifyButton_Click(this, null);
        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            String email = EmailTectBox.Text;
            Color red = System.Drawing.Color.Red;
            Color green = System.Drawing.Color.Green;

            Regex rgx = new Regex(@"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z]+$");

            if (String.IsNullOrEmpty(email))
            {
                ResultLabel.Text = "請確實輸入Email! ";
                ResultLabel.ForeColor = red;
            }
            else
            {
                /*
                int atIndex = email.IndexOf("@");
                int dotIndex = email.IndexOf(".");
                if (atIndex != -1 && dotIndex != -1)
                {
                    if (atIndex > 0 && dotIndex < email.Length - 2 && atIndex < dotIndex)
                    {
                        ResultLabel.Text = "驗證成功!";
                        ResultLabel.ForeColor = green;
                    }
                    else {
                        ResultLabel.Text = "格式不正確，請重新輸入";
                        ResultLabel.ForeColor = red;
                    }
                }

                */
                if (IsEmail(email, rgx))
                {
                    ResultLabel.Text = "驗證成功!";
                    ResultLabel.ForeColor = green;
                }
                else
                {
                    ResultLabel.Text = "格式不正確，請重新輸入";
                    ResultLabel.ForeColor = red;
                }
            }
        }

        public Boolean IsEmail(string s, Regex rgx)
        {
            return rgx.IsMatch(s);
        }
    }
}