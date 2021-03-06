using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MrCy.BaseClass;

namespace MrCy {
    public partial class Pwd : Form {
        public Pwd() {
            InitializeComponent();
        }

        public string names;

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (txtPwd1.Text == "") {
                MessageBox.Show("请输入密码");
                txtPwd1.Focus();
            }
            else {
                if (txtPwd2.Text != txtPwd1.Text) {
                    MessageBox.Show("两次密码不一致");
                    txtPwd2.Focus();
                }
                else {
                    var conn = DbConn.CyCon();
                    conn.Open();
                    var cmd = new SqlCommand(
                        "update tb_User set UserPwd='" + txtPwd1.Text + "' where UserName='" + names + "'", conn);
                    cmd.ExecuteNonQuery();
                    if (MessageBox.Show("密码修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) ==
                        DialogResult.OK) {
                        this.Close();
                    }
                }
            }
        }

        private void frmPwd_Load(object sender, EventArgs e) {
        }
    }
}