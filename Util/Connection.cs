using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.Util
{
    internal class Connection
    {
        private static string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private static string databasePath = Path.Combine(userPath, "source", "repos", "QuanLyRapChieuPhim", "QuanLyRapChieuPhim.mdf");
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + databasePath + ";Integrated Security=True";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns>Trả về số lượng bản ghi được tìm thấy từ câu lệnh SELECT</returns>
        public static int ExecuteScalarInt32(string query, (string, object)[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                                cmd.Parameters.AddWithValue(param.Item1, param.Item2);
                        }
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return 0;
        }

        public static object ExecuteScalar(string query, (string, object)[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                                cmd.Parameters.AddWithValue(param.Item1, param.Item2);
                        }
                        return cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns>Trả về TRUE nếu câu lệnh thực thi thành công và ngược lại.</returns>
        public static bool ExcuteNonQuery(string query, (string, object)[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                                cmd.Parameters.AddWithValue(param.Item1, param.Item2);
                        }
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns>Trả về một bảng với câu truy vấn đã gửi. Nếu lỗi sẽ trả về null</returns>
        public static DataTable GetDataTable(string query, (string, object)[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                                command.Parameters.AddWithValue(param.Item1, param.Item2);
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns>Trả về một bảng với câu truy vấn đã gửi. Nếu lỗi sẽ trả về null</returns>
        public static DataTable GetDataTable(string query, (string, object)[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))// bắt đầu truy vấn
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                                command.Parameters.AddWithValue(param.Item1, param.Item2);
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command)) //chuyển dữ liệu về
                        {
                            DataTable dt = new DataTable(); // tạo kho dữ liệu ảo
                            adapter.Fill(dt); // đổ dữ liệu từ dt vào kho
                            return dt; // trả về kho dữ liệu
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return null;
        }

		public static SqlTransaction BeginTransaction(out SqlConnection connection)
		{
			connection = new SqlConnection(connectionString);
			connection.Open();
			return connection.BeginTransaction();
		}

		// Phương thức thực thi truy vấn trong phạm vi của giao dịch
		public static bool ExecuteWithTransaction(string query, SqlTransaction transaction, (string, object)[] parameters = null)
		{
			using (SqlCommand cmd = new SqlCommand(query, transaction.Connection, transaction))
			{
				if (parameters != null)
				{
					foreach (var param in parameters)
						cmd.Parameters.AddWithValue(param.Item1, param.Item2);
				}
				cmd.ExecuteNonQuery();
				return true;
			}
		}

	}
}
