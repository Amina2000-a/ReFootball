using FootballArea.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballArea
{
    public partial class Area_Dashboard : Form
    {
        FootballAreaDBEntities db = new FootballAreaDBEntities();

        Areas selectedSt;
        public Area_Dashboard()
        {
            InitializeComponent();
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstname.Text;
            string lastName = txtLastname.Text;
            string phone = txtPhone.Text;
            string stName = cmbAreaName.Text;
            string roomNumber = cmbRoomNumber.Text;
            DateTime startTime = dtgFrom.Value;
            DateTime endTime = dtgTo.Value;
            
            int phoneNumber;
            if (Extensions.isNotEmpty(new string[]{
                firstName,lastName,phone,stName,roomNumber
            }, string.Empty))
            {
                if (db.Rooms.Any(m => m.RoomNumber <= 12))
                {
                    if (int.TryParse(phone, out phoneNumber))
                    {
                        Rooms selectedRoom = db.Rooms.FirstOrDefault(r => r.RoomNumber.ToString() == roomNumber);
                        Areas selectedSt = db.Areas.FirstOrDefault(s => s.AreaName == stName);
                       decimal totalPrice = selectedSt.Price;

                        Customer newCus = new Customer()
                        {
                            Firstname = firstName,
                            Lastname = lastName,
                            Phone = Convert.ToString(phoneNumber)
                        };
                        db.Customer.Add(newCus);
                        db.SaveChanges();

                        Reservation rv = db.Reservation.Add(new Reservation
                        {
                            ReserveDateFrom = startTime,
                            ReserveDateTo = endTime,
                            CustomerID = newCus.ID,
                            AreaID = selectedSt.ID,
                            Price = (int)totalPrice
                        });
                        db.SaveChanges();
                        for (int i = 0; i < ckRoomList.Items.Count; i++)
                        {
                            string roomname = ckRoomList.Items[i].ToString();
                            int roomnumber = Convert.ToInt32(roomname.Substring(roomname.LastIndexOf("|") + 1));
                            db.Room_TO_Reservs.Add(new Room_TO_Reservs()
                            {
                                RoomID = roomnumber,
                                ReservID = rv.ID
                            });
                            db.SaveChanges();
                        }

                        MessageBox.Show("Reservation was added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblError.Text = "Please enter correct phone number";
                        lblError.Visible = true;
                        
                    }
                }
                else
                {
                    lblError.Text = "This room if full";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "Fill all the field!!!";
                lblError.Visible = true;
            }
        }

        private void cmbAreaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string AreaName = cmbAreaName.Text; ;
            if (AreaName != string.Empty)
            {
                selectedSt = db.Areas.First(s => s.AreaName == AreaName);
                lblPrice.Text = selectedSt.Price + "AZN";
                lblPrice.Visible = true;
            }
        }

        private void Area_Dashboard_Load(object sender, EventArgs e)
        {
            FillcmbAreaName();
            FillcmbRoomNumber();

        }

        private void FillcmbAreaName()
        {
            cmbAreaName.Items.AddRange(db.Areas.Select(sna => sna.AreaName).ToArray());
        }
        private void FillcmbRoomNumber()
        {
            cmbRoomNumber.Items.AddRange(db.Rooms.Select(r => r.RoomNumber.ToString()).ToArray());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void cmbRoomNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rmnumber = Convert.ToInt32(cmbRoomNumber.Text);
            Rooms selectedRoom = db.Rooms.FirstOrDefault(x => x.RoomNumber == rmnumber);
            if (!ckRoomList.Items.Contains(rmnumber))
            {
                ckRoomList.Items.Add(rmnumber+"|"+selectedRoom.ID,true);
            }
        }

        private void ckRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
