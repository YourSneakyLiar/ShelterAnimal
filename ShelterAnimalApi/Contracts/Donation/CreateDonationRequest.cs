namespace ShelterAnimalApi.Contracts.Donation
{
    public class CreateDonationRequest
    {
        public string DonorName { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonationDate { get; set; }
    }
}
