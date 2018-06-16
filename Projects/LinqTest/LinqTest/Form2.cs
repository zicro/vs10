using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinqTest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext Dc = new DataClasses1DataContext();
            //MessageBox.Show(Dc.Connection.ConnectionString);

            var r = from emp in Dc.Employees
                    select emp;

            ListBox lbx = new ListBox();
            foreach (var item in r)
            {
                lbx.Items.Add(item.Name+" | "+item.City);
            }
            Controls.Add(lbx);
        }
    }
}
