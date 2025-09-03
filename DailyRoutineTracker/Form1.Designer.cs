namespace DailyRoutineTracker
{
    partial class home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btntambah = new Button();
            label1 = new Label();
            pleft = new Panel();
            flpActions = new FlowLayoutPanel();
            txtbactivity = new TextBox();
            lblkegiatan = new Label();
            dtptime = new DateTimePicker();
            lblwkt = new Label();
            dtpdate = new DateTimePicker();
            lbltngl = new Label();
            btnhps = new Button();
            pright = new Panel();
            pSearchBar = new Panel();
            btnjson = new Button();
            dgv = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pleft.SuspendLayout();
            flpActions.SuspendLayout();
            pright.SuspendLayout();
            pSearchBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(462, 84);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(0, 0);
            dataGridView1.TabIndex = 3;
            // 
            // btntambah
            // 
            btntambah.BackColor = Color.Red;
            btntambah.FlatAppearance.BorderSize = 0;
            btntambah.FlatStyle = FlatStyle.Flat;
            btntambah.ForeColor = Color.White;
            btntambah.Location = new Point(3, 3);
            btntambah.Name = "btntambah";
            btntambah.Size = new Size(110, 34);
            btntambah.TabIndex = 4;
            btntambah.Text = "Tambah";
            btntambah.UseVisualStyleBackColor = false;
            btntambah.Click += btntambah_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(178, 19);
            label1.Name = "label1";
            label1.Size = new Size(335, 41);
            label1.TabIndex = 5;
            label1.Text = "Daily Routine Tracker  ";
            label1.Click += label1_Click;
            // 
            // pleft
            // 
            pleft.BorderStyle = BorderStyle.FixedSingle;
            pleft.Controls.Add(flpActions);
            pleft.Controls.Add(txtbactivity);
            pleft.Controls.Add(lblkegiatan);
            pleft.Controls.Add(dtptime);
            pleft.Controls.Add(lblwkt);
            pleft.Controls.Add(dtpdate);
            pleft.Controls.Add(lbltngl);
            pleft.ForeColor = Color.Black;
            pleft.ImeMode = ImeMode.NoControl;
            pleft.Location = new Point(20, 84);
            pleft.Name = "pleft";
            pleft.Size = new Size(340, 205);
            pleft.TabIndex = 11;
            pleft.Paint += pleft_Paint;
            // 
            // flpActions
            // 
            flpActions.BorderStyle = BorderStyle.FixedSingle;
            flpActions.Controls.Add(btntambah);
            flpActions.Location = new Point(3, 148);
            flpActions.Margin = new Padding(0, 8, 0, 0);
            flpActions.Name = "flpActions";
            flpActions.Size = new Size(120, 43);
            flpActions.TabIndex = 13;
            // 
            // txtbactivity
            // 
            txtbactivity.BorderStyle = BorderStyle.FixedSingle;
            txtbactivity.Location = new Point(69, 68);
            txtbactivity.Multiline = true;
            txtbactivity.Name = "txtbactivity";
            txtbactivity.Size = new Size(251, 69);
            txtbactivity.TabIndex = 13;
            // 
            // lblkegiatan
            // 
            lblkegiatan.AutoSize = true;
            lblkegiatan.Location = new Point(3, 68);
            lblkegiatan.Name = "lblkegiatan";
            lblkegiatan.Size = new Size(60, 20);
            lblkegiatan.TabIndex = 16;
            lblkegiatan.Text = "Kegitan";
            // 
            // dtptime
            // 
            dtptime.CustomFormat = "HH : mm";
            dtptime.Format = DateTimePickerFormat.Custom;
            dtptime.Location = new Point(70, 34);
            dtptime.Name = "dtptime";
            dtptime.ShowUpDown = true;
            dtptime.Size = new Size(250, 27);
            dtptime.TabIndex = 15;
            dtptime.ValueChanged += dtptime_ValueChanged;
            // 
            // lblwkt
            // 
            lblwkt.AutoSize = true;
            lblwkt.Location = new Point(3, 34);
            lblwkt.Name = "lblwkt";
            lblwkt.Size = new Size(50, 20);
            lblwkt.TabIndex = 14;
            lblwkt.Text = "Waktu";
            lblwkt.Click += lblwkt_Click;
            // 
            // dtpdate
            // 
            dtpdate.Location = new Point(70, 3);
            dtpdate.Name = "dtpdate";
            dtpdate.Size = new Size(250, 27);
            dtpdate.TabIndex = 13;
            // 
            // lbltngl
            // 
            lbltngl.AutoSize = true;
            lbltngl.Location = new Point(3, 3);
            lbltngl.Name = "lbltngl";
            lbltngl.Size = new Size(61, 20);
            lbltngl.TabIndex = 13;
            lbltngl.Text = "Tanggal";
            lbltngl.Click += lbltngl_Click;
            // 
            // btnhps
            // 
            btnhps.BackColor = Color.Red;
            btnhps.FlatAppearance.BorderSize = 0;
            btnhps.FlatStyle = FlatStyle.Flat;
            btnhps.ForeColor = Color.White;
            btnhps.Location = new Point(253, 403);
            btnhps.Name = "btnhps";
            btnhps.Size = new Size(110, 34);
            btnhps.TabIndex = 5;
            btnhps.Text = "Hapus";
            btnhps.UseVisualStyleBackColor = false;
            // 
            // pright
            // 
            pright.BorderStyle = BorderStyle.FixedSingle;
            pright.Controls.Add(btnhps);
            pright.Controls.Add(pSearchBar);
            pright.Controls.Add(dgv);
            pright.Location = new Point(550, 0);
            pright.Name = "pright";
            pright.Size = new Size(377, 450);
            pright.TabIndex = 12;
            pright.Paint += pright_Paint;
            // 
            // pSearchBar
            // 
            pSearchBar.BackColor = Color.White;
            pSearchBar.BorderStyle = BorderStyle.FixedSingle;
            pSearchBar.Controls.Add(btnjson);
            pSearchBar.Dock = DockStyle.Top;
            pSearchBar.Location = new Point(0, 0);
            pSearchBar.Name = "pSearchBar";
            pSearchBar.Size = new Size(375, 44);
            pSearchBar.TabIndex = 0;
            // 
            // btnjson
            // 
            btnjson.Location = new Point(228, 3);
            btnjson.Name = "btnjson";
            btnjson.Size = new Size(142, 29);
            btnjson.TabIndex = 1;
            btnjson.Text = "Export JSON";
            btnjson.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            dgv.BackgroundColor = Color.FromArgb(224, 224, 224);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 0);
            dgv.Name = "dgv";
            dgv.RowHeadersWidth = 51;
            dgv.Size = new Size(375, 448);
            dgv.TabIndex = 13;
            // 
            // home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(926, 450);
            Controls.Add(pright);
            Controls.Add(pleft);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "home";
            Text = "Home";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pleft.ResumeLayout(false);
            pleft.PerformLayout();
            flpActions.ResumeLayout(false);
            pright.ResumeLayout(false);
            pSearchBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button btntambah;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel pleft;
        private Label lbltngl;
        private DateTimePicker dtpdate;
        private Label lblwkt;
        private DateTimePicker dtptime;
        private Label lblkegiatan;
        private TextBox txtbactivity;
        private FlowLayoutPanel flpActions;
        private Button btnhps;
        private Panel pright;
        private Panel pSearchBar;
        private DataGridView dgv;
        private Button button1;
        private Button btnjson;
    }
}
