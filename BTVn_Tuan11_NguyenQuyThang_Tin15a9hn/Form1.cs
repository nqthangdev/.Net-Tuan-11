using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTVn_Tuan11_NguyenQuyThang_Tin15a9hn
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection($@"Data Source=DESKTOP-LHV9DSP;Initial Catalog=dbQuanLySV;Integrated Security=True");
        DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        void loaddl()
        {
            txtMaNv.DataBindings.Clear();
            txtHoTen.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Clear();
            lstboxPhong.DataBindings.Clear();

            SqlCommand cmd = new SqlCommand($@"select MaNV, HoTen, NgaySinh, HeSoLuong, ChucVu, Phong.MaPhong as MaPhong, TenPhong from Phong, NhanVien where Phong.MaPhong = NhanVien.MaPhong", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            txtMaNv.DataBindings.Add("Text", dt, "MaNV");
            txtHoTen.DataBindings.Add("Text", dt, "HoTen");
            dtpNgaySinh.DataBindings.Add("Value", dt, "NgaySinh");
            txtHeSoLuong.DataBindings.Add("Text", dt, "HeSoLuong");
            txtChucVu.DataBindings.Add("Text", dt, "ChucVu");
            lstboxPhong.DataBindings.Add("SelectedValue", dt, "MaPhong");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            loaddl();

            SqlDataAdapter da = new SqlDataAdapter("select MaPhong, TenPhong from Phong", con);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            lstboxPhong.DataSource = dt1;
            lstboxPhong.DisplayMember = "TenPhong";
            lstboxPhong.ValueMember = "MaPhong";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Close();
        }
    }
}
