﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientReservasi_071
{
    public partial class Form1 : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();

        public Form1()
        {
            InitializeComponent();

            TampilData();
            btUpdate.Enabled = false;
            btHapus.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btSimpan_Click(object sender, EventArgs e)
        {
            string IDPemesanan = textBoxID.Text;
            string NamaCustomer = textBoxNama.Text;
            string NoTelpon = textBoxTlf.Text;
            int JumlahPemesanan = int.Parse(textBoxJumlah.Text);
            string IDLokasi = textBoxIDLokasi.Text;

            var d = service.pemesanan(IDPemesanan, NamaCustomer, NoTelpon, JumlahPemesanan, IDLokasi);
            MessageBox.Show(d);
            TampilData();
            Clear();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string IDPemesanan = textBoxID.Text;
            string NamaCustomer = textBoxNama.Text;
            string NoTelpon = textBoxTlf.Text;

            var d = service.editPemesanan(IDPemesanan, NamaCustomer, NoTelpon);
            MessageBox.Show(d);
            TampilData();
            Clear();
        }

        private void btHapus_Click(object sender, EventArgs e)
        {
            string IDPemesanan = textBoxID.Text;


            var d = service.deletePemesanan(IDPemesanan);
            MessageBox.Show(d);
            TampilData();
            Clear();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dtPemesanan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[0].Value);
            textBoxNama.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[1].Value);
            textBoxTlf.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[2].Value);
            textBoxJumlah.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[3].Value);
            textBoxIDLokasi.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[4].Value);

            textBoxJumlah.Enabled = false;
            textBoxIDLokasi.Enabled = false;

            btSimpan.Enabled = false;
            btUpdate.Enabled = true;
            btHapus.Enabled = true;

            textBoxID.Enabled = false;
        }

        public void TampilData()
        {
            var List = service.Pemesanan1();
            dtPemesanan.DataSource = List;
        }

        public void Clear()
        {
            textBoxID.Clear();
            textBoxNama.Clear();
            textBoxTlf.Clear();
            textBoxJumlah.Clear();
            textBoxIDLokasi.Clear();

            textBoxJumlah.Enabled = true;
            textBoxIDLokasi.Enabled = true;

            btSimpan.Enabled = true;
            btUpdate.Enabled = false;
            btHapus.Enabled = false;

            textBoxID.Enabled = true;
        }
    }
}
