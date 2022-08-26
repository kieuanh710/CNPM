using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLKS
{
    public partial class fRoom : Form
    {
        public fRoom()
        {
            InitializeComponent();
            LoadCategory();


        }

        void addRoom()
        {

            int s = getIDcategoryRoom();
            string query = @"INSERT INTO hr.PHONG ( TenPhong, MaLoaiPhong,  GhiChu) VALUES (N'" + txtNameRoom.Text + @"',N'" + s + @"',N'" + txtNote.Text + @"')";
            DataProvider data = new DataProvider();
            data.ExecuteNonQuery(query);
        }

        int getIDcategoryRoom()
        {
            string name = cbCategoryRoom.Text.ToString();
            string query = "EXEC USP_GetIDByCategory  @NameCategory ";
            DataProvider data = new DataProvider();
            int s = (int)data.ExecuteScalar(query, new object[] { name });

            return s;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            fmnRoom b = new fmnRoom();
            this.Hide();
            b.ShowDialog();


        }

        void LoadCategory()

        {
            List<CategoryRoomDTO> categoryRoomList = CategoryRoomDAO.Instance.LoadCategoryRoomList1();
            cbCategoryRoom.DataSource = categoryRoomList;
            cbCategoryRoom.DisplayMember = "Name";
            cbCategoryRoom.ValueMember = "Name";
            cbPrice.DataSource = categoryRoomList;
            cbPrice.DisplayMember = "Price";

        }
        void LoadPriceByCategory(string name)
        {
            string query = "EXEC USP_GetPriceByCategory  @NameCategory ";
            DataProvider data = new DataProvider();
            data.ExecuteNonQuery(query, new object[] { name });
        }

        private void cbCategoryRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            CategoryRoomDTO selected = cb.SelectedItem as CategoryRoomDTO;
            name = selected.Name;
            LoadPriceByCategory(name);

        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            addRoom();
            uptPrice();
            MessageBox.Show("Thành công!");
            fmnRoom a = new fmnRoom();
            this.Hide();
            a.ShowDialog();


        }
        void uptPrice()
        {
            string category = cbCategoryRoom.Text;
            string price;
            int idCategory = 0;

            List<CategoryRoomDTO> categoryRoomList = CategoryRoomDAO.Instance.LoadCategoryRoomList();
            foreach (CategoryRoomDTO item in categoryRoomList)
            {
                if (String.Compare(category, item.Name, true) == 0)
                {
                    price = cbPrice.Text;
                    idCategory = item.ID;
                    string query = "EXEC   USP_UpdatePrice @ID , @price ";
                    DataProvider data = new DataProvider();
                    data.ExecuteNonQuery(query, new object[] { idCategory, price });

                }
            }
        }
    }


}
