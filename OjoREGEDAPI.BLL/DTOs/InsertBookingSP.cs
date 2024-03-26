namespace OjoREGEDAPI.BLL.DTOs
{
    public class InsertBookingSP
    {

        public int Customer_ID { get; set; }
        public int Employee_Schedule_ID { get; set; }
        public decimal Weight { get; set; }
        public string Size { get; set; }
        public string Order_Instruction { get; set; }
    }
}
