namespace ClientCB
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonGioca = new System.Windows.Forms.Button();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.button = new System.Windows.Forms.Button();
            this.labelRecord = new System.Windows.Forms.Label();
            this.labelVittorie = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.buttonRigioca = new System.Windows.Forms.Button();
            this.timerPartita = new System.Windows.Forms.Timer(this.components);
            this.labelPunteggio = new System.Windows.Forms.Label();
            this.buttonInizia = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // buttonGioca
            // 
            this.buttonGioca.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.buttonGioca.Location = new System.Drawing.Point(609, 316);
            this.buttonGioca.Name = "buttonGioca";
            this.buttonGioca.Size = new System.Drawing.Size(101, 57);
            this.buttonGioca.TabIndex = 0;
            this.buttonGioca.Text = "Gioca";
            this.buttonGioca.UseVisualStyleBackColor = true;
            this.buttonGioca.Click += new System.EventHandler(this.Login_Click);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.textBoxNome.Location = new System.Drawing.Point(545, 252);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(236, 31);
            this.textBoxNome.TabIndex = 1;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(1223, 12);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(75, 23);
            this.buttonLogout.TabIndex = 3;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Visible = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.LimeGreen;
            this.button.Location = new System.Drawing.Point(320, 418);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(60, 60);
            this.button.TabIndex = 4;
            this.button.UseVisualStyleBackColor = false;
            this.button.Visible = false;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // labelRecord
            // 
            this.labelRecord.AutoSize = true;
            this.labelRecord.Location = new System.Drawing.Point(12, 32);
            this.labelRecord.Name = "labelRecord";
            this.labelRecord.Size = new System.Drawing.Size(42, 13);
            this.labelRecord.TabIndex = 8;
            this.labelRecord.Text = "Record";
            this.labelRecord.Visible = false;
            // 
            // labelVittorie
            // 
            this.labelVittorie.AutoSize = true;
            this.labelVittorie.Location = new System.Drawing.Point(12, 56);
            this.labelVittorie.Name = "labelVittorie";
            this.labelVittorie.Size = new System.Drawing.Size(39, 13);
            this.labelVittorie.TabIndex = 10;
            this.labelVittorie.Text = "Vittorie";
            this.labelVittorie.Visible = false;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(12, 9);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(35, 13);
            this.labelNome.TabIndex = 11;
            this.labelNome.Text = "Nome";
            this.labelNome.Visible = false;
            // 
            // buttonRigioca
            // 
            this.buttonRigioca.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.buttonRigioca.Location = new System.Drawing.Point(609, 317);
            this.buttonRigioca.Name = "buttonRigioca";
            this.buttonRigioca.Size = new System.Drawing.Size(101, 60);
            this.buttonRigioca.TabIndex = 5;
            this.buttonRigioca.Text = "Rigioca";
            this.buttonRigioca.UseVisualStyleBackColor = true;
            this.buttonRigioca.Visible = false;
            this.buttonRigioca.Click += new System.EventHandler(this.buttonRivincita_Click);
            // 
            // timerPartita
            // 
            this.timerPartita.Interval = 10000;
            this.timerPartita.Tick += new System.EventHandler(this.timerPartita_Tick_1);
            // 
            // labelPunteggio
            // 
            this.labelPunteggio.AutoSize = true;
            this.labelPunteggio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.labelPunteggio.Location = new System.Drawing.Point(556, 0);
            this.labelPunteggio.Name = "labelPunteggio";
            this.labelPunteggio.Size = new System.Drawing.Size(115, 25);
            this.labelPunteggio.TabIndex = 15;
            this.labelPunteggio.Text = "Punteggio:";
            this.labelPunteggio.Visible = false;
            // 
            // buttonInizia
            // 
            this.buttonInizia.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.buttonInizia.Location = new System.Drawing.Point(609, 316);
            this.buttonInizia.Name = "buttonInizia";
            this.buttonInizia.Size = new System.Drawing.Size(101, 61);
            this.buttonInizia.TabIndex = 16;
            this.buttonInizia.Text = "Inizia";
            this.buttonInizia.UseVisualStyleBackColor = true;
            this.buttonInizia.Visible = false;
            this.buttonInizia.Click += new System.EventHandler(this.buttonInizia_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(15, 96);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(143, 326);
            this.listView1.TabIndex = 17;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 644);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonInizia);
            this.Controls.Add(this.labelPunteggio);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.labelVittorie);
            this.Controls.Add(this.labelRecord);
            this.Controls.Add(this.buttonRigioca);
            this.Controls.Add(this.button);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.buttonGioca);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGioca;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label labelRecord;
        private System.Windows.Forms.Label labelVittorie;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Button buttonRigioca;
        private System.Windows.Forms.Timer timerPartita;
        private System.Windows.Forms.Label labelPunteggio;
        private System.Windows.Forms.Button buttonInizia;
        private System.Windows.Forms.ListView listView1;
    }
}

