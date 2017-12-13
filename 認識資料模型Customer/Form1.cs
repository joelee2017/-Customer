using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 認識資料模型Customer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NorthwindEntities dc = new NorthwindEntities();
            customersBindingSource.DataSource = dc.Customers.ToArray();
            //ToArray 限用於視窗軟體，其它會嚴重影響效能
        }

        private void customersBindingSource_PositionChanged(object sender, EventArgs e)
        {
            ordersBindingSource.DataSource = ((Customers)customersBindingSource.Current).Orders.ToList();
            //((Customers)customersBindingSource.Current).Orders.ToList(); 
            //接order需要將customersBindingSource.Current轉型成Customers
        }
    }
}
