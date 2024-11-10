using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.Util
{
    internal class SharedData
    {
        private static readonly Dictionary<string, object> data = new Dictionary<string, object>();
        public static void SetValue(string key, object value)
        {
            data[key] = value;
        }
        public static object GetValue(string key)
        {
            if (data.TryGetValue(key, out _))
                return data[key];
            return null;
        }
    }
}
