using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db=new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Locations.ToList();
            dataGridView1.DataSource = values;

        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values= db.Guides.Select(x=>new
            {
                
            Fullname =x.GuideName+" "+x.GuideSurname,
                x.GuideId
            }).ToList();
            cmbGuide.DisplayMember="Fullname";
            cmbGuide.ValueMember="GuideId";
            cmbGuide.DataSource=values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location=new Location();
            location.City=txtCity.Text;
            location.Capacity = byte.Parse(nudCapacity.Value.ToString());
            location.Country= txtCountry.Text;
            location.DayNight= txtDayNight.Text;
            location.Price=decimal.Parse(txtPrice.Text);
            location.GuideId=int.Parse(cmbGuide.SelectedValue.ToString());
            db.Locations.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme Başarılı");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id= int.Parse(txtId.Text);
            var deletedValue = db.Locations.Find(id);
            db.Locations.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id= int.Parse(txtId.Text);
            var updatedValue = db.Locations.Find(id);
            updatedValue.City= txtCity.Text;
            updatedValue.Country= txtCountry.Text;
            updatedValue.DayNight= txtDayNight.Text;
            updatedValue.Price= decimal.Parse(txtPrice.Text);
            updatedValue.Capacity= byte.Parse(nudCapacity.Value.ToString());
            updatedValue.GuideId= int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme Başarılı");
        }
    }
}
