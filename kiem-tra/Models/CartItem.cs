namespace kiem_tra.Models;

public class CartItem
{
    public int SanPhamId { get; set; }
    public string TenSp { get; set; }
    public string Hinh { get; set; }
    public decimal DonGia { get; set; }
    public int SoLuong { get; set; }
    public decimal ThanhTien => DonGia * SoLuong;
}
