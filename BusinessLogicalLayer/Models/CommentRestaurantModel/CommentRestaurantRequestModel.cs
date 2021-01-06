namespace BusinessLogicalLayer.Models.CommentRestaurantModel
{
    public class CommentRestaurantRequestModel
    {
        public string Commentary { get; set; }
        public int UserId { get; set; }
        public bool IsGood { get; set; }
    }
}
