using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XoSo_VoQuocHung
{
    public partial class frmQuocHung : Form
    {
        public frmQuocHung()
        {
            InitializeComponent();
            thoiGian.Start();
        }

        private void quayDai1_Tick(object sender, EventArgs e)
        {
            var rand = new Random();
            // 0 < 10 100 in = 0,1s
            // <=10 10 *0.1s  = 1
            if(Cls_Hung.quayDai1 > 0 && Cls_Hung.quayDai1 <= Cls_Hung.thoiGianquay)
            {
                // 0 -- 99 1 01 10 02
                dai1giai8.Text = rand.Next(0, 99).ToString("D2");
                //0<10  - 5S 0 <= 50 5S
                //10<20 // 50  <= 50 *2  = 100 5S
            }else if(Cls_Hung.quayDai1 > Cls_Hung.thoiGianquay && Cls_Hung.quayDai1 <= Cls_Hung.thoiGianquay * 2)
            {
                dai1giai7.Text = rand.Next(0, 999).ToString("D3");
            }else if(Cls_Hung.quayDai1 > Cls_Hung.thoiGianquay*2 && Cls_Hung.quayDai1 <= Cls_Hung.thoiGianquay * 3)
            {
                dai1giai61.Text = rand.Next(0, 9999).ToString("D4");
                dai1giai62.Text = rand.Next(0, 9999).ToString("D4");
                dai1giai63.Text = rand.Next(0, 9999).ToString("D4");
            }else if(Cls_Hung.quayDai1 > Cls_Hung.thoiGianquay * 3 && Cls_Hung.quayDai1 <= Cls_Hung.thoiGianquay * 4) 
            {
                dai1giai5.Text = rand.Next(0, 9999).ToString("D4");
            }else if(Cls_Hung.quayDai1 > Cls_Hung.thoiGianquay * 4 && Cls_Hung.quayDai1 <= Cls_Hung.thoiGianquay * 5)
            {
                dai1giai41.Text = rand.Next(0, 99999).ToString("D5");
                dai1giai42.Text = rand.Next(0, 99999).ToString("D5");
                dai1giai43.Text = rand.Next(0, 99999).ToString("D5");
                dai1giai44.Text = rand.Next(0, 99999).ToString("D5");
                dai1giai45.Text = rand.Next(0, 99999).ToString("D5");
                dai1giai46.Text = rand.Next(0, 99999).ToString("D5");
                dai1giai47.Text = rand.Next(0, 99999).ToString("D5");
            }
            else if (Cls_Hung.quayDai1 > Cls_Hung.thoiGianquay * 5 && Cls_Hung.quayDai1 <= Cls_Hung.thoiGianquay * 6)
            {
                dai1giai31.Text = rand.Next(0, 99999).ToString("D5");
                dai1giai32.Text = rand.Next(0, 99999).ToString("D5");
            }
            else if (Cls_Hung.quayDai1 > Cls_Hung.thoiGianquay * 6 && Cls_Hung.quayDai1 <= Cls_Hung.thoiGianquay * 7)
            {
                dai1giai2.Text = rand.Next(0, 99999).ToString("D5");
            }
            else if (Cls_Hung.quayDai1 > Cls_Hung.thoiGianquay * 7 && Cls_Hung.quayDai1 <= Cls_Hung.thoiGianquay * 8)
            {
                dai1giai1.Text = rand.Next(0, 99999).ToString("D5");
            }
            else if (Cls_Hung.quayDai1 > Cls_Hung.thoiGianquay * 8 && Cls_Hung.quayDai1 <= Cls_Hung.thoiGianquay * 9)
            {
                dai1giaiDB.Text = rand.Next(0, 999999).ToString("D6");
            }
            if (Cls_Hung.quayDai1 > Cls_Hung.thoiGianquay * 10)
            {
                Cls_Hung.quayDai1 = 0;
                quayDai1.Stop();
            }
            Cls_Hung.quayDai1 += 1; // bien len 1  0.1s
        }

        private void quaySo_Click(object sender, EventArgs e)
        {
            Cls_Hung.thoiGianquay = datThoiGian.Value * 10;
            // 1 * 10 =S
            
            if(chkDai1.Checked && chkDai2.Checked)
            {
                quayDai1.Start();
                quayDai2.Start();
            }
            else if(chkDai1.Checked && !chkDai2.Checked)
            {
                quayDai1.Start();
            } else if(!chkDai1.Checked && chkDai2.Checked)
            {
                quayDai2.Start();
            }
            else 
            {
                MessageBox.Show("Vui lòng chọn đài quay");
            }

        }

        

        private void thoiGian_Tick(object sender, EventArgs e)
        {
            thoiGianHienTai.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnHenGio_Click(object sender, EventArgs e)
        {
            henGioQuay.Start();
            MessageBox.Show("Đã Hẹn Giờ Quay Số");
        }

        private void henGioQuay_Tick(object sender, EventArgs e)
        {
            String[] s = thoiGianHienTai.Text.Split(':');
            if(s[0] == henGio.Text && s[1]== henPhut.Text) 
            {
                henGioQuay.Stop();
                quaySo.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                if(tb_ghi.Text == "/")
                {
                MessageBox.Show("Tên File không được chứa ký tự /");
                return;
                }
                string a = tb_ghi.Text;
                string h = DateTime.Now.ToString("dd/MM/yyy--HH/mm/ss");
                String path = @"D:\C#\XoSo_VoQuocHung\XoSo_VoQuocHung\ketQuaXoSo\" + a + ".txt";
                FileStream file = File.Create(path);
                var ghi = new StreamWriter(file);
                ghi.WriteLine(dai1.Text);
                ghi.WriteLine("Ngày xổ :" + h);
                ghi.WriteLine("Giá Vé :" + cbbGiaVe.Text);
                ghi.WriteLine("Giải8" + " : " + dai1giai8.Text);
                ghi.WriteLine("Giải7" + " : " + dai1giai7.Text);
                ghi.WriteLine("Giải6" + " : " + dai1giai61.Text + " ," + dai1giai62.Text + " ," + dai1giai63.Text);
                ghi.WriteLine("Giải5" + " : " + dai1giai5.Text);
                ghi.WriteLine("Giải4" + " : " + dai1giai41.Text + " ," + dai1giai42.Text + " ," + dai1giai43.Text
                + " ," + dai1giai44.Text + " ," + dai1giai45.Text + " ," + dai1giai46.Text + " ," + dai1giai47.Text);
                ghi.WriteLine("Giải3" + " : " + dai1giai31.Text + " ," + dai1giai32.Text);
                ghi.WriteLine("Giải2" + " : " + dai1giai2.Text);
                ghi.WriteLine("Giải1" + " : " + dai1giai1.Text);
                ghi.WriteLine("Giải ĐB" + " : " + dai1giaiDB.Text);
                //============================================================//
                ghi.WriteLine();
                ghi.WriteLine(dai2.Text);
                ghi.WriteLine("Ngày xổ :" + h);
                ghi.WriteLine("Giá Vé :" + cbbGiaVe.Text);
                ghi.WriteLine("Giải8" + " : " + dai2giai8.Text);
                ghi.WriteLine("Giải7" + " : " + dai2giai7.Text);
                ghi.WriteLine("Giải6" + " : " + dai2giai61.Text + " ," + dai2giai62.Text + " ," + dai2giai63.Text);
                ghi.WriteLine("Giải5" + " : " + dai2giai5.Text);
                ghi.WriteLine("Giải4" + " : " + dai2giai41.Text + " ," + dai2giai42.Text + " ," + dai2giai43.Text
                + " ," + dai2giai44.Text + " ," + dai2giai45.Text + " ," + dai2giai46.Text + " ," + dai2giai47.Text);
                ghi.WriteLine("Giải3" + " : " + dai2giai31.Text + " ," + dai2giai32.Text);
                ghi.WriteLine("Giải2" + " : " + dai2giai2.Text);
                ghi.WriteLine("Giải1" + " : " + dai2giai1.Text);
                ghi.WriteLine("Giải ĐB" + " : " + dai2giaiDB.Text);
                ghi.Close();
                file.Close();
                MessageBox.Show("Ghi Kết Quả Thành Công");
            
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            String so = txtDo.Text;
            String trungGiai = "";
            if (so.Length < 6)
            {
                MessageBox.Show("Nhập đầy đủ 6 số trong vé để kiểm tra");
                return;
            }
            
            int sizeSo = so.Length;

            // 12 giai8 2so
            // ve so 7 so vd 1234567
            // so.substring(7-2 = 5)
            if(dai1giai8.Text.Equals(so.Substring(so.Length - dai1giai8.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 8 Miền Bắc: " + dai1giai8.Text + "\n";
            }
            if (dai1giai7.Text.Equals(so.Substring(so.Length - dai1giai7.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 7 Miền Bắc: " + dai1giai7.Text + "\n";
            }
            if (dai1giai61.Text.Equals(so.Substring(so.Length - dai1giai61.Text.Length)))      
            {
                trungGiai += "Bạn đã trúng giải 6 Miền Bắc: " + dai1giai61.Text + "\n";
            }
            if (dai1giai62.Text.Equals(so.Substring(so.Length - dai1giai62.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 6 Miền Bắc : " + dai1giai62.Text + "\n";
            }    
            if (dai1giai63.Text.Equals(so.Substring(so.Length - dai1giai63.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 6 Miền Bắc : " + dai1giai63.Text + "\n";
            }
            if (dai1giai5.Text.Equals(so.Substring(so.Length - dai1giai5.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 5 Miền Bắc: " + dai1giai5.Text + "\n";
            }
            if (dai1giai41.Text.Equals(so.Substring(so.Length - dai1giai41.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 4 Miền Bắc : " + dai1giai41.Text + "\n";
            }
            if (dai1giai42.Text.Equals(so.Substring(so.Length - dai1giai42.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 4 Miền Bắc: " + dai1giai42.Text + "\n";
            }
            if (dai1giai43.Text.Equals(so.Substring(so.Length - dai1giai43.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 4 Miền Bắc : " + dai1giai43.Text + "\n";
            }
            if (dai1giai44.Text.Equals(so.Substring(so.Length - dai1giai44.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 4 Miền Bắc : " + dai1giai44.Text + "\n";
            }
            if (dai1giai45.Text.Equals(so.Substring(so.Length - dai1giai45.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 4 Miền Bắc : " + dai1giai45.Text + "\n";
            }
            if (dai1giai46.Text.Equals(so.Substring(so.Length - dai1giai46.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 4 Miền Bắc : " + dai1giai46.Text + "\n";
            }
            if (dai1giai47.Text.Equals(so.Substring(so.Length - dai1giai47.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 4 Miền Bắc : " + dai1giai47.Text + "\n";
            }
            if (dai1giai31.Text.Equals(so.Substring(so.Length - dai1giai31.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 3 Miền Bắc : " + dai1giai31.Text + "\n";
            }
            if (dai1giai32.Text.Equals(so.Substring(so.Length - dai1giai32.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 3 Miền Bắc : " + dai1giai32.Text + "\n";
            }
            if (dai1giai2.Text.Equals(so.Substring(so.Length - dai1giai2.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 2 Miền Bắc : " + dai1giai2.Text + "\n";
            }
            if (dai1giai1.Text.Equals(so.Substring(so.Length - dai1giai1.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 1 Miền Bắc : " + dai1giai1.Text + "\n";
            }
            if (dai1giaiDB.Text.Equals(so.Substring(so.Length - dai1giaiDB.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải Đặc Biệt Miền Bắc: " + dai1giaiDB.Text + "\n";
            }

            //==========================================================================//

            if (dai2giai8.Text.Equals(so.Substring(so.Length - dai2giai8.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 8 Miền Trung : " + dai2giai8.Text + "\n";
            }
            if (dai2giai7.Text.Equals(so.Substring(so.Length - dai2giai7.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 7 Miền Trung : " + dai2giai7.Text + "\n";
            }
            if (dai2giai61.Text.Equals(so.Substring(so.Length - dai2giai61.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 6 Miền Trung : " + dai2giai61.Text + "\n";
            }
            if (dai2giai62.Text.Equals(so.Substring(so.Length - dai2giai62.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 6 Miền Trung  : " + dai2giai62.Text + "\n";
            }
            if (dai2giai63.Text.Equals(so.Substring(so.Length - dai2giai63.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 6 Miền Trung  : " + dai2giai63.Text + "\n";
            }
            if (dai2giai5.Text.Equals(so.Substring(so.Length - dai2giai5.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 5 Miền Trung  : " + dai2giai5.Text + "\n";
            }
            if (dai2giai41.Text.Equals(so.Substring(so.Length - dai2giai41.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 4 Miền Trung  : " + dai2giai41.Text + "\n";
            }
            if (dai2giai42.Text.Equals(so.Substring(so.Length - dai2giai42.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 4 Miền Trung  : " + dai2giai42.Text + "\n";
            }
            if (dai2giai43.Text.Equals(so.Substring(so.Length - dai2giai43.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 4 Miền Trung  : " + dai2giai43.Text + "\n";
            }
            if (dai2giai44.Text.Equals(so.Substring(so.Length - dai2giai44.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 4 Miền Trung  : " + dai2giai44.Text + "\n";
            }
            if (dai2giai45.Text.Equals(so.Substring(so.Length - dai2giai45.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 4 Miền Trung  : " + dai2giai45.Text + "\n";
            }
            if (dai2giai46.Text.Equals(so.Substring(so.Length - dai2giai46.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 4 Miền Trung  : " + dai2giai46.Text + "\n";
            }
            if (dai2giai47.Text.Equals(so.Substring(so.Length - dai2giai47.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 4 Miền Trung  : " + dai2giai47.Text + "\n";
            }
            if (dai2giai31.Text.Equals(so.Substring(so.Length - dai2giai31.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 3 Miền Trung  : " + dai2giai31.Text + "\n";
            }
            if (dai2giai32.Text.Equals(so.Substring(so.Length - dai2giai32.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 3 Miền Trung  : " + dai2giai32.Text + "\n";
            }
            if (dai2giai2.Text.Equals(so.Substring(so.Length - dai2giai2.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 2 Miền Trung  : " + dai2giai2.Text + "\n";
            }
            if (dai2giai1.Text.Equals(so.Substring(so.Length - dai2giai1.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải 1 Miền Trung  : " + dai2giai1.Text + "\n";
            }
            if (dai2giaiDB.Text.Equals(so.Substring(so.Length - dai2giaiDB.Text.Length)))
            {
                trungGiai += "Bạn đã trúng giải Đặc Biệt Miền Trung  : " + dai2giaiDB.Text + "\n";
            }

            if (trungGiai.Length == 0)
            {
                MessageBox.Show("Rất Tiết ,Chúc Bạn May Mắn LẦn Sau.");
            }
            else
            {
                MessageBox.Show(trungGiai);
            }

        }

        private void quayDai2_Tick(object sender, EventArgs e)
        {
            var rand2 = new Random();
            // 0 < 10 100 in = 0,1s
            // <=10 10 *0.1s  = 1
            if (Cls_Hung.quayDai2 > 0 && Cls_Hung.quayDai2 <= Cls_Hung.thoiGianquay)
            {
                // 0 -- 99 1 01 10 02
                dai2giai8.Text = rand2.Next(0, 99).ToString("D2");
                //0<10  - 5S 0 <= 50 5S
                //10<20 // 50  <= 50 *2  = 100 5S
            }
            else if (Cls_Hung.quayDai2 > Cls_Hung.thoiGianquay && Cls_Hung.quayDai2 <= Cls_Hung.thoiGianquay * 2)
            {
                dai2giai7.Text = rand2.Next(0, 999).ToString("D3");
            }
            else if (Cls_Hung.quayDai2 > Cls_Hung.thoiGianquay * 2 && Cls_Hung.quayDai2 <= Cls_Hung.thoiGianquay * 3)
            {
                dai2giai61.Text = rand2.Next(0, 9999).ToString("D4");
                dai2giai62.Text = rand2.Next(0, 9999).ToString("D4");
                dai2giai63.Text = rand2.Next(0, 9999).ToString("D4");
            }
            else if (Cls_Hung.quayDai2 > Cls_Hung.thoiGianquay * 3 && Cls_Hung.quayDai2 <= Cls_Hung.thoiGianquay * 4)
            {
                dai2giai5.Text = rand2.Next(0, 9999).ToString("D4");
            }
            else if (Cls_Hung.quayDai2 > Cls_Hung.thoiGianquay * 4 && Cls_Hung.quayDai2 <= Cls_Hung.thoiGianquay * 5)
            {
                dai2giai41.Text = rand2.Next(0, 99999).ToString("D5");
                dai2giai42.Text = rand2.Next(0, 99999).ToString("D5");
                dai2giai43.Text = rand2.Next(0, 99999).ToString("D5");
                dai2giai44.Text = rand2.Next(0, 99999).ToString("D5");
                dai2giai45.Text = rand2.Next(0, 99999).ToString("D5");
                dai2giai46.Text = rand2.Next(0, 99999).ToString("D5");
                dai2giai47.Text = rand2.Next(0, 99999).ToString("D5");
            }
            else if (Cls_Hung.quayDai2 > Cls_Hung.thoiGianquay * 5 && Cls_Hung.quayDai2 <= Cls_Hung.thoiGianquay * 6)
            {
                dai2giai31.Text = rand2.Next(0, 99999).ToString("D5");
                dai2giai32.Text = rand2.Next(0, 99999).ToString("D5");
            }
            else if (Cls_Hung.quayDai2 > Cls_Hung.thoiGianquay * 6 && Cls_Hung.quayDai2 <= Cls_Hung.thoiGianquay * 7)
            {
                dai2giai2.Text = rand2.Next(0, 99999).ToString("D5");
            }
            else if (Cls_Hung.quayDai2 > Cls_Hung.thoiGianquay * 7 && Cls_Hung.quayDai2 <= Cls_Hung.thoiGianquay * 8)
            {
                dai2giai1.Text = rand2.Next(0, 99999).ToString("D5");
            }
            else if (Cls_Hung.quayDai2 > Cls_Hung.thoiGianquay * 8 && Cls_Hung.quayDai2 <= Cls_Hung.thoiGianquay * 9)
            {
                dai2giaiDB.Text = rand2.Next(0, 999999).ToString("D6");
            }
            if (Cls_Hung.quayDai2 > Cls_Hung.thoiGianquay * 10)
            {
                Cls_Hung.quayDai2 = 0;
                quayDai2.Stop();
            }
            Cls_Hung.quayDai2 += 1; // bien len 1  0.1s
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dai1giai8.Text = "--";
            dai1giai7.Text = "--";
            dai1giai61.Text = "--";
            dai1giai62.Text = "--";
            dai1giai63.Text = "--";
            dai1giai5.Text = "--";
            dai1giai41.Text = "--";
            dai1giai42.Text = "--";
            dai1giai43.Text = "--";
            dai1giai44.Text = "--";
            dai1giai45.Text = "--";
            dai1giai46.Text = "--";
            dai1giai47.Text = "--";
            dai1giai31.Text = "--";
            dai1giai32.Text = "--";
            dai1giai2.Text = "--";
            dai1giai1.Text = "--";
            dai1giaiDB.Text = "--";

            dai2giai8.Text = "--";
            dai2giai7.Text = "--";
            dai2giai61.Text = "--";
            dai2giai62.Text = "--";
            dai2giai63.Text = "--";
            dai2giai5.Text = "--";
            dai2giai41.Text = "--";
            dai2giai42.Text = "--";
            dai2giai43.Text = "--";
            dai2giai44.Text = "--";
            dai2giai45.Text = "--";
            dai2giai46.Text = "--";
            dai2giai47.Text = "--";
            dai2giai31.Text = "--";
            dai2giai32.Text = "--";
            dai2giai2.Text = "--";
            dai2giai1.Text = "--";
            dai2giaiDB.Text = "--";
        }
    }
}
