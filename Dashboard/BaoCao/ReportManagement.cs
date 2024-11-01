using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using QuanLyRapChieuPhim.Util;
using System.Collections;


namespace QuanLyRapChieuPhim.BaoCao
{
    public partial class ReportManagement : Form
    {

        private LiveCharts.WinForms.CartesianChart chart; // Biến chứa biểu đồ


        private LiveCharts.WinForms.CartesianChart chart2;

        private LiveCharts.WinForms.CartesianChart chart3; // Biểu đồ cho panel3
        public ReportManagement()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void baoCao_Load(object sender, EventArgs e)
        {
            // Khởi tạo biểu đồ và gán vào panel
            chart = new LiveCharts.WinForms.CartesianChart { Dock = DockStyle.Fill };
            panel1.Controls.Add(chart);

            chart2 = new LiveCharts.WinForms.CartesianChart { Dock = DockStyle.Fill };
            panel2.Controls.Add(chart2);

            chart3 = new LiveCharts.WinForms.CartesianChart { Dock = DockStyle.Fill };
            panel3.Controls.Add(chart3);

            // Gọi các hàm tải dữ liệu cho biểu đồ
            LoadChartData();            // Biểu đồ theo thể loại phim (panel1)
            LoadChartByTopScreenings(); // Biểu đồ top 5 suất chiếu (panel2)
            LoadChartByTopMovies();     // Biểu đồ top 10 phim (panel3)
        }

        // 3. Biểu đồ top 10 bộ phim được xem nhiều nhất (panel3)
        private void LoadChartByTopMovies()
        {
            var topMoviesChart = new LiveCharts.WinForms.CartesianChart
            {
                DisableAnimations = true,  // Disable animations to reduce extra padding
                Dock = DockStyle.Fill
            };

            try
            {
                string query = @"
                    SELECT TOP 10 
                        P.TenPhim,  P.MaPhim,
                        COUNT(V.MaVe) AS SoLuotXem
                    FROM 
                        VeXemPhim V
                        JOIN SuatChieu SC ON V.MaSuatChieu = SC.MaSuatChieu
                        JOIN Phim P ON SC.MaPhim = P.MaPhim
                    GROUP BY 
                        P.MaPhim,  TenPhim
                    ORDER BY 
                        SoLuotXem DESC";

                DataTable data = Connection.GetDataTable(query, null);

                SeriesCollection series = new SeriesCollection();
                ChartValues<int> values = new ChartValues<int>();
                string[] labels = new string[data.Rows.Count];

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    values.Add(Convert.ToInt32(data.Rows[i]["SoLuotXem"]));
                    labels[i] = data.Rows[i]["TenPhim"].ToString();
                }

                chart3.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Số lượt xem",
                        Values = values,
                            Fill = System.Windows.Media.Brushes.Red,
                             MinWidth = 100
                    }
                };



                chart3.AxisX.Add(new Axis
                {
                    Title = "Tên phim",
                    Labels = labels,
                    LabelsRotation = 15, // Đặt góc nghiêng cho nhãn
                    Separator = new Separator { Step = 1 } // Hiển thị cách đều mỗi 2 nhãn

                });

                chart3.AxisY.Add(new Axis
                {
                    Title = "Số lượt xem"
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadChartData()
        {
            try
            {
                // Câu truy vấn SQL lấy top 5 thể loại phim được xem nhiều nhất
                string query = @"
                    SELECT TOP 5 
                         LP.MaLoaiPhim, LP.TenLoaiPhim, 
                        COUNT(V.MaVe) AS SoLuotXem
                    FROM 
                        VeXemPhim V
                        JOIN SuatChieu SC ON V.MaSuatChieu = SC.MaSuatChieu
                        JOIN Phim P ON SC.MaPhim = P.MaPhim
                        JOIN Phim_LoaiPhim PLP ON P.MaPhim = PLP.MaPhim
                        JOIN LoaiPhim LP ON PLP.MaLoaiPhim = LP.MaLoaiPhim
                    GROUP BY 
                         LP.TenLoaiPhim, LP.MaLoaiPhim
                    ORDER BY 
                        SoLuotXem DESC";

                // Sử dụng lớp Connection để lấy dữ liệu từ cơ sở dữ liệu
                DataTable data = Connection.GetDataTable(query, null);

                // Biến lưu dữ liệu cho biểu đồ
                SeriesCollection series = new SeriesCollection();
                ChartValues<int> values = new ChartValues<int>();
                string[] labels = new string[data.Rows.Count];
                int index = 0;

                // Lặp qua các hàng dữ liệu từ DataTable và thêm vào biểu đồ
                foreach (DataRow row in data.Rows)
                {
                    values.Add(Convert.ToInt32(row["SoLuotXem"]));
                    labels[index] = row["TenLoaiPhim"].ToString();
                    index++;
                }

                // Tạo series cột cho biểu đồ
                ColumnSeries columnSeries = new ColumnSeries
                {
                    Title = "Số lượt xem",
                    Values = values,
                    Fill = System.Windows.Media.Brushes.Red, // Chuyển cột thành màu đỏ
                                                             //DataLabels = true, // Hiển thị nhãn trên các cột
                                                             //LabelsPosition = LiveCharts.BarLabelPosition.Middle // Hiển thị tên giữa các cột
                };

                // Thêm series vào biểu đồ
                series.Add(columnSeries);

                // Gán series và labels cho biểu đồ
                chart.Series = series;

                // Thiết lập trục X (Tên thể loại phim)
                chart.AxisX.Add(new Axis
                {
                    Title = "Thể loại phim",
                    Labels = labels,
                    LabelsRotation = 15, // Đặt góc nghiêng cho nhãn
                    Separator = new Separator { Step = 1 } // Hiển thị cách đều mỗi 2 nhãn
                });

                // Thiết lập trục Y (Số lượt xem)
                chart.AxisY.Add(new Axis
                {
                    Title = "Số lượt xem"
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void LoadChartByTopScreenings()
        {
            try
            {
                string query = @"
                    SELECT TOP 5 
                        SC.MaSuatChieu, 
                        COUNT(V.MaVe) AS SoVeBanDuoc
                    FROM 
                        VeXemPhim V
                        JOIN SuatChieu SC ON V.MaSuatChieu = SC.MaSuatChieu
                    GROUP BY 
                        SC.MaSuatChieu
                    ORDER BY 
                        SoVeBanDuoc DESC";

                DataTable data = Connection.GetDataTable(query, null);

                // Kiểm tra null
                if (data == null || data.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị biểu đồ top suất chiếu.");
                    return;
                }

                SeriesCollection series = new SeriesCollection();
                ChartValues<int> values = new ChartValues<int>();
                string[] labels = new string[data.Rows.Count];
                int index = 0;

                foreach (DataRow row in data.Rows)
                {
                    values.Add(Convert.ToInt32(row["SoVeBanDuoc"]));
                    labels[index] = "Suất " + row["MaSuatChieu"].ToString();
                    index++;
                }

                ColumnSeries columnSeries = new ColumnSeries
                {
                    Title = "Số vé bán được",

                    Values = values,
                    Fill = System.Windows.Media.Brushes.Red
                };

                series.Add(columnSeries);

                chart2.Series = series;

                chart2.AxisX.Add(new Axis
                {
                    Title = "Suất chiếu",
                    Labels = labels,
                    LabelsRotation = 15, // Đặt góc nghiêng cho nhãn
                    Separator = new Separator { Step = 1 } // Hiển thị cách đều mỗi 2 nhãn
                });
                chart2.AxisY.Add(new Axis
                {
                    Title = "Số vé bán được"
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }


}
