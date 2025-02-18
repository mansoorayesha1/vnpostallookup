using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

class Program
{
    static Dictionary<string, string> postalCodes;

    static void Main()
    {
        LoadPostalCodes();
        Console.WriteLine("\nChào mừng bạn đến với hệ thống tra cứu mã bưu chính Việt Nam!\n");
        
        while (true)
        {
            Console.Write("Nhập tên tỉnh/thành phố (hoặc 'exit' để thoát): ");
            string input = Console.ReadLine().Trim();

            if (input.ToLower() == "exit") 
            {
                Console.WriteLine("Cảm ơn bạn đã sử dụng hệ thống. Hẹn gặp lại!");
                break;
            }

            if (postalCodes.TryGetValue(input, out string postalCode))
            {
                Console.WriteLine($"Mã bưu chính của {input} là: {postalCode}\n");
            }
            else
            {
                Console.WriteLine("Không tìm thấy mã bưu chính. Hãy thử lại hoặc kiểm tra chính tả.\n");
            }
        }
    }

    static void LoadPostalCodes()
    {
        string json = @"{
            \"Hà Nội\": \"100000\",
            \"Hồ Chí Minh\": \"700000\",
            \"Đà Nẵng\": \"550000\",
            \"Hải Phòng\": \"180000\",
            \"Cần Thơ\": \"900000\",
            \"Bắc Ninh\": \"790000\",
            \"Quảng Ninh\": \"200000\",
            \"Lào Cai\": \"330000\",
            \"Thanh Hóa\": \"400000\",
            \"Nghệ An\": \"430000\",
            \"Huế\": \"530000\",
            \"Khánh Hòa\": \"650000\",
            \"Bình Dương\": \"820000\",
            \"Đồng Nai\": \"810000\",
            \"Vũng Tàu\": \"790000\"
        }";

        postalCodes = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        Console.WriteLine("Dữ liệu mã bưu chính đã được tải thành công!\n");
    }
}
