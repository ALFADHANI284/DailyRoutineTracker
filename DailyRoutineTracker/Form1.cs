using System;
using System.Collections.Generic;
using System.ComponentModel;   
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace DailyRoutineTracker
{
    public partial class home : Form
    {
        public class RoutineItem
        {
            public Guid Id { get; set; } = Guid.NewGuid();
            public DateTime Date { get; set; } = DateTime.Today;

            // Jam mulai & berakhir
            public int StartHour { get; set; }
            public int StartMinute { get; set; }
            public int EndHour { get; set; }
            public int EndMinute { get; set; }

            public string Activity { get; set; } = "";

            public DateTime StartAt => new DateTime(Date.Year, Date.Month, Date.Day, StartHour, StartMinute, 0);
            public DateTime EndAt => new DateTime(Date.Year, Date.Month, Date.Day, EndHour, EndMinute, 0);

            public string Tanggal => Date.ToString("dd MMM yyyy");
            public string WaktuRange => $"{StartAt:HH:mm}–{EndAt:HH:mm}";
        }

        // ================== STATE & PATH ==================
        private BindingList<RoutineItem> _items = new BindingList<RoutineItem>();
        private readonly BindingSource _bs = new BindingSource();

        private readonly string _folder =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                         "DailyRoutineTracker");
        private string FilePath => Path.Combine(_folder, "routines.json"); // penyimpanan internal

        public home()
        {
            InitializeComponent();
        }

        // ================== FORM LOAD ==================
        private void Form1_Load(object sender, EventArgs e)
        {
            // Tanggal
            dtpdate.Format = DateTimePickerFormat.Short;

            // Jam Mulai
            dtptime.Format = DateTimePickerFormat.Custom;
            dtptime.CustomFormat = "HH:mm";
            dtptime.ShowUpDown = true;

            // Jam Berakhir
            dtptimes.Format = DateTimePickerFormat.Custom;
            dtptimes.CustomFormat = "HH:mm";
            dtptimes.ShowUpDown = true;

            // Default values
            dtpdate.Value = DateTime.Today;
            dtptime.Value = DateTime.Today.AddHours(8);
            dtptimes.Value = DateTime.Today.AddHours(9);

            // ===== DataGridView setup =====
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;   // hilangkan baris input kosong
            dgv.RowHeadersVisible = false;   // hilangkan header kiri
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            dgv.Columns.Clear();
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTanggal",
                HeaderText = "Tanggal",
                DataPropertyName = "Tanggal",
                Width = 120
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colWaktu",
                HeaderText = "Waktu",
                DataPropertyName = "WaktuRange",
                Width = 120
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colActivity",
                HeaderText = "Kegiatan",
                DataPropertyName = "Activity",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgv.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colDel",
                HeaderText = "",
                Text = "Hapus",
                UseColumnTextForButtonValue = true,
                Width = 70,
                ReadOnly = false
            });

            // event tombol hapus per-baris
            dgv.CellContentClick -= dgv_CellContentClick;
            dgv.CellContentClick += dgv_CellContentClick;
            dgv.CellClick -= dgv_CellClick;   // fallback
            dgv.CellClick += dgv_CellClick;

            // Binding
            _bs.DataSource = _items;
            dgv.DataSource = _bs;

            // Load dari disk (JSON internal)
            Directory.CreateDirectory(_folder);
            var loaded = LoadFromDisk();
            _items = new BindingList<RoutineItem>(loaded.OrderBy(i => i.StartAt).ThenBy(i => i.EndAt).ToList());
            _bs.DataSource = _items;
            dgv.DataSource = _bs;
        }

        // ================== FORM CLOSING ==================
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToDisk();
        }

        // ================== TAMBAH ==================
        private void btntambah_Click(object sender, EventArgs e)
        {
            var activity = GetActivityText();
            if (string.IsNullOrEmpty(activity))
            {
                MessageBox.Show("Isi 'Kegiatan' dulu ya.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var date = dtpdate.Value.Date;

            var sh = dtptime.Value.Hour;
            var sm = dtptime.Value.Minute;

            var eh = dtptimes.Value.Hour;
            var em = dtptimes.Value.Minute;

            var start = new DateTime(date.Year, date.Month, date.Day, sh, sm, 0);
            var end = new DateTime(date.Year, date.Month, date.Day, eh, em, 0);

            if (end <= start)
            {
                MessageBox.Show("Jam berakhir harus lebih besar dari jam mulai.", "Validasi Waktu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = new RoutineItem
            {
                Date = date,
                StartHour = sh,
                StartMinute = sm,
                EndHour = eh,
                EndMinute = em,
                Activity = activity
            };

            _items.Add(item);
            Resort();
            SaveToDisk();
            ClearInputs();
        }

        // ================== HAPUS (tombol per baris) ==================
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgv.Columns[e.ColumnIndex].Name != "colDel") return;

            if (dgv.Rows[e.RowIndex].DataBoundItem is RoutineItem sel && ConfirmDelete(sel))
            {
                _items.Remove(sel);
                SaveToDisk();
            }
        }

        // Fallback: sebagian environment memicu CellClick
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgv.Columns[e.ColumnIndex].Name != "colDel") return;

            if (dgv.Rows[e.RowIndex].DataBoundItem is RoutineItem sel && ConfirmDelete(sel))
            {
                _items.Remove(sel);
                SaveToDisk();
            }
        }

        private bool ConfirmDelete(RoutineItem sel)
        {
            var ok = MessageBox.Show(
                $"Hapus '{sel.Activity}' ({sel.Tanggal} {sel.WaktuRange})?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return ok == DialogResult.Yes;
        }

        // ================== EXPORT TXT (btntxt) ==================
        private void btnexport_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                FileName = $"Routine_{DateTime.Now:yyyyMMdd_HHmm}.txt"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var lines = _items
                        .OrderBy(i => i.StartAt)
                        .ThenBy(i => i.EndAt)
                        .Select(i => $"{i.Tanggal}\t{i.WaktuRange}\t{i.Activity}")
                        .ToArray();

                    var header = "Tanggal\tWaktu\tKegiatan";
                    var content = header + Environment.NewLine + string.Join(Environment.NewLine, lines);

                    File.WriteAllText(sfd.FileName, content, Encoding.UTF8);
                    MessageBox.Show("Berhasil diekspor ke .txt", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal ekspor: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ================== SAVE / LOAD (internal JSON) ==================
        private void SaveToDisk()
        {
            try
            {
                Directory.CreateDirectory(_folder);
                var json = JsonSerializer.Serialize(_items.ToList(),
                    new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, json, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menyimpan: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<RoutineItem> LoadFromDisk()
        {
            try
            {
                if (!File.Exists(FilePath)) return new List<RoutineItem>();
                var json = File.ReadAllText(FilePath, Encoding.UTF8);
                return JsonSerializer.Deserialize<List<RoutineItem>>(json) ?? new List<RoutineItem>();
            }
            catch
            {
                return new List<RoutineItem>();
            }
        }

        // ================== HELPER ==================
        private void Resort()
        {
            var ordered = _items.OrderBy(i => i.StartAt).ThenBy(i => i.EndAt).ToList();
            _items = new BindingList<RoutineItem>(ordered);
            _bs.DataSource = _items;
            dgv.DataSource = _bs;
        }

        private void ClearInputs()
        {
            dtpdate.Value = DateTime.Today;
            dtptime.Value = DateTime.Today.AddHours(8);
            dtptimes.Value = DateTime.Today.AddHours(9);
            txtbactivity.Text = "";
        }

        private string GetActivityText()
        {
            var s = txtbactivity.Text ?? "";
            s = s.Replace("\u200B", "")   // zero-width space
                 .Replace("\u00A0", " "); // non-breaking space
            return s.Trim();
        }

        // ================== STUB HANDLERS (opsional; aman untuk Designer) ==================
        // Kalau Designer masih mengacu ke handler lama, biarkan stub kosong ini.
        private void button1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void lbltngl_Click(object sender, EventArgs e) { }
        private void lblwkt_Click(object sender, EventArgs e) { }
        private void dtptime_ValueChanged(object sender, EventArgs e) { }
        private void txtbactivity_TextChanged(object sender, EventArgs e) { }
        private void dtpdate_ValueChanged(object sender, EventArgs e) { }
        private void pleft_Paint(object sender, PaintEventArgs e) { }
        private void pright_Paint(object sender, PaintEventArgs e) { }
        private void tlpLeft_Paint(object sender, PaintEventArgs e) { }
        private void btntxt_Click_1(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e) { }
    }
}
