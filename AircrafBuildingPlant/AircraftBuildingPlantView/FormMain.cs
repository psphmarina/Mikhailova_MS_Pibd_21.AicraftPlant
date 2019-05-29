using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.Interfaces;
using AircraftBuildingPlantServiceDAL.ViewModel;
using AircraftPlantView;
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
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                List<AircraftOrderViewModel> list =
                APIClient.GetRequest<List<AircraftOrderViewModel>>("api/Main/GetList");
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCustomer();
            form.ShowDialog();
        }

        private void компонентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormElements();
            form.ShowDialog();
        }

        private void изделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormAircraft();
            form.ShowDialog();
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = new FormOrder();
            form.ShowDialog();
            LoadData();
        }

        private void buttonTakeOrderInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    APIClient.PostRequest<AircraftOrderBindingModel,
                    bool>("api/Main/TakeOrderInWork", new AircraftOrderBindingModel
                    {
                        Id = id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonFinishOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    APIClient.PostRequest<AircraftOrderBindingModel,
                    bool>("api/Main/FinishOrder", new AircraftOrderBindingModel
                    {
                        Id = id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                }
            }

        private void buttonPayOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    APIClient.PostRequest<AircraftOrderBindingModel, bool>("api/Main/PayOrder",
                    new AircraftOrderBindingModel
                    {
                        Id = id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void клиентыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = new FormCustomer();
            form.ShowDialog();
        }

        private void компонентыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = new FormElements();
            form.ShowDialog();
        }

        private void изделияToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = new FormAircraft();
            form.ShowDialog();
        }

        private void складыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
                var form = new FormWarehouses();
                form.ShowDialog();
            
        }

        private void пополнитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormPutOnWarehouse();
            form.ShowDialog();
        }

        private void прайсИзделийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "doc|*.doc|docx|*.docx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    APIClient.PostRequest<ReplayBindingModel,
                    bool>("api/Report/SaveProductPrice", new ReplayBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void загруженностьСкладовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormWarehouseLoading();
            form.ShowDialog();
        }

        private void заказыКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCustomerOrders();
            form.ShowDialog();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormExecutors();
            form.ShowDialog();
        }

        private void запускРаботToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                APIClient.PostRequest<int?, bool>("api/Main/StartWork", null);
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}
