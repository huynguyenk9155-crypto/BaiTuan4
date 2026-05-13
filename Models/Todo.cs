using System.ComponentModel;

namespace BaiTuan3.Models
{
    public class Todo
    {
        [DisplayName("Mã công việc")]
        public int Id { get; set; }

        [DisplayName("Tên công việc")]
        public string Title { get; set; } = string.Empty;

        [DisplayName("Trạng thái hoàn thành")]
        public bool IsCompleted { get; set; }
    }
}
