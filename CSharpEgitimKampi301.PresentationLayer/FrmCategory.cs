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
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;

        public FrmCategory()
        {
            //manuel dependency injection connection
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            category.CategoryStatus = true;
            _categoryService.TInsert(category);
            MessageBox.Show("Kategori Eklendi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updateId = Convert.ToInt32(txtCategoryId.Text);
            var updatedValue = _categoryService.TGetById(updateId);
            updatedValue.CategoryName= txtCategoryName.Text;
            updatedValue.CategoryStatus = true;
            MessageBox.Show("Kategori Güncellendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryId.Text);
            var deletedValue = _categoryService.TGetById(id);
            _categoryService.TDelete(deletedValue);
            MessageBox.Show("Kategori Silindi");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryId.Text);
            var categoryValue = _categoryService.TGetById(id);
            dataGridView1.DataSource = new List<Category> { categoryValue };

        }
    }
}
