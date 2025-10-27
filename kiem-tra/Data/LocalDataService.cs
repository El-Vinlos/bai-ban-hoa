using System.Text.Json;
using kiem_tra.Models;

namespace kiem_tra.Data
{
    public static class LocalDataService
    {
        private static readonly string DataPath = Path.Combine("App_Data", "sanpham.json");

        public static List<SanPham> GetSanPhams()
        {
            if (!File.Exists(DataPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(DataPath)!);
                var sampleData = GetSampleData();
                SaveSanPhams(sampleData);
                return sampleData;
            }

            var json = File.ReadAllText(DataPath);
            return JsonSerializer.Deserialize<List<SanPham>>(json) ?? new List<SanPham>();
        }

        public static void SaveSanPhams(List<SanPham> sanPhams)
        {
            var json = JsonSerializer.Serialize(sanPhams, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(DataPath, json);
        }

        private static List<SanPham> GetSampleData() => new()
        {
            new SanPham { MaSp = 1, TenSp = "Hoa Hồng Đỏ", MoTa = "test", MaLoaiSp = 1, SoLuong = 12, DonGia = 1200000, Hinh = "rose.webp" },
            new SanPham { MaSp = 2, TenSp = "Hoa Lilac", MoTa = "test", MaLoaiSp = 2, SoLuong = 8, DonGia = 950000, Hinh = "lilac.jpg" },
            new SanPham { MaSp = 3, TenSp = "Hoa Hướng Dương", MoTa = "test", MaLoaiSp = 3, SoLuong = 10, DonGia = 850000, Hinh = "sunflower.webp" },
            new SanPham { MaSp = 4, TenSp = "Lily Trắng", MoTa = "test", MaLoaiSp = 4, SoLuong = 6, DonGia = 1100000, Hinh = "lily.webp" },
            new SanPham { MaSp = 5, TenSp = "test", MaLoaiSp = 4, SoLuong = 6, DonGia = 1100000, Hinh = "test.webp" }
        };
    }
}
