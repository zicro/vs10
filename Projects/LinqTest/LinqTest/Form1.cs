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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        employe[] employees = {
                                  new employe() {Number=1,Name="hamid",City="Rbat",Salary=600, Sons = new string[] {"omae","samed","halab" }},
                                  new employe() {Number=2,Name="hanibal",City="casa",Salary=302},
                                  new employe() {Number=3,Name="hassan",City="taza",Salary=3070, Sons = new string[] {"hamid","labid","samid" }},
                                  new employe() {Number=4,Name="habiba",City="zdida",Salary=3080},
                                  new employe() {Number=5,Name="halima",City="usa",Salary=30},
                                  new employe() {Number=6,Name="hasna",City="Ksa",Salary=150, Sons = new string[] {"razan","hanan","laban" }},
                                  new employe() {Number=7,Name="hafsa",City="Ma",Salary=200},
                                  new employe() {Number=8,Name="khansa",City="Ksa",Salary=150, Sons = new string[] {"said","sozan","koban" }},
                                  new employe() {Number=9,Name="fola",City="Ma",Salary=200}
                                  };
        phones[] phone = {
                            new phones(){Number = 1, Phone = "0658889009"},
                            new phones(){Number = 2, Phone = "23232"},
                            new phones(){Number = 3, Phone = "111144"},
                            new phones(){Number = 4, Phone = "565656"}
                
                         };

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "LinQ Frm";


           


            // charge the list box from the Array
            foreach (employe emp in employees)
            {
               // listBox1.Items.Add(emp.Number + " ; " +emp.Name + " ; " + emp.City + " ; " + emp.Salary);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var all = from emps in employees select emps;

            foreach (var emp in all)
            {
                if(emp.Salary > 400)
                listBox1.Items.Add(emp.Number + " ; " +emp.Name + " ; " + emp.City + " ; " + emp.Salary);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nSal = from emps in employees
                       select new { emps.Name, emps.Salary };

            foreach (var emp in nSal)
            {
               
                    listBox1.Items.Add(emp.Name + " ; " +  emp.Salary);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var filtre = from emps in employees
                         where emps.Salary > 300 && emps.Name.Contains(textBox1.Text)
                         orderby emps.Salary descending, emps.Number ascending
                        
                         select emps;

            foreach (var emp in filtre)
            {
                listBox1.Items.Add(emp.Name + " ; " + emp.Salary);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
             var filtre = from emps in employees
                         orderby emps.Salary descending, emps.Number ascending
                         group emps by emps.City;

            foreach (var emp in filtre)
            {
                listBox1.Items.Add(emp.Key+ " " +emp.Count());
                foreach (var y in emp)
                {
                    listBox1.Items.Add(y.Name + " ; " + y.Salary);
                }
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var rx = from emps in employees
                     where emps.Sons != null
                     from sons in emps.Sons
                     select sons;

            
          
            foreach (var yx in rx)
            {
                if (yx != null)
                listBox1.Items.Add(yx + " ; ");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var r = from emps in employees
                    join tel in phone
                    on emps.Number equals tel.Number
                    select tel;

            foreach (var y in r)
            {
                    listBox1.Items.Add(y.Phone + " ; " + y.Number);
            }
        }
    }
}
