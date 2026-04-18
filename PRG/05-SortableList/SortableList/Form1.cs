using SortableList.Controllers;
using SortableList.Models;

namespace SortableList
{
    public partial class Form1 : Form
    {
        private MyContext context = new MyContext();
        public Form1()
        {
            InitializeComponent();

            List<Product> products = this.context.Products.ToList();
            SortableListControl<Product> sortableList = new SortableListControl<Product>(products);

            sortableList.IsSelected = p => p.Selected;
            sortableList.ShowableText = p => p.Name;

            sortableList.Dock = DockStyle.Fill;

            Controls.Add(sortableList);
        }

    }
}
