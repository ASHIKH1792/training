namespace DManage.SystemManagement.Application.ResponseDto
{
    public class WareHouseNodeDto
    {
        public int Id { get; set; }

        public WareHouseDto WareHouse { get; set; }

        public NodeDto Node { get; set; }
    }
}
