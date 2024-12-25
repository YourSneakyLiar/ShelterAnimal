namespace ShelterAnimalApi.Contracts.Donation
{
    public class GetDonationResponse
    {
        public int DonationId { get; set; }
        public string DonorName { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonationDate { get; set; }
    }
}
