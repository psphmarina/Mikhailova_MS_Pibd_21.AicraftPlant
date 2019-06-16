
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
    public partial class FormOneCustomer : Form
    {
        public int Id { set { id = value; } }
        private int? id;

        public FormOneCustomer()
        {
            InitializeComponent();
        }
        private void FormOneCustomer_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CustomerViewModel client =
                    APIClient.GetRequest<CustomerViewModel>("api/Customer/Get/" + id.Value);
                    textBoxFIOCustomer.Text = client.CustomerFIO;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIOCustomer.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APIClient.PostRequest<CustomerBindingModel,
                    bool>("api/Customer/UpdElement", new CustomerBindingModel
                    {
                        Id = id.Value,
                        CustomerFIO = textBoxFIOCustomer.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<CustomerBindingModel,
                    bool>("api/Customer/AddElement", new CustomerBindingModel
                    {
                        CustomerFIO = textBoxFIOCustomer.Text
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
    }
}
