using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoRepository;

namespace MongoTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btText_Click(object sender, EventArgs e)
        {
            DateTime dt1 = DateTime.Now;
            var repo = new MongoRepository<Customer>();

            /*
            // adding new entity
            var newCustomer = new Customer
            {
                FirstName = "Steve",
                LastName = "Cornell"
            };

            repo.Add(newCustomer);
            */

            // searching
            //var result = repo.Where(c => c.FirstName == "Steve");
            //var result = repo.Where(c => c.FirstName.Contains("Steve"));
            var result = repo.Where(c => c.FirstName.StartsWith("Steve"));


            //MessageBox.Show(result.Count<Customer>().ToString());
            this.Text = "总记录数量：" + result.Count<Customer>().ToString();
            
            // updating 
            //newCustomer.LastName = "Castle";
            //repo.Update(newCustomer);

            dataGridView1.DataSource = result.ToList<Customer>();

            DateTime dt2 = DateTime.Now;
            TimeSpan ts = dt2 - dt1;
            MessageBox.Show("总共用时" + ts.TotalSeconds + "秒");

        }

        private void btInsert100W_Click(object sender, EventArgs e)
        {
            DateTime dt1 = DateTime.Now;
            var repo = new MongoRepository<Customer>();

            for (int i = 0; i < 100000; i++)
            {
                // adding new entity
                var newCustomer = new Customer
                {
                    FirstName = "Steve"+i,
                    LastName = "Cornell"+i
                };
                repo.Add(newCustomer);
            }
            DateTime dt2 = DateTime.Now;
            TimeSpan ts = dt2 - dt1;
            MessageBox.Show("总共用时" + ts.TotalSeconds + "秒");

        }
    }
}
