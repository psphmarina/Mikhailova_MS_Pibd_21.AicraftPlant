
using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.Interfaces;
using AircraftBuildingPlantServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AircraftBuildingPlantView
{
    public partial class FormWarehouse : Form
    {
        
        public int Id { set { id = value; } }
        private int? id;

        public FormWarehouse()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                   // service.UpdElement(new WarehouseBindingModel
                    APIClient.PostRequest<WarehouseBindingModel, bool>("api/Warehouse/UpdElement", new WarehouseBindingModel
                    {
                        Id = id.Value,
                        WarehouseName = textBoxName.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<WarehouseBindingModel, bool>("api/Warehouse/AddElement", new WarehouseBindingModel
                    {
                        WarehouseName = textBoxName.Text
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void FormWarehouse_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    WarehouseViewModel view = APIClient.GetRequest<WarehouseViewModel>("api/Warehouse/Get/" + id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.WarehouseName;
                        dataGridView1.DataSource = view.WarehouseElements;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        }
}
