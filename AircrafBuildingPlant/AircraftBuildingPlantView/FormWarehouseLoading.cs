using AircraftBuildingPlantServiceDAL.BindingModel;
using AircraftBuildingPlantServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace AircraftBuildingPlantView
{
    public partial class FormWarehouseLoading : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IReplayService service;

        public FormWarehouseLoading(IReplayService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormWarehousesLoading_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = service.GetWarehousesLoad();
                if (dict != null)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView1.Rows.Add(new object[] { elem.WarehouseName, "", "" });
                        foreach (var listElem in elem.Elements)
                        {
                            dataGridView1.Rows.Add(new object[] { "", listElem.Item1,
listElem.Item2 });
                        }
                        dataGridView1.Rows.Add(new object[] { "Итого", "", elem.TotalCount
});
                        dataGridView1.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonSaveExc_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "xls|*.xls|xlsx|*.xlsx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    service.SaveWarehousesLoad(new ReplayBindingModel
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
    }
}
