using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.PresentationLayer
{
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public FrmProduct()
        {
            _productService=new ProductManager(new EfProductDal());
            _categoryService=new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetAll();
            dataGridView1.DataSource = values;
        }

        private void btnList2_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductsWithCategory();
            dataGridView1.DataSource = values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtProductId.Text);
            var deletedValue = _productService.TGetById(id);
            _productService.TDelete(deletedValue);
            MessageBox.Show("Ürün Silindi");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.CategoryId=int.Parse(cmbCategory.SelectedValue.ToString());
            product.ProductName = txtProductName.Text;
            product.ProductStock=int.Parse(txtProductStock.Text);
            product.ProductPrice=decimal.Parse(txtProductPrice.Text);
            product.ProductDescription=txtDescription.Text;
            _productService.TInsert(product);
            MessageBox.Show("Ürün Eklendi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updateId= Convert.ToInt32(txtProductId.Text);
            var updatedValue = _productService.TGetById(updateId);
            updatedValue.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            updatedValue.ProductName = txtProductName.Text;
            updatedValue.ProductStock = int.Parse(txtProductStock.Text);
            updatedValue.ProductPrice = decimal.Parse(txtProductPrice.Text);
            updatedValue.ProductDescription = txtDescription.Text;
            _productService.TUpdate(updatedValue);
            MessageBox.Show("Ürün Güncellendi");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtProductId.Text);
            var productValue = _productService.TGetById(id);
            dataGridView1.DataSource = new List<Product> { productValue };
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values = _categoryService.TGetAll();
            cmbCategory.DataSource = values;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";

        }
    }
}
