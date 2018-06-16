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
        employe[] employees2 = {
                                  new employe() {Number=1,Name="hamid",City="Rbat",Salary=600, Sons = new string[] {"omae","samed","halab" }},
                                  new employe() {Number=2,Name="hanibala",City="casa",Salary=3012},
                                  new employe() {Number=3,Name="hassana",City="taza",Salary=30710, Sons = new string[] {"hamid","labid","samid" }},
                                  new employe() {Number=4,Name="habibaa",City="zdida",Salary=30180}
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

        private void button7_Click(object sender, EventArgs e)
        {
            var r = from emps in employees
                    join tel in phone
                    on emps.Number equals tel.Number into phoneData
                    select new { emps, phoneData};

            foreach (var y in r)
            {
                listBox1.Items.Add(y.emps.Name);
                foreach (var z in y.phoneData) {
                    listBox1.Items.Add(z.Phone + " ; " + z.Number);
                }
                
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var r = from emps in employees
                    select emps.City;

            var data = r.Distinct();

            foreach (var item in data)
            {
                listBox1.Items.Add(item);
                
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable tblEmp = new DataTable("emp");
            tblEmp.Columns.Add("empno", typeof(int));
            tblEmp.Columns.Add("empname");
            tblEmp.Columns.Add("city");
            tblEmp.Columns.Add("salary", typeof(int));

            tblEmp.Rows.Add(1, "amhar", "sweed", 1200);
            tblEmp.Rows.Add(2, "aljad", "turkich", 1200);
            tblEmp.Rows.Add(3, "majed", "rinkha", 3344);
            tblEmp.Rows.Add(4, "mohab", "arbid", 4433);
            tblEmp.Rows.Add(55, "hindo", "abidjan", 2233);
            tblEmp.Rows.Add(66, "hajib", "stookholm", 2333);

            DataSet ds = new DataSet("com");
            ds.Tables.Add(tblEmp);

            var r = from emp in ds.Tables[0].AsEnumerable()
                    where emp[1].ToString().Contains("h")
                    select new { 
                        Number = emp[0],
                        Name = emp[1],
                        City = emp[2],
                        Salary = emp[3] 
                    };
            foreach (var item in r)
            {
                listBox1.Items.Add(item.Name);
            }
        }

        delegate void Hello();
        delegate void msgparam(string name);
        delegate void operat(int a, int b);
        private void button10_Click(object sender, EventArgs e)
        {
            Hello h1 = () => MessageBox.Show("Hello Lambda There ...");
            h1();

            Hello h2 = () =>
            {
                MessageBox.Show("Test it Again");
            };

            h2();

            msgparam h3 = (msg) =>
            {
                MessageBox.Show(msg);
            };
            h3("say hallo");

            //operat h4 = (a,b) => a + b;

            //int i = h4(2,2);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var r = employees.Select(emp => emp);
            var y = employees.Where(emp => emp.City.Contains("s")).OrderBy(emp => emp.Salary);
            var z = employees.OrderByDescending(emp => emp.Number);
            // Group BY
            var x = employees.OrderByDescending(emp => emp.Number).GroupBy(emp => emp.City).Select(emp => emp);
            foreach (var item in x)
            {
                listBox1.Items.Add(item.Key);
                 foreach (var data in item){
                    listBox1.Items.Add(data.Number+" "+data.City);
                 }
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            var r = employees.Join(
                phone,
                emp => emp.Number,
                ph => ph.Number,
                (emp, ph) => new { emp, ph }
                );
            foreach (var item in r)
            {
                listBox1.Items.Add(item.emp.Name + " : "+item.ph.Phone);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var r = (from emp in employees
                     select emp).Where(emp => emp.Name.Contains("h"));

            var s = (from emp in employees
                     where emp.Name.Contains("h")
                     select emp).OrderByDescending(emp => emp.Salary);

            foreach (var item in s)
            {
                listBox1.Items.Add(item.Name+" / "+item.Salary);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var r = (from emp1 in employees select emp1)
                    .Union
                    (from emp2 in employees2 select emp2);

            var r2 = employees.Union(employees2);

            foreach (var item in r2)
            {
                listBox1.Items.Add(item.Name + " / " + item.Salary);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var r = employees.Intersect(employees2);

            foreach (var item in r)
            {
                listBox1.Items.Add(item.Name);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DataTable tblEmp = new DataTable("emp");
            tblEmp.Columns.Add("empno", typeof(int));
            tblEmp.Columns.Add("empname");
            tblEmp.Columns.Add("city");
            tblEmp.Columns.Add("salary", typeof(int));

            tblEmp.Rows.Add(1, "amhar", "sweed", 1200);
            tblEmp.Rows.Add(2, "aljad", "turkich", 1200);
            tblEmp.Rows.Add(3, "majed", "rinkha", 3344);
            tblEmp.Rows.Add(4, "mohab", "arbid", 4433);
            tblEmp.Rows.Add(55, "hindo", "abidjan", 2233);
            tblEmp.Rows.Add(66, "hajib", "stookholm", 2333);

            var r = from emp in tblEmp.AsEnumerable()
                    where emp[1].ToString().Contains("a")
                    select emp;

            DataTable tblNew = r.CopyToDataTable();

            DataGridView dgv = new DataGridView();
            dgv.Height = Height - 20;
            dgv.Width = Width - 300;
            Controls.Add(dgv);
            Controls.Remove(listBox1);
            dgv.DataSource = tblNew;
        }
    }
}
