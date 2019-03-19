namespace AircraftPlantView
{
    partial class FormAircraftElement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxEl = new System.Windows.Forms.TextBox();
            this.textBoxNum = new System.Windows.Forms.TextBox();
            this.comboBoxElement = new System.Windows.Forms.ComboBox();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.elementViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.elementViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxEl
            // 
            this.textBoxEl.Location = new System.Drawing.Point(10, 25);
            this.textBoxEl.Name = "textBoxEl";
            this.textBoxEl.ReadOnly = true;
            this.textBoxEl.Size = new System.Drawing.Size(69, 20);
            this.textBoxEl.TabIndex = 0;
            this.textBoxEl.Text = "Запчасть";
            // 
            // textBoxNum
            // 
            this.textBoxNum.Location = new System.Drawing.Point(9, 61);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.ReadOnly = true;
            this.textBoxNum.Size = new System.Drawing.Size(70, 20);
            this.textBoxNum.TabIndex = 1;
            this.textBoxNum.Text = "Количество";
            // 
            // comboBoxElement
            // 
            this.comboBoxElement.FormattingEnabled = true;
            this.comboBoxElement.Location = new System.Drawing.Point(94, 26);
            this.comboBoxElement.Name = "comboBoxElement";
            this.comboBoxElement.Size = new System.Drawing.Size(212, 21);
            this.comboBoxElement.TabIndex = 2;
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(93, 64);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(212, 20);
            this.textBoxAmount.TabIndex = 3;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(36, 110);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(98, 25);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(155, 111);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(102, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // elementViewModelBindingSource
            // 
            this.elementViewModelBindingSource.DataSource = typeof(AircraftBuildingPlantServiceDAL.ViewModel.ElementViewModel);
            // 
            // FormAircraftElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 153);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.comboBoxElement);
            this.Controls.Add(this.textBoxNum);
            this.Controls.Add(this.textBoxEl);
            this.Name = "FormAircraftElement";
            this.Text = "Запчасти самолёта";
            this.Load += new System.EventHandler(this.FormAircraftElement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.elementViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEl;
        private System.Windows.Forms.TextBox textBoxNum;
        private System.Windows.Forms.ComboBox comboBoxElement;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.BindingSource elementViewModelBindingSource;
    }
}