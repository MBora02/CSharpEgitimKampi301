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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Locations.Count().ToString();
            lblSumCapacity.Text = db.Locations.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Guides.Count().ToString();
            lblAverageCapacity.Text = db.Locations.Average(x => x.Capacity).ToString();
            lblAvgLocationPrice.Text = db.Locations.Average(x => (double?)x.Price).Value.ToString("0.00") + " ₺";
            lblLastCountryName.Text = db.Locations.OrderByDescending(x => x.LocationId).Select(y => y.Country).FirstOrDefault();



        }

        private void lblSumCapacity_Click(object sender, EventArgs e)
        {

        }
    }
}
