using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioTienda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

            private List<Product> products = new List<Product>();

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            decimal price;
            int stock;

            // Validar conversión de precio y stock
            if (!decimal.TryParse(txtPrice.Text, out price) || !int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("Por favor, ingrese valores válidos para el precio y el stock.");
                return;
            }

            Category category;
            if (!Enum.TryParse(cmbCategory.SelectedItem.ToString(), out category))
            {
                MessageBox.Show("Seleccione una categoría válida.");
                return;
            }

            if (Validations.ValidateProduct(name, price, stock))
            {
                Product product = new Product
                {
                    Name = name,
                    Price = price,
                    Stock = stock,
                    Category = category
                };
                products.Add(product);
                MessageBox.Show("Producto agregado exitosamente.");
                UpdateProductList();
            }
            else
            {
                MessageBox.Show("Datos del producto no válidos.");
            }
        }

        private void UpdateProductList()
        {
            lstProducts.Items.Clear();
            foreach (var product in products)
            {
                string status = product.IsAvailable() ? "Disponible" : "Agotado";
                lstProducts.Items.Add($"{product.Name} - {product.Price:C} - {status} - {product.Category}");
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

