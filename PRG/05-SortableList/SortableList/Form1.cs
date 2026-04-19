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

            sortableList.ItemSelectionChanged += (sender, product) =>
            {
                product.Selected = !product.Selected;

                this.context.SaveChanges();

                sortableList.DataSource = this.context.Products
                                                .OrderBy(p => p.Order)
                                                .ToList();
                sortableList.Invalidate();
            };

            sortableList.ItemOrderChanged += (product, newOrder) =>
            {
                List<Product> allProducts = this.context.Products
                                                .OrderBy(p => p.Order)
                                                .ToList();

                allProducts.RemoveAll(p => p.Id == product.Id);

                int globalInsertIndex = 0;
                int currentColumnIndex = 0;

                foreach (Product p in allProducts)
                {
                    if (p.Selected == product.Selected)
                    {
                        if (currentColumnIndex == newOrder)
                        {
                            break;
                        }
                        currentColumnIndex++;
                    }
                    globalInsertIndex++;
                }

                allProducts.Insert(globalInsertIndex, product);

                for (int i = 0; i < allProducts.Count; i++)
                {
                    allProducts[i].Order = i;
                }

                this.context.SaveChanges();

                sortableList.DataSource = allProducts;
                sortableList.Invalidate();
            };

            sortableList.Dock = DockStyle.Fill;

            Controls.Add(sortableList);
        }

    }
}
