namespace DManage.SystemManagement.Application.ResponseDto
{
    public class PalletDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public long Quantity { get; set; }
        public ProductTypeDto ProductType { get; set; }
    }
}
