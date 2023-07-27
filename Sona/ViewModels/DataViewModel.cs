using Sona.Models;

namespace Sona.ViewModels
{
    public class DataViewModel
    {
        public List<Order> OrderData { get; set; }
        public List<Room> RoomData { get; set; }
        public List<Testimonial> TestimonialData { get; set; }
        public List<News> NewsData { get; set; }

        public DataViewModel(List<Order> orderList, List<Room> roomList, List<Testimonial> testimonialList, List<News> newsData)
        {
            OrderData = orderList;
            RoomData = roomList;
            TestimonialData = testimonialList;
            NewsData = newsData;
        }
    }
}
