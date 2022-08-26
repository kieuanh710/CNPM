using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace QLKS
{
    public partial class fmnRoom : Form
    {
        public fmnRoom()
        {
            InitializeComponent();
            loadRoom();
            LoadCategory();
        }


        void LoadCategory()

        {
            List<CategoryRoomDTO> categoryRoomList = CategoryRoomDAO.Instance.LoadCategoryRoomList1();
            cbCategory.DataSource = categoryRoomList;
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Name";
            cbPrice.DataSource = categoryRoomList;
            cbPrice.DisplayMember = "Price";

        }
        void loadRoom()
        {
            List<RoomDTO> roomList = RoomDAO.Instance.LoadRoomList();
            foreach (RoomDTO item in roomList)
            {
                Button btn = new Button() { Width = RoomDAO.RoomWidth, Height = RoomDAO.RoomHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += Btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Turquoise;


                        break;
                    default:
                        btn.BackColor = Color.LightSeaGreen;

                        break;
                }


                int x = item.Category;


                flpRoom.Controls.Add(btn);

            }
        }
        void showInfo(int id)
        {
            string query = "EXEC USP_GetRoomInFo @ID";
            DataProvider data = new DataProvider();
            dgwInfo.DataSource = data.ExecuteQuery(query, new object[] { id });


        }

        void Btn_Click(object sender, EventArgs e)
        {
            showRoom((sender as Button).Tag as RoomDTO);
            int roomID = ((sender as Button).Tag as RoomDTO).ID;
            showInfo(roomID);
            string s = ((sender as Button).Tag as RoomDTO).Status;
            if (s == "Có người") { btnMultiUse.Text = "Thanh toán"; }
            else { btnMultiUse.Text = "Thuê phòng"; }


        }
        void showRoom(RoomDTO b)
        {
            txbIdRoom.Text = b.ID.ToString();
            txbNameRoom.Text = b.Name;
            txbStatus.Text = b.Status;
            List<CategoryRoomDTO> categoryRoomList = CategoryRoomDAO.Instance.LoadCategoryRoomList();
            foreach (CategoryRoomDTO item in categoryRoomList)
            {
                if (b.Category == item.ID)
                {
                    cbCategory.Text = item.Name;
                    cbPrice.Text = item.Price.ToString();
                }


            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            fRoom r = new fRoom();
            this.Hide();
            r.ShowDialog();

        }

        private void deleteRoom_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa phòng?", "Thông báo", MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                delRoom();
                flpRoom.Controls.Clear();
                loadRoom();

            }

        }
        void delRoom()
        {
            string id = txbIdRoom.Text;
            string query = "EXEC  USP_DeleteRoom  @ID";
            DataProvider data = new DataProvider();
            data.ExecuteNonQuery(query, new object[] { id });


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            uptRoom();
            uptCategoryRoom();
            uptPrice();
            MessageBox.Show("Thành công. Click lại vào ô phòng để reload lại thông tin!");
            flpRoom.Controls.Clear();
            loadRoom();

        }
        void uptRoom()
        {
            string id = txbIdRoom.Text;
            string nameRoom = txbNameRoom.Text;

            string query = "EXEC  USP_UpdateRoom  @ID , @NAME";
            DataProvider data = new DataProvider();
            data.ExecuteNonQuery(query, new object[] { id, nameRoom });


        }
        void uptCategoryRoom()
        {
            string id = txbIdRoom.Text;

            string category = cbCategory.Text;
            int idCategory = 0;
            int flag = 0;
            List<CategoryRoomDTO> categoryRoomList = CategoryRoomDAO.Instance.LoadCategoryRoomList();
            foreach (CategoryRoomDTO item in categoryRoomList)
            {

                if (String.Compare(category, item.Name, true) == 0)
                {
                    flag = 1;
                    idCategory = item.ID;
                }
            }
            if (flag == 1)
            {
                string query = "EXEC   USP_UpdateCategoryRoom  @ID , @category ";
                DataProvider data = new DataProvider();
                data.ExecuteNonQuery(query, new object[] { id, idCategory });

            }
        }

        void uptPrice()
        {
            string category = cbCategory.Text;
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
