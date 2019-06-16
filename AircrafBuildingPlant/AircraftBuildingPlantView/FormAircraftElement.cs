
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
    public partial class FormAircraftElement : Form
    {
        
        public AircraftElementViewModel Model
        {
            set { model = value; }
            get { return model;  }
        }
        private AircraftElementViewModel model;

        public FormAircraftElement()
        {
            InitializeComponent();
        }

        private void FormAircraftElement_Load(object sender, EventArgs e)
        {
            try
            {
                List<ElementViewModel> list = APIClient.GetRequest<List<ElementViewModel>>("api/Element/GetList");
                if (list != null)
                {
                    comboBoxElement.DisplayMember = "ElementName";
                    comboBoxElement.ValueMember = "Id";
                    comboBoxElement.DataSource = list;
                    comboBoxElement.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxElement.Enabled = false;
                comboBoxElement.SelectedValue = model.ElementId;
                textBoxAmount.Text = model.Count.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAmount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxElement.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null) 
            {
                    model = new AircraftElementViewModel
                    {
                        ElementId = Convert.ToInt32(comboBoxElement.SelectedValue),
                        ElementName = comboBoxElement.Text,
                        Count = Convert.ToInt32(textBoxAmount.Text)
                    };
                }
                    else
                {
                    model.Count = Convert.ToInt32(textBoxAmount.Text);
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
