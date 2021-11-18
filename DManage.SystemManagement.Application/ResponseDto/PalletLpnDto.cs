namespace DManage.SystemManagement.Application.ResponseDto
{
    public class PalletLpnDto
    {
        public int Id { get; set; }
        public PalletDto Pallet { get; set; }

        public LpnDto Lpn { get; set; }
    }
}
