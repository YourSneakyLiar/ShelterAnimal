namespace ShelterAnimalApi.Contracts.Donation
{
    public class UpdateDonationRequest
    {
        public string DonorName { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonationDate { get; set; }
    }
}
