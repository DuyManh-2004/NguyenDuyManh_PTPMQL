# NetCoreAPI
BUOI 3
1. CẤU TRÚC THƯ MỤC CỦA DỰ ÁN .NET MVC :
    - Controllers : Thư mục chứa các controller (code để xử lý yêu cầu từ view gửi về)
    - Models : Chứa các lớp đại diện cho CSDL của ứng dụng
    - View : Thư mục chứa các thành phần hiển thị giao diện người dùng 
    - wwwroot : Thư mục chứa các file của dự án (HTML, CSS, JS)
    - appsettings.json , Program.cs : file chứa code cấu hình dự án
2. Định tuyến trong MVC 
    - MVC sẽ gọi bộ điều khiển (Controller) và các hành động bên trong (Action) thông qua URL
    - Logic định tuyến MVC sử dụng dạng: /[Controller]/[Action]/[Parameters]
    - Định tuyến được cấu hình trong file Program.cs: 
                    app.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
3. TÌM HIỂU VỀ NAMESPACE TRONG C#
    - Là một cơ chế dùng để tổ chức và phân nhóm các lớp (class), interface, struct, enum...
    - Mục đích chính:
        + Tránh trùng tên giữa các class
        + Giúp code dễ quản lý, dễ đọc, dễ bảo trì
        + Phân chai rõ ràng các module trong project lớn
4. Controller trong MVC : 
    - Tên của Controller bắt buộc phải có phần hậu tố Controller: Ví dụ StudentController, PersonController
    - Nằm trong thư mục Controllers
    - Nhiệm vụ của Controller:
        + Xử lý các yêu cầu của người dùng gửi tới từ View.
        + Truy xuất dữ liệu trong cơ sở dữ liệu.
        + Gọi các mẫu View và trả về dữ liệu
    - Mặc định khi tạo project sẽ có HomeController
    - Trong controller sẽ chứa các action (ví dụ: Index, Privacy), mỗi action sẽ thực thi một nhiệm vụ cụ thể (trả về các view tương ứng)
5. View trong MVC
    - Có phần mở rộng là “.cshtml”
    - Nằm trong thư mục Views/Controler_Name (tương ứng với HelloWorldController sẽ có thư mục HelloWorld trong thư mục Views)
    - Nhiệm vụ của View: Cung cấp giao diện người dùng (HTML) bằng C#


BUOI 4
1. Viewbag trong MVC
    - ViewBag là dynamic object
    - Dùng để gửi dữ liệu 1 chiều: Controller → View    
    - Không cần tạo Model riêng
    - Tồn tại chỉ trong 1 request
2. Vi du su dung ViewBag
    - Trong Controller :
        + public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Hello Nguyễn Duy Mạnh - MSSV: 2221050029";
            return View();
        }
    }
    - Trong View :
        + <h2>@ViewBag.Message</h2>
3. Tìm hiểu về gửi nhận dữ liệu giữa View và Controller thông qua Submit form.
    - Gui du lieu tu view len controller : 
        + <form asp-action="Index">
            <label for=""> Nhap ho ten :</label>
            <input type="text" name="Fullname">
            <label for="">Nhap dia chi :</label>
            <input type="text" name="Address">
            <input type="submit" value="gui du lieu">
            </form>
        + Thẻ form: dung để chứa các phần từ nhập liệu từ người dung.
            asp-action="Index": chỉ định dữ liệu được gửi từ View lên action Index
            input type="text": các ô để nhập dữ liệu gửi từ View
            asp-action="submit": nút lệnh để thực hiện gửi dữ liệu từ form lên action ở controller
            name của thẻ input: sử dụng để khớp với các thuộc tính ở phương thức Index trên Controller
    - Controller nhan du lieu tu view gui len :
        + [HttpPost]
            public IActionResult Index (string Fullname , string Address)
        {
            string strOutput = " Xin chao " + Fullname + " den tu " + Address;
            ViewBag.Message = strOutput;
            return View();
        }
        + HttpPost: sử dụng để chỉ định phương thức sẽ nhận dữ liệu từ View gửi lên.
        2 thuộc tính FullName và Address của action Index: sử dụng để lưu dữ liệu từ View gửi lên, tên của 2 thuộc tính chính là name của các thẻ input muốn gửi dữ liệu trên View.
        ViewBag: là phương thức hỗ trợ gửi dữ liệu từ Controller tới View
    - Hien thi du lieu Controller gui ve View
        + <h1>@ViewBag.Message</h1>
