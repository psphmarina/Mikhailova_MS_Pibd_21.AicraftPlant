
using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.Interfaces;
using AircraftBuildingPlantServiceDAL.ViewModel;
using AircraftBuildingPlantView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AircraftPlantView
{
    public partial class FormAircraft : Form
    {
        
        public int Id { set { id = value; } }
        private int? id;
        private List<AircraftElementViewModel> aircraftElements;

        public FormAircraft()
        {
            InitializeComponent();
        }

        private void FormAircraft_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    AircraftViewModel view = APIClient.GetRequest<AircraftViewModel>("api/Aircraft/Get/" + id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.AircraftName;
                        textBoxPrice.Text = view.Price.ToString();
                        aircraftElements = view.AircraftElements;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                aircraftElements = new List<AircraftElementViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (aircraftElements != null)
                {
                    dataGridViewElements.DataSource = null;
                    dataGridViewElements.DataSource = aircraftElements;
                    dataGridViewElements.Columns[0].Visible = false;
                    dataGridViewElements.Columns[1].Visible = false;
                    dataGridViewElements.Columns[2].Visible = false;
                    dataGridViewElements.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new FormAircraftElement();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.AircraftId = id.Value;
                    }
                    aircraftElements.Add(form.Model);
                }
                LoadData();
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewElements.SelectedRows.Count == 1)
            {
                var form = new FormAircraftElement();
                form.Model = aircraftElements[dataGridViewElements.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    aircraftElements[dataGridViewElements.SelectedRows[0].Cells[0].RowIndex] =
                    form.Model;
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewElements.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        aircraftElements.RemoveAt(dataGridViewElements.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (aircraftElements == null || aircraftElements.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<AircraftElementBindingModel> aircraftElementBM = new
                List<AircraftElementBindingModel>();
                for (int i = 0; i < aircraftElements.Count; ++i)
                {
                    aircraftElementBM.Add(new AircraftElementBindingModel
                    {
                        Id = aircraftElements[i].Id,
                        AircraftId = aircraftElements[i].AircraftId,
                        ElementId = aircraftElements[i].ElementId,
                        Count = aircraftElements[i].Count
                    });
                }
                if (id.HasValue)
                {
                    APIClient.PostRequest<AircraftBindingModel,
                     bool>("api/Aircraft/UpdElement", new AircraftBindingModel
                     {
                        Id = id.Value,
                        AircraftName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        AircraftElements = aircraftElementBM
                    });
                }
                else
            {

                    APIClient.PostRequest<AircraftBindingModel,
                            bool>("api/Aircraft/AddElement", new AircraftBindingModel
                            {
                AircraftName = textBoxName.Text,
                Price = Convert.ToInt32(textBoxPrice.Text),
                AircraftElements = aircraftElementBM
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
